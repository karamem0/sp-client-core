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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands.Tests;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class SetListItemCommandTests
{

    [Test()]
    public void SetListItemByHashtable()
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
        var result3 = context.Runspace.InvokeCommand<ListItem>(
            "Add-KshListItem",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "Value", new Hashtable() }
            }
        );
        var result4 = context.Runspace.InvokeCommand<ColumnLookupValue>(
            "New-KshColumnLookupValue",
            new Dictionary<string, object>()
            {
                { "LookupId", context.AppSettings["ListItem1Id"] },
            }
        );
        var result5 = context.Runspace.InvokeCommand<ColumnUserValue>(
            "New-KshColumnUserValue",
            new Dictionary<string, object>()
            {
                { "LookupId", context.AppSettings["User1Id"] },
            }
        );
        var result6 = context.Runspace.InvokeCommand<ColumnUrlValue>(
            "New-KshColumnUrlValue",
            new Dictionary<string, object>()
            {
                { "Url", "https://www.example.com" },
                { "Description", "Test Value 0" }
            }
        );
        var result7 = context.Runspace.InvokeCommand<ColumnGeolocationValue>(
            "New-KshColumnGeolocationValue",
            new Dictionary<string, object>()
            {
                { "Latitude", 10 },
                { "Longitude", 10 }
            }
        );
        var result8 = context.Runspace.InvokeCommand<TermGroup>(
            "Get-KshTermGroup",
            new Dictionary<string, object>()
            {
                { "TermGroupId", context.AppSettings["TermGroup1Id"] }
            }
        );
        var result9 = context.Runspace.InvokeCommand<TermSet>(
            "Get-KshTermSet",
            new Dictionary<string, object>()
            {
                { "TermGroup", result8.ElementAt(0) },
                { "TermSetId", context.AppSettings["TermSet1Id"] }
            }
        );
        var result10 = context.Runspace.InvokeCommand<Term>(
            "Get-KshTerm",
            new Dictionary<string, object>()
            {
                { "TermSet", result9.ElementAt(0) },
                { "TermId", context.AppSettings["Term1Id"] }
            }
        );
        var result11 = context.Runspace.InvokeCommand<ColumnTaxonomyValue>(
            "New-KshColumnTaxonomyValue",
            new Dictionary<string, object>()
            {
                { "Term", result10.ElementAt(0) }
            }
        );
        var result12 = context.Runspace.InvokeCommand<ImageItem>(
            "Save-KshImage",
            new Dictionary<string, object>()
            {
                { "ListItem", result3.ElementAt(0) },
                { "FileName", "TestFile0.png" },
                { "Content", new System.IO.MemoryStream(Convert.FromBase64String(
                    "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABAQMAAAAl21bKAAAAA1BMVEUAAACnej3aAAAAAXRSTlMA" +
                    "QObYZgAAAApJREFUCNdjYAAAAAIAAeIhvDMAAAAASUVORK5CYII="
                )) }
            }
        );
        var result13 = context.Runspace.InvokeCommand<ColumnImageValue>(
            "New-KshColumnImageValue",
            new Dictionary<string, object>()
            {
                { "ImageItem", result12.ElementAt(0) },
                { "ColumnName", "TestColumn17" }
            }
        );
        var result14 = context.Runspace.InvokeCommand<ListItem>(
            "Set-KshListItem",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) },
                { "Value", new Hashtable()
                    {
                        { "TestColumn1", "Test Value 0" },
                        { "TestColumn2", "Test Value 0" },
                        { "TestColumn3", "Test Value 0" },
                        { "TestColumn4", new List<string>() { "Test Value 0" } },
                        { "TestColumn5", 1 },
                        { "TestColumn6", 200 },
                        { "TestColumn7", new DateTime(2010, 10, 10, 0, 0, 0, DateTimeKind.Utc) },
                        { "TestColumn8", result4.ElementAt(0) },
                        { "TestColumn9", new[] { result4.ElementAt(0) } },
                        { "TestColumn10", true },
                        { "TestColumn11", result5.ElementAt(0) },
                        { "TestColumn12", new[] { result5.ElementAt(0) } },
                        { "TestColumn13", result6.ElementAt(0) },
                        { "TestColumn15", result7.ElementAt(0) },
                        { "TestColumn16", result11.ElementAt(0) },
                        { "TestColumn17", result13.ElementAt(0) }
                    }
                },
                { "PassThru", true }
            }
        );
        var result15 = context.Runspace.InvokeCommand(
            "Remove-KshListItem",
            new Dictionary<string, object>()
            {
                { "Identity", result14.ElementAt(0) }
            }
        );
        var result16 = context.Runspace.InvokeCommand<File>(
            "Get-KshFile",
            new Dictionary<string, object>()
            {
                { "FileUrl", result12.ElementAt(0).ServerRelativeUrl }
            }
        );
        var result17 = context.Runspace.InvokeCommand(
            "Remove-KshFile",
            new Dictionary<string, object>()
            {
                { "Identity", result16.ElementAt(0) }
            }
        );
        var actual = result14.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void SetListItemByObject()
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
        var result3 = context.Runspace.InvokeCommand<ListItem>(
            "Add-KshListItem",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "Value", new Hashtable() }
            }
        );
        var result4 = context.Runspace.InvokeCommand<ColumnLookupValue>(
            "New-KshColumnLookupValue",
            new Dictionary<string, object>()
            {
                { "LookupId", context.AppSettings["ListItem1Id"] },
            }
        );
        var result5 = context.Runspace.InvokeCommand<ColumnUserValue>(
            "New-KshColumnUserValue",
            new Dictionary<string, object>()
            {
                { "LookupId", context.AppSettings["User1Id"] },
            }
        );
        var result6 = context.Runspace.InvokeCommand<ColumnUrlValue>(
            "New-KshColumnUrlValue",
            new Dictionary<string, object>()
            {
                { "Url", "https://www.example.com" },
                { "Description", "Test Value 0" }
            }
        );
        var result7 = context.Runspace.InvokeCommand<ColumnGeolocationValue>(
            "New-KshColumnGeolocationValue",
            new Dictionary<string, object>()
            {
                { "Latitude", 10 },
                { "Longitude", 10 }
            }
        );
        var result8 = context.Runspace.InvokeCommand<TermGroup>(
            "Get-KshTermGroup",
            new Dictionary<string, object>()
            {
                { "TermGroupId", context.AppSettings["TermGroup1Id"] }
            }
        );
        var result9 = context.Runspace.InvokeCommand<TermSet>(
            "Get-KshTermSet",
            new Dictionary<string, object>()
            {
                { "TermGroup", result8.ElementAt(0) },
                { "TermSetId", context.AppSettings["TermSet1Id"] }
            }
        );
        var result10 = context.Runspace.InvokeCommand<Term>(
            "Get-KshTerm",
            new Dictionary<string, object>()
            {
                { "TermSet", result9.ElementAt(0) },
                { "TermId", context.AppSettings["Term1Id"] }
            }
        );
        var result11 = context.Runspace.InvokeCommand<ColumnTaxonomyValue>(
            "New-KshColumnTaxonomyValue",
            new Dictionary<string, object>()
            {
                { "Term", result10.ElementAt(0) }
            }
        );
        var result12 = context.Runspace.InvokeCommand<ImageItem>(
            "Save-KshImage",
            new Dictionary<string, object>()
            {
                { "ListItem", result3.ElementAt(0) },
                { "FileName", "TestFile0.png" },
                { "Content", new System.IO.MemoryStream(Convert.FromBase64String(
                    "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABAQMAAAAl21bKAAAAA1BMVEUAAACnej3aAAAAAXRSTlMA" +
                    "QObYZgAAAApJREFUCNdjYAAAAAIAAeIhvDMAAAAASUVORK5CYII="
                )) }
            }
        );
        var result13 = context.Runspace.InvokeCommand<ColumnImageValue>(
            "New-KshColumnImageValue",
            new Dictionary<string, object>()
            {
                { "ImageItem", result12.ElementAt(0) },
                { "ColumnName", "TestColumn17" }
            }
        );
        var result14 = context.Runspace.InvokeCommand<ListItem>(
            "Set-KshListItem",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) },
                { "Value", new
                    {
                        TestColumn1 = "Test Value 0",
                        TestColumn2 = "Test Value 0",
                        TestColumn3 = "Test Value 0",
                        TestColumn4 = new List<string>() { "Test Value 0" },
                        TestColumn5 = 1,
                        TestColumn6 = 200,
                        TestColumn7 = new DateTime(2010, 10, 10, 0, 0, 0, DateTimeKind.Utc),
                        TestColumn8 = result4.ElementAt(0),
                        TestColumn9 = new[] { result4.ElementAt(0) },
                        TestColumn10 = true,
                        TestColumn11 = result5.ElementAt(0),
                        TestColumn12 = new[] { result5.ElementAt(0) },
                        TestColumn13 = result6.ElementAt(0),
                        TestColumn15 = result7.ElementAt(0),
                        TestColumn16 = result11.ElementAt(0),
                        TestColumn17 = result13.ElementAt(0)
                    }
                },
                { "PassThru", true }
            }
        );
        var result15 = context.Runspace.InvokeCommand(
            "Remove-KshListItem",
            new Dictionary<string, object>()
            {
                { "Identity", result14.ElementAt(0) }
            }
        );
        var result16 = context.Runspace.InvokeCommand<File>(
            "Get-KshFile",
            new Dictionary<string, object>()
            {
                { "FileUrl", result12.ElementAt(0).ServerRelativeUrl }
            }
        );
        var result17 = context.Runspace.InvokeCommand(
            "Remove-KshFile",
            new Dictionary<string, object>()
            {
                { "Identity", result16.ElementAt(0) }
            }
        );
        var actual = result14.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void SetListItemUsingSystemUpdate()
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
        var result3 = context.Runspace.InvokeCommand<ListItem>(
            "Add-KshListItem",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "Value", new Hashtable() }
            }
        );
        var result4 = context.Runspace.InvokeCommand<ListItem>(
            "Set-KshListItem",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) },
                { "Value", new Hashtable()
                    {
                        { "Title", "Test List Item 0" }
                    }
                },
                { "SystemUpdate", true },
                { "PassThru", true }
            }
        );
        var result5 = context.Runspace.InvokeCommand(
            "Remove-KshListItem",
            new Dictionary<string, object>()
            {
                { "Identity", result4.ElementAt(0) }
            }
        );
        var actual = result4.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}
