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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands.Tests;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class SetListItemCommandTests
{

    [Test()]
    public void InvokeCommand_UpdateTextByHashtable_ShouldSucceed()
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
        var result3 = context.Runspace.InvokeCommand<ListItem>(
            "Set-KshListItem",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) },
                { "Value", new Hashtable()
                    {
                        { "TestColumn1", "Test Value 0" }
                    }
                },
                { "PassThru", true }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshListItem",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_UpdateTextByObject_ShouldSucceed()
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
        var result3 = context.Runspace.InvokeCommand<ListItem>(
            "Set-KshListItem",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) },
                { "Value", new
                    {
                        TestColumn1 = "Test Value 0"
                    }
                },
                { "PassThru", true }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshListItem",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_SetItemBySystemUpdate_ShouldSucceed()
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
        var result3 = context.Runspace.InvokeCommand<ListItem>(
            "Set-KshListItem",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) },
                { "Value", new Hashtable()
                    {
                        { "Title", "Test List Item 0" }
                    }
                },
                { "SystemUpdate", true },
                { "PassThru", true }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshListItem",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}
