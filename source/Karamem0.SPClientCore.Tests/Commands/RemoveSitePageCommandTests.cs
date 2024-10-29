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
public class RemoveSitePageCommandTests
{

    [Test()]
    public void RemoveSitePage()
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
        var result2 = context.Runspace.InvokeCommand(
            "Add-KshSitePage",
            new Dictionary<string, object>()
            {
                { "PageName", "Test Site Page 0" }
            }
        );
        var result3 = context.Runspace.InvokeCommand(
            "Remove-KshSitePage",
            new Dictionary<string, object>()
            {
                { "PageName", "Test Site Page 0" }
            }
        );
    }

    [Test()]
    public void RemoveSitePageByList()
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
                { "LibraryType", "ClientRenderedSitePages" }
            }
        );
        var result3 = context.Runspace.InvokeCommand(
            "Add-KshSitePage",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "PageName", "Test Site Page 0" }
            }
        );
        var result4 = context.Runspace.InvokeCommand(
            "Remove-KshSitePage",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "PageName", "Test Site Page 0" },
            }
        );
    }

}
