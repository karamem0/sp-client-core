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
using System.Management.Automation;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Get, "CurrentUser")]
[OutputType(typeof(User))]
public class GetCurrentUserCommand : ClientObjectCmdlet<IUserService>
{

    protected override void ProcessRecordCore()
    {
        this.Outputs.Add(this.Service.GetObject());
    }

}
