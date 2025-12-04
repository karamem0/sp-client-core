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
public class GetSiteCollectionCommandTests
{

    [Test()]
    public void InvokeCommand_GetByIdentity_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<SiteCollection>(
            "Get-KshSiteCollection",
            new Dictionary<string, object>()
            {
                ["SiteCollectionUrl"] = context.AppSettings["BaseUrl"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<SiteCollection>(
            "Get-KshSiteCollection",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0]
            }
        );
        var actual = result2[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_GetBySiteCollectionUrl_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<SiteCollection>(
            "Get-KshSiteCollection",
            new Dictionary<string, object>()
            {
                ["SiteCollectionUrl"] = context.AppSettings["BaseUrl"]
            }
        );
        var actual = result1[0];
        Assert.That(actual, Is.Not.Null);
    }

}
