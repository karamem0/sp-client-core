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
public class GetGroupMemberCommandTests
{

    [Test()]
    public void GetGroupMembers()
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
                { "GroupId", context.AppSettings["Group1Id"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<User>(
            "Get-KshGroupMember",
            new Dictionary<string, object>()
            {
                { "Group", result2.ElementAt(0) }
            }
        );
        var actual = result3.ToArray();
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void GetGroupMemberByMemberId()
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
                { "GroupId", context.AppSettings["Group1Id"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<User>(
            "Get-KshGroupMember",
            new Dictionary<string, object>()
            {
                { "Group", result2.ElementAt(0) },
                { "MemberId", context.AppSettings["User1Id"] }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void GetGroupMemberByMemberLoginName()
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
                { "GroupId", context.AppSettings["Group1Id"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<User>(
            "Get-KshGroupMember",
            new Dictionary<string, object>()
            {
                { "Group", result2.ElementAt(0) },
                { "MemberName", context.AppSettings["User1LoginName"] }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void GetGroupMemberByMemberEmail()
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
                { "GroupId", context.AppSettings["Group1Id"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<User>(
            "Get-KshGroupMember",
            new Dictionary<string, object>()
            {
                { "Group", result2.ElementAt(0) },
                { "MemberName", context.AppSettings["User1Email"] },
            }
        );
        var actual = result3.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}
