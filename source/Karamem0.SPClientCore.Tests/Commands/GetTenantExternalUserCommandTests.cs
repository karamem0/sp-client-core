//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests.Commands;

public class GetTenantExternalUserCommandTests
{

    [Test()]
    public void GetExternalUsers()
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
        var result2 = context.Runspace.InvokeCommand<ExternalUser>(
            "Get-KshTenantExternalUser",
            new Dictionary<string, object>()
            {
            }
        );
        var actual = result2.ToList();
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void GetExternalUsersBySite()
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
        var result2 = context.Runspace.InvokeCommand<ExternalUser>(
            "Get-KshTenantExternalUser",
            new Dictionary<string, object>()
            {
                { "SiteCollectionUrl", context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"] },
            }
        );
        var actual = result2.ToList();
        Assert.That(actual, Is.Not.Null);
    }

}