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
public class RemoveListCommandTests
{

    [Test()]
    public void InvokeCommand_RemoveItem_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
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
        var result1 = context.Runspace.InvokeCommand<List>(
            "Add-KshList",
            new Dictionary<string, object>()
            {
                ["Template"] = "GenericList",
                ["Title"] = "Test List 0"
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshList",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0]
            }
        );
    }

    [Test()]
    public void InvokeCommand_MoveItemToRecycleBin_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
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
        var result1 = context.Runspace.InvokeCommand<List>(
            "Add-KshList",
            new Dictionary<string, object>()
            {
                ["Template"] = "GenericList",
                ["Title"] = "Test List 0"
            }
        );
        var result2 = context.Runspace.InvokeCommand<Guid>(
            "Remove-KshList",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["RecycleBin"] = true
            }
        );
        var result3 = context.Runspace.InvokeCommand<RecycleBinItem>(
            "Get-KshRecycleBinItem",
            new Dictionary<string, object>()
            {
                ["ItemId"] = result2[0]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshRecycleBinItem",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3[0]
            }
        );
        var actual = result2[0];
        Assert.That(actual, Is.Not.Default);
    }

}
