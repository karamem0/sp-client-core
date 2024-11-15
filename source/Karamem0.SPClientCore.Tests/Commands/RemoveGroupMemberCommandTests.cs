//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Tests.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands.Tests;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class RemoveGroupMemberCommandTests
{

    [Test()]
    public void RemoveGroupMember()
    {
        using var context = new PSCmdletContext();
        var result1 = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"] },
                { "Credential", PSCredentialFactory.CreateCredential(
                    context.AppSettings["LoginUserName"],
                    context.AppSettings["LoginPassword"])
                }
            }
        );
        var result2 = context.Runspace.InvokeCommand<Group>(
            "Get-KshGroup",
            new Dictionary<string, object>()
            {
                { "GroupId", context.AppSettings["Group1Id"] },
            }
        );
        var result3 = context.Runspace.InvokeCommand<User>(
            "Add-KshUser",
            new Dictionary<string, object>()
            {
                { "LoginName", "i:0#.f|membership|testuser000@" + context.AppSettings["LoginDomainName"] },
            }
        );
        var result4 = context.Runspace.InvokeCommand(
            "Add-KshGroupMember",
            new Dictionary<string, object>()
            {
                { "Group", result2.ElementAt(0) },
                { "Member", result3.ElementAt(0) }
            }
        );
        var result5 = context.Runspace.InvokeCommand(
            "Remove-KshGroupMember",
            new Dictionary<string, object>()
            {
                { "Group", result2.ElementAt(0) },
                { "Member", result3.ElementAt(0) }
            }
        );
        var result6 = context.Runspace.InvokeCommand(
            "Remove-KshUser",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) }
            }
        );
    }

}
