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

[Cmdlet(VerbsCommon.Add, "KshTermSet")]
[OutputType(typeof(TermSet))]
public class AddTermSetCommand : ClientObjectCmdlet<ITermSetService>
{

    public AddTermSetCommand()
    {
    }

    [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
    public TermGroup TermGroup { get; private set; }

    [Parameter(Mandatory = false)]
    public Guid Id { get; private set; }

    [Parameter(Mandatory = true)]
    public uint Lcid { get; private set; }

    [Parameter(Mandatory = true)]
    public string Name { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.Id == default)
        {
            this.Id = Guid.NewGuid();
        }
        this.Outputs.Add(this.Service.AddObject(this.TermGroup, this.Name, this.Id, this.Lcid));
    }

}
