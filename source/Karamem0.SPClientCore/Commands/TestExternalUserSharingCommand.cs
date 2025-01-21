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

[Cmdlet(VerbsDiagnostic.Test, "KshExternalUserSharing")]
[OutputType(typeof(bool))]
public class TestExternalUserSharingCommand : ClientObjectCmdlet<IExternalUserService>
{

    public TestExternalUserSharingCommand()
    {
    }

    [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet1")]
    public SwitchParameter Site { get; private set; }

    [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet2")]
    public List List { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            this.ValidateSwitchParameter(nameof(this.Site));
            this.Outputs.Add(this.Service.CheckObject());
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            this.Outputs.Add(this.Service.CheckObject(this.List));
        }
    }

}
