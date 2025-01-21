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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands.Tests;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class RemoveCommentCommandTests
{

    [Test()]
    public void InvokeCommand_RemoveItem_ShouldSucceed()
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
                { "LibraryType", "ClientRenderedSitePages" }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Add-KshSitePage",
            new Dictionary<string, object>()
            {
                { "List", result1.ElementAt(0) },
                { "PageName", "Test Site Page 0" },
                { "PageLayoutType", "Article" }
            }
        );
        var result2 = context.Runspace.InvokeCommand<Folder>(
            "Get-KshFolder",
            new Dictionary<string, object>()
            {
                { "List", result1.ElementAt(0) }
            }
        );
        var result3 = context.Runspace.InvokeCommand<File>(
            "Get-KshFile",
            new Dictionary<string, object>()
            {
                { "Folder", result2.ElementAt(0) },
                { "FileName", "Test Site Page 0.aspx" }
            }
        );
        var result4 = context.Runspace.InvokeCommand<ListItem>(
            "Get-KshListItem",
            new Dictionary<string, object>()
            {
                { "File", result3.ElementAt(0) }
            }
        );
        var result5 = context.Runspace.InvokeCommand<Comment>(
            "Add-KshComment",
            new Dictionary<string, object>()
            {
                { "ListItem", result4.ElementAt(0) },
                { "Text", "Test Comment 0" }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshComment",
            new Dictionary<string, object>()
            {
                { "Identity", result5.ElementAt(0) }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshFile",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) }
            }
        );
    }

}
