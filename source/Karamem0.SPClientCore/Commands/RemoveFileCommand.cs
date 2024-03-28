//
// Copyright (c) 2018-2024 karamem0
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

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Remove, "KshFile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
[OutputType((Type[])null)]
public class RemoveFileCommand : ClientObjectCmdlet<IFileService>
{

    public RemoveFileCommand()
    {
    }

    [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet2")]
    public File Identity { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    public SwitchParameter Force { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public SwitchParameter RecycleBin { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ShouldProcess(this.Identity.Name, VerbsCommon.Remove))
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                this.Service.RemoveObject(this.Identity, this.Force);
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                this.ValidateSwitchParameter(nameof(this.RecycleBin));
                this.Outputs.Add(this.Service.RecycleObject(this.Identity));
            }
        }
    }

}
