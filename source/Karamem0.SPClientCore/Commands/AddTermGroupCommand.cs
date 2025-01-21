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

[Cmdlet(VerbsCommon.Add, "KshTermGroup")]
[OutputType(typeof(TermGroup))]
public class AddTermGroupCommand : ClientObjectCmdlet<ITermGroupService>
{

    public AddTermGroupCommand()
    {
    }

    [Parameter(Mandatory = false)]
    public Guid Id { get; private set; }

    [Parameter(Mandatory = true)]
    public string Name { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.Id == default)
        {
            this.Id = Guid.NewGuid();
        }
        this.Outputs.Add(this.Service.AddObject(this.Name, this.Id));
    }

}
