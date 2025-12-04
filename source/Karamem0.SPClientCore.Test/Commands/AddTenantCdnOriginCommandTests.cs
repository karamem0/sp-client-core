//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Test.Utility;
using NUnit.Framework;

namespace Karamem0.SharePoint.PowerShell.Commands.Test;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class AddTenantCdnOriginCommandTests
{

    [Test()]
    public void InvokeCommand_AddPublic_ShouldSucceed()
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
        _ = context.Runspace.InvokeCommand(
            "Add-KshTenantCdnOrigin",
            new Dictionary<string, object>()
            {
                ["Public"] = true,
                ["Origin"] = "*/TESTLIST1"
            }
        );
        var result1 = context.Runspace.InvokeCommand<string>(
            "Get-KshTenantCdnOrigin",
            new Dictionary<string, object>()
            {
                ["Public"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshTenantCdnOrigin",
            new Dictionary<string, object>()
            {
                ["Public"] = true,
                ["Origin"] = "*/TESTLIST1"
            }
        );
        var actual = result1.ToArray();
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_AddPrivate_ShouldSucceed()
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
        _ = context.Runspace.InvokeCommand(
            "Add-KshTenantCdnOrigin",
            new Dictionary<string, object>()
            {
                ["Private"] = true,
                ["Origin"] = "*/TESTLIST1"
            }
        );
        var result1 = context.Runspace.InvokeCommand<string>(
            "Get-KshTenantCdnOrigin",
            new Dictionary<string, object>()
            {
                ["Private"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshTenantCdnOrigin",
            new Dictionary<string, object>()
            {
                ["Private"] = true,
                ["Origin"] = "*/TESTLIST1"
            }
        );
        var actual = result1.ToArray();
        Assert.That(actual, Is.Not.Null);
    }

}
