//
// Copyright (c) 2019 karamem0
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
using System.Linq;
using System.Management.Automation;
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
        public Uri Url { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
        public PSCredential Credential { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
        [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
        public Uri Authority { get; private set; }

        protected override void ProcessRecordCore()
        {
            if (this.Authority == null)
            {
                this.Authority = new Uri(OAuthConstants.Authority);
            }
            var oAuthContext = new OAuthContext(this.Authority.GetAuthority(), OAuthConstants.ClientId, this.Url.GetAuthority());
            if (this.ParameterSetName == "ParamSet1")
            {
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
                        if (oAuthTokenMessage is OAuthToken oAuthToken)
                        {
                            ClientService.Register(new ClientContext(this.Url, new OAuthTokenCache(oAuthContext, oAuthToken)));
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
                var credential = this.Credential.GetNetworkCredential();
                var oAuthMessage = oAuthContext.AcquireTokenByPassword(credential.UserName, credential.Password);
                if (oAuthMessage is OAuthToken oAuthToken)
                {
                    ClientService.Register(new ClientContext(this.Url, new OAuthTokenCache(oAuthContext, oAuthToken)));
                }
                if (oAuthMessage is OAuthError oAuthError)
                {
                    throw new InvalidOperationException(oAuthError.ErrorDescription);
                }
            }
        }

    }

}
