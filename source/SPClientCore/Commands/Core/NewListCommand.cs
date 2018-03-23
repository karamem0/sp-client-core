//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.Core;
using Karamem0.SharePoint.PowerShell.Models.OData;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Services;
using Karamem0.SharePoint.PowerShell.Services.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands.Core
{

    [Cmdlet("New", "SPList")]
    [OutputType(typeof(List))]
    public class NewListCommand : PSCmdlet
    {

        public NewListCommand()
        {
        }

        [Parameter(Mandatory = false)]
        public int? BaseTemplate { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? ContentTypesEnabled { get; private set; }

        [Parameter(Mandatory = false)]
        public string DefaultContentApprovalWorkflowId { get; private set; }

        [Parameter(Mandatory = false)]
        public string DefaultDisplayFormUrl { get; private set; }

        [Parameter(Mandatory = false)]
        public string DefaultEditFormUrl { get; private set; }

        [Parameter(Mandatory = false)]
        public string DefaultNewFormUrl { get; private set; }

        [Parameter(Mandatory = false)]
        public string Description { get; private set; }

        [Parameter(Mandatory = false)]
        public string Direction { get; private set; }

        [Parameter(Mandatory = false)]
        public string DocumentTemplateUrl { get; private set; }

        [Parameter(Mandatory = false)]
        public DraftVisibilityType? DraftVersionVisibility { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? EnableAttachments { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? EnableFolderCreation { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? EnableMajorVersions { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? EnableMinorVersions { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? EnableModeration { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? EnableVersioning { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? ForceCheckout { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? Hidden { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? IrmEnabled { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? IrmExpire { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? IrmReject { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? IsApplicationList { get; private set; }

        [Parameter(Mandatory = false)]
        public DateTime? LastItemModifiedDate { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? MultipleDataList { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? NoCrawl { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? OnQuickLaunch { get; private set; }

        [Parameter(Mandatory = true)]
        public string Title { get; private set; }

        [Parameter(Mandatory = false)]
        public string ValidationFormula { get; private set; }

        [Parameter(Mandatory = false)]
        public string ValidationMessage { get; private set; }

        [Parameter(Mandatory = false)]
        public string[] Includes { get; private set; }

        protected override void ProcessRecord()
        {
            if (ClientObjectService.ServiceProvider == null)
            {
                throw new InvalidOperationException(StringResources.ErrorNotConnected);
            }
            var listService = ClientObjectService.ServiceProvider.GetService<IListService>();
            var listQuery = ODataQuery.Create<List>(this.MyInvocation.BoundParameters);
            this.WriteObject(listService.CreateList(this.MyInvocation.BoundParameters, listQuery));
        }

    }

}
