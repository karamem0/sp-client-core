//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(
    VerbsCommon.Remove,
    "KshViewColumn",
    SupportsShouldProcess = true,
    ConfirmImpact = ConfirmImpact.High
)]
[OutputType(typeof(void))]
public class RemoveViewColumnCommand : ClientObjectCmdlet<IViewColumnService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ParameterSetName = "ParamSet1"
    )]
    [Parameter(
        Mandatory = true,
        Position = 0,
        ParameterSetName = "ParamSet2"
    )]
    [Parameter(
        Mandatory = true,
        Position = 0,
        ParameterSetName = "ParamSet3"
    )]
    public View? View { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 1,
        ParameterSetName = "ParamSet1"
    )]
    public Column? Column { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 1,
        ParameterSetName = "ParamSet2"
    )]
    public string? ColumnName { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
    public SwitchParameter All { get; private set; }

    protected override void ProcessRecordCore()
    {
        _ = this.View ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.View));
        if (this.ShouldProcess(this.View.Title, VerbsCommon.Remove))
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                _ = this.Column ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Column));
                this.Service.RemoveObject(this.View, this.Column);
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                _ = this.ColumnName ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ColumnName));
                this.Service.RemoveObject(this.View, this.ColumnName);
            }
            if (this.ParameterSetName == "ParamSet3")
            {
                this.Service.RemoveObjectAll(this.View);
            }
        }
    }

}
