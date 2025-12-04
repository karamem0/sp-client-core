//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Test.Utility;
using NUnit.Framework;

namespace Karamem0.SharePoint.PowerShell.Commands.Test;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class SetGroupOwnerCommandTests
{

    [Test()]
    public void InvokeCommand_SetItem_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKeyPath"] = context.AppSettings["PrivateKeyPath"]
            }
        );
        var result1 = context.Runspace.InvokeCommand<User>(
            "Get-KshUser",
            new Dictionary<string, object>()
            {
                ["UserId"] = context.AppSettings["User1Id"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<Group>(
            "Add-KshGroup",
            new Dictionary<string, object>()
            {
                ["Title"] = "Test Group 0"
            }
        );
        _ = context.Runspace.InvokeCommand<Principal>(
            "Set-KshGroupOwner",
            new Dictionary<string, object>()
            {
                ["Group"] = result2[0],
                ["Owner"] = result1[0]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshGroup",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0]
            }
        );
    }

}
