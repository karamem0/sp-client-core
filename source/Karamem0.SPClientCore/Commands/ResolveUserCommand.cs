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

[Cmdlet(VerbsDiagnostic.Resolve, "User")]
[OutputType(typeof(User))]
public class ResolveUserCommand : ClientObjectCmdlet<IUserService>
{

    [Parameter(Mandatory = true, Position = 0)]
    public string? LoginName { get; private set; }

    protected override void ProcessRecordCore()
    {
        _ = this.LoginName ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.LoginName));
        this.Outputs.Add(this.Service.EnsureObject(this.LoginName));
    }

}
