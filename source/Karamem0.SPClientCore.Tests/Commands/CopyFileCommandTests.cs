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
public class CopyFileCommandTests
{

    [Test()]
    public void CopyFile()
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
        var result2 = context.Runspace.InvokeCommand<File>(
            "Get-KshFile",
            new Dictionary<string, object>()
            {
                { "FileUrl", context.AppSettings["File1Url"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand(
            "Copy-KshFile",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) },
                { "NewUrl", context.AppSettings["AuthorityUrl"] + context.AppSettings["Folder1Url"] + "/TestFile9.txt" },
                { "Overwrite", true },
                { "KeepBoth", true },
                { "ResetAuthorAndCreatedOnCopy", true },
                { "RetainEditorAndModifiedOnMove", true },
                { "ShouldBypassSharedLocks", true }
            }
        );
        var result4 = context.Runspace.InvokeCommand<File>(
            "Get-KshFile",
            new Dictionary<string, object>()
            {
                { "FileUrl", context.AppSettings["Folder1Url"] + "/TestFile9.txt" }
            }
        );
        var result5 = context.Runspace.InvokeCommand(
            "Remove-KshFile",
            new Dictionary<string, object>()
            {
                { "Identity", result4.ElementAt(0) }
            }
        );
        var actual = result4.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void CopyFileLegacyByRelativeUrl()
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
        var result2 = context.Runspace.InvokeCommand<File>(
            "Get-KshFile",
            new Dictionary<string, object>()
            {
                { "FileUrl", context.AppSettings["File1Url"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<File>(
            "Copy-KshFile",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) },
                { "NewUrl", context.AppSettings["Folder1Url"] + "/TestFile9.txt" },
                { "Overwrite", true },
                { "Legacy", true },
                { "PassThru", true }
            }
        );
        var result4 = context.Runspace.InvokeCommand(
            "Remove-KshFile",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void CopyFileLegacyByAbsoluteUrl()
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
        var result2 = context.Runspace.InvokeCommand<File>(
            "Get-KshFile",
            new Dictionary<string, object>()
            {
                { "FileUrl", context.AppSettings["File1Url"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<File>(
            "Copy-KshFile",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) },
                { "NewUrl", context.AppSettings["AuthorityUrl"] + context.AppSettings["Folder1Url"] + "/TestFile9.txt" },
                { "Overwrite", true },
                { "Legacy", true },
                { "PassThru", true }
            }
        );
        var result4 = context.Runspace.InvokeCommand(
            "Remove-KshFile",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}
