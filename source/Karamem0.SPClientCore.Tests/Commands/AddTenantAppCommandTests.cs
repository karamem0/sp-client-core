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
public class AddTenantAppCommandTests
{

    [Test()]
    public void AddApp()
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
            "Remove-KshTenantApp",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) }
            }
        );
        var actual = result2.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}
