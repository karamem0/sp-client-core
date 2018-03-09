//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("Connect", "SPServer")]
    [OutputType(typeof(User))]
    public class ConnectServerCommand : PSCmdlet
    {

        public ConnectServerCommand()
        {
        }

        [Parameter(Mandatory = true)]
        public Uri Url { get; private set; }

        [Parameter(Mandatory = false)]
        public PSCredential Credential { get; private set; }

        protected override void ProcessRecord()
        {
            if (this.Credential == null)
            {
                ClientObjectService.Register(new NetworkClientContext(this.Url, CredentialCache.DefaultNetworkCredentials));
            }
            else
            {
                ClientObjectService.Register(new NetworkClientContext(this.Url, this.Credential.GetNetworkCredential()));
            }
            var userService = ClientObjectService.ServiceProvider.GetService<IUserService>();
            this.WriteObject(userService.GetUser());
        }

    }

}
