//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Test.Utility;
using NUnit.Framework;

namespace Karamem0.SharePoint.PowerShell.Commands.Test;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class CopyFileCommandTests
{

    [Test()]
    public void InvokeCommand_CopyItemModern_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKeyPath"] = context.AppSettings["PrivateKeyPath"]
            }
        );
        var result1 = context.Runspace.InvokeCommand<File>(
            "Get-KshFile",
            new Dictionary<string, object>()
            {
                ["FileUrl"] = context.AppSettings["File1Url"]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Copy-KshFile",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["NewUrl"] = context.AppSettings["AuthorityUrl"] + context.AppSettings["Folder1Url"] + "/TestFile9.txt",
                ["Overwrite"] = true,
                ["KeepBoth"] = true,
                ["ResetAuthorAndCreatedOnCopy"] = true,
                ["RetainEditorAndModifiedOnMove"] = true,
                ["ShouldBypassSharedLocks"] = true
            }
        );
        var result2 = context.Runspace.InvokeCommand<File>(
            "Get-KshFile",
            new Dictionary<string, object>()
            {
                ["FileUrl"] = context.AppSettings["Folder1Url"] + "/TestFile9.txt"
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshFile",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0]
            }
        );
        var actual = result2[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_CopyItemLegacyByRelativeUrl_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKeyPath"] = context.AppSettings["PrivateKeyPath"]
            }
        );
        var result1 = context.Runspace.InvokeCommand<File>(
            "Get-KshFile",
            new Dictionary<string, object>()
            {
                ["FileUrl"] = context.AppSettings["File1Url"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<File>(
            "Copy-KshFile",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["NewUrl"] = context.AppSettings["Folder1Url"] + "/TestFile9.txt",
                ["Overwrite"] = true,
                ["Legacy"] = true,
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshFile",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0]
            }
        );
        var actual = result2[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_CopyItemLegacyByAbsoluteUrl_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKeyPath"] = context.AppSettings["PrivateKeyPath"]
            }
        );
        var result1 = context.Runspace.InvokeCommand<File>(
            "Get-KshFile",
            new Dictionary<string, object>()
            {
                ["FileUrl"] = context.AppSettings["File1Url"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<File>(
            "Copy-KshFile",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["NewUrl"] = context.AppSettings["AuthorityUrl"] + context.AppSettings["Folder1Url"] + "/TestFile9.txt",
                ["Overwrite"] = true,
                ["Legacy"] = true,
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshFile",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0]
            }
        );
        var actual = result2[0];
        Assert.That(actual, Is.Not.Null);
    }

}
