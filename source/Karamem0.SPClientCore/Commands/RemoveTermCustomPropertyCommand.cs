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

[Cmdlet(VerbsCommon.Remove, "KshTermCustomProperty", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
[OutputType(typeof(void))]
public class RemoveTermCustomPropertyCommand : ClientObjectCmdlet<ITermCustomPropertyService>
{

    public RemoveTermCustomPropertyCommand()
    {
    }

    [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet1")]
    public TermSet TermSet { get; private set; }

    [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet2")]
    public Term Term { get; private set; }

    [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet2")]
    public string Name { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ShouldProcess(this.Name, VerbsCommon.Remove))
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                this.Service.RemoveObject(this.TermSet, this.Name);
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                this.Service.RemoveObject(this.Term, this.Name);
            }
        }
    }

}
