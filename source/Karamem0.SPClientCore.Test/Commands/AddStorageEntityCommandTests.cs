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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands.Test;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class AddStorageEntityTests
{

    [Test()]
    public void InvokeCommand_AddItem_ShouldSucceed()
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
        _ = context.Runspace.InvokeCommand(
            "Add-KshStorageEntity",
            new Dictionary<string, object>()
            {
                ["Key"] = "Test Entity 0",
                ["Value"] = "Test Value 0",
                ["Description"] = "Test Value 0 Description",
                ["Comment"] = "Test Value 0 Comment"
            }
        );
        var result1 = context.Runspace.InvokeCommand<StorageEntity>(
            "Get-KshStorageEntity",
            new Dictionary<string, object>()
            {
                ["Key"] = "Test Entity 0"
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshStorageEntity",
            new Dictionary<string, object>()
            {
                ["Key"] = "Test Entity 0"
            }
        );
        var actual = result1[0];
        Assert.That(actual, Is.Not.Null);
    }

}
