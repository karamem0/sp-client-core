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
public class AddViewCommandTests
{

    [Test()]
    public void AddView()
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
        var result3 = context.Runspace.InvokeCommand<View>(
            "Add-KshView",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "Paged", true },
                { "PersonalView", false },
                { "RowLimit", 10 },
                { "SetAsDefaultView", true },
                { "Title", "Test View 0" },
                { "ViewColumns", new List<string>() { "Test Value 1", "Test Value 2", "Test Value 3" } },
                { "ViewQuery", "<OrderBy><FieldRef Name='Title'/></OrderBy>" },
                { "ViewType", "Html" }
            }
        );
        var result4 = context.Runspace.InvokeCommand(
            "Remove-KshView",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}
