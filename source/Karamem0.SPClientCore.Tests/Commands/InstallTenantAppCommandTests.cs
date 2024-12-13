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
using System.Threading;

namespace Karamem0.SharePoint.PowerShell.Commands.Tests;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class InstallTenantAppCommandTests
{

    [Test()]
    public void InstallTenantApp()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["TenantAppCatalogUrl"] },
                { "ClientId", context.AppSettings["ClientId"] },
                { "CertificatePath", context.AppSettings["CertificatePath"] },
                { "CertificatePassword", context.AppSettings["CertificatePassword"].ToSecureString() }
            }
        );
        var result1 = context.Runspace.InvokeCommand<App>(
            "Add-KshTenantApp",
            new Dictionary<string, object>()
            {
                { "Content", System.IO.File.OpenRead(context.AppSettings["App0Path"]) },
                { "FileName", "TestApp0.sppkg" },
                { "Overwrite", true }
            }
        );
        var result2 = context.Runspace.InvokeCommand<File>(
            "Get-KshFile",
            new Dictionary<string, object>()
            {
                { "App", result1.ElementAt(0) }
            }
        );
        var result3 = context.Runspace.InvokeCommand<ListItem>(
            "Get-KshListItem",
            new Dictionary<string, object>()
            {
                { "File", result2.ElementAt(0) }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"] },
                { "ClientId", context.AppSettings["ClientId"] },
                { "CertificatePath", context.AppSettings["CertificatePath"] },
                { "CertificatePassword", context.AppSettings["CertificatePassword"].ToSecureString() }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Install-KshTenantApp",
            new Dictionary<string, object>()
            {
                { "Identity", result1.ElementAt(0) }
            }
        );
        while (true)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            var result4 = context.Runspace.InvokeCommand<AppInstance>(
                "Get-KshAppInstance",
                new Dictionary<string, object>()
                {
                    { "AppProductId", result3.ElementAt(0)["AppProductID"] }
                }
            );
            if (result4.ElementAt(0).Status == AppStatus.Installed)
            {
                break;
            }
        }

        _ = context.Runspace.InvokeCommand(
            "Uninstall-KshTenantApp",
            new Dictionary<string, object>()
            {
                { "Identity", result1.ElementAt(0) }
            }
        );
        while (true)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            var result5 = context.Runspace.InvokeCommand<AppInstance>(
                "Get-KshAppInstance",
                new Dictionary<string, object>()
                {
                    { "AppProductId", result3.ElementAt(0)["AppProductID"] }
                }
            );
            if (result5.Any())
            {
            }
            else
            {
                break;
            }
        }

        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["TenantAppCatalogUrl"] },
                { "ClientId", context.AppSettings["ClientId"] },
                { "CertificatePath", context.AppSettings["CertificatePath"] },
                { "CertificatePassword", context.AppSettings["CertificatePassword"].ToSecureString() }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshTenantApp",
            new Dictionary<string, object>()
            {
                { "Identity", result1.ElementAt(0) }
            }
        );
    }

}
