//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Test.Utility;
using NUnit.Framework;
using System.Collections;

namespace Karamem0.SharePoint.PowerShell.Commands.Test;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class SetPropertyCommandTests
{

    [Test()]
    public void InvokeCommand_SetHashtableToSite_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKey"] = Convert.FromBase64String(context.AppSettings["PrivateKey"])
            }
        );
        var result1 = context.Runspace.InvokeCommand<Site>(
            "Add-KshSite",
            new Dictionary<string, object>()
            {
                ["Description"] = "Test Site 0 Description",
                ["ServerRelativeUrl"] = "TestSite0",
                ["Title"] = "Test Site 0"
            }
        );
        var result2 = context.Runspace.InvokeCommand<Site>(
            "Select-KshSite",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["PassThru"] = true
            }
        );
        var result3 = context.Runspace.InvokeCommand<PropertyValues>(
            "Set-KshProperty",
            new Dictionary<string, object>()
            {
                ["Site"] = true,
                ["Value"] = new Hashtable()
                {
                    ["TestEntity0"] = "Test Value 0"
                },
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshSite",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0]
            }
        );
        var actual = result3[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_SetObjectToSite_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKey"] = Convert.FromBase64String(context.AppSettings["PrivateKey"])
            }
        );
        var result1 = context.Runspace.InvokeCommand<Site>(
            "Add-KshSite",
            new Dictionary<string, object>()
            {
                ["Description"] = "Test Site 0 Description",
                ["ServerRelativeUrl"] = "TestSite0",
                ["Title"] = "Test Site 0"
            }
        );
        var result2 = context.Runspace.InvokeCommand<Site>(
            "Select-KshSite",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["PassThru"] = true
            }
        );
        var result3 = context.Runspace.InvokeCommand<PropertyValues>(
            "Set-KshProperty",
            new Dictionary<string, object>()
            {
                ["Site"] = true,
                ["Value"] = new
                {
                    TestEntity0 = "Test Value 0"
                },
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshSite",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0]
            }
        );
        var actual = result3[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_SetHashtableToFile_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKey"] = Convert.FromBase64String(context.AppSettings["PrivateKey"])
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
                ["Overwrite"] = false,
                ["FileName"] = "TestFile0.txt"
            }
        );
        var result3 = context.Runspace.InvokeCommand<PropertyValues>(
            "Set-KshProperty",
            new Dictionary<string, object>()
            {
                ["File"] = result2[0],
                ["Value"] = new Hashtable()
                {
                    ["TestEntity0"] = "Test Value 0"
                },
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
    public void InvokeCommand_SetObjectToFile_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKey"] = Convert.FromBase64String(context.AppSettings["PrivateKey"])
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
                ["Overwrite"] = false,
                ["FileName"] = "TestFile0.txt"
            }
        );
        var result3 = context.Runspace.InvokeCommand<PropertyValues>(
            "Set-KshProperty",
            new Dictionary<string, object>()
            {
                ["File"] = result2[0],
                ["Value"] = new
                {
                    TestEntity0 = "Test Value 0"
                },
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
    public void InvokeCommand_SetHashtableToFolder_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKey"] = Convert.FromBase64String(context.AppSettings["PrivateKey"])
            }
        );
        var result1 = context.Runspace.InvokeCommand<Folder>(
            "Get-KshFolder",
            new Dictionary<string, object>()
            {
                ["FolderUrl"] = context.AppSettings["Folder1Url"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<Folder>(
            "Add-KshFolder",
            new Dictionary<string, object>()
            {
                ["Folder"] = result1[0],
                ["FolderName"] = "Test Folder 0"
            }
        );
        var result3 = context.Runspace.InvokeCommand<PropertyValues>(
            "Set-KshProperty",
            new Dictionary<string, object>()
            {
                ["Folder"] = result2[0],
                ["Value"] = new Hashtable()
                {
                    ["TestEntity0"] = "Test Value 0"
                },
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshFolder",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0]
            }
        );
        var actual = result3[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_SetObjectToFolder_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKey"] = Convert.FromBase64String(context.AppSettings["PrivateKey"])
            }
        );
        var result1 = context.Runspace.InvokeCommand<Folder>(
            "Get-KshFolder",
            new Dictionary<string, object>()
            {
                ["FolderUrl"] = context.AppSettings["Folder1Url"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<Folder>(
            "Add-KshFolder",
            new Dictionary<string, object>()
            {
                ["Folder"] = result1[0],
                ["FolderName"] = "Test Folder 0"
            }
        );
        var result3 = context.Runspace.InvokeCommand<PropertyValues>(
            "Set-KshProperty",
            new Dictionary<string, object>()
            {
                ["Folder"] = result2[0],
                ["Value"] = new
                {
                    TestEntity0 = "Test Value 0"
                },
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshFolder",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0]
            }
        );
        var actual = result3[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_SetHashtableToListItem_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKey"] = Convert.FromBase64String(context.AppSettings["PrivateKey"])
            }
        );
        var result1 = context.Runspace.InvokeCommand<List>(
            "Get-KshList",
            new Dictionary<string, object>()
            {
                ["ListId"] = context.AppSettings["List1Id"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<ListItem>(
            "Add-KshListItem",
            new Dictionary<string, object>()
            {
                ["List"] = result1[0],
                ["Value"] = new Hashtable()
            }
        );
        var result3 = context.Runspace.InvokeCommand<PropertyValues>(
            "Set-KshProperty",
            new Dictionary<string, object>()
            {
                ["ListItem"] = result2[0],
                ["Value"] = new Hashtable()
                {
                    ["TestEntity0"] = "Test Value 0"
                },
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshListItem",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0]
            }
        );
        var actual = result3[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_SetObjectToListItem_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKey"] = Convert.FromBase64String(context.AppSettings["PrivateKey"])
            }
        );
        var result1 = context.Runspace.InvokeCommand<List>(
            "Get-KshList",
            new Dictionary<string, object>()
            {
                ["ListId"] = context.AppSettings["List1Id"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<ListItem>(
            "Add-KshListItem",
            new Dictionary<string, object>()
            {
                ["List"] = result1[0],
                ["Value"] = new Hashtable()
            }
        );
        var result3 = context.Runspace.InvokeCommand<PropertyValues>(
            "Set-KshProperty",
            new Dictionary<string, object>()
            {
                ["ListItem"] = result2[0],
                ["Value"] = new
                {
                    TestEntity0 = "Test Value 0"
                },
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshListItem",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0]
            }
        );
        var actual = result3[0];
        Assert.That(actual, Is.Not.Null);
    }

}
