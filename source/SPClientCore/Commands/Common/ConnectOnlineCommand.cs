//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.Core;
using Karamem0.SharePoint.PowerShell.Services;
using Karamem0.SharePoint.PowerShell.Services.Core;
using Karamem0.SharePoint.PowerShell.Services.OAuth;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading;

namespace Karamem0.SharePoint.PowerShell.Commands.Common
{

    [Cmdlet("Connect", "SPOnline", DefaultParameterSetName = "DeviceCode")]
    [OutputType(typeof(User), ParameterSetName = new[] { "DeviceCode", "Password" })]
    [OutputType(typeof(string), ParameterSetName = new[] { "AdminConsent" })]
    public class ConnectOnlineCommand : ClientObjectCmdlet
    {

        public ConnectOnlineCommand()
        {
        }

        [Parameter(Mandatory = true, ParameterSetName = "DeviceCode")]
        [Parameter(Mandatory = true, ParameterSetName = "Password")]
        [Parameter(Mandatory = true, ParameterSetName = "AdminConsent")]
        public Uri Url { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "Password")]
        public PSCredential Credential { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "AdminConsent")]
        public SwitchParameter AdminConsent { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "DeviceCode")]
        [Parameter(Mandatory = false, ParameterSetName = "Password")]
        [Parameter(Mandatory = false, ParameterSetName = "AdminConsent")]
        public Uri Authority { get; private set; }

        protected override void ProcessRecord()
        {
            if (this.Authority == null)
            {
                this.Authority = new Uri(Constants.Authority);
            }
            var oAuthContext = new OAuthContext(this.Authority.GetLeftPart(UriPartial.Authority), Constants.ClientId, this.Url.GetLeftPart(UriPartial.Authority));
            if (this.ParameterSetName == "DeviceCode")
            {
                var oAuthDeviceCodeMessage = oAuthContext.AcquireDeviceCode();
                if (oAuthDeviceCodeMessage is OAuthDeviceCode oAuthDeviceCode)
                {
                    Console.WriteLine(oAuthDeviceCode.Message);
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
                            ClientObjectService.Register(new BearerClientContext(this.Url, oAuthContext, oAuthToken));
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
                        if (ClientObjectService.ServiceProvider != null)
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
                var userService = ClientObjectService.ServiceProvider.GetService<IUserService>();
                this.WriteObject(userService.GetUser());
            }
            if (this.ParameterSetName == "Password")
            {
                var credential = this.Credential.GetNetworkCredential();
                var oAuthMessage = oAuthContext.AcquireTokenByPassword(credential.UserName, credential.Password);
                if (oAuthMessage is OAuthToken oAuthToken)
                {
                    ClientObjectService.Register(new BearerClientContext(this.Url, oAuthContext, oAuthToken));
                }
                if (oAuthMessage is OAuthError oAuthError)
                {
                    throw new InvalidOperationException(oAuthError.ErrorDescription);
                }
                var userService = ClientObjectService.ServiceProvider.GetService<IUserService>();
                this.WriteObject(userService.GetUser());
            }
            if (this.ParameterSetName == "AdminConsent")
            {
                this.WriteObject(oAuthContext.GetAdminConsentUrl().AbsoluteUri);
            }
        }

    }

}
