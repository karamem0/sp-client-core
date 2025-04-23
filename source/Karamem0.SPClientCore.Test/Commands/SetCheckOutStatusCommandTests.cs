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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands.Test;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class SetCheckOutStatusCommandTests
{

    [Test()]
    public void InvokeCommand_CheckOutItem_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<Folder>(
            "Get-KshFolder",
            new Dictionary<string, object>()
            {
                ["FolderUrl"] = context.AppSettings["Folder1Url"],
            }
        );
        var result2 = context.Runspace.InvokeCommand<File>(
            "Add-KshFile",
            new Dictionary<string, object>()
            {
                ["Folder"] = result1[0],
                ["Content"] = Encoding.UTF8.GetBytes("TestFile0"),
                ["FileName"] = "TestFile0.txt"
            }
        );
        var result3 = context.Runspace.InvokeCommand<File>(
            "Set-KshCheckOutStatus",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0],
                ["CheckOut"] = true,
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshCheckOutStatus",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0],
                ["CheckIn"] = true
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
    public void InvokeCommand_CheckInItem_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<Folder>(
            "Get-KshFolder",
            new Dictionary<string, object>()
            {
                ["FolderUrl"] = context.AppSettings["Folder1Url"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<File>(
            "Add-KshFile",
            new Dictionary<string, object>()
            {
                ["Folder"] = result1[0],
                ["Content"] = Encoding.UTF8.GetBytes("TestFile0"),
                ["FileName"] = "TestFile0.txt"
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshCheckOutStatus",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0],
                ["CheckOut"] = true
            }
        );
        var result3 = context.Runspace.InvokeCommand<File>(
            "Set-KshCheckOutStatus",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0],
                ["CheckIn"] = true,
                ["Comment"] = "Test Comment 0",
                ["CheckInType"] = "MajorCheckIn",
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
        var actual = result3[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_UndoCheckOutItem_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<Folder>(
            "Get-KshFolder",
            new Dictionary<string, object>()
            {
                ["FolderUrl"] = context.AppSettings["Folder1Url"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<File>(
            "Add-KshFile",
            new Dictionary<string, object>()
            {
                ["Folder"] = result1[0],
                ["Content"] = Encoding.UTF8.GetBytes("TestFile0"),
                ["FileName"] = "TestFile0.txt"
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshCheckOutStatus",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0],
                ["CheckOut"] = true
            }
        );
        var result3 = context.Runspace.InvokeCommand<File>(
            "Set-KshCheckOutStatus",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0],
                ["UndoCheckOut"] = true,
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
        var actual = result3[0];
        Assert.That(actual, Is.Not.Null);
    }

}
