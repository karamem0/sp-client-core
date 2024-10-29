//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Tests.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands.Tests;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class RemoveTenantCdnOriginCommandTests
{

    [Test()]
    public void RemoveTenantPublicCdnOrigin()
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
        var result2 = context.Runspace.InvokeCommand(
            "Add-KshTenantCdnOrigin",
            new Dictionary<string, object>()
            {
                { "Public", true },
                { "Origin", "*/TESTLIST1" }
            }
        );
        var result3 = context.Runspace.InvokeCommand(
            "Remove-KshTenantCdnOrigin",
            new Dictionary<string, object>()
            {
                { "Public", true },
                { "Origin", "*/TESTLIST1" }
            }
        );
        var result4 = context.Runspace.InvokeCommand<string>(
            "Get-KshTenantCdnOrigin",
            new Dictionary<string, object>()
            {
                { "Private", true }
            }
        );
        var actual = result4.ToArray();
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void RemoveTenantPrivateCdnOrigin()
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
        var result2 = context.Runspace.InvokeCommand(
            "Add-KshTenantCdnOrigin",
            new Dictionary<string, object>()
            {
                { "Private", true },
                { "Origin", "*/TESTLIST1" }
            }
        );
        var result3 = context.Runspace.InvokeCommand(
            "Remove-KshTenantCdnOrigin",
            new Dictionary<string, object>()
            {
                { "Private", true },
                { "Origin", "*/TESTLIST1" }
            }
        );
        var result4 = context.Runspace.InvokeCommand<string>(
            "Get-KshTenantCdnOrigin",
            new Dictionary<string, object>()
            {
                { "Private", true }
            }
        );
        var actual = result4.ToArray();
        Assert.That(actual, Is.Not.Null);
    }

}
