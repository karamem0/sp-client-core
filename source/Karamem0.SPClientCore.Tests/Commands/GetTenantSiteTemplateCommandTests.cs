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
public class GetTenantSiteTemplateCommandTests
{

    [Test()]
    public void GetTenantSiteTemplates()
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
        var result2 = context.Runspace.InvokeCommand<TenantSiteTemplate>(
            "Get-KshTenantSiteTemplate",
            new Dictionary<string, object>()
            {
            }
        );
        var actual = result2.ToArray();
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void GetTenantSiteTemplatesByFilter()
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
        var result2 = context.Runspace.InvokeCommand<TenantSiteTemplate>(
            "Get-KshTenantSiteTemplate",
            new Dictionary<string, object>()
            {
                { "CompatibilityLevel", 15 },
                { "Lcid", 1033 }
            }
        );
        var actual = result2.ToArray();
        Assert.That(actual, Is.Not.Null);
    }

}
