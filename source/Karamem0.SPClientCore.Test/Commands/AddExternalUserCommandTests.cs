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
public class AddExternalUserCommandTests
{

    [Test()]
    public void InvokeCommand_AddItemToSite_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<UserSharingResult>(
            "Add-KshExternalUser",
            new Dictionary<string, object>()
            {
                ["Site"] = true,
                ["UserId"] = new[]
                {
                    context.AppSettings["ExternalUserName"]
                },
                ["Role"] = "View",
            }
        );
        var result2 = context.Runspace.InvokeCommand<User>(
            "Get-KshUser",
            new Dictionary<string, object>()
            {
                ["UserName"] = result1[0].UserId,
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshUser",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0],
            }
        );
        var actual = result1[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_AddItemToFile_ShouldSucceed()
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
        var result2 = context.Runspace.InvokeCommand<UserSharingResult>(
            "Add-KshExternalUser",
            new Dictionary<string, object>()
            {
                ["File"] = result1[0],
                ["UserId"] = new[]
                {
                    context.AppSettings["ExternalUserName"]
                },
                ["Role"] = "View",
                ["AdditivePermission"] = true,
                ["CustomMessage"] = "TestFile1.txt",
                ["IncludeAnonymousLinksInNotification"] = true,
                ["PropagateAcl"] = true,
                ["SendServerManagedNotification"] = true,
                ["ValidateExistingPermissions"] = true
            }
        );
        var actual = result2[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_AddItemToFolder_ShouldSucceed()
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
        var result2 = context.Runspace.InvokeCommand<UserSharingResult>(
            "Add-KshExternalUser",
            new Dictionary<string, object>()
            {
                ["Folder"] = result1[0],
                ["UserId"] = new[]
                {
                    context.AppSettings["ExternalUserName"]
                },
                ["Role"] = "View",
                ["AdditivePermission"] = true,
                ["CustomMessage"] = "TestFile1.txt",
                ["IncludeAnonymousLinksInNotification"] = true,
                ["PropagateAcl"] = true,
                ["SendServerManagedNotification"] = true,
                ["ValidateExistingPermissions"] = true
            }
        );
        var actual = result2[0];
        Assert.That(actual, Is.Not.Null);
    }

}
