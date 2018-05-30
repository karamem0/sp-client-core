//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.OData;
using Karamem0.SharePoint.PowerShell.Models.Social;
using Karamem0.SharePoint.PowerShell.PipeBinds.Social;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Services;
using Karamem0.SharePoint.PowerShell.Services.Social;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands.Social
{

    [Cmdlet("Get", "SPSocialFeed")]
    [OutputType(typeof(SocialRestFeed))]
    public class GetSocialFeedCommand : PSCmdlet
    {

        public GetSocialFeedCommand()
        {
        }

        [Parameter(Mandatory = false, Position = 0, ValueFromPipeline = true)]
        public SocialActorPipeBind Actor { get; private set; }

        protected override void ProcessRecord()
        {
            if (ClientObjectService.ServiceProvider == null)
            {
                throw new InvalidOperationException(StringResources.ErrorNotConnected);
            }
            var socialService = ClientObjectService.ServiceProvider.GetService<ISocialService>();
            if (this.Actor == null)
            {
                this.WriteObject(socialService.GetSocialFeed(null));
            }
            else
            {
                this.WriteObject(socialService.GetSocialFeed(this.Actor));
            }
        }

    }

}
