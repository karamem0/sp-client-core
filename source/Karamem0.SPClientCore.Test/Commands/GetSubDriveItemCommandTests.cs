//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V2;
using Karamem0.SharePoint.PowerShell.Test.Utility;
using NUnit.Framework;

namespace Karamem0.SharePoint.PowerShell.Commands.Test;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class GetSubDriveItemCommandTests
{

    [Test()]
    public void InvokeCommand_GetByDrive_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<Drive>(
            "Get-KshDrive",
            new Dictionary<string, object>()
            {
                ["DriveId"] = context.AppSettings["List2DriveId"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<DriveItem>(
            "Get-KshSubDriveItem",
            new Dictionary<string, object>()
            {
                ["Drive"] = result1[0]
            }
        );
        var actual = result2.ToArray();
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_GetByDriveItem_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<Drive>(
            "Get-KshDrive",
            new Dictionary<string, object>()
            {
                ["DriveId"] = context.AppSettings["List2DriveId"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<DriveItem>(
            "Get-KshDriveItem",
            new Dictionary<string, object>()
            {
                ["Drive"] = result1[0],
                ["DriveItemId"] = context.AppSettings["Folder1DriveItemId"]
            }
        );
        _ = context.Runspace.InvokeCommand<DriveItem>(
            "Get-KshSubDriveItem",
            new Dictionary<string, object>()
            {
                ["DriveItem"] = result2[0]
            }
        );
        var actual = result2.ToArray();
        Assert.That(actual, Is.Not.Null);
    }

}
