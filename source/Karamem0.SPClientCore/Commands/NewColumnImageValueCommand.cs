//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("New", "KshColumnImageValue")]
    [Alias("Initialize-KshColumnImageValue")]
    [OutputType(typeof(ColumnImageValue))]
    public class NewColumnImageValueCommand : ClientObjectCmdlet<ISiteService>
    {

        public NewColumnImageValueCommand()
        {
        }

        [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
        public ImageItem ImageItem { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
        [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
        public string ColumnName { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
        public string FileName { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
        public string ServerUrl { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
        public string ServerRelativeUrl { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
        public Guid Id { get; private set; }

        protected override void ProcessRecordCore()
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                var siteObject = this.Service.GetObject();
                this.Outputs.Add(new ColumnImageValue(
                    this.ColumnName,
                    this.ImageItem.Name,
                    new Uri(siteObject.Url).GetAuthority(),
                    this.ImageItem.ServerRelativeUrl,
                    this.ImageItem.UniqueId.ToString()));
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                this.Outputs.Add(new ColumnImageValue(
                    this.ColumnName,
                    this.FileName,
                    this.ServerUrl,
                    this.ServerRelativeUrl,
                    this.Id.ToString()));
            }
        }

    }

}
