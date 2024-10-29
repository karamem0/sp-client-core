//
// Copyright (c) 2018-2024 karamem0
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
public class AddTenantHubSiteCommandTests
{

    [Test()]
    public void AddHubSite()
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
                { "Description", "Test Hub Site 0 Description" },
                { "EnablePermissionsSync", true },
                { "HideNameInNavigation", true },
                { "LogoUrl", result3.ElementAt(0).Url + "/_layouts/15/images/siteIcon.png" },
                { "SiteCollectionId", result3.ElementAt(0).Id },
                { "SiteCollectionUrl", result3.ElementAt(0).Url },
                { "Title", "Test Hub Site 0" }
            }
        );
        var result5 = context.Runspace.InvokeCommand(
            "Remove-KshTenantHubSite",
            new Dictionary<string, object>()
            {
                { "Identity", result4.ElementAt(0) }
            }
        );
        var result6 = context.Runspace.InvokeCommand(
            "Remove-KshTenantSiteCollection",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) }
            }
        );
        var result7 = context.Runspace.InvokeCommand<TenantDeletedSiteCollection>(
            "Get-KshTenantDeletedSiteCollection",
            new Dictionary<string, object>()
            {
                { "SiteCollectionUrl", result2.ElementAt(0).Url }
            }
        );
        var result8 = context.Runspace.InvokeCommand(
            "Remove-KshTenantDeletedSiteCollection",
            new Dictionary<string, object>()
            {
                { "Identity", result7.ElementAt(0) }
            }
        );
        var actual = result4.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}
