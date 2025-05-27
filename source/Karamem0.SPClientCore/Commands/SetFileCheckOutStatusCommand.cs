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

[Cmdlet(VerbsCommon.Set, "KshFileCheckOutStatus")]
[OutputType(typeof(void))]
public class SetFileCheckOutStatusCommand : ClientObjectCmdlet<IFileService>
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
    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet3"
    )]
    public File File { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    public SwitchParameter CheckOut { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public SwitchParameter CheckIn { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
    public SwitchParameter UndoCheckOut { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    public string Comment { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    public CheckInType CheckInType { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            this.ValidateSwitchParameter(nameof(this.CheckOut));
            this.Service.CheckOutObject(this.File);
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            this.ValidateSwitchParameter(nameof(this.CheckIn));
            this.Service.CheckInObject(
                this.File,
                this.Comment,
                this.CheckInType
            );
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            this.ValidateSwitchParameter(nameof(this.UndoCheckOut));
            this.Service.UndoCheckOutObject(this.File);
        }
    }

}
