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
public class SetAppPublishedCommandTests
{

    [Test()]
    public void InvokeCommand_PublishItemOfTenant_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["TenantAppCatalogUrl"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKeyPath"] = context.AppSettings["PrivateKeyPath"]
            }
        );
        var result1 = context.Runspace.InvokeCommand<App>(
            "Add-KshApp",
            new Dictionary<string, object>()
            {
                ["Content"] = System.IO.File.OpenRead(context.AppSettings["App0Path"]),
                ["FileName"] = "TestApp0.sppkg",
                ["Overwrite"] = false,
                ["Tenant"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshAppPublished",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["Published"] = true,
                ["Tenant"] = true
            }
        );
        var result2 = context.Runspace.InvokeCommand<App>(
            "Get-KshApp",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["Tenant"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshAppPublished",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["Published"] = false,
                ["Tenant"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshApp",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0],
                ["Tenant"] = true
            }
        );
        var actual = result2[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_PublishItemOfSiteCollection_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<App>(
            "Add-KshApp",
            new Dictionary<string, object>()
            {
                ["Content"] = System.IO.File.OpenRead(context.AppSettings["App0Path"]),
                ["FileName"] = "TestApp0.sppkg",
                ["Overwrite"] = false,
                ["Tenant"] = false
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshAppPublished",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["Published"] = true,
                ["Tenant"] = false
            }
        );
        var result2 = context.Runspace.InvokeCommand<App>(
            "Get-KshApp",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["Tenant"] = false
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshAppPublished",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["Published"] = false,
                ["Tenant"] = false
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshApp",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0],
                ["Tenant"] = false
            }
        );
        var actual = result2[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_UnpublishItemOfTenant_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["TenantAppCatalogUrl"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKeyPath"] = context.AppSettings["PrivateKeyPath"]
            }
        );
        var result1 = context.Runspace.InvokeCommand<App>(
            "Add-KshApp",
            new Dictionary<string, object>()
            {
                ["Content"] = System.IO.File.OpenRead(context.AppSettings["App0Path"]),
                ["FileName"] = "TestApp0.sppkg",
                ["Overwrite"] = false,
                ["Tenant"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshAppPublished",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["Published"] = true,
                ["Tenant"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshAppPublished",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["Published"] = false,
                ["Tenant"] = true
            }
        );
        var result2 = context.Runspace.InvokeCommand<App>(
            "Get-KshApp",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["Tenant"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshApp",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0],
                ["Tenant"] = true
            }
        );
        var actual = result2[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_UnpublishItemOfSiteCollection_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<App>(
            "Add-KshApp",
            new Dictionary<string, object>()
            {
                ["Content"] = System.IO.File.OpenRead(context.AppSettings["App0Path"]),
                ["FileName"] = "TestApp0.sppkg",
                ["Overwrite"] = false,
                ["Tenant"] = false
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshAppPublished",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["Published"] = true,
                ["Tenant"] = false
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshAppPublished",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["Published"] = false,
                ["Tenant"] = false
            }
        );
        var result2 = context.Runspace.InvokeCommand<App>(
            "Get-KshApp",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["Tenant"] = false
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshApp",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0],
                ["Tenant"] = false
            }
        );
        var actual = result2[0];
        Assert.That(actual, Is.Not.Null);
    }

}
