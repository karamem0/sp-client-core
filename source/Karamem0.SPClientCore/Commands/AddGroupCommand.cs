//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System.Management.Automation;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Add, "Group")]
[OutputType(typeof(Group))]
public class AddGroupCommand : ClientObjectCmdlet<IGroupService>
{

    [Parameter(Mandatory = false)]
    public string? Description { get; private set; }

    [Parameter(Mandatory = true)]
    public string? Title { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter SelectAllProperties { get; private set; } = true;

    protected override void ProcessRecordCore()
    {
        var creationInfo = new Dictionary<string, object?>(this.MyInvocation.BoundParameters);
        this.Outputs.Add(this.Service.AddObject(creationInfo, this.SelectAllProperties));
    }

}
