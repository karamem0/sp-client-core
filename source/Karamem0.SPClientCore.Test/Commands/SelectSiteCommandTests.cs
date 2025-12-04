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
public class SelectSiteCommandTests
{

    [Test()]
    public void InvokeCommand_SelectItem_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["BaseUrl"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKeyPath"] = context.AppSettings["PrivateKeyPath"]
            }
        );
        var result1 = context.Runspace.InvokeCommand<Site>(
            "Get-KshSite",
            new Dictionary<string, object>()
            {
                ["SiteId"] = context.AppSettings["Site1Id"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<Site>(
            "Select-KshSite",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["PassThru"] = true
            }
        );
        var actual = result2[0];
        Assert.That(actual, Is.Not.Null);
    }

}
