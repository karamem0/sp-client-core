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
public class PublishTenantAppCommandTests
{

    [Test()]
    public void InvokeCommand_PublishItem_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["TenantAppCatalogUrl"] },
                { "ClientId", context.AppSettings["ClientId"] },
                { "CertificatePath", context.AppSettings["CertificatePath"] },
                { "CertificatePassword", context.AppSettings["CertificatePassword"].ToSecureString() }
            }
        );
        var result1 = context.Runspace.InvokeCommand<App>(
            "Add-KshTenantApp",
            new Dictionary<string, object>()
            {
                { "Content", System.IO.File.OpenRead(context.AppSettings["App0Path"]) },
                { "FileName", "TestApp0.sppkg" },
                { "Overwrite", false }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Publish-KshTenantApp",
            new Dictionary<string, object>()
            {
                { "Identity", result1.ElementAt(0) }
            }
        );
        var result2 = context.Runspace.InvokeCommand<App>(
            "Get-KshTenantApp",
            new Dictionary<string, object>()
            {
                { "Identity", result1.ElementAt(0) }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Unpublish-KshTenantApp",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) }
            }
        );
        _ = context.Runspace.InvokeCommand(
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
