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
public class CopyFolderCommandTests
{

    [Test()]
    public void CopyFolder()
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
        var result2 = context.Runspace.InvokeCommand<Folder>(
            "Get-KshFolder",
            new Dictionary<string, object>()
            {
                { "FolderUrl", context.AppSettings["Folder1Url"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand(
            "Copy-KshFolder",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) },
                { "NewUrl", context.AppSettings["AuthorityUrl"] + context.AppSettings["List2Url"] + "/Test Folder 9" },
                { "KeepBoth", true },
                { "ResetAuthorAndCreatedOnCopy", true },
                { "RetainEditorAndModifiedOnMove", true },
                { "ShouldBypassSharedLocks", true }
            }
        );
        var result4 = context.Runspace.InvokeCommand<Folder>(
            "Get-KshFolder",
            new Dictionary<string, object>()
            {
                { "FolderUrl", context.AppSettings["List2Url"] + "/Test Folder 9" }
            }
        );
        var result5 = context.Runspace.InvokeCommand(
            "Remove-KshFolder",
            new Dictionary<string, object>()
            {
                { "Identity", result4.ElementAt(0) }
            }
        );
        var actual = result4.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}
