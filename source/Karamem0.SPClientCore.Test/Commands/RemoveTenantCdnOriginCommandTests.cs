//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Test.Utility;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands.Test;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class RemoveTenantCdnOriginCommandTests
{

    [Test()]
    public void InvokeCommand_RemovePublic_ShouldSucceed()
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
        _ = context.Runspace.InvokeCommand(
            "Remove-KshTenantCdnOrigin",
            new Dictionary<string, object>()
            {
                ["Public"] = true,
                ["Origin"] = "*/TESTLIST1"
            }
        );
        var result3 = context.Runspace.InvokeCommand<string>(
            "Get-KshTenantCdnOrigin",
            new Dictionary<string, object>()
            {
                ["Private"] = true
            }
        );
        var actual = result3.ToArray();
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_RemovePrivate_ShouldSucceed()
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
        _ = context.Runspace.InvokeCommand(
            "Remove-KshTenantCdnOrigin",
            new Dictionary<string, object>()
            {
                ["Private"] = true,
                ["Origin"] = "*/TESTLIST1"
            }
        );
        var result3 = context.Runspace.InvokeCommand<string>(
            "Get-KshTenantCdnOrigin",
            new Dictionary<string, object>()
            {
                ["Private"] = true
            }
        );
        var actual = result3.ToArray();
        Assert.That(actual, Is.Not.Null);
    }

}
