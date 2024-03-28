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

[Cmdlet(VerbsCommon.Add, "KshTerm")]
[OutputType(typeof(Term))]
public class AddTermCommand : ClientObjectCmdlet<ITermService>
{

    public AddTermCommand()
    {
    }

    [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet1")]
    public TermSet TermSet { get; private set; }

    [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet2")]
    public Term Term { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    public Guid Id { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public uint Lcid { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public string Name { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.Id == default)
        {
            this.Id = Guid.NewGuid();
        }
        if (this.ParameterSetName == "ParamSet1")
        {
            this.Outputs.Add(this.Service.AddObject(this.TermSet, this.Name, this.Id, this.Lcid));
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            this.Outputs.Add(this.Service.AddObject(this.Term, this.Name, this.Id, this.Lcid));
        }
    }

}
