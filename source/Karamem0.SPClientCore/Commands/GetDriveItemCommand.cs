//
// Copyright (c) 2023 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Models.V2;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("Get", "KshDriveItem")]
    [OutputType(typeof(DriveItem))]
    public class GetDriveItemCommand : ClientObjectCmdlet<IDriveItemService>
    {

        public GetDriveItemCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet1")]
        public DriveItem Identity { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet2")]
        public Models.V1.Folder Folder { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet3")]
        public Models.V1.File File { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet4")]
        public ListItem ListItem { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet5")]
        public Uri DriveItemUrl { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet6")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet7")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet8")]
        public Drive Drive { get; private set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet6")]
        public string DriveItemId { get; private set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet7")]
        public Uri DriveItemPath { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet9")]
        public DriveItem DriveItem { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet8")]
        [Parameter(Mandatory = false, ParameterSetName = "ParamSet9")]
        public SwitchParameter NoEnumerate { get; private set; }

        protected override void ProcessRecordCore()
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                this.Outputs.Add(this.Service.GetObject(this.Identity));
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                this.Outputs.Add(this.Service.GetObject(this.Folder));
            }
            if (this.ParameterSetName == "ParamSet3")
            {
                this.Outputs.Add(this.Service.GetObject(this.File));
            }
            if (this.ParameterSetName == "ParamSet4")
            {
                this.Outputs.Add(this.Service.GetObject(this.ListItem));
            }
            if (this.ParameterSetName == "ParamSet5")
            {
                if (this.DriveItemUrl.IsAbsoluteUri)
                {
                    this.Outputs.Add(this.Service.GetObject(this.DriveItemUrl));
                }
                else
                {
                    throw new ArgumentException(
                        string.Format(StringResources.ErrorValueIsNotAbsoluteUrl, this.DriveItemUrl),
                        nameof(this.DriveItemUrl));
                }
            }
            if (this.ParameterSetName == "ParamSet6")
            {
                this.Outputs.Add(this.Service.GetObject(this.Drive, this.DriveItemId));
            }
            if (this.ParameterSetName == "ParamSet7")
            {
                this.Outputs.Add(this.Service.GetObject(this.Drive, this.DriveItemPath));
            }
            if (this.ParameterSetName == "ParamSet8")
            {
                if (this.NoEnumerate)
                {
                    this.Outputs.Add(this.Service.GetObjectEnumerable(this.Drive));
                }
                else
                {
                    this.Outputs.AddRange(this.Service.GetObjectEnumerable(this.Drive));
                }
            }
            if (this.ParameterSetName == "ParamSet9")
            {
                if (this.NoEnumerate)
                {
                    this.Outputs.Add(this.Service.GetObjectEnumerable(this.DriveItem));
                }
                else
                {
                    this.Outputs.AddRange(this.Service.GetObjectEnumerable(this.DriveItem));
                }
            }
        }

    }

}
