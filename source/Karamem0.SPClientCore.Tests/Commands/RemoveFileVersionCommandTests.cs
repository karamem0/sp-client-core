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
public class RemoveFileVersionCommandTests
{

    [Test()]
    public void InvokeCommand_RemoveOne_ShouldSucceed()
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
        _ = context.Runspace.InvokeCommand<File>(
            "Save-KshFile",
            new Dictionary<string, object>()
            {
                ["Folder"] = result1.ElementAt(0),
                ["Content"] = new System.IO.MemoryStream(Encoding.UTF8.GetBytes("TestFile0")),
                ["FileName"] = "TestFile0.txt",
                ["Overwrite"] = false,
                ["PassThru"] = true
            }
        );
        var result2 = context.Runspace.InvokeCommand<File>(
            "Save-KshFile",
            new Dictionary<string, object>()
            {
                ["Folder"] = result1.ElementAt(0),
                ["Content"] = new System.IO.MemoryStream(Encoding.UTF8.GetBytes("TestFile9")),
                ["FileName"] = "TestFile0.txt",
                ["Overwrite"] = true,
                ["PassThru"] = true
            }
        );
        var result3 = context.Runspace.InvokeCommand<FileVersion>(
            "Get-KshFileVersion",
            new Dictionary<string, object>()
            {
                ["File"] = result2.ElementAt(0),
                ["FileVersionId"] = 1
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshFileVersion",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3.ElementAt(0)
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshFile",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2.ElementAt(0)
            }
        );
    }

    [Test()]
    public void InvokeCommand_RemoveAll_ShouldSucceed()
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
        _ = context.Runspace.InvokeCommand<File>(
            "Save-KshFile",
            new Dictionary<string, object>()
            {
                ["Folder"] = result1.ElementAt(0),
                ["Content"] = new System.IO.MemoryStream(Encoding.UTF8.GetBytes("TestFile0")),
                ["FileName"] = "TestFile0.txt",
                ["Overwrite"] = false,
                ["PassThru"] = true
            }
        );
        var result2 = context.Runspace.InvokeCommand<File>(
            "Save-KshFile",
            new Dictionary<string, object>()
            {
                ["Folder"] = result1.ElementAt(0),
                ["Content"] = new System.IO.MemoryStream(Encoding.UTF8.GetBytes("TestFile9")),
                ["FileName"] = "TestFile0.txt",
                ["Overwrite"] = true,
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshFileVersion",
            new Dictionary<string, object>()
            {
                ["File"] = result2.ElementAt(0),
                ["All"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshFile",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2.ElementAt(0)
            }
        );
    }

    [Test()]
    public void InvokeCommand_RemoveItemToRecycleBin_ShouldSucceed()
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
        _ = context.Runspace.InvokeCommand<File>(
            "Save-KshFile",
            new Dictionary<string, object>()
            {
                ["Folder"] = result1.ElementAt(0),
                ["Content"] = new System.IO.MemoryStream(Encoding.UTF8.GetBytes("TestFile0")),
                ["FileName"] = "TestFile0.txt",
                ["Overwrite"] = false,
                ["PassThru"] = true
            }
        );
        var result2 = context.Runspace.InvokeCommand<File>(
            "Save-KshFile",
            new Dictionary<string, object>()
            {
                ["Folder"] = result1.ElementAt(0),
                ["Content"] = new System.IO.MemoryStream(Encoding.UTF8.GetBytes("TestFile9")),
                ["FileName"] = "TestFile0.txt",
                ["Overwrite"] = true,
                ["PassThru"] = true
            }
        );
        var result3 = context.Runspace.InvokeCommand<FileVersion>(
            "Get-KshFileVersion",
            new Dictionary<string, object>()
            {
                ["File"] = result2.ElementAt(0),
                ["FileVersionId"] = 1
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshFileVersion",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3.ElementAt(0),
                ["RecycleBin"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshFile",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2.ElementAt(0)
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshRecycleBinItem",
            new Dictionary<string, object>()
            {
                ["All"] = true
            }
        );
    }

}
