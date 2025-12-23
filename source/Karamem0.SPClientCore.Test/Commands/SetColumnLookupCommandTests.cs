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
public class SetColumnLookupCommandTests
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
            "Add-KshList",
            new Dictionary<string, object>()
            {
                ["Template"] = "GenericList",
                ["Title"] = "Test List 0"
            }
        );
        var result2 = context.Runspace.InvokeCommand<ColumnLookup>(
            "Add-KshColumnLookup",
            new Dictionary<string, object>()
            {
                ["List"] = result1[0],
                ["AllowMultipleValues"] = true,
                ["LookupListId"] = context.AppSettings["List1Id"],
                ["LookupColumnName"] = context.AppSettings["Column1Name"],
                ["Name"] = "TestColumn0",
                ["Title"] = "Test Column 0",
                ["AddColumnInternalNameHint"] = true,
                ["AddToDefaultView"] = true
            }
        );
        var result3 = context.Runspace.InvokeCommand<ColumnLookup>(
            "Set-KshColumnLookup",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0],
                ["AllowMultipleValues"] = false,
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                ["CustomFormatter"] = /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }",
                ["Description"] = "Test Column 0 Description",
                ["Direction"] = "none",
                ["EnforceUniqueValues"] = false,
                ["Group"] = "Test Group 0",
                ["Hidden"] = true,
                ["Indexed"] = false,
                ["JSLink"] = "clienttemplates.js",
                ["LookupListId"] = context.AppSettings["List1Id"],
                ["LookupColumnName"] = context.AppSettings["Column2Name"],
                ["NoCrawl"] = true,
                ["ReadOnly"] = true,
                ["RelationshipDeleteBehavior"] = "None",
                ["Required"] = true,
                ["StaticName"] = "TestColumn0",
                ["Title"] = "Test Column 0",
                ["UnlimitedLengthInDocumentLibrary"] = true,
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshColumnLookup",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3[0],
                ["Hidden"] = false,
                ["ReadOnly"] = false
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3[0]
            }
        );
        _ = context.Runspace.InvokeCommand<Guid>(
            "Remove-KshList",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0]
            }
        );
        var actual = result3[0];
        Assert.That(actual, Is.Not.Null);
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
        var result1 = context.Runspace.InvokeCommand<ColumnLookup>(
            "Add-KshColumnLookup",
            new Dictionary<string, object>()
            {
                ["AllowMultipleValues"] = true,
                ["LookupListId"] = context.AppSettings["List1Id"],
                ["LookupColumnName"] = context.AppSettings["Column1Name"],
                ["Name"] = "TestColumn0",
                ["Title"] = "Test Column 0",
                ["AddColumnInternalNameHint"] = true,
                ["AddToDefaultView"] = true
            }
        );
        var result2 = context.Runspace.InvokeCommand<ColumnLookup>(
            "Set-KshColumnLookup",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["AllowMultipleValues"] = false,
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                ["CustomFormatter"] = /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }",
                ["Description"] = "Test Column 0 Description",
                ["Direction"] = "none",
                ["EnforceUniqueValues"] = false,
                ["Group"] = "Test Group 0",
                ["Hidden"] = true,
                ["Indexed"] = false,
                ["JSLink"] = "clienttemplates.js",
                ["LookupListId"] = context.AppSettings["List1Id"],
                ["LookupColumnName"] = context.AppSettings["Column2Name"],
                ["NoCrawl"] = true,
                ["ReadOnly"] = true,
                ["RelationshipDeleteBehavior"] = "None",
                ["Required"] = true,
                ["StaticName"] = "TestColumn0",
                ["Title"] = "Test Column 0",
                ["UnlimitedLengthInDocumentLibrary"] = true,
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshColumnLookup",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0],
                ["Hidden"] = false,
                ["ReadOnly"] = false
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0]
            }
        );
        var actual = result2[0];
        Assert.That(actual, Is.Not.Null);
    }

}
