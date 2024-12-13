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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands.Tests;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class GetTenantListDesignCommandTests
{

    [Test()]
    public void GetTenantListDesigns()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["AdminUrl"] },
                { "ClientId", context.AppSettings["ClientId"] },
                { "CertificatePath", context.AppSettings["CertificatePath"] },
                { "CertificatePassword", context.AppSettings["CertificatePassword"].ToSecureString() }
            }
        );
        var result1 = context.Runspace.InvokeCommand<TenantListDesign>(
            "Get-KshTenantListDesign",
            new Dictionary<string, object>()
            {
            }
        );
        var actual = result1.ToArray();
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void GetTenantListDesignByIdentity()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["AdminUrl"] },
                { "ClientId", context.AppSettings["ClientId"] },
                { "CertificatePath", context.AppSettings["CertificatePath"] },
                { "CertificatePassword", context.AppSettings["CertificatePassword"].ToSecureString() }
            }
        );
        var result1 = context.Runspace.InvokeCommand<TenantListDesign>(
            "Get-KshTenantListDesign",
            new Dictionary<string, object>()
            {
                { "ListDesignId", context.AppSettings["ListDesign1Id"] }
            }
        );
        var result2 = context.Runspace.InvokeCommand<TenantListDesign>(
            "Get-KshTenantListDesign",
            new Dictionary<string, object>()
            {
                { "Identity", result1.ElementAt(0) }
            }
        );
        var actual = result2.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void GetTenantListDesignByListDesignId()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["AdminUrl"] },
                { "ClientId", context.AppSettings["ClientId"] },
                { "CertificatePath", context.AppSettings["CertificatePath"] },
                { "CertificatePassword", context.AppSettings["CertificatePassword"].ToSecureString() }
            }
        );
        var result1 = context.Runspace.InvokeCommand<TenantListDesign>(
            "Get-KshTenantListDesign",
            new Dictionary<string, object>()
            {
                { "ListDesignId", context.AppSettings["ListDesign1Id"] }
            }
        );
        var actual = result1.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}
