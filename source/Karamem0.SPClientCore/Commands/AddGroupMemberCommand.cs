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

[Cmdlet(VerbsCommon.Add, "GroupMember")]
[OutputType(typeof(void))]
public class AddGroupMemberCommand : ClientObjectCmdlet<IGroupMemberService>
{

    [Parameter(Mandatory = true, Position = 0)]
    public Group? Group { get; private set; }

    [Parameter(Mandatory = true)]
    public User? Member { get; private set; }

    protected override void ProcessRecordCore()
    {
        _ = this.Group ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Group));
        _ = this.Member ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Member));
        _ = this.Service.AddObject(this.Group, this.Member);
    }

}
