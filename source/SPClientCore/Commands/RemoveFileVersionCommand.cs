//
// Copyright (c) 2019 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("Remove", "KshFileVersion")]
    [OutputType(typeof(void))]
    public class RemoveFileVersionCommand : ClientObjectCmdlet<IFileVersionService>
    {

        public RemoveFileVersionCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet1")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet2")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet3")]
        public File File { get; private set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet1")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet2")]
        public FileVersion FileVersion { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
        public SwitchParameter RecycleBin { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
        public SwitchParameter All { get; private set; }

        protected override void ProcessRecordCore()
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                    this.Service.RemoveObject(this.File, this.FileVersion);
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                if (this.RecycleBin ? false : true)
                {
                    throw new ArgumentException(
                        string.Format(StringResources.ErrorValueCannotBeValue, false),
                        nameof(this.RecycleBin));
                }
                this.Service.RecycleObject(this.File, this.FileVersion);
            }
            if (this.ParameterSetName == "ParamSet3")
            {
                if (this.All ? false : true)
                {
                    throw new ArgumentException(
                        string.Format(StringResources.ErrorValueCannotBeValue, false),
                        nameof(this.All));
                }
                this.Service.RemoveObjectAll(this.File);
            }
        }

    }

}
