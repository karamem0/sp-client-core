//
// Copyright (c) 2020 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Karamem0.SharePoint.PowerShell.Runtime.OAuth;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Security;
using System.Text;
using System.Threading;

namespace Karamem0.SharePoint.PowerShell.Commands.Common
{

    [Cmdlet("Connect", "KshSite")]
    [OutputType(typeof(void))]
    public class ConnectSiteCommand : ClientObjectCmdlet
    {

        public ConnectSiteCommand()
        {
        }

        [Parameter(Mandatory = true, ParameterSetName = "ParamSet1", Position = 0, ValueFromPipeline = true)]
        [Parameter(Mandatory = true, ParameterSetName = "ParamSet2", Position = 0, ValueFromPipeline = true)]
        [Parameter(Mandatory = true, ParameterSetName = "ParamSet3", Position = 0, ValueFromPipeline = true)]
        [Parameter(Mandatory = true, ParameterSetName = "ParamSet4", Position = 0, ValueFromPipeline = true)]
        [Parameter(Mandatory = true, ParameterSetName = "ParamSet5", Position = 0, ValueFromPipeline = true)]
        public Uri Url { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
        public PSCredential Credential { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
        [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
        [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
        [Parameter(Mandatory = false, ParameterSetName = "ParamSet4")]
        [Parameter(Mandatory = true, ParameterSetName = "ParamSet5")]
        public string ClientId { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
        [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
        [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
        [Parameter(Mandatory = false, ParameterSetName = "ParamSet4")]
        public Uri Authority { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
        [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
        public SwitchParameter UserMode { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
        public string CertificatePath { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
        public SecureString CertificatePassword { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "ParamSet4")]
        public SwitchParameter Cached { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "ParamSet5")]
        public string ClientSecret { get; private set; }

        protected override void ProcessRecordCore()
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                if (this.Authority == null)
                {
                    this.Authority = new Uri(OAuthConstants.AadAuthority);
                }
                var oAuthContext = new AadOAuthContext(
                    this.Authority.GetAuthority(),
                    this.ClientId ?? OAuthConstants.ClientId,
                    this.Url.GetAuthority(),
                    this.UserMode);
                var oAuthDeviceCodeMessage = oAuthContext.AcquireDeviceCode();
                if (oAuthDeviceCodeMessage is OAuthDeviceCode oAuthDeviceCode)
                {
                    this.WriteWarning(oAuthDeviceCode.Message);
                    var expiresOn = DateTime.UtcNow.AddSeconds(oAuthDeviceCode.ExpiresIn);
                    do
                    {
                        for (var second = 0; second < oAuthDeviceCode.Interval; second++)
                        {
                            if (Console.KeyAvailable)
                            {
                                var key = Console.ReadKey(true);
                                if (key.Key == ConsoleKey.Escape)
                                {
                                    return;
                                }
                            }
                            Thread.Sleep(TimeSpan.FromSeconds(1));
                        }
                        var oAuthTokenMessage = oAuthContext.AcquireTokenByDeviceCode(oAuthDeviceCode.DeviceCode);
                        if (oAuthTokenMessage is AadOAuthToken oAuthToken)
                        {
                            ClientService.Register(new ClientContext(this.Url, new AadOAuthTokenCache(oAuthContext, oAuthToken)));
                        }
                        if (oAuthTokenMessage is OAuthError oAuthTokenError)
                        {
                            if (oAuthTokenError.Error == "authorization_pending")
                            {
                                continue;
                            }
                            else
                            {
                                throw new InvalidOperationException(oAuthTokenError.ErrorDescription);
                            }
                        }
                        if (ClientService.ServiceProvider != null)
                        {
                            break;
                        }
                    }
                    while (expiresOn > DateTime.UtcNow);
                }
                if (oAuthDeviceCodeMessage is OAuthError oAuthDeviceCodeError)
                {
                    throw new InvalidOperationException(oAuthDeviceCodeError.ErrorDescription);
                }
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                if (this.Authority == null)
                {
                    this.Authority = new Uri(OAuthConstants.AadAuthority);
                }
                var oAuthContext = new AadOAuthContext(
                    this.Authority.GetAuthority(),
                    this.ClientId ?? OAuthConstants.ClientId,
                    this.Url.GetAuthority(),
                    this.UserMode);
                var credential = this.Credential.GetNetworkCredential();
                var oAuthMessage = oAuthContext.AcquireTokenByPassword(credential.UserName, credential.Password);
                if (oAuthMessage is AadOAuthToken oAuthToken)
                {
                    ClientService.Register(new ClientContext(this.Url, new AadOAuthTokenCache(oAuthContext, oAuthToken)));
                }
                if (oAuthMessage is OAuthError oAuthError)
                {
                    throw new InvalidOperationException(oAuthError.ErrorDescription);
                }
            }
            if (this.ParameterSetName == "ParamSet3")
            {
                if (this.Authority == null)
                {
                    this.Authority = new Uri(OAuthConstants.AadAuthority);
                }
                var oAuthContext = new AadOAuthContext(
                    this.Authority.GetAuthority(),
                    this.ClientId ?? OAuthConstants.ClientId,
                    this.Url.GetAuthority(),
                    this.UserMode);
                var certificatePath = this.SessionState.Path.GetResolvedPSPathFromPSPath(this.CertificatePath)[0];
                var certificateBytes = File.ReadAllBytes(Path.GetFullPath(certificatePath.Path));
                var oAuthMessage = oAuthContext.AcquireTokenByCertificate(certificateBytes, this.CertificatePassword);
                if (oAuthMessage is AadOAuthToken oAuthToken)
                {
                    ClientService.Register(new ClientContext(this.Url, new AadOAuthTokenCache(oAuthContext, oAuthToken)));
                }
                if (oAuthMessage is OAuthError oAuthError)
                {
                    throw new InvalidOperationException(oAuthError.ErrorDescription);
                }
            }
            if (this.ParameterSetName == "ParamSet4")
            {
                this.ValidateSwitchParameter(nameof(this.Cached));
                if (this.Authority == null)
                {
                    this.Authority = new Uri(OAuthConstants.AadAuthority);
                }
                var oAuthContext = new AadOAuthContext(
                    this.Authority.GetAuthority(),
                    this.ClientId ?? OAuthConstants.ClientId,
                    this.Url.GetAuthority(),
                    this.UserMode);
                ClientService.Register(new ClientContext(this.Url, new AadOAuthTokenCache(oAuthContext)));
            }
            if (this.ParameterSetName == "ParamSet5")
            {
                var oAuthContext = new AcsOAuthContext(
                    this.ClientId,
                    this.ClientSecret,
                    this.Url.GetAuthority()
                );
                var oAuthMessage = oAuthContext.AcquireToken();
                if (oAuthMessage is AcsOAuthToken oAuthToken)
                {
                    ClientService.Register(new ClientContext(this.Url, new AcsOAuthTokenCache(oAuthContext, oAuthToken)));
                }
                if (oAuthMessage is OAuthError oAuthError)
                {
                    throw new InvalidOperationException(oAuthError.ErrorDescription);
                }
            }
        }

    }

}
