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
public class AddTenantHubSiteCommandTests
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
                ["Owner"] = context.AppSettings["OwnerUserName"],
                ["Template"] = "SITEPAGEPUBLISHING#0",
                ["Url"] = context.AppSettings["AuthorityUrl"] + "/sites/TestSite0"
            }
        );
        var result2 = context.Runspace.InvokeCommand<SiteCollection>(
            "Get-KshSiteCollection",
            new Dictionary<string, object>()
            {
                ["SiteCollectionUrl"] = result1[0].Url
            }
        );
        var result3 = context.Runspace.InvokeCommand<HubSite>(
            "Add-KshTenantHubSite",
            new Dictionary<string, object>()
            {
                ["Description"] = "Test Hub Site 0 Description",
                ["EnablePermissionsSync"] = true,
                ["HideNameInNavigation"] = true,
                ["LogoUrl"] = $"{result2[0].Url}/_layouts/15/images/siteIcon.png",
                ["SiteCollectionId"] = result2[0].Id,
                ["SiteCollectionUrl"] = result2[0].Url,
                ["Title"] = "Test Hub Site 0"
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshTenantHubSite",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3[0]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshTenantSiteCollection",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0]
            }
        );
        var result4 = context.Runspace.InvokeCommand<TenantDeletedSiteCollection>(
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
                ["Identity"] = result4[0]
            }
        );
        var actual = result3[0];
        Assert.That(actual, Is.Not.Null);
    }

}
