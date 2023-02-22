//
// Copyright (c) 2023 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("Add", "KshTenantSiteDesign")]
    [Alias("New-KshTenantSiteDesign")]
    [OutputType(typeof(TenantSiteDesign))]
    public class AddTenantSiteDesignCommand : ClientObjectCmdlet<ITenantSiteDesignService>
    {

        public AddTenantSiteDesignCommand()
        {
        }

        [Parameter(Mandatory = false)]
        public string Description { get; private set; }

        [Parameter(Mandatory = false)]
        public Guid DesignPackageId { get; private set; }

        [Parameter(Mandatory = false)]
        public bool IsDefault { get; private set; }

        [Parameter(Mandatory = false)]
        public string PreviewImageAltText { get; private set; }

        [Parameter(Mandatory = false)]
        public string PreviewImageUrl { get; private set; }

        [Parameter(Mandatory = true)]
        public string[] SiteScriptIds { get; private set; }

        [Parameter(Mandatory = false)]
        public string SiteTemplate { get; private set; }

        [Parameter(Mandatory = false)]
        public string ThumbnailUrl { get; private set; }

        [Parameter(Mandatory = true)]
        public string Title { get; private set; }

        protected override void ProcessRecordCore()
        {
            this.Outputs.Add(this.Service.AddObject(this.MyInvocation.BoundParameters));
        }

    }

}
