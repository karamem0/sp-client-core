//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Models.V2;
using Karamem0.SharePoint.PowerShell.Tests.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands.Tests;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class GetDriveItemCommandTests
{

    [Test()]
    public void GetDriveItemsByDrive()
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
        var result2 = context.Runspace.InvokeCommand<Drive>(
            "Get-KshDrive",
            new Dictionary<string, object>()
            {
                { "DriveId", context.AppSettings["List2DriveId"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<DriveItem>(
            "Get-KshDriveItem",
            new Dictionary<string, object>()
            {
                { "Drive", result2.ElementAt(0) }
            }
        );
        var actual = result3.ToArray();
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void GetDriveItemsByDriveItem()
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
        var result2 = context.Runspace.InvokeCommand<Drive>(
            "Get-KshDrive",
            new Dictionary<string, object>()
            {
                { "DriveId", context.AppSettings["List2DriveId"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<DriveItem>(
            "Get-KshDriveItem",
            new Dictionary<string, object>()
            {
                { "Drive", result2.ElementAt(0) },
                { "DriveItemId", context.AppSettings["Folder1DriveItemId"] }
            }
        );
        var result4 = context.Runspace.InvokeCommand<DriveItem>(
            "Get-KshDriveItem",
            new Dictionary<string, object>()
            {
                { "DriveItem", result3.ElementAt(0) }
            }
        );
        var actual = result3.ToArray();
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void GetDriveItemByFolder()
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
        var result2 = context.Runspace.InvokeCommand<Models.V1.Folder>(
            "Get-KshFolder",
            new Dictionary<string, object>()
            {
                { "FolderUrl", context.AppSettings["Folder1Url"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<DriveItem>(
            "Get-KshDriveItem",
            new Dictionary<string, object>()
            {
                { "Folder", result2.ElementAt(0) }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void GetDriveItemByFile()
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
        var result2 = context.Runspace.InvokeCommand<Models.V1.File>(
            "Get-KshFile",
            new Dictionary<string, object>()
            {
                { "FileUrl", context.AppSettings["File1Url"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<DriveItem>(
            "Get-KshDriveItem",
            new Dictionary<string, object>()
            {
                { "File", result2.ElementAt(0) }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void GetDriveItemByListItem()
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
        var result2 = context.Runspace.InvokeCommand<Models.V1.File>(
            "Get-KshFile",
            new Dictionary<string, object>()
            {
                { "FileUrl", context.AppSettings["File1Url"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<ListItem>(
            "Get-KshListItem",
            new Dictionary<string, object>()
            {
                { "File", result2.ElementAt(0) }
            }
        );
        var result4 = context.Runspace.InvokeCommand<DriveItem>(
            "Get-KshDriveItem",
            new Dictionary<string, object>()
            {
                { "ListItem", result3.ElementAt(0) }
            }
        );
        var actual = result4.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void GetDriveItemByDriveItemUrl()
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
        var result2 = context.Runspace.InvokeCommand<DriveItem>(
            "Get-KshDriveItem",
            new Dictionary<string, object>()
            {
                { "DriveItemUrl", context.AppSettings["AuthorityUrl"] + context.AppSettings["File1Url"] }
            }
        );
        var actual = result2.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void GetDriveItemByDriveItemId()
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
        var result2 = context.Runspace.InvokeCommand<Drive>(
            "Get-KshDrive",
            new Dictionary<string, object>()
            {
                { "DriveId", context.AppSettings["List2DriveId"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<DriveItem>(
            "Get-KshDriveItem",
            new Dictionary<string, object>()
            {
                { "Drive", result2.ElementAt(0) },
                { "DriveItemId", context.AppSettings["File1DriveItemId"] }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void GetDriveItemByDriveItemPath()
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
        var result2 = context.Runspace.InvokeCommand<Drive>(
            "Get-KshDrive",
            new Dictionary<string, object>()
            {
                { "DriveId", context.AppSettings["List2DriveId"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<DriveItem>(
            "Get-KshDriveItem",
            new Dictionary<string, object>()
            {
                { "Drive", result2.ElementAt(0) },
                { "DriveItemPath", context.AppSettings["File1Url"][context.AppSettings["List2Url"].Length..] }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}
