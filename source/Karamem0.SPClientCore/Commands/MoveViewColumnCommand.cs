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

[Cmdlet(VerbsCommon.Move, "KshViewColumn")]
[OutputType((Type[])null)]
public class MoveViewColumnCommand : ClientObjectCmdlet<IViewColumnService>
{

    public MoveViewColumnCommand()
    {
    }

    [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet2")]
    public View View { get; private set; }

    [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet1")]
    public Column Column { get; private set; }

    [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet2")]
    public string ColumnName { get; private set; }

    [Parameter(Mandatory = true, Position = 2, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = true, Position = 2, ParameterSetName = "ParamSet2")]
    public int NewIndex { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            this.Service.MoveObject(this.View, this.Column, this.NewIndex);
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            this.Service.MoveObject(this.View, this.ColumnName, this.NewIndex);
        }
    }

}
