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
using System.Collections;

namespace Karamem0.SharePoint.PowerShell.Commands.Test;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class MoveRecycleBinItemCommandTests
{

    [Test()]
    public void InvokeCommand_MoveOne_ShouldSucceed()
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
                ["ListId"] = context.AppSettings["List1Id"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<ListItem>(
            "Add-KshListItem",
            new Dictionary<string, object>()
            {
                ["List"] = result1[0],
                ["Value"] = new Hashtable()
            }
        );
        var result3 = context.Runspace.InvokeCommand<Guid>(
            "Remove-KshListItem",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0],
                ["RecycleBin"] = true
            }
        );
        var result4 = context.Runspace.InvokeCommand<RecycleBinItem>(
            "Get-KshRecycleBinItem",
            new Dictionary<string, object>()
            {
                ["ItemId"] = result3[0]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Move-KshRecycleBinItem",
            new Dictionary<string, object>()
            {
                ["Identity"] = result4[0]
            }
        );
        var result5 = context.Runspace.InvokeCommand<RecycleBinItem>(
            "Get-KshRecycleBinItem",
            new Dictionary<string, object>()
            {
                ["ItemId"] = result3[0],
                ["SecondStage"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshRecycleBinItem",
            new Dictionary<string, object>()
            {
                ["Identity"] = result5[0]
            }
        );
    }

    [Test()]
    public void InvokeCommand_MoveAll_ShouldSucceed()
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
                ["ListId"] = context.AppSettings["List1Id"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<ListItem>(
            "Add-KshListItem",
            new Dictionary<string, object>()
            {
                ["List"] = result1[0],
                ["Value"] = new Hashtable()
            }
        );
        var result3 = context.Runspace.InvokeCommand<Guid>(
            "Remove-KshListItem",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0],
                ["RecycleBin"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Move-KshRecycleBinItem",
            new Dictionary<string, object>()
            {
                ["All"] = true
            }
        );
        var result4 = context.Runspace.InvokeCommand<RecycleBinItem>(
            "Get-KshRecycleBinItem",
            new Dictionary<string, object>()
            {
                ["ItemId"] = result3[0],
                ["SecondStage"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshRecycleBinItem",
            new Dictionary<string, object>()
            {
                ["Identity"] = result4[0]
            }
        );
    }

}
