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

[Cmdlet(VerbsCommon.Add, "TermGroup")]
[OutputType(typeof(TermGroup))]
public class AddTermGroupCommand : ClientObjectCmdlet<ITermGroupService>
{

    [Parameter(Mandatory = false)]
    public Guid Id { get; private set; }

    [Parameter(Mandatory = true)]
    public string? Name { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.Id == default)
        {
            this.Id = Guid.NewGuid();
        }
        _ = this.Name ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Name));
        this.Outputs.Add(this.Service.AddObject(this.Name, this.Id));
    }

}
