//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests.Commands;

public class AddColumnLookupCommandTests
{

    [Test()]
    public void AddListColumnLookup()
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
        var result3 = context.Runspace.InvokeCommand<ColumnLookup>(
            "Add-KshColumnLookup",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "AllowMultipleValues", false },
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                { "CustomFormatter", /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }" },
                { "Description", "Test Column 0 Description" },
                { "Direction", "none" },
                { "EnforceUniqueValues", true },
                { "Group", "Test Column 0 Group" },
                { "Hidden", true },
                { "Id", "35aa78a6-66d7-472c-ab6b-d534193842af" },
                { "Indexed", true },
                { "JSLink", "clienttemplates.js" },
                { "LookupListId", context.AppSettings["List1Id"] },
                { "LookupColumnName", context.AppSettings["Column1Name"] },
                { "Name", "TestColumn0" },
                { "NoCrawl", true },
                { "ReadOnly", true },
                { "RelationshipDeleteBehavior", "None" },
                { "Required", true },
                { "Title", "Test Column 0" },
                { "UnlimitedLengthInDocumentLibrary", true },
                { "AddColumnInternalNameHint", true },
                { "AddToDefaultView", true }
            }
        );
        var result4 = context.Runspace.InvokeCommand(
            "Set-KshColumnLookup",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) },
                { "Hidden", false },
                { "ReadOnly", false }
            }
        );
        var result5 = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void AddListColumnLookupMulti()
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
        var result3 = context.Runspace.InvokeCommand<ColumnLookup>(
            "Add-KshColumnLookup",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "AllowMultipleValues", true },
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                { "CustomFormatter", /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }" },
                { "Description", "Test Column 0 Description" },
                { "Direction", "none" },
                { "EnforceUniqueValues", false },
                { "Group", "Test Column 0 Group" },
                { "Hidden", true },
                { "Id", "35aa78a6-66d7-472c-ab6b-d534193842af" },
                { "Indexed", false },
                { "JSLink", "clienttemplates.js" },
                { "LookupListId", context.AppSettings["List1Id"] },
                { "LookupColumnName", context.AppSettings["Column1Name"] },
                { "Name", "TestColumn0" },
                { "NoCrawl", true },
                { "ReadOnly", true },
                { "RelationshipDeleteBehavior", "None" },
                { "Required", true },
                { "Title", "Test Column 0" },
                { "UnlimitedLengthInDocumentLibrary", true },
                { "AddColumnInternalNameHint", true },
                { "AddToDefaultView", true }
            }
        );
        var result4 = context.Runspace.InvokeCommand(
            "Set-KshColumnLookup",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) },
                { "Hidden", false },
                { "ReadOnly", false }
            }
        );
        var result5 = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void AddSiteColumnLookup()
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
        var result2 = context.Runspace.InvokeCommand<ColumnLookup>(
            "Add-KshColumnLookup",
            new Dictionary<string, object>()
            {
                { "AllowMultipleValues", false },
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                { "CustomFormatter", /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }" },
                { "Description", "Test Column 0 Description" },
                { "Direction", "none" },
                { "EnforceUniqueValues", true },
                { "Group", "Test Column 0 Group" },
                { "Hidden", true },
                { "Id", "35aa78a6-66d7-472c-ab6b-d534193842af" },
                { "Indexed", true },
                // { "JSLink", "clienttemplates.js" },
                { "LookupListId", context.AppSettings["List1Id"] },
                { "LookupColumnName", context.AppSettings["Column1Name"] },
                { "Name", "TestColumn0" },
                { "NoCrawl", true },
                { "ReadOnly", true },
                { "RelationshipDeleteBehavior", "None" },
                { "Required", true },
                { "StaticName", "TestColumn0" },
                { "Title", "Test Column 0" },
                { "UnlimitedLengthInDocumentLibrary", true },
                { "AddColumnInternalNameHint", true },
                { "AddToDefaultView", true }
            }
        );
        var result3 = context.Runspace.InvokeCommand(
            "Set-KshColumnLookup",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) },
                { "Hidden", false },
                { "ReadOnly", false }
            }
        );
        var result4 = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) }
            }
        );
        var actual = result2.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void AddSiteColumnLookupMulti()
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
        var result2 = context.Runspace.InvokeCommand<ColumnLookup>(
            "Add-KshColumnLookup",
            new Dictionary<string, object>()
            {
                { "AllowMultipleValues", true },
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                { "CustomFormatter", /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }" },
                { "Description", "Test Column 0 Description" },
                { "Direction", "none" },
                { "EnforceUniqueValues", false },
                { "Group", "Test Column 0 Group" },
                { "Hidden", true },
                { "Id", "35aa78a6-66d7-472c-ab6b-d534193842af" },
                { "Indexed", false },
                // { "JSLink", "clienttemplates.js" },
                { "LookupListId", context.AppSettings["List1Id"] },
                { "LookupColumnName", context.AppSettings["Column1Name"] },
                { "Name", "TestColumn0" },
                { "NoCrawl", true },
                { "ReadOnly", true },
                { "RelationshipDeleteBehavior", "None" },
                { "Required", true },
                { "StaticName", "TestColumn0" },
                { "Title", "Test Column 0" },
                { "UnlimitedLengthInDocumentLibrary", true },
                { "AddColumnInternalNameHint", true },
                { "AddToDefaultView", true }
            }
        );
        var result3 = context.Runspace.InvokeCommand(
            "Set-KshColumnLookup",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) },
                { "Hidden", false },
                { "ReadOnly", false }
            }
        );
        var result4 = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) }
            }
        );
        var actual = result2.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}