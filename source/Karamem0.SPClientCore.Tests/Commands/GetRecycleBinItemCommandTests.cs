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
public class GetRecycleBinItemCommandTests
{

    [Test()]
    public void GetRecycleBinItems()
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
        var result2 = context.Runspace.InvokeCommand<List>(
            "Get-KshList",
            new Dictionary<string, object>()
            {
                { "ListId", context.AppSettings["List1Id"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<ListItem>(
            "Add-KshListItem",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "Value", new Hashtable() }
            }
        );
        var result4 = context.Runspace.InvokeCommand(
            "Remove-KshListItem",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) },
                { "RecycleBin", true }
            }
        );
        var result5 = context.Runspace.InvokeCommand<RecycleBinItem>(
            "Get-KshRecycleBinItem",
            new Dictionary<string, object>()
            {
            }
        );
        var result6 = context.Runspace.InvokeCommand(
            "Remove-KshRecycleBinItem",
            new Dictionary<string, object>()
            {
                { "All", true }
            }
        );
        var actual = result5.ToArray();
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void GetRecycleBinItemByIdentity()
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
        var result2 = context.Runspace.InvokeCommand<List>(
            "Get-KshList",
            new Dictionary<string, object>()
            {
                { "ListId", context.AppSettings["List1Id"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<ListItem>(
            "Add-KshListItem",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "Value", new Hashtable() }
            }
        );
        var result4 = context.Runspace.InvokeCommand<Guid>(
            "Remove-KshListItem",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) },
                { "RecycleBin", true }
            }
        );
        var result5 = context.Runspace.InvokeCommand<RecycleBinItem>(
            "Get-KshRecycleBinItem",
            new Dictionary<string, object>()
            {
                { "ItemId", result4.ElementAt(0) }
            }
        );
        var result6 = context.Runspace.InvokeCommand<RecycleBinItem>(
            "Get-KshRecycleBinItem",
            new Dictionary<string, object>()
            {
                { "Identity", result5.ElementAt(0) }
            }
        );
        var result7 = context.Runspace.InvokeCommand(
            "Remove-KshRecycleBinItem",
            new Dictionary<string, object>()
            {
                { "Identity", result6.ElementAt(0) }
            }
        );
        var actual = result5.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void GetRecycleBinItemByItemId()
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
        var result2 = context.Runspace.InvokeCommand<List>(
            "Get-KshList",
            new Dictionary<string, object>()
            {
                { "ListId", context.AppSettings["List1Id"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<ListItem>(
            "Add-KshListItem",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "Value", new Hashtable() }
            }
        );
        var result4 = context.Runspace.InvokeCommand<Guid>(
            "Remove-KshListItem",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) },
                { "RecycleBin", true }
            }
        );
        var result5 = context.Runspace.InvokeCommand<RecycleBinItem>(
            "Get-KshRecycleBinItem",
            new Dictionary<string, object>()
            {
                { "ItemId", result4.ElementAt(0) }
            }
        );
        var result6 = context.Runspace.InvokeCommand(
            "Remove-KshRecycleBinItem",
            new Dictionary<string, object>()
            {
                { "Identity", result5.ElementAt(0) }
            }
        );
        var actual = result5.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void GetRecycleBinItemInSecondStageByItemId()
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
        var result2 = context.Runspace.InvokeCommand<List>(
            "Get-KshList",
            new Dictionary<string, object>()
            {
                { "ListId", context.AppSettings["List1Id"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<ListItem>(
            "Add-KshListItem",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "Value", new Hashtable() }
            }
        );
        var result4 = context.Runspace.InvokeCommand<Guid>(
            "Remove-KshListItem",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) },
                { "RecycleBin", true }
            }
        );
        var result5 = context.Runspace.InvokeCommand<RecycleBinItem>(
            "Get-KshRecycleBinItem",
            new Dictionary<string, object>()
            {
                { "ItemId", result4.ElementAt(0) }
            }
        );
        var result6 = context.Runspace.InvokeCommand(
            "Move-KshRecycleBinItem",
            new Dictionary<string, object>()
            {
                { "Identity", result5.ElementAt(0) }
            }
        );
        var result7 = context.Runspace.InvokeCommand<RecycleBinItem>(
            "Get-KshRecycleBinItem",
            new Dictionary<string, object>()
            {
                { "ItemId", result4.ElementAt(0) },
                { "SecondStage", true }
            }
        );
        var result8 = context.Runspace.InvokeCommand(
            "Remove-KshRecycleBinItem",
            new Dictionary<string, object>()
            {
                { "Identity", result7.ElementAt(0) }
            }
        );
        var actual = result7.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}
