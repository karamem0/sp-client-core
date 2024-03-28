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

namespace Karamem0.SharePoint.PowerShell.Tests;

[TestClass()]
public class PublishTenantAppCommandTests
{

    [TestMethod()]
    public void PublishApp()
    {
        using var context = new PSCmdletContext();
        var result1 = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["TenantAppCatalogUrl"] },
                { "Credential", PSCredentialFactory.CreateCredential(
                    context.AppSettings["LoginUserName"],
                    context.AppSettings["LoginPassword"])
                }
            }
        );
        var result2 = context.Runspace.InvokeCommand<App>(
            "Add-KshTenantApp",
            new Dictionary<string, object>()
            {
                { "Content", System.IO.File.OpenRead(context.AppSettings["App0Path"]) },
                { "FileName", "TestApp0.sppkg" },
                { "Overwrite", false }
            }
        );
        var result3 = context.Runspace.InvokeCommand(
            "Publish-KshTenantApp",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) }
            }
        );
        var result4 = context.Runspace.InvokeCommand<App>(
            "Get-KshTenantApp",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) }
            }
        );
        var result5 = context.Runspace.InvokeCommand(
            "Unpublish-KshTenantApp",
            new Dictionary<string, object>()
            {
                { "Identity", result4.ElementAt(0) }
            }
        );
        var result6 = context.Runspace.InvokeCommand(
            "Remove-KshTenantApp",
            new Dictionary<string, object>()
            {
                { "Identity", result4.ElementAt(0) }
            }
        );
        var actual = result4.ElementAt(0);
        Assert.IsNotNull(actual);
    }

}
