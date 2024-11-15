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

namespace Karamem0.SharePoint.PowerShell.Commands.Tests;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class SetContentTypeColumnOrder
{

    [Test()]
    public void SetListContentTypeColumnOrder()
    {
        using var context = new PSCmdletContext();
        var result1 = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"] },
                { "Credential", PSCredentialFactory.CreateCredential(
                    context.AppSettings["LoginUserName"],
                    context.AppSettings["LoginPassword"])
                }
            }
        );
        var result2 = context.Runspace.InvokeCommand<List>(
            "Get-KshList",
            new Dictionary<string, object>()
            {
                { "ListId", context.AppSettings["List1Id"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<ContentType>(
            "Add-KshContentType",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "Description", "Test Content Type 0 Description" },
                { "Group", "Test Content Type 0 Group" },
                { "Name", "Test Content Type 0" }
            }
        );
        var result4 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                { "ColumnId", context.AppSettings["Column1Id"] }
            }
        );
        var result5 = context.Runspace.InvokeCommand<ContentTypeColumn>(
            "Add-KshContentTypeColumn",
            new Dictionary<string, object>()
            {
                { "ContentType", result3.ElementAt(0) },
                { "Column", result4.ElementAt(0) }
            }
        );
        var result6 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                { "ColumnId", context.AppSettings["Column2Id"] }
            }
        );
        var result7 = context.Runspace.InvokeCommand<ContentTypeColumn>(
            "Add-KshContentTypeColumn",
            new Dictionary<string, object>()
            {
                { "ContentType", result3.ElementAt(0) },
                { "Column", result6.ElementAt(0) }
            }
        );
        var result8 = context.Runspace.InvokeCommand(
            "Set-KshContentTypeColumnOrder",
            new Dictionary<string, object>()
            {
                { "ContentType", result3.ElementAt(0) },
                { "ContentTypeColumns", new List<string>() { "TestColumn2", "TestColumn1" } }
            }
        );
        var result9 = context.Runspace.InvokeCommand(
            "Remove-KshContentType",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) }
            }
        );
    }

    [Test()]
    public void SetSiteContentTypeColumnOrder()
    {
        using var context = new PSCmdletContext();
        var result1 = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"] },
                { "Credential", PSCredentialFactory.CreateCredential(
                    context.AppSettings["LoginUserName"],
                    context.AppSettings["LoginPassword"])
                }
            }
        );
        var result2 = context.Runspace.InvokeCommand<ContentType>(
            "Add-KshContentType",
            new Dictionary<string, object>()
            {
                { "Description", "Test Content Type 0 Description" },
                { "Group", "Test Content Type 0 Group" },
                { "Name", "Test Content Type 0" }
            }
        );
        var result3 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                { "ColumnId", context.AppSettings["Column1Id"] }
            }
        );
        var result4 = context.Runspace.InvokeCommand<ContentTypeColumn>(
            "Add-KshContentTypeColumn",
            new Dictionary<string, object>()
            {
                { "ContentType", result2.ElementAt(0) },
                { "Column", result3.ElementAt(0) }
            }
        );
        var result5 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                { "ColumnId", context.AppSettings["Column2Id"] }
            }
        );
        var result6 = context.Runspace.InvokeCommand<ContentTypeColumn>(
            "Add-KshContentTypeColumn",
            new Dictionary<string, object>()
            {
                { "ContentType", result2.ElementAt(0) },
                { "Column", result5.ElementAt(0) }
            }
        );
        var result7 = context.Runspace.InvokeCommand(
            "Set-KshContentTypeColumnOrder",
            new Dictionary<string, object>()
            {
                { "ContentType", result2.ElementAt(0) },
                { "ContentTypeColumns", new List<string>() { "TestColumn2", "TestColumn1" } }
            }
        );
        var result8 = context.Runspace.InvokeCommand(
            "Remove-KshContentType",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) }
            }
        );
    }

}
