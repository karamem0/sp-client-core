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
public class AddViewColumnCommandTests
{

    [Test()]
    public void InvokeCommand_AddItemByColumn_ShouldSucceed()
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
            "Get-KshList",
            new Dictionary<string, object>()
            {
                ["ListId"] = context.AppSettings["List1Id"],
            }
        );
        var result2 = context.Runspace.InvokeCommand<View>(
            "Get-KshView",
            new Dictionary<string, object>()
            {
                ["List"] = result1[0],
                ["ViewId"] = context.AppSettings["View1Id"]
            }
        );
        var result3 = context.Runspace.InvokeCommand<ColumnText>(
            "Add-KshColumnText",
            new Dictionary<string, object>()
            {
                ["List"] = result1[0],
                ["Name"] = "TestColumn0",
                ["Title"] = "Test Column 0",
                ["AddColumnInternalNameHint"] = true,
                ["AddToDefaultView"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Add-KshViewColumn",
            new Dictionary<string, object>()
            {
                ["View"] = result2[0],
                ["Column"] = result3[0]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshViewColumn",
            new Dictionary<string, object>()
            {
                ["View"] = result2[0],
                ["Column"] = result3[0]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3[0]
            }
        );
    }

    [Test()]
    public void InvokeCommand_AddItemByColumnName_ShouldSucceed()
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
            "Get-KshList",
            new Dictionary<string, object>()
            {
                ["ListId"] = context.AppSettings["List1Id"],
            }
        );
        var result2 = context.Runspace.InvokeCommand<View>(
            "Get-KshView",
            new Dictionary<string, object>()
            {
                ["List"] = result1[0],
                ["ViewId"] = context.AppSettings["View1Id"]
            }
        );
        var result3 = context.Runspace.InvokeCommand<ColumnText>(
            "Add-KshColumnText",
            new Dictionary<string, object>()
            {
                ["List"] = result1[0],
                ["Name"] = "TestColumn0",
                ["Title"] = "Test Column 0",
                ["AddColumnInternalNameHint"] = true,
                ["AddToDefaultView"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Add-KshViewColumn",
            new Dictionary<string, object>()
            {
                ["View"] = result2[0],
                ["ColumnName"] = result3[0].Name
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshViewColumn",
            new Dictionary<string, object>()
            {
                ["View"] = result2[0],
                ["Column"] = result3[0]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3[0]
            }
        );
    }

}
