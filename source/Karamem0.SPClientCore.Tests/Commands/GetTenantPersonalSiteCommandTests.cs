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
public class GetTenantPersonalSiteCommandTests
{

    [Test()]
    public void InvokeCommand_GetByUser_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["AdminUrl"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["CertificatePassword"] = context.AppSettings["CertificatePassword"].ToSecureString()
            }
        );
        var result1 = context.Runspace.InvokeCommand<TenantSiteCollection>(
            "Get-KshTenantSiteCollection",
            new Dictionary<string, object>()
            {
                ["SiteCollectionUrl"] = context.AppSettings["BaseUrl"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<User>(
            "Get-KshTenantUser",
            new Dictionary<string, object>()
            {
                ["SiteCollection"] = result1.ElementAt(0),
                ["UserId"] = context.AppSettings["User1Id"]
            }
        );
        var result3 = context.Runspace.InvokeCommand<string>(
            "Get-KshTenantPersonalSite",
            new Dictionary<string, object>()
            {
                ["User"] = result2.ElementAt(0)
            }
        );
        var actual = result3.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_GetByUserId_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["AdminUrl"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["CertificatePassword"] = context.AppSettings["CertificatePassword"].ToSecureString()
            }
        );
        var result1 = context.Runspace.InvokeCommand<string>(
            "Get-KshTenantPersonalSite",
            new Dictionary<string, object>()
            {
                ["UserId"] = context.AppSettings["User1Email"]
            }
        );
        var actual = result1.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}
