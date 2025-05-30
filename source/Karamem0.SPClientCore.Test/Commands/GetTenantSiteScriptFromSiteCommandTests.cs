//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Test.Utility;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands.Test;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class GetTenantSiteScriptFromSiteCommandTests
{

    [Test()]
    public void InvokeCommand_GetBySiteUrl_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<string>(
            "Get-KshTenantSiteScriptFromSite",
            new Dictionary<string, object>()
            {
                ["SiteUrl"] = context.AppSettings["BaseUrl"],
                ["IncludeBranding"] = true,
                ["IncludedLists"] = null,
                ["IncludeLinksToExportedItems"] = false,
                ["IncludeRegionalSettings"] = false,
                ["IncludeSiteExternalSharingCapability"] = false,
                ["IncludeTheme"] = false,
            }
        );
        var actual = result1[0];
        Assert.That(actual, Is.Not.Null);
    }

}
