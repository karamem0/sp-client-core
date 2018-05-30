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
using System.Management.Automation;
using System.Linq;
using System.Text;
using System.Threading;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("Get", "SPOnlineAdminConsentUrl")]
    [OutputType(typeof(string))]
    public class GetOnlineAdminConsentUrlCommand : PSCmdlet
    {

        public GetOnlineAdminConsentUrlCommand()
        {
        }

        [Parameter(Mandatory = true)]
        public Uri Url { get; private set; }

        [Parameter(Mandatory = false)]
        public Uri Authority { get; private set; }

        [Parameter(Mandatory = false)]
        public Guid? ClientId { get; private set; }

        protected override void ProcessRecord()
        {
            if (this.Authority == null)
            {
                this.Authority = new Uri(Constants.Authority);
            }
            if (this.ClientId == null)
            {
                this.ClientId = new Guid(Constants.ClientId);
            }
            var oAuthContext = new OAuthContext(this.Authority.ToString(), this.ClientId.ToString(), this.Url.GetLeftPart(UriPartial.Authority));
            this.WriteObject(oAuthContext.GetAdminConsentUrl().AbsoluteUri);
        }

    }

}
