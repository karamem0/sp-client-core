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
public class SetTenantSiteCollectionLockStatusCommandTests
{

    [Test()]
    public void InvokeCommand_LockItem_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["AdminUrl"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKeyPath"] = context.AppSettings["PrivateKeyPath"]
            }
        );
        var result1 = context.Runspace.InvokeCommand<TenantSiteCollection>(
            "Add-KshTenantSiteCollection",
            new Dictionary<string, object>()
            {
                ["Owner"] = context.AppSettings["OwnerUserName"],
                ["Template"] = "SITEPAGEPUBLISHING#0",
                ["Url"] = context.AppSettings["AuthorityUrl"] + "/sites/TestSite0"
            }
        );
        var result2 = context.Runspace.InvokeCommand<TenantSiteCollection>(
            "Set-KshTenantSiteCollectionLockStatus",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["PassThru"] = true,
                ["Lock"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshTenantSiteCollectionLockStatus",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["Unlock"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshTenantSiteCollection",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0]
            }
        );
        var result3 = context.Runspace.InvokeCommand<TenantDeletedSiteCollection>(
            "Get-KshTenantDeletedSiteCollection",
            new Dictionary<string, object>()
            {
                ["SiteCollectionUrl"] = result1[0].Url
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshTenantDeletedSiteCollection",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3[0]
            }
        );
        var actual = result2[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_UnlockItem_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["AdminUrl"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKeyPath"] = context.AppSettings["PrivateKeyPath"]
            }
        );
        var result1 = context.Runspace.InvokeCommand<TenantSiteCollection>(
            "Add-KshTenantSiteCollection",
            new Dictionary<string, object>()
            {
                ["Owner"] = context.AppSettings["OwnerUserName"],
                ["Template"] = "SITEPAGEPUBLISHING#0",
                ["Url"] = context.AppSettings["AuthorityUrl"] + "/sites/TestSite0"
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshTenantSiteCollectionLockStatus",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["Lock"] = true
            }
        );
        var result2 = context.Runspace.InvokeCommand<TenantSiteCollection>(
            "Set-KshTenantSiteCollectionLockStatus",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["Unlock"] = true,
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshTenantSiteCollection",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0]
            }
        );
        var result3 = context.Runspace.InvokeCommand<TenantDeletedSiteCollection>(
            "Get-KshTenantDeletedSiteCollection",
            new Dictionary<string, object>()
            {
                ["SiteCollectionUrl"] = result1[0].Url
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshTenantDeletedSiteCollection",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3[0]
            }
        );
        var actual = result2[0];
        Assert.That(actual, Is.Not.Null);
    }

}
