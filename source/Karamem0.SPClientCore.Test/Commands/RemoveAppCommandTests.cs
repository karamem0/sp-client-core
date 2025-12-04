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
public class RemoveAppCommandTests
{

    [Test()]
    public void InvokeCommand_RemoveItemFromTenant_ShouldSucceed()
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
            "Remove-KshApp",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["Tenant"] = true
            }
        );
    }

    [Test()]
    public void InvokeCommand_RemoveItemFromSiteCollection_ShouldSucceed()
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
            "Remove-KshApp",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["Tenant"] = false
            }
        );
    }

}
