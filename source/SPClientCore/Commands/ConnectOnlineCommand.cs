//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Services;
using Karamem0.SharePoint.PowerShell.Services.OAuth;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Linq;
using System.Text;
using System.Threading;
using System.Management.Automation.Host;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("Connect", "SPOnline")]
    [OutputType(typeof(User))]
    public class ConnectOnlineCommand : PSCmdlet
    {

        public ConnectOnlineCommand()
        {
            this.Authority = new Uri("https://login.microsoftonline.com");
            this.ClientId = new Guid("2212ff95-3f5a-4de7-b55e-8efebb515180");
        }

        [Parameter(Mandatory = true)]
        public Uri Url { get; private set; }

        [Parameter(Mandatory = false)]
        public Uri Authority { get; private set; }

        [Parameter(Mandatory = false)]
        public Guid? ClientId { get; private set; }

        [Parameter(Mandatory = false)]
        public PSCredential Credential { get; private set; }

        protected override void ProcessRecord()
        {
            var oAuthContext = new OAuthContext(this.Authority.ToString(), this.ClientId.ToString(), this.Url.GetLeftPart(UriPartial.Authority));
            if (this.Credential == null)
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
            }
            else
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
            }
            var userService = ClientObjectService.ServiceProvider.GetService<IUserService>();
            this.WriteObject(userService.GetUser());
        }

    }

}
