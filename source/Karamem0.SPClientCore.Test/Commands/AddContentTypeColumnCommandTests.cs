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
public class AddContentTypeColumnCommandTests
{

    [Test()]
    public void InvokeCommand_AddItemToList_ShouldSucceed()
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
            "Get-KshContentType",
            new Dictionary<string, object>()
            {
                ["List"] = result1[0],
                ["ContentTypeId"] = context.AppSettings["ListContentType1Id"]
            }
        );
        var result3 = context.Runspace.InvokeCommand<ColumnText>(
            "Add-KshColumnText",
            new Dictionary<string, object>()
            {
                ["Name"] = "TestColumn0",
                ["Title"] = "Test Column 0"
            }
        );
        var result4 = context.Runspace.InvokeCommand<ContentTypeColumn>(
            "Add-KshContentTypeColumn",
            new Dictionary<string, object>()
            {
                ["ContentType"] = result2[0],
                ["Column"] = result3[0]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshContentTypeColumn",
            new Dictionary<string, object>()
            {
                ["Identity"] = result4[0]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3[0]
            }
        );
        var result7 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                ["List"] = result1[0],
                ["ColumnId"] = result3[0].Id
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                ["Identity"] = result7[0]
            }
        );
        var actual = result4[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_AddItemToSite_ShouldSucceed()
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
            "Get-KshContentType",
            new Dictionary<string, object>()
            {
                ["ContentTypeId"] = context.AppSettings["SiteContentType1Id"]
            }
        );
        var result3 = context.Runspace.InvokeCommand<ColumnText>(
            "Add-KshColumnText",
            new Dictionary<string, object>()
            {
                ["Name"] = "TestColumn0",
                ["Title"] = "Test Column 0"
            }
        );
        var result4 = context.Runspace.InvokeCommand<ContentTypeColumn>(
            "Add-KshContentTypeColumn",
            new Dictionary<string, object>()
            {
                ["ContentType"] = result2[0],
                ["Column"] = result3[0],
                ["PushChanges"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshContentTypeColumn",
            new Dictionary<string, object>()
            {
                ["Identity"] = result4[0],
                ["PushChanges"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3[0]
            }
        );
        var result7 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                ["List"] = result1[0],
                ["ColumnId"] = result3[0].Id
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                ["Identity"] = result7[0]
            }
        );
        var actual = result2[0];
        Assert.That(actual, Is.Not.Null);
    }

}
