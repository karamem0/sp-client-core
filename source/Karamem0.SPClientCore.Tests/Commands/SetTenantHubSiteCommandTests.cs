//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests.Commands;

public class SetTenantHubSiteCommandTests
{

    [Test()]
    public void SetHubSite()
    {
        using var context = new PSCmdletContext();
        var result1 = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["AdminUrl"] },
                { "Credential", PSCredentialFactory.CreateCredential(
                    context.AppSettings["LoginUserName"],
                    context.AppSettings["LoginPassword"])
                }
            }
        );
        var result2 = context.Runspace.InvokeCommand<TenantSiteCollection>(
            "Add-KshTenantSiteCollection",
            new Dictionary<string, object>()
            {
                { "Owner", context.AppSettings["LoginUserName"] },
                { "Template", "SITEPAGEPUBLISHING#0" },
                { "Url", context.AppSettings["AuthorityUrl"] + "/sites/TestSite0" }
            }
        );
        var result3 = context.Runspace.InvokeCommand<SiteCollection>(
            "Get-KshSiteCollection",
            new Dictionary<string, object>()
            {
                { "SiteCollectionUrl", result2.ElementAt(0).Url }
            }
        );
        var result4 = context.Runspace.InvokeCommand<HubSite>(
            "Add-KshTenantHubSite",
            new Dictionary<string, object>()
            {
                { "SiteCollectionId", result3.ElementAt(0).Id },
                { "SiteCollectionUrl", result3.ElementAt(0).Url },
                { "Title", "Test Hub Site 1" }
            }
        );
        var result5 = context.Runspace.InvokeCommand<HubSite>(
            "Set-KshTenantHubSite",
            new Dictionary<string, object>()
            {
                { "Identity", result4.ElementAt(0) },
                { "Description", "Test Hub Site 9 Description" },
                { "EnablePermissionsSync", true },
                { "HideNameInNavigation", true },
                { "LogoUrl", context.AppSettings["BaseUrl"] + "/_layouts/15/images/siteIcon.png" },
                { "Title", "Test Hub Site 9" },
                { "PassThru", true }
            }
        );
        var result6 = context.Runspace.InvokeCommand(
            "Remove-KshTenantHubSite",
            new Dictionary<string, object>()
            {
                { "Identity", result5.ElementAt(0) }
            }
        );
        var result7 = context.Runspace.InvokeCommand(
            "Remove-KshTenantSiteCollection",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) }
            }
        );
        var result8 = context.Runspace.InvokeCommand<TenantDeletedSiteCollection>(
            "Get-KshTenantDeletedSiteCollection",
            new Dictionary<string, object>()
            {
                { "SiteCollectionUrl", result2.ElementAt(0).Url }
            }
        );
        var result9 = context.Runspace.InvokeCommand(
            "Remove-KshTenantDeletedSiteCollection",
            new Dictionary<string, object>()
            {
                { "Identity", result8.ElementAt(0) }
            }
        );
        var actual = result4.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}
