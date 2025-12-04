//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Test.Utility;
using NUnit.Framework;

namespace Karamem0.SharePoint.PowerShell.Commands.Test;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class GetTenantExternalUserCommandTests
{

    [Test()]
    public void InvokeCommand_GetFromTetnant_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<ExternalUser>(
            "Get-KshTenantExternalUser",
            new Dictionary<string, object>()
            {
            }
        );
        var actual = result1.ToList();
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_GetFromSiteCollectionUrl_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<ExternalUser>(
            "Get-KshTenantExternalUser",
            new Dictionary<string, object>()
            {
                ["SiteCollectionUrl"] = context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"],
            }
        );
        var actual = result1.ToList();
        Assert.That(actual, Is.Not.Null);
    }

}
