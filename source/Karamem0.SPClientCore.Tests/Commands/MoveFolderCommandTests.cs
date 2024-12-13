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
public class MoveFolderCommandTests
{

    [Test()]
    public void MoveFolder()
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
        var result1 = context.Runspace.InvokeCommand<Folder>(
            "Get-KshFolder",
            new Dictionary<string, object>()
            {
                { "FolderUrl", context.AppSettings["Folder1Url"] }
            }
        );
        var result2 = context.Runspace.InvokeCommand<Folder>(
            "Add-KshFolder",
            new Dictionary<string, object>()
            {
                { "Folder", result1.ElementAt(0) },
                { "FolderName", "Test Folder 0" }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Move-KshFolder",
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
        var result3 = context.Runspace.InvokeCommand<Folder>(
            "Get-KshFolder",
            new Dictionary<string, object>()
            {
                { "FolderUrl", context.AppSettings["List2Url"] + "/Test Folder 9" }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshFolder",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void MoveFolderLegacyByRelativeUrl()
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
        var result1 = context.Runspace.InvokeCommand<Folder>(
            "Get-KshFolder",
            new Dictionary<string, object>()
            {
                { "FolderUrl", context.AppSettings["Folder1Url"] }
            }
        );
        var result2 = context.Runspace.InvokeCommand<Folder>(
            "Add-KshFolder",
            new Dictionary<string, object>()
            {
                { "Folder", result1.ElementAt(0) },
                { "FolderName", "Test Folder 0" }
            }
        );
        var result3 = context.Runspace.InvokeCommand<Folder>(
            "Move-KshFolder",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) },
                { "NewUrl", context.AppSettings["Folder1Url"] + "/TestFolder9" },
                { "Legacy", true },
                { "PassThru", true }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshFolder",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void MoveFolderLegacyByAbsoluteUrl()
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
        var result1 = context.Runspace.InvokeCommand<Folder>(
            "Get-KshFolder",
            new Dictionary<string, object>()
            {
                { "FolderUrl", context.AppSettings["Folder1Url"] }
            }
        );
        var result2 = context.Runspace.InvokeCommand<Folder>(
            "Add-KshFolder",
            new Dictionary<string, object>()
            {
                { "Folder", result1.ElementAt(0) },
                { "FolderName", "Test Folder 0" }
            }
        );
        var result3 = context.Runspace.InvokeCommand<Folder>(
            "Move-KshFolder",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) },
                { "NewUrl", context.AppSettings["AuthorityUrl"] + context.AppSettings["Folder1Url"] + "/TestFolder9" },
                { "Legacy", true },
                { "PassThru", true }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshFolder",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}
