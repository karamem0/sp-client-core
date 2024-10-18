//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Tests.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests.Commands;

[TestClass()]
public class AddTenantListDesignCommandTests
{

    [TestMethod()]
    public void AddListDesign()
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
        var result2 = context.Runspace.InvokeCommand<TenantListDesign>(
            "Add-KshTenantListDesign",
            new Dictionary<string, object>()
            {
                { "Description", "Test List Design 0" },
                { "ListColor", "DarkRed" },
                { "ListIcon", "CubeShape" },
                { "SiteScriptIds", new[] { context.AppSettings["ListScript1Id"] } },
                { "TemplateFeatures", null },
                { "ThumbnailUrl", null },
                { "Title", "Test List Design 0" },
            }
        );
        var result3 = context.Runspace.InvokeCommand(
            "Remove-KshTenantListDesign",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) }
            }
        );
        var actual = result2.ElementAt(0);
        Assert.IsNotNull(actual);
    }

}
