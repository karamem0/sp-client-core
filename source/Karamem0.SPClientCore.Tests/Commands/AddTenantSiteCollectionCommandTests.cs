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
public class AddTenantSiteCollectionCommandTests
{

    [Test()]
    public void InvokeCommand_AddItem_ShouldSucceed()
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
                ["CompatibilityLevel"] = 15,
                ["Lcid"] = 1041,
                ["Owner"] = context.AppSettings["OwnerUserName"],
                ["StorageMaxLevel"] = 26214400,
                ["StorageWarningLevel"] = 25574400,
                ["Template"] = "SITEPAGEPUBLISHING#0",
                ["TimeZoneId"] = 20,
                ["Title"] = "Test Site 0",
                ["Url"] = context.AppSettings["AuthorityUrl"] + "/sites/TestSite0",
                ["UserCodeMaxLevel"] = 300,
                ["UserCodeWarningLevel"] = 100
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshTenantSiteCollection",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1.ElementAt(0)
            }
        );
        var result2 = context.Runspace.InvokeCommand<TenantDeletedSiteCollection>(
            "Get-KshTenantDeletedSiteCollection",
            new Dictionary<string, object>()
            {
                ["SiteCollectionUrl"] = result1.ElementAt(0).Url
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshTenantDeletedSiteCollection",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2.ElementAt(0)
            }
        );
        var actual = result1.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}
