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

[Cmdlet(VerbsCommon.Set, "GroupOwner")]
[OutputType(typeof(void))]
public class SetGroupOwnerCommand : ClientObjectCmdlet<IGroupOwnerService>
{

    [Parameter(Mandatory = true, Position = 0)]
    public Group? Group { get; private set; }

    [Parameter(Mandatory = true)]
    public Principal? Owner { get; private set; }

    protected override void ProcessRecordCore()
    {
        _ = this.Group ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Group));
        _ = this.Owner ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Owner));
        this.Service.SetObject(this.Group, this.Owner);
    }

}
