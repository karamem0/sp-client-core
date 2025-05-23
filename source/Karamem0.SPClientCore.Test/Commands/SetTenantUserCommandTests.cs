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
public class SetTenantUserCommandTests
{

    [Test()]
    public void InvokeCommand_SetItemBySiteCollectionAndUser_ShouldSucceed()
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
            "Get-KshTenantSiteCollection",
            new Dictionary<string, object>()
            {
                ["SiteCollectionUrl"] = context.AppSettings["BaseUrl"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<User>(
            "Add-KshTenantUser",
            new Dictionary<string, object>()
            {
                ["SiteCollection"] = result1[0],
                ["Email"] = "testuser0@" + context.AppSettings["LoginDomainName"],
                ["LoginName"] = "i:0#.f|membership|testuser0@" + context.AppSettings["LoginDomainName"],
                ["Title"] = "Test User 0"
            }
        );
        var result3 = context.Runspace.InvokeCommand<User>(
            "Set-KshTenantUser",
            new Dictionary<string, object>()
            {
                ["SiteCollection"] = result1[0],
                ["User"] = result2[0],
                ["IsSiteCollectionAdmin"] = true,
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshTenantUser",
            new Dictionary<string, object>()
            {
                ["SiteCollection"] = result1[0],
                ["User"] = result3[0]
            }
        );
        var actual = result3[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_SetItemBySiteCollectionAndUserLoginName_ShouldSucceed()
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
            "Get-KshTenantSiteCollection",
            new Dictionary<string, object>()
            {
                ["SiteCollectionUrl"] = context.AppSettings["BaseUrl"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<User>(
            "Add-KshTenantUser",
            new Dictionary<string, object>()
            {
                ["SiteCollection"] = result1[0],
                ["Email"] = "testuser0@" + context.AppSettings["LoginDomainName"],
                ["LoginName"] = "i:0#.f|membership|testuser0@" + context.AppSettings["LoginDomainName"],
                ["Title"] = "Test User 0"
            }
        );
        var result3 = context.Runspace.InvokeCommand<User>(
            "Set-KshTenantUser",
            new Dictionary<string, object>()
            {
                ["SiteCollection"] = result1[0],
                ["UserName"] = result2[0].LoginName,
                ["IsSiteCollectionAdmin"] = true,
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshTenantUser",
            new Dictionary<string, object>()
            {
                ["SiteCollection"] = result1[0],
                ["User"] = result3[0]
            }
        );
        var actual = result3[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_SetItemBySiteCollectionAndUserEmail_ShouldSucceed()
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
            "Get-KshTenantSiteCollection",
            new Dictionary<string, object>()
            {
                ["SiteCollectionUrl"] = context.AppSettings["BaseUrl"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<User>(
            "Add-KshTenantUser",
            new Dictionary<string, object>()
            {
                ["SiteCollection"] = result1[0],
                ["Email"] = "testuser0@" + context.AppSettings["LoginDomainName"],
                ["LoginName"] = "i:0#.f|membership|testuser0@" + context.AppSettings["LoginDomainName"],
                ["Title"] = "Test User 0"
            }
        );
        var result3 = context.Runspace.InvokeCommand<User>(
            "Set-KshTenantUser",
            new Dictionary<string, object>()
            {
                ["SiteCollection"] = result1[0],
                ["UserName"] = result2[0].Email,
                ["IsSiteCollectionAdmin"] = true,
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshTenantUser",
            new Dictionary<string, object>()
            {
                ["SiteCollection"] = result1[0],
                ["User"] = result3[0]
            }
        );
        var actual = result3[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_SetItemBySiteCollectionUrlAndUser_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<User>(
            "Add-KshTenantUser",
            new Dictionary<string, object>()
            {
                ["SiteCollectionUrl"] = context.AppSettings["BaseUrl"],
                ["Email"] = "testuser0@" + context.AppSettings["LoginDomainName"],
                ["LoginName"] = "i:0#.f|membership|testuser0@" + context.AppSettings["LoginDomainName"],
                ["Title"] = "Test User 0"
            }
        );
        var result2 = context.Runspace.InvokeCommand<User>(
            "Set-KshTenantUser",
            new Dictionary<string, object>()
            {
                ["SiteCollectionUrl"] = context.AppSettings["BaseUrl"],
                ["User"] = result1[0],
                ["IsSiteCollectionAdmin"] = true,
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshTenantUser",
            new Dictionary<string, object>()
            {
                ["SiteCollectionUrl"] = context.AppSettings["BaseUrl"],
                ["User"] = result2[0]
            }
        );
        var actual = result2[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_SetItemBySiteCollectionUrlAndUserLoginName_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<User>(
            "Add-KshTenantUser",
            new Dictionary<string, object>()
            {
                ["SiteCollectionUrl"] = context.AppSettings["BaseUrl"],
                ["Email"] = "testuser0@" + context.AppSettings["LoginDomainName"],
                ["LoginName"] = "i:0#.f|membership|testuser0@" + context.AppSettings["LoginDomainName"],
                ["Title"] = "Test User 0"
            }
        );
        var result2 = context.Runspace.InvokeCommand<User>(
            "Set-KshTenantUser",
            new Dictionary<string, object>()
            {
                ["SiteCollectionUrl"] = context.AppSettings["BaseUrl"],
                ["UserName"] = result1[0].LoginName,
                ["IsSiteCollectionAdmin"] = true,
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshTenantUser",
            new Dictionary<string, object>()
            {
                ["SiteCollectionUrl"] = context.AppSettings["BaseUrl"],
                ["User"] = result2[0]
            }
        );
        var actual = result2[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_SetItemBySiteCollectionUrlAndUserEmail_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<User>(
            "Add-KshTenantUser",
            new Dictionary<string, object>()
            {
                ["SiteCollectionUrl"] = context.AppSettings["BaseUrl"],
                ["Email"] = "testuser0@" + context.AppSettings["LoginDomainName"],
                ["LoginName"] = "i:0#.f|membership|testuser0@" + context.AppSettings["LoginDomainName"],
                ["Title"] = "Test User 0"
            }
        );
        var result2 = context.Runspace.InvokeCommand<User>(
            "Set-KshTenantUser",
            new Dictionary<string, object>()
            {
                ["SiteCollectionUrl"] = context.AppSettings["BaseUrl"],
                ["UserName"] = result1[0].Email,
                ["IsSiteCollectionAdmin"] = true,
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshTenantUser",
            new Dictionary<string, object>()
            {
                ["SiteCollectionUrl"] = context.AppSettings["BaseUrl"],
                ["User"] = result2[0]
            }
        );
        var actual = result2[0];
        Assert.That(actual, Is.Not.Null);
    }

}
