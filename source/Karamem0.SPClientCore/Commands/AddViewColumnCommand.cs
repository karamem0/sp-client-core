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
using System.Management.Automation;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Add, "ViewColumn")]
[OutputType(typeof(void))]
public class AddViewColumnCommand : ClientObjectCmdlet<IViewColumnService>
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
    public View? View { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    public Column? Column { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public string? ColumnName { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            _ = this.View ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.View));
            _ = this.Column ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Column));
            this.Service.AddObject(this.View, this.Column);
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            _ = this.View ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.View));
            _ = this.ColumnName ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ColumnName));
            this.Service.AddObject(this.View, this.ColumnName);
        }
    }

}
