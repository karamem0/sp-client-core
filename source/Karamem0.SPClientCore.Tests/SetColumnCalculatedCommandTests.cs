//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Tests.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests;

[TestClass()]
public class SetColumnCalculatedCommandTests
{

    [TestMethod()]
    public void SetListColumnCalculatedOfBoolean()
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
        var result3 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "ColumnId", context.AppSettings["Column1Id"] }
            }
        );
        var result4 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "ColumnId", context.AppSettings["Column10Id"] }
            }
        );
        var result5 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Add-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "Columns", new[] { result3.ElementAt(0) } },
                { "Formula", "=[Test Column 1]" },
                { "Name", "TestColumn0" },
                { "OutputType", "Boolean" },
                { "Title", "Test Column 0" },
                { "AddColumnInternalNameHint", true },
                { "AddToDefaultView", true }
            }
        );
        var result6 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                { "Identity", result5.ElementAt(0) },
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                { "Columns", new[] { result4.ElementAt(0) } },
                { "CustomFormatter", /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }" },
                { "Direction", "none" },
                { "Description", "Test Column 0 Description" },
                { "Formula", "=[Test Column 10]" },
                { "Group", "Test Group 0" },
                { "Hidden", true },
                { "JSLink", "clienttemplates.js" },
                { "NoCrawl", true },
                { "OutputType", "Boolean" },
                { "StaticName", "TestColumn0" },
                { "Title", "Test Column 0" },
                { "PassThru", true }
            }
        );
        var result7 = context.Runspace.InvokeCommand(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                { "Identity", result6.ElementAt(0) },
                { "Hidden", false }
            }
        );
        var result8 = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                { "Identity", result6.ElementAt(0) }
            }
        );
        var actual = result6.ElementAt(0);
        Assert.IsNotNull(actual);
    }

    [TestMethod()]
    public void SetListColumnCalculatedOfCurrency()
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
        var result3 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "ColumnId", context.AppSettings["Column1Id"] }
            }
        );
        var result4 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "ColumnId", context.AppSettings["Column6Id"] }
            }
        );
        var result5 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Add-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "Columns", new[] { result3.ElementAt(0) } },
                { "Formula", "=[Test Column 6]" },
                { "Name", "TestColumn0" },
                { "OutputType", "Currency" },
                { "Title", "Test Column 0" },
                { "AddColumnInternalNameHint", true },
                { "AddToDefaultView", true }
            }
        );
        var result6 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                { "Identity", result5.ElementAt(0) },
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                { "Columns", new[] { result4.ElementAt(0) } },
                { "CurrencyLcid", 1041 },
                { "CustomFormatter", /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }" },
                { "Direction", "none" },
                { "Description", "Test Column 0 Description" },
                { "Formula", "=[Test Column 6]" },
                { "Group", "Test Group 0" },
                { "Hidden", true },
                { "JSLink", "clienttemplates.js" },
                { "NoCrawl", true },
                { "NumberFormat", 2 },
                { "OutputType", "Currency" },
                { "StaticName", "TestColumn0" },
                { "Title", "Test Column 0" },
                { "PassThru", true }
            }
        );
        var result7 = context.Runspace.InvokeCommand(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                { "Identity", result6.ElementAt(0) },
                { "Hidden", false }
            }
        );
        var result8 = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                { "Identity", result6.ElementAt(0) }
            }
        );
        var actual = result6.ElementAt(0);
        Assert.IsNotNull(actual);
    }

    [TestMethod()]
    public void SetListColumnCalculatedOfDateTime()
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
        var result3 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "ColumnId", context.AppSettings["Column1Id"] }
            }
        );
        var result4 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "ColumnId", context.AppSettings["Column7Id"] }
            }
        );
        var result5 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Add-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "Columns", new[] { result3.ElementAt(0) } },
                { "Formula", "=[Test Column 7]" },
                { "Name", "TestColumn0" },
                { "OutputType", "DateTime" },
                { "Title", "Test Column 0" },
                { "AddColumnInternalNameHint", true },
                { "AddToDefaultView", true }
            }
        );
        var result6 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                { "Identity", result5.ElementAt(0) },
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                { "Columns", new[] { result4.ElementAt(0) } },
                { "CustomFormatter", /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }" },
                { "DateFormat", "DateTime" },
                { "Direction", "none" },
                { "Description", "Test Column 0 Description" },
                { "Formula", "=[Test Column 7]" },
                { "Group", "Test Group 0" },
                { "Hidden", true },
                { "JSLink", "clienttemplates.js" },
                { "NoCrawl", true },
                { "OutputType", "DateTime" },
                { "StaticName", "TestColumn0" },
                { "Title", "Test Column 0" },
                { "PassThru", true }
            }
        );
        var result7 = context.Runspace.InvokeCommand(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                { "Identity", result6.ElementAt(0) },
                { "Hidden", false }
            }
        );
        var result8 = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                { "Identity", result6.ElementAt(0) },
            }
        );
        var actual = result6.ElementAt(0);
        Assert.IsNotNull(actual);
    }

    [TestMethod()]
    public void SetListColumnCalculatedOfNumber()
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
        var result3 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "ColumnId", context.AppSettings["Column1Id"] }
            }
        );
        var result4 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "ColumnId", context.AppSettings["Column5Id"] }
            }
        );
        var result5 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Add-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "Columns", new[] { result3.ElementAt(0) } },
                { "Formula", "=[Test Column 5]" },
                { "Name", "TestColumn0" },
                { "OutputType", "Number" },
                { "Title", "Test Column 0" },
                { "AddColumnInternalNameHint", true },
                { "AddToDefaultView", true }
            }
        );
        var result6 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                { "Identity", result5.ElementAt(0) },
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                { "Columns", new[] { result4.ElementAt(0) } },
                { "CustomFormatter", /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }" },
                { "Direction", "none" },
                { "Description", "Test Column 0 Description" },
                { "Formula", "=[Test Column 5]" },
                { "Group", "Test Group 0" },
                { "Hidden", true },
                { "JSLink", "clienttemplates.js" },
                { "NoCrawl", true },
                { "NumberFormat", 2 },
                { "OutputType", "Number" },
                { "StaticName", "TestColumn0" },
                { "Title", "Test Column 0" },
                { "PassThru", true }
            }
        );
        var result7 = context.Runspace.InvokeCommand(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                { "Identity", result6.ElementAt(0) },
                { "Hidden", false }
            }
        );
        var result8 = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                { "Identity", result6.ElementAt(0) }
            }
        );
        var actual = result6.ElementAt(0);
        Assert.IsNotNull(actual);
    }

    [TestMethod()]
    public void SetListColumnCalculatedOfText()
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
        var result3 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "ColumnId", context.AppSettings["Column1Id"] }
            }
        );
        var result4 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "ColumnId", context.AppSettings["Column2Id"] }
            }
        );
        var result5 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Add-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "Columns", new[] { result3.ElementAt(0) } },
                { "Formula", "=[Test Column 1]" },
                { "Name", "TestColumn0" },
                { "OutputType", "Text" },
                { "Title", "Test Column 0" },
                { "AddColumnInternalNameHint", true },
                { "AddToDefaultView", true }
            }
        );
        var result6 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                { "Identity", result5.ElementAt(0) },
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                { "Columns", new[] { result4.ElementAt(0) } },
                { "CustomFormatter", /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }" },
                { "Direction", "none" },
                { "Description", "Test Column 0 Description" },
                { "Formula", "=[Test Column 1]" },
                { "Group", "Test Group 0" },
                { "Hidden", true },
                { "JSLink", "clienttemplates.js" },
                { "NoCrawl", true },
                { "OutputType", "Text" },
                { "StaticName", "TestColumn0" },
                { "Title", "Test Column 0" },
                { "PassThru", true }
            }
        );
        var result7 = context.Runspace.InvokeCommand(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                { "Identity", result6.ElementAt(0) },
                { "Hidden", false }
            }
        );
        var result8 = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                { "Identity", result6.ElementAt(0) }
            }
        );
        var actual = result6.ElementAt(0);
        Assert.IsNotNull(actual);
    }

    [TestMethod()]
    public void SetSiteColumnCalculatedOfBoolean()
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
        var result2 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                { "ColumnId", context.AppSettings["Column1Id"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                { "ColumnId", context.AppSettings["Column10Id"] }
            }
        );
        var result4 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Add-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                { "Columns", new[] { result2.ElementAt(0) } },
                { "Formula", "=TestColumn1" },
                { "Name", "TestColumn0" },
                { "OutputType", "Boolean" },
                { "Title", "Test Column 0" },
                { "AddColumnInternalNameHint", true },
                { "AddToDefaultView", true }
            }
        );
        var result5 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                { "Identity", result4.ElementAt(0) },
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                { "Columns", new[] { result3.ElementAt(0) } },
                { "CustomFormatter", /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }" },
                { "Direction", "none" },
                { "Description", "Test Column 0 Description" },
                { "Formula", "=TestColumn10" },
                { "Group", "Test Group 0" },
                { "Hidden", true },
                { "JSLink", "clienttemplates.js" },
                { "NoCrawl", true },
                { "OutputType", "Boolean" },
                { "StaticName", "TestColumn0" },
                { "Title", "Test Column 0" },
                { "PassThru", true }
            }
        );
        var result6 = context.Runspace.InvokeCommand(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                { "Identity", result5.ElementAt(0) },
                { "Hidden", false }
            }
        );
        var result7 = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                { "Identity", result5.ElementAt(0) }
            }
        );
        var actual = result5.ElementAt(0);
        Assert.IsNotNull(actual);
    }

    [TestMethod()]
    public void SetSiteColumnCalculatedOfCurrency()
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
        var result2 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                { "ColumnId", context.AppSettings["Column1Id"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                { "ColumnId", context.AppSettings["Column6Id"] }
            }
        );
        var result4 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Add-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                { "Columns", new[] { result2.ElementAt(0) } },
                { "Formula", "=TestColumn1" },
                { "Name", "TestColumn0" },
                { "OutputType", "Currency" },
                { "Title", "Test Column 0" },
                { "AddColumnInternalNameHint", true },
                { "AddToDefaultView", true }
            }
        );
        var result5 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                { "Identity", result4.ElementAt(0) },
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                { "Columns", new[] { result3.ElementAt(0) } },
                { "CurrencyLcid", 1041 },
                { "CustomFormatter", /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }" },
                { "Direction", "none" },
                { "Description", "Test Column 0 Description" },
                { "Formula", "=TestColumn6" },
                { "Group", "Test Group 0" },
                { "Hidden", true },
                { "JSLink", "clienttemplates.js" },
                { "NoCrawl", true },
                { "NumberFormat", 2 },
                { "OutputType", "Currency" },
                { "StaticName", "TestColumn0" },
                { "Title", "Test Column 0" },
                { "PassThru", true }
            }
        );
        var result6 = context.Runspace.InvokeCommand(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                { "Identity", result5.ElementAt(0) },
                { "Hidden", false }
            }
        );
        var result7 = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                { "Identity", result5.ElementAt(0) }
            }
        );
        var actual = result5.ElementAt(0);
        Assert.IsNotNull(actual);
    }

    [TestMethod()]
    public void SetSiteColumnCalculatedOfDateTime()
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
        var result2 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                { "ColumnId", context.AppSettings["Column1Id"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                { "ColumnId", context.AppSettings["Column7Id"] }
            }
        );
        var result4 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Add-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                { "Columns", new[] { result2.ElementAt(0) } },
                { "Formula", "=TestColumn1" },
                { "Name", "TestColumn0" },
                { "OutputType", "DateTime" },
                { "Title", "Test Column 0" },
                { "AddColumnInternalNameHint", true },
                { "AddToDefaultView", true }
            }
        );
        var result5 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                { "Identity", result4.ElementAt(0) },
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                { "Columns", new[] { result3.ElementAt(0) } },
                { "CustomFormatter", /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }" },
                { "DateFormat", "DateTime" },
                { "Direction", "none" },
                { "Description", "Test Column 0 Description" },
                { "Formula", "=TestColumn7" },
                { "Group", "Test Group 0" },
                { "Hidden", true },
                { "JSLink", "clienttemplates.js" },
                { "NoCrawl", true },
                { "OutputType", "DateTime" },
                { "StaticName", "TestColumn0" },
                { "Title", "Test Column 0" },
                { "PassThru", true }
            }
        );
        var result6 = context.Runspace.InvokeCommand(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                { "Identity", result5.ElementAt(0) },
                { "Hidden", false }
            }
        );
        var result7 = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                { "Identity", result5.ElementAt(0) }
            }
        );
        var actual = result5.ElementAt(0);
        Assert.IsNotNull(actual);
    }

    [TestMethod()]
    public void SetSiteColumnCalculatedOfNumber()
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
        var result2 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                { "ColumnId", context.AppSettings["Column1Id"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                { "ColumnId", context.AppSettings["Column5Id"] }
            }
        );
        var result4 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Add-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                { "Columns", new[] { result2.ElementAt(0) } },
                { "Formula", "=TestColumn1" },
                { "Name", "TestColumn0" },
                { "OutputType", "Number" },
                { "Title", "Test Column 0" },
                { "AddColumnInternalNameHint", true },
                { "AddToDefaultView", true }
            }
        );
        var result5 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                { "Identity", result4.ElementAt(0) },
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                { "Columns", new[] { result3.ElementAt(0) } },
                { "CustomFormatter", /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }" },
                { "Direction", "none" },
                { "Description", "Test Column 0 Description" },
                { "Formula", "=TestColumn5" },
                { "Group", "Test Group 0" },
                { "Hidden", true },
                { "JSLink", "clienttemplates.js" },
                { "NoCrawl", true },
                { "NumberFormat", 2 },
                { "OutputType", "Number" },
                { "ShowAsPercentage", true },
                { "StaticName", "TestColumn0" },
                { "Title", "Test Column 0" },
                { "PassThru", true }
            }
        );
        var result6 = context.Runspace.InvokeCommand(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                { "Identity", result5.ElementAt(0) },
                { "Hidden", false }
            }
        );
        var result7 = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                { "Identity", result5.ElementAt(0) }
            }
        );
        var actual = result5.ElementAt(0);
        Assert.IsNotNull(actual);
    }

    [TestMethod()]
    public void SetSiteColumnCalculatedOfText()
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
        var result2 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                { "ColumnId", context.AppSettings["Column1Id"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                { "ColumnId", context.AppSettings["Column2Id"] }
            }
        );
        var result4 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Add-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                { "Columns", new[] { result2.ElementAt(0) } },
                { "Formula", "=TestColumn1" },
                { "Name", "TestColumn0" },
                { "OutputType", "Boolean" },
                { "Title", "Test Column 0" },
                { "AddColumnInternalNameHint", true },
                { "AddToDefaultView", true }
            }
        );
        var result5 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                { "Identity", result4.ElementAt(0) },
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                { "Columns", new[] { result3.ElementAt(0) } },
                { "CustomFormatter", /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }" },
                { "Direction", "none" },
                { "Description", "Test Column 0 Description" },
                { "Group", "Test Group 0" },
                { "Formula", "=TestColumn2" },
                { "Hidden", true },
                { "JSLink", "clienttemplates.js" },
                { "NoCrawl", true },
                { "OutputType", "Boolean" },
                { "StaticName", "TestColumn0" },
                { "Title", "Test Column 0" },
                { "PassThru", true }
            }
        );
        var result6 = context.Runspace.InvokeCommand(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                { "Identity", result5.ElementAt(0) },
                { "Hidden", false }
            }
        );
        var result7 = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                { "Identity", result5.ElementAt(0) }
            }
        );
        var actual = result5.ElementAt(0);
        Assert.IsNotNull(actual);
    }

}
