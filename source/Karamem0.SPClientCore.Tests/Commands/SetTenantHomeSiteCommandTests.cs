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
public class SetTenantHomeSiteCommandTests
{

    [Test()]
    public void InvokeCommand_SetItem_ShouldSucceed()
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
        var result2 = context.Runspace.InvokeCommand<string>(
            "Set-KshTenantHomeSite",
            new Dictionary<string, object>()
            {
                ["Url"] = result1.ElementAt(0).Url,
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshTenantHomeSite",
            new Dictionary<string, object>()
            {
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshTenantSiteCollection",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1.ElementAt(0)
            }
        );
        var result3 = context.Runspace.InvokeCommand<TenantDeletedSiteCollection>(
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
                ["Identity"] = result3.ElementAt(0)
            }
        );
        var actual = result2.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}
