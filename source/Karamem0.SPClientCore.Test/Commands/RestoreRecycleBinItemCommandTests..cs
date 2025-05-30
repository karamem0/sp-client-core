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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands.Test;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class RestoreRecycleBinItemCommandTests
{

    [Test()]
    public void InvokeCommand_RestoreOne_ShouldSucceed()
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
            "Restore-KshRecycleBinItem",
            new Dictionary<string, object>()
            {
                ["Identity"] = result4[0]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshListItem",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0]
            }
        );
    }

    [Test()]
    public void InvokeCommand_RestoreAll_ShouldSucceed()
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
        _ = context.Runspace.InvokeCommand<Guid>(
            "Remove-KshListItem",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0],
                ["RecycleBin"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Restore-KshRecycleBinItem",
            new Dictionary<string, object>()
            {
                ["All"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshListItem",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0]
            }
        );
    }

}
