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
public class SetContentTypeColumnOrder
{

    [Test()]
    public void InvokeCommand_SetItemToList_ShouldSucceed()
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
        var result2 = context.Runspace.InvokeCommand<ContentType>(
            "Add-KshContentType",
            new Dictionary<string, object>()
            {
                ["List"] = result1[0],
                ["Description"] = "Test Content Type 0 Description",
                ["Group"] = "Test Content Type 0 Group",
                ["Name"] = "Test Content Type 0"
            }
        );
        var result3 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                ["ColumnId"] = context.AppSettings["Column1Id"]
            }
        );
        _ = context.Runspace.InvokeCommand<ContentTypeColumn>(
            "Add-KshContentTypeColumn",
            new Dictionary<string, object>()
            {
                ["ContentType"] = result2[0],
                ["Column"] = result3[0]
            }
        );
        var result4 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                ["ColumnId"] = context.AppSettings["Column2Id"]
            }
        );
        _ = context.Runspace.InvokeCommand<ContentTypeColumn>(
            "Add-KshContentTypeColumn",
            new Dictionary<string, object>()
            {
                ["ContentType"] = result2[0],
                ["Column"] = result4[0]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshContentTypeColumnOrder",
            new Dictionary<string, object>()
            {
                ["ContentType"] = result2[0],
                ["ContentTypeColumns"] = new List<string>()
                {
                    "TestColumn2",
                    "TestColumn1"
                }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshContentType",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0]
            }
        );
    }

    [Test()]
    public void InvokeCommand_SetItemToSite_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<ContentType>(
            "Add-KshContentType",
            new Dictionary<string, object>()
            {
                ["Description"] = "Test Content Type 0 Description",
                ["Group"] = "Test Content Type 0 Group",
                ["Name"] = "Test Content Type 0"
            }
        );
        var result2 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                ["ColumnId"] = context.AppSettings["Column1Id"]
            }
        );
        _ = context.Runspace.InvokeCommand<ContentTypeColumn>(
            "Add-KshContentTypeColumn",
            new Dictionary<string, object>()
            {
                ["ContentType"] = result1[0],
                ["Column"] = result2[0]
            }
        );
        var result3 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                ["ColumnId"] = context.AppSettings["Column2Id"]
            }
        );
        _ = context.Runspace.InvokeCommand<ContentTypeColumn>(
            "Add-KshContentTypeColumn",
            new Dictionary<string, object>()
            {
                ["ContentType"] = result1[0],
                ["Column"] = result3[0]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshContentTypeColumnOrder",
            new Dictionary<string, object>()
            {
                ["ContentType"] = result1[0],
                ["ContentTypeColumns"] = new List<string>()
                {
                    "TestColumn2",
                    "TestColumn1"
                }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshContentType",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0]
            }
        );
    }

}
