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
public class AddRoleAssignmentCommandTests
{

    [Test()]
    public void InvokeCommand_AddItemToSite_ShouldSucceed()
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
            "Add-KshUser",
            new Dictionary<string, object>()
            {
                ["Email"] = "testuser0@" + context.AppSettings["LoginDomainName"],
                ["LoginName"] = "i:0#.f|membership|testuser0@" + context.AppSettings["LoginDomainName"],
                ["Title"] = "Test User 0"
            }
        );
        var result2 = context.Runspace.InvokeCommand<RoleDefinition>(
            "Get-KshRoleDefinition",
            new Dictionary<string, object>()
            {
                ["RoleDefinitionId"] = context.AppSettings["RoleDefinition1Id"]
            }
        );
        var result3 = context.Runspace.InvokeCommand<RoleAssignment>(
            "Add-KshRoleAssignment",
            new Dictionary<string, object>()
            {
                ["Site"] = true,
                ["Principal"] = result1[0],
                ["RoleDefinition"] = result2[0]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshRoleAssignment",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3[0]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshUser",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0]
            }
        );
        var actual = result3[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_AddItemToList_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<List>(
            "Get-KshList",
            new Dictionary<string, object>()
            {
                ["ListId"] = context.AppSettings["List1Id"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<User>(
            "Add-KshUser",
            new Dictionary<string, object>()
            {
                ["Email"] = "testuser0@" + context.AppSettings["LoginDomainName"],
                ["LoginName"] = "i:0#.f|membership|testuser0@" + context.AppSettings["LoginDomainName"],
                ["Title"] = "Test User 0"
            }
        );
        var result3 = context.Runspace.InvokeCommand<RoleDefinition>(
            "Get-KshRoleDefinition",
            new Dictionary<string, object>()
            {
                ["RoleDefinitionId"] = context.AppSettings["RoleDefinition1Id"]
            }
        );
        var result4 = context.Runspace.InvokeCommand<RoleAssignment>(
            "Add-KshRoleAssignment",
            new Dictionary<string, object>()
            {
                ["List"] = result1[0],
                ["Principal"] = result2[0],
                ["RoleDefinition"] = result3[0]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshRoleAssignment",
            new Dictionary<string, object>()
            {
                ["Identity"] = result4[0]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshUser",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0]
            }
        );
        var actual = result4[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_AddItemToListItem_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<List>(
            "Get-KshList",
            new Dictionary<string, object>()
            {
                ["ListId"] = context.AppSettings["List1Id"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<ListItem>(
            "Get-KshListItem",
            new Dictionary<string, object>()
            {
                ["List"] = result1[0],
                ["ItemId"] = context.AppSettings["ListItem1Id"]
            }
        );
        var result3 = context.Runspace.InvokeCommand<User>(
            "Add-KshUser",
            new Dictionary<string, object>()
            {
                ["Email"] = "testuser0@" + context.AppSettings["LoginDomainName"],
                ["LoginName"] = "i:0#.f|membership|testuser0@" + context.AppSettings["LoginDomainName"],
                ["Title"] = "Test User 0"
            }
        );
        var result4 = context.Runspace.InvokeCommand<RoleDefinition>(
            "Get-KshRoleDefinition",
            new Dictionary<string, object>()
            {
                ["RoleDefinitionId"] = context.AppSettings["RoleDefinition1Id"]
            }
        );
        var result5 = context.Runspace.InvokeCommand<RoleAssignment>(
            "Add-KshRoleAssignment",
            new Dictionary<string, object>()
            {
                ["ListItem"] = result2[0],
                ["Principal"] = result3[0],
                ["RoleDefinition"] = result4[0]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshRoleAssignment",
            new Dictionary<string, object>()
            {
                ["Identity"] = result5[0]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshUser",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3[0]
            }
        );
        var actual = result5[0];
        Assert.That(actual, Is.Not.Null);
    }

}
