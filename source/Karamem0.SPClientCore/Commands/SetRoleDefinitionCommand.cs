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

[Cmdlet(VerbsCommon.Set, "RoleDefinition")]
[OutputType(typeof(RoleDefinition))]
public class SetRoleDefinitionCommand : ClientObjectCmdlet<IRoleDefinitionService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true
    )]
    public RoleDefinition? Identity { get; private set; }

    [Parameter(Mandatory = false)]
    public BasePermission? BasePermission { get; private set; }

    [Parameter(Mandatory = false)]
    public string? Description { get; private set; }

    [Parameter(Mandatory = true)]
    public string? Name { get; private set; }

    [Parameter(Mandatory = false)]
    public int Order { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter PassThru { get; private set; }

    protected override void ProcessRecordCore()
    {
        _ = this.Identity ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Identity));
        this.Service.SetObject(this.Identity, this.MyInvocation.BoundParameters);
        if (this.PassThru)
        {
            this.Outputs.Add(this.Service.GetObject(this.Identity));
        }
    }

}
