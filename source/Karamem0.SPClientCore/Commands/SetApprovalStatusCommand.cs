//
// Copyright (c) 2018-2025 karamem0
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

[Cmdlet(VerbsCommon.Set, "KshApprovalStatus")]
[OutputType(typeof(void))]
public class SetApprovalStatusCommand : ClientObjectCmdlet<IApprovalStatusService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet1"
    )]
    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet2"
    )]
    public File File { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet3"
    )]
    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet4"
    )]
    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet5"
    )]
    public Folder Folder { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet6"
    )]
    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet7"
    )]
    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet8"
    )]
    public ListItem ListItem { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet6")]
    public SwitchParameter Approve { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet4")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet7")]
    public SwitchParameter Reject { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet5")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet8")]
    public SwitchParameter Pending { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet4")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet5")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet6")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet7")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet8")]
    public string Comment { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            this.ValidateSwitchParameter(nameof(this.Approve));
            this.Service.ApproveObject(this.File, this.Comment);
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            this.ValidateSwitchParameter(nameof(this.Reject));
            this.Service.DenyObject(this.File, this.Comment);
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            this.ValidateSwitchParameter(nameof(this.Approve));
            this.Service.ApproveObject(this.Folder, this.Comment);
        }
        if (this.ParameterSetName == "ParamSet4")
        {
            this.ValidateSwitchParameter(nameof(this.Reject));
            this.Service.DenyObject(this.Folder, this.Comment);
        }
        if (this.ParameterSetName == "ParamSet5")
        {
            this.ValidateSwitchParameter(nameof(this.Pending));
            this.Service.SuspendObject(this.Folder, this.Comment);
        }
        if (this.ParameterSetName == "ParamSet6")
        {
            this.ValidateSwitchParameter(nameof(this.Approve));
            this.Service.ApproveObject(this.ListItem, this.Comment);
        }
        if (this.ParameterSetName == "ParamSet7")
        {
            this.ValidateSwitchParameter(nameof(this.Reject));
            this.Service.DenyObject(this.ListItem, this.Comment);
        }
        if (this.ParameterSetName == "ParamSet8")
        {
            this.ValidateSwitchParameter(nameof(this.Pending));
            this.Service.SuspendObject(this.ListItem, this.Comment);
        }
    }

}
