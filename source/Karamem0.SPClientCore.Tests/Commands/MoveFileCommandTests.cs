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
public class MoveFileCommandTests
{

    [Test()]
    public void MoveFile()
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
        var result3 = context.Runspace.InvokeCommand<File>(
            "Add-KshFile",
            new Dictionary<string, object>()
            {
                { "Folder", result2.ElementAt(0) },
                { "Content", Encoding.UTF8.GetBytes("TestFile0") },
                { "FileName", "TestFile0.txt" }
            }
        );
        var result4 = context.Runspace.InvokeCommand(
            "Move-KshFile",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) },
                { "NewUrl", context.AppSettings["AuthorityUrl"] + context.AppSettings["Folder1Url"] + "/TestFile9.txt" },
                { "Overwrite", true },
                { "KeepBoth", true },
                { "ResetAuthorAndCreatedOnCopy", true },
                { "RetainEditorAndModifiedOnMove", true },
                { "ShouldBypassSharedLocks", true }
            }
        );
        var result5 = context.Runspace.InvokeCommand<File>(
            "Get-KshFile",
            new Dictionary<string, object>()
            {
                { "FileUrl", context.AppSettings["Folder1Url"] + "/TestFile9.txt" }
            }
        );
        var result6 = context.Runspace.InvokeCommand(
            "Remove-KshFile",
            new Dictionary<string, object>()
            {
                { "Identity", result5.ElementAt(0) }
            }
        );
        var actual = result5.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void MoveFileLegacyByRelativeUrl()
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
        var result3 = context.Runspace.InvokeCommand<File>(
            "Add-KshFile",
            new Dictionary<string, object>()
            {
                { "Folder", result2.ElementAt(0) },
                { "Content", Encoding.UTF8.GetBytes("TestFile0") },
                { "FileName", "TestFile0.txt" }
            }
        );
        var result4 = context.Runspace.InvokeCommand<File>(
            "Move-KshFile",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) },
                { "NewUrl", context.AppSettings["Folder1Url"] + "/TestFile9.txt" },
                { "Overwrite", true },
                { "AllowBrokenThickets", true },
                { "Legacy", true },
                { "PassThru", true }
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
    public void MoveFileLegacyByAbsoluteUrl()
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
        var result3 = context.Runspace.InvokeCommand<File>(
            "Add-KshFile",
            new Dictionary<string, object>()
            {
                { "Folder", result2.ElementAt(0) },
                { "Content", Encoding.UTF8.GetBytes("TestFile0") },
                { "FileName", "TestFile0.txt" }
            }
        );
        var result4 = context.Runspace.InvokeCommand<File>(
            "Move-KshFile",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) },
                { "NewUrl", context.AppSettings["AuthorityUrl"] + context.AppSettings["Folder1Url"] + "/TestFile9.txt" },
                { "Overwrite", true },
                { "AllowBrokenThickets", true },
                { "Legacy", true },
                { "PassThru", true }
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

}
