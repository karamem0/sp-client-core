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
public class RestoreFileVersionCommandTests
{

    [Test()]
    public void InvokeCommand_RestoreItem_ShouldSucceed()
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
                ["Folder"] = result1[0],
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
                ["Folder"] = result1[0],
                ["Content"] = new System.IO.MemoryStream(Encoding.UTF8.GetBytes("TestFile9")),
                ["FileName"] = "TestFile0.txt",
                ["Overwrite"] = true,
                ["PassThru"] = true
            }
        );
        var result4 = context.Runspace.InvokeCommand<FileVersion>(
            "Get-KshFileVersion",
            new Dictionary<string, object>()
            {
                ["File"] = result2[0],
                ["FileVersionId"] = 1
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Restore-KshFileVersion",
            new Dictionary<string, object>()
            {
                ["Identity"] = result4[0]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshFile",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0]
            }
        );
    }

}
