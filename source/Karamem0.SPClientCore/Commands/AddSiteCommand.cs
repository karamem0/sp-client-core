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

    [Cmdlet("Add", "KshSite")]
    [Alias("New-KshSite")]
    [OutputType(typeof(Site))]
    public class AddSiteCommand : ClientObjectCmdlet<ISiteService>
    {

        public AddSiteCommand()
        {
        }

        [Parameter(Mandatory = false)]
        public string Description { get; private set; }

        [Parameter(Mandatory = false)]
        public uint Lcid { get; private set; }

        [Parameter(Mandatory = false)]
        public string ServerRelativeUrl { get; private set; }

        [Parameter(Mandatory = false)]
        public string Template { get; private set; }

        [Parameter(Mandatory = false)]
        public string Title { get; private set; }

        [Parameter(Mandatory = false)]
        public bool UseSamePermissionsAsParentSite { get; private set; }

        protected override void ProcessRecordCore()
        {
            this.Outputs.Add(this.Service.AddObject(this.MyInvocation.BoundParameters));
        }

    }

}
