//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Tests.Utilities;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands.Tests;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class SetUniqueRoleAssignmentEnabledCommandTests
{

    [Test()]
    public void InvokeCommand_SetDisabledToSite_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"] },
                { "ClientId", context.AppSettings["ClientId"] },
                { "CertificatePath", context.AppSettings["CertificatePath"] },
                { "CertificatePassword", context.AppSettings["CertificatePassword"].ToSecureString() }
            }
        );
        var result1 = context.Runspace.InvokeCommand<Site>(
            "Add-KshSite",
            new Dictionary<string, object>()
            {
                { "ServerRelativeUrl", "TestSite0" }
            }
        );
        var result2 = context.Runspace.InvokeCommand<Site>(
            "Select-KshSite",
            new Dictionary<string, object>()
            {
                { "Identity", result1.ElementAt(0) },
                { "PassThru", true }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshUniqueRoleAssignmentEnabled",
            new Dictionary<string, object>()
            {
                { "Site", true },
                { "Enabled", true }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshUniqueRoleAssignmentEnabled",
            new Dictionary<string, object>()
            {
                { "Site", true },
                { "Disabled", true }
            }
        );
        var result3 = context.Runspace.InvokeCommand<Site>(
            "Get-KshSite",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshSite",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_SetDisabledToList_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"] },
                { "ClientId", context.AppSettings["ClientId"] },
                { "CertificatePath", context.AppSettings["CertificatePath"] },
                { "CertificatePassword", context.AppSettings["CertificatePassword"].ToSecureString() }
            }
        );
        var result1 = context.Runspace.InvokeCommand<List>(
            "Add-KshList",
            new Dictionary<string, object>()
            {
                { "Template", "GenericList" },
                { "Title", "Test List 0" }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshUniqueRoleAssignmentEnabled",
            new Dictionary<string, object>()
            {
                { "List", result1.ElementAt(0) },
                { "Enabled", true }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshUniqueRoleAssignmentEnabled",
            new Dictionary<string, object>()
            {
                { "List", result1.ElementAt(0) },
                { "Disabled", true }
            }
        );
        var result2 = context.Runspace.InvokeCommand<List>(
            "Get-KshList",
            new Dictionary<string, object>()
            {
                { "Identity", result1.ElementAt(0) }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshList",
            new Dictionary<string, object>()
            {
                { "Identity", result1.ElementAt(0) }
            }
        );
        var actual = result2.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_SetDisabledToListItem_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"] },
                { "ClientId", context.AppSettings["ClientId"] },
                { "CertificatePath", context.AppSettings["CertificatePath"] },
                { "CertificatePassword", context.AppSettings["CertificatePassword"].ToSecureString() }
            }
        );
        var result1 = context.Runspace.InvokeCommand<List>(
            "Get-KshList",
            new Dictionary<string, object>()
            {
                { "ListId", context.AppSettings["List1Id"] }
            }
        );
        var result2 = context.Runspace.InvokeCommand<ListItem>(
            "Add-KshListItem",
            new Dictionary<string, object>()
            {
                { "List", result1.ElementAt(0) },
                { "Value", new Hashtable() }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshUniqueRoleAssignmentEnabled",
            new Dictionary<string, object>()
            {
                { "ListItem", result2.ElementAt(0) },
                { "Enabled", true }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshUniqueRoleAssignmentEnabled",
            new Dictionary<string, object>()
            {
                { "ListItem", result2.ElementAt(0) },
                { "Disabled", true }
            }
        );
        var result3 = context.Runspace.InvokeCommand<ListItem>(
            "Get-KshListItem",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshListItem",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_SetEnabledToSite_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"] },
                { "ClientId", context.AppSettings["ClientId"] },
                { "CertificatePath", context.AppSettings["CertificatePath"] },
                { "CertificatePassword", context.AppSettings["CertificatePassword"].ToSecureString() }
            }
        );
        var result1 = context.Runspace.InvokeCommand<Site>(
            "Add-KshSite",
            new Dictionary<string, object>()
            {
                { "ServerRelativeUrl", "TestSite0" }
            }
        );
        var result2 = context.Runspace.InvokeCommand<Site>(
            "Select-KshSite",
            new Dictionary<string, object>()
            {
                { "Identity", result1.ElementAt(0) },
                { "PassThru", true }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshUniqueRoleAssignmentEnabled",
            new Dictionary<string, object>()
            {
                { "Site", true },
                { "Enabled", true },
                { "CopyRoleAssignments", true },
                { "ClearSubscopes", true }
            }
        );
        var result4 = context.Runspace.InvokeCommand<Site>(
            "Get-KshSite",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshUniqueRoleAssignmentEnabled",
            new Dictionary<string, object>()
            {
                { "Site", true },
                { "Disabled", true }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshSite",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) }
            }
        );
        var actual = result4.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_SetEnabledToList_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"] },
                { "ClientId", context.AppSettings["ClientId"] },
                { "CertificatePath", context.AppSettings["CertificatePath"] },
                { "CertificatePassword", context.AppSettings["CertificatePassword"].ToSecureString() }
            }
        );
        var result1 = context.Runspace.InvokeCommand<List>(
            "Add-KshList",
            new Dictionary<string, object>()
            {
                { "Template", "GenericList" },
                { "Title", "Test List 0" }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshUniqueRoleAssignmentEnabled",
            new Dictionary<string, object>()
            {
                { "List", result1.ElementAt(0) },
                { "Enabled", true },
                { "CopyRoleAssignments", true },
                { "ClearSubscopes", true }
            }
        );
        var result2 = context.Runspace.InvokeCommand<List>(
            "Get-KshList",
            new Dictionary<string, object>()
            {
                { "Identity", result1.ElementAt(0) }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshUniqueRoleAssignmentEnabled",
            new Dictionary<string, object>()
            {
                { "List", result1.ElementAt(0) },
                { "Disabled", true }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshList",
            new Dictionary<string, object>()
            {
                { "Identity", result1.ElementAt(0) }
            }
        );
        var actual = result2.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_SetEnabledToListItem_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"] },
                { "ClientId", context.AppSettings["ClientId"] },
                { "CertificatePath", context.AppSettings["CertificatePath"] },
                { "CertificatePassword", context.AppSettings["CertificatePassword"].ToSecureString() }
            }
        );
        var result1 = context.Runspace.InvokeCommand<List>(
            "Get-KshList",
            new Dictionary<string, object>()
            {
                { "ListId", context.AppSettings["List1Id"] }
            }
        );
        var result2 = context.Runspace.InvokeCommand<ListItem>(
            "Add-KshListItem",
            new Dictionary<string, object>()
            {
                { "List", result1.ElementAt(0) },
                { "Value", new Hashtable() }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshUniqueRoleAssignmentEnabled",
            new Dictionary<string, object>()
            {
                { "ListItem", result2.ElementAt(0) },
                { "Enabled", true },
                { "CopyRoleAssignments", true },
                { "ClearSubscopes", true }
            }
        );
        var result3 = context.Runspace.InvokeCommand<ListItem>(
            "Get-KshListItem",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshUniqueRoleAssignmentEnabled",
            new Dictionary<string, object>()
            {
                { "ListItem", result2.ElementAt(0) },
                { "Disabled", true }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshListItem",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}
