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
using System.Threading;

namespace Karamem0.SharePoint.PowerShell.Commands.Test;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class SetAppInstalledCommandTests
{

    [Test()]
    public void InvokeCommand_InstallItemOfTenant_ShouldSucceed()
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
                ["Overwrite"] = true,
                ["Tenant"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKeyPath"] = context.AppSettings["PrivateKeyPath"]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshAppInstalled",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["Installed"] = true,
                ["Tenant"] = true
            }
        );
        while (true)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            var result2 = context.Runspace.InvokeCommand<AppInstance>(
                "Get-KshAppInstance",
                new Dictionary<string, object>()
                {
                    ["AppProductId"] = result1[0].ProductId
                }
            );
            if (result2[0].Status == AppStatus.Installed)
            {
                break;
            }
        }
        _ = context.Runspace.InvokeCommand(
            "Set-KshAppInstalled",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["Installed"] = false,
                ["Tenant"] = true
            }
        );
        while (true)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            var result3 = context.Runspace.InvokeCommand<AppInstance>(
                "Get-KshAppInstance",
                new Dictionary<string, object>()
                {
                    ["AppProductId"] = result1[0].ProductId
                }
            );
            if (result3.Count == 0)
            {
                break;
            }
        }
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
        _ = context.Runspace.InvokeCommand(
            "Remove-KshApp",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["Tenant"] = true
            }
        );
    }

    [Test()]
    public void InvokeCommand_InstallItemOfSiteCollection_ShouldSucceed()
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
                ["Overwrite"] = true,
                ["Tenant"] = false
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKeyPath"] = context.AppSettings["PrivateKeyPath"]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshAppInstalled",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["Installed"] = true,
                ["Tenant"] = false
            }
        );
        while (true)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            var result2 = context.Runspace.InvokeCommand<AppInstance>(
                "Get-KshAppInstance",
                new Dictionary<string, object>()
                {
                    ["AppProductId"] = result1[0].ProductId
                }
            );
            if (result2[0].Status == AppStatus.Installed)
            {
                break;
            }
        }
        _ = context.Runspace.InvokeCommand(
            "Set-KshAppInstalled",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["Installed"] = false,
                ["Tenant"] = false
            }
        );
        while (true)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            var result3 = context.Runspace.InvokeCommand<AppInstance>(
                "Get-KshAppInstance",
                new Dictionary<string, object>()
                {
                    ["AppProductId"] = result1[0].ProductId
                }
            );
            if (result3.Count == 0)
            {
                break;
            }
        }
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
        _ = context.Runspace.InvokeCommand(
            "Remove-KshApp",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["Tenant"] = false
            }
        );
    }

    [Test()]
    public void InvokeCommand_UninstallItemOfTenant_ShouldSucceed()
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
                ["Overwrite"] = true,
                ["Tenant"] = true,
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKeyPath"] = context.AppSettings["PrivateKeyPath"]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshAppInstalled",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["Installed"] = true,
                ["Tenant"] = true,
            }
        );
        while (true)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            var result2 = context.Runspace.InvokeCommand<AppInstance>(
                "Get-KshAppInstance",
                new Dictionary<string, object>()
                {
                    ["AppProductId"] = result1[0].ProductId
                }
            );
            if (result2[0].Status == AppStatus.Installed)
            {
                break;
            }
        }
        _ = context.Runspace.InvokeCommand(
            "Set-KshAppInstalled",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["Installed"] = false,
                ["Tenant"] = true
            }
        );
        while (true)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            var result3 = context.Runspace.InvokeCommand<AppInstance>(
                "Get-KshAppInstance",
                new Dictionary<string, object>()
                {
                    ["AppProductId"] = result1[0].ProductId
                }
            );
            if (result3.Count == 0)
            {
                break;
            }
        }
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
        _ = context.Runspace.InvokeCommand(
            "Remove-KshApp",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["Tenant"] = true,
            }
        );
    }

    [Test()]
    public void InvokeCommand_UninstallItemOfSiteCollection_ShouldSucceed()
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
                ["Overwrite"] = true,
                ["Tenant"] = false,
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKeyPath"] = context.AppSettings["PrivateKeyPath"]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshAppInstalled",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["Installed"] = true,
                ["Tenant"] = false
            }
        );
        while (true)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            var result2 = context.Runspace.InvokeCommand<AppInstance>(
                "Get-KshAppInstance",
                new Dictionary<string, object>()
                {
                    ["AppProductId"] = result1[0].ProductId
                }
            );
            if (result2[0].Status == AppStatus.Installed)
            {
                break;
            }
        }
        _ = context.Runspace.InvokeCommand(
            "Set-KshAppInstalled",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["Installed"] = false,
                ["Tenant"] = false
            }
        );
        while (true)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            var result3 = context.Runspace.InvokeCommand<AppInstance>(
                "Get-KshAppInstance",
                new Dictionary<string, object>()
                {
                    ["AppProductId"] = result1[0].ProductId
                }
            );
            if (result3.Count == 0)
            {
                break;
            }
        }
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
        _ = context.Runspace.InvokeCommand(
            "Remove-KshApp",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["Tenant"] = false
            }
        );
    }

}
