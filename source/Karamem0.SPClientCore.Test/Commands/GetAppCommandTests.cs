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
public class GetAppCommandTests
{

    [Test()]
    public void InvokeCommand_GetAllFromTenant_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["TenantAppCatalogUrl"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKeyPath"] = context.AppSettings["PrivateKeyPath"]
            }
        );
        var result1 = context.Runspace.InvokeCommand<App>(
            "Get-KshApp",
            new Dictionary<string, object>()
            {
                ["Tenant"] = true
            }
        );
        var actual = result1.ToArray();
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_GetByIdentityFromTenant_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["TenantAppCatalogUrl"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKeyPath"] = context.AppSettings["PrivateKeyPath"]
            }
        );
        var result1 = context.Runspace.InvokeCommand<App>(
            "Get-KshApp",
            new Dictionary<string, object>()
            {
                ["AppId"] = context.AppSettings["TenantApp1Id"],
                ["Tenant"] = true
            }
        );
        var result2 = context.Runspace.InvokeCommand<App>(
            "Get-KshApp",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["Tenant"] = true
            }
        );
        var actual = result2[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_GetByAppIdFromTenant_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["TenantAppCatalogUrl"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKeyPath"] = context.AppSettings["PrivateKeyPath"]
            }
        );
        var result1 = context.Runspace.InvokeCommand<App>(
            "Get-KshApp",
            new Dictionary<string, object>()
            {
                ["AppId"] = context.AppSettings["TenantApp1Id"],
                ["Tenant"] = true
            }
        );
        var actual = result1[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_GetAllFromSiteCollection_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["BaseUrl"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKeyPath"] = context.AppSettings["PrivateKeyPath"]
            }
        );
        var result1 = context.Runspace.InvokeCommand<App>(
            "Get-KshApp",
            new Dictionary<string, object>()
            {
                ["Tenant"] = false
            }
        );
        var actual = result1.ToArray();
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_GetByIdentityFromSiteCollection_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["BaseUrl"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKeyPath"] = context.AppSettings["PrivateKeyPath"]
            }
        );
        var result1 = context.Runspace.InvokeCommand<App>(
            "Get-KshApp",
            new Dictionary<string, object>()
            {
                ["AppId"] = context.AppSettings["SiteCollectionApp1Id"],
                ["Tenant"] = false
            }
        );
        var result2 = context.Runspace.InvokeCommand<App>(
            "Get-KshApp",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["Tenant"] = false
            }
        );
        var actual = result2[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_GetByAppIdFromSiteCollection_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["BaseUrl"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKeyPath"] = context.AppSettings["PrivateKeyPath"]
            }
        );
        var result1 = context.Runspace.InvokeCommand<App>(
            "Get-KshApp",
            new Dictionary<string, object>()
            {
                ["AppId"] = context.AppSettings["SiteCollectionApp1Id"],
                ["Tenant"] = false
            }
        );
        var actual = result1[0];
        Assert.That(actual, Is.Not.Null);
    }

}
