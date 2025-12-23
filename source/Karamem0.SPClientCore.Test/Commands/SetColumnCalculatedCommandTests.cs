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
public class SetColumnCalculatedCommandTests
{

    [Test()]
    public void InvokeCommand_SetItemBooleanFromList_ShouldSucceed()
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
        var result2 = context.Runspace.InvokeCommand<Column>(
            "Add-KshColumnBoolean",
            new Dictionary<string, object>()
            {
                ["List"] = result1[0],
                ["Name"] = "TestColumn9",
                ["Title"] = "Test Column 9",
                ["AddColumnInternalNameHint"] = true
            }
        );
        var result3 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Add-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                ["List"] = result1[0],
                ["Columns"] = new[]
                {
                    result2[0]
                },
                ["Formula"] = "=[Test Column 9]",
                ["Id"] = "35aa78a6-66d7-472c-ab6b-d534193842af",
                ["Name"] = "TestColumn0",
                ["OutputType"] = "Boolean",
                ["Title"] = "Test Column 0",
                ["AddColumnInternalNameHint"] = true
            }
        );
        var result4 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3[0],
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                ["Columns"] = new[]
                {
                    result2[0]
                },
                ["CustomFormatter"] = /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }",
                ["Description"] = "Test Column 0 Description",
                ["Direction"] = "none",
                ["Formula"] = "=[Test Column 9]",
                ["Group"] = "Test Group 0",
                ["Hidden"] = true,
                ["JSLink"] = "clienttemplates.js",
                ["NoCrawl"] = true,
                ["OutputType"] = "Boolean",
                ["StaticName"] = "TestColumn0",
                ["Title"] = "Test Column 0",
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                ["Identity"] = result4[0],
                ["Hidden"] = false
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                ["Identity"] = result4[0]
            }
        );
        _ = context.Runspace.InvokeCommand<Guid>(
            "Remove-KshList",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0]
            }
        );
        var actual = result4[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_SetItemCurrencyFromList_ShouldSucceed()
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
        var result2 = context.Runspace.InvokeCommand<Column>(
            "Add-KshColumnCurrency",
            new Dictionary<string, object>()
            {
                ["List"] = result1[0],
                ["Name"] = "TestColumn9",
                ["Title"] = "Test Column 9",
                ["AddColumnInternalNameHint"] = true
            }
        );
        var result3 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Add-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                ["List"] = result1[0],
                ["Columns"] = new[]
                {
                    result2[0]
                },
                ["Formula"] = "=[Test Column 9]",
                ["Id"] = "35aa78a6-66d7-472c-ab6b-d534193842af",
                ["Name"] = "TestColumn0",
                ["OutputType"] = "Currency",
                ["Title"] = "Test Column 0",
                ["AddColumnInternalNameHint"] = true
            }
        );
        var result4 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3[0],
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                ["Columns"] = new[]
                {
                    result2[0]
                },
                ["CurrencyLcid"] = 1041,
                ["CustomFormatter"] = /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }",
                ["Description"] = "Test Column 0 Description",
                ["Direction"] = "none",
                ["Formula"] = "=[Test Column 9]",
                ["Group"] = "Test Group 0",
                ["Hidden"] = true,
                ["JSLink"] = "clienttemplates.js",
                ["NoCrawl"] = true,
                ["NumberFormat"] = 2,
                ["OutputType"] = "Currency",
                ["StaticName"] = "TestColumn0",
                ["Title"] = "Test Column 0",
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                ["Identity"] = result4[0],
                ["Hidden"] = false
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                ["Identity"] = result4[0]
            }
        );
        _ = context.Runspace.InvokeCommand<Guid>(
            "Remove-KshList",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0]
            }
        );
        var actual = result4[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_SetItemDateTimeFromList_ShouldSucceed()
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
        var result2 = context.Runspace.InvokeCommand<Column>(
            "Add-KshColumnDateTime",
            new Dictionary<string, object>()
            {
                ["List"] = result1[0],
                ["Name"] = "TestColumn9",
                ["Title"] = "Test Column 9",
                ["AddColumnInternalNameHint"] = true
            }
        );
        var result3 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Add-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                ["List"] = result1[0],
                ["Columns"] = new[]
                {
                    result2[0]
                },
                ["Formula"] = "=[Test Column 9]",
                ["Id"] = "35aa78a6-66d7-472c-ab6b-d534193842af",
                ["Name"] = "TestColumn0",
                ["OutputType"] = "DateTime",
                ["Title"] = "Test Column 0",
                ["AddColumnInternalNameHint"] = true
            }
        );
        var result4 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3[0],
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                ["Columns"] = new[]
                {
                    result2[0]
                },
                ["CustomFormatter"] = /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }",
                ["Description"] = "Test Column 0 Description",
                ["DateFormat"] = "DateTime",
                ["Direction"] = "none",
                ["Formula"] = "=[Test Column 9]",
                ["Group"] = "Test Group 0",
                ["Hidden"] = true,
                ["JSLink"] = "clienttemplates.js",
                ["NoCrawl"] = true,
                ["OutputType"] = "DateTime",
                ["StaticName"] = "TestColumn0",
                ["Title"] = "Test Column 0",
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                ["Identity"] = result4[0],
                ["Hidden"] = false
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                ["Identity"] = result4[0],
            }
        );
        _ = context.Runspace.InvokeCommand<Guid>(
            "Remove-KshList",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0]
            }
        );
        var actual = result4[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_SetItemNumberFromList_ShouldSucceed()
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
        var result2 = context.Runspace.InvokeCommand<Column>(
            "Add-KshColumnNumber",
            new Dictionary<string, object>()
            {
                ["List"] = result1[0],
                ["Name"] = "TestColumn9",
                ["Title"] = "Test Column 9",
                ["AddColumnInternalNameHint"] = true
            }
        );
        var result3 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Add-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                ["List"] = result1[0],
                ["Columns"] = new[]
                {
                    result2[0]
                },
                ["Formula"] = "=[Test Column 9]",
                ["Id"] = "35aa78a6-66d7-472c-ab6b-d534193842af",
                ["Name"] = "TestColumn0",
                ["OutputType"] = "Number",
                ["Title"] = "Test Column 0",
                ["AddColumnInternalNameHint"] = true
            }
        );
        var result4 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3[0],
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                ["Columns"] = new[]
                {
                    result2[0]
                },
                ["CustomFormatter"] = /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }",
                ["Description"] = "Test Column 0 Description",
                ["Direction"] = "none",
                ["Formula"] = "=[Test Column 9]",
                ["Group"] = "Test Group 0",
                ["Hidden"] = true,
                ["JSLink"] = "clienttemplates.js",
                ["NoCrawl"] = true,
                ["NumberFormat"] = 2,
                ["OutputType"] = "Number",
                ["StaticName"] = "TestColumn0",
                ["Title"] = "Test Column 0",
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                ["Identity"] = result4[0],
                ["Hidden"] = false
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                ["Identity"] = result4[0]
            }
        );
        _ = context.Runspace.InvokeCommand<Guid>(
            "Remove-KshList",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0]
            }
        );
        var actual = result4[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_SetItemTextFromList_ShouldSucceed()
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
        var result2 = context.Runspace.InvokeCommand<Column>(
            "Add-KshColumnText",
            new Dictionary<string, object>()
            {
                ["List"] = result1[0],
                ["Name"] = "TestColumn9",
                ["Title"] = "Test Column 9",
                ["AddColumnInternalNameHint"] = true
            }
        );
        var result3 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Add-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                ["List"] = result1[0],
                ["Columns"] = new[]
                {
                    result2[0]
                },
                ["Formula"] = "=[Test Column 9]",
                ["Id"] = "35aa78a6-66d7-472c-ab6b-d534193842af",
                ["Name"] = "TestColumn0",
                ["OutputType"] = "Text",
                ["Title"] = "Test Column 0",
                ["AddColumnInternalNameHint"] = true
            }
        );
        var result4 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3[0],
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                ["Columns"] = new[]
                {
                    result2[0]
                },
                ["CustomFormatter"] = /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }",
                ["Description"] = "Test Column 0 Description",
                ["Direction"] = "none",
                ["Formula"] = "=[Test Column 9]",
                ["Group"] = "Test Group 0",
                ["Hidden"] = true,
                ["JSLink"] = "clienttemplates.js",
                ["NoCrawl"] = true,
                ["OutputType"] = "Text",
                ["StaticName"] = "TestColumn0",
                ["Title"] = "Test Column 0",
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                ["Identity"] = result4[0],
                ["Hidden"] = false
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                ["Identity"] = result4[0]
            }
        );
        _ = context.Runspace.InvokeCommand<Guid>(
            "Remove-KshList",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0]
            }
        );
        var actual = result4[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_SetItemBooleanFromSite_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<Column>(
            "Add-KshColumnBoolean",
            new Dictionary<string, object>()
            {
                ["Name"] = "TestColumn99",
                ["Title"] = "Test Column 99",
                ["AddColumnInternalNameHint"] = true
            }
        );
        var result2 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Add-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                ["Columns"] = new[]
                {
                    result1[0]
                },
                ["Formula"] = "=TestColumn99",
                ["Name"] = "TestColumn0",
                ["OutputType"] = "Boolean",
                ["Title"] = "Test Column 0",
                ["AddColumnInternalNameHint"] = true
            }
        );
        var result3 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0],
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                ["Columns"] = new[]
                {
                    result1[0]
                },
                ["CustomFormatter"] = /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }",
                ["Description"] = "Test Column 0 Description",
                ["Direction"] = "none",
                ["Formula"] = "=TestColumn90",
                ["Group"] = "Test Group 0",
                ["Hidden"] = true,
                ["JSLink"] = "clienttemplates.js",
                ["NoCrawl"] = true,
                ["OutputType"] = "Boolean",
                ["StaticName"] = "TestColumn0",
                ["Title"] = "Test Column 0",
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3[0],
                ["Hidden"] = false
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3[0]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0]
            }
        );
        var actual = result3[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_SetItemCurrencyFromSite_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<Column>(
            "Add-KshColumnCurrency",
            new Dictionary<string, object>()
            {
                ["Name"] = "TestColumn99",
                ["Title"] = "Test Column 99",
                ["AddColumnInternalNameHint"] = true
            }
        );
        var result2 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Add-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                ["Columns"] = new[]
                {
                    result1[0]
                },
                ["Formula"] = "=TestColumn99",
                ["Name"] = "TestColumn0",
                ["OutputType"] = "Currency",
                ["Title"] = "Test Column 0",
                ["AddColumnInternalNameHint"] = true,
                ["AddToDefaultView"] = true
            }
        );
        var result3 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0],
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                ["Columns"] = new[]
                {
                    result1[0]
                },
                ["CurrencyLcid"] = 1041,
                ["CustomFormatter"] = /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }",
                ["Description"] = "Test Column 0 Description",
                ["Direction"] = "none",
                ["Formula"] = "=TestColumn99",
                ["Group"] = "Test Group 0",
                ["Hidden"] = true,
                ["JSLink"] = "clienttemplates.js",
                ["NoCrawl"] = true,
                ["NumberFormat"] = 2,
                ["OutputType"] = "Currency",
                ["StaticName"] = "TestColumn0",
                ["Title"] = "Test Column 0",
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3[0],
                ["Hidden"] = false
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3[0]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0]
            }
        );
        var actual = result3[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_SetItemDateTimeFromSite_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<Column>(
            "Add-KshColumnDateTime",
            new Dictionary<string, object>()
            {
                ["Name"] = "TestColumn99",
                ["Title"] = "Test Column 99",
                ["AddColumnInternalNameHint"] = true
            }
        );
        var result2 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Add-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                ["Columns"] = new[]
                {
                    result1[0]
                },
                ["Formula"] = "=TestColumn9",
                ["Name"] = "TestColumn0",
                ["OutputType"] = "DateTime",
                ["Title"] = "Test Column 0",
                ["AddColumnInternalNameHint"] = true,
                ["AddToDefaultView"] = true
            }
        );
        var result3 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0],
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                ["Columns"] = new[]
                {
                    result1[0]
                },
                ["CustomFormatter"] = /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }",
                ["Description"] = "Test Column 0 Description",
                ["DateFormat"] = "DateTime",
                ["Direction"] = "none",
                ["Formula"] = "=TestColumn99",
                ["Group"] = "Test Group 0",
                ["Hidden"] = true,
                ["JSLink"] = "clienttemplates.js",
                ["NoCrawl"] = true,
                ["OutputType"] = "DateTime",
                ["StaticName"] = "TestColumn0",
                ["Title"] = "Test Column 0",
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3[0],
                ["Hidden"] = false
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3[0]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0]
            }
        );
        var actual = result3[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_SetItemNumberFromSite_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<Column>(
            "Add-KshColumnNumber",
            new Dictionary<string, object>()
            {
                ["Name"] = "TestColumn99",
                ["Title"] = "Test Column 99",
                ["AddColumnInternalNameHint"] = true
            }
        );
        var result2 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Add-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                ["Columns"] = new[]
                {
                    result1[0]
                },
                ["Formula"] = "=TestColumn99",
                ["Name"] = "TestColumn0",
                ["OutputType"] = "Number",
                ["Title"] = "Test Column 0",
                ["AddColumnInternalNameHint"] = true,
                ["AddToDefaultView"] = true
            }
        );
        var result3 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0],
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                ["Columns"] = new[]
                {
                    result1[0]
                },
                ["CustomFormatter"] = /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }",
                ["Description"] = "Test Column 0 Description",
                ["Direction"] = "none",
                ["Formula"] = "=TestColumn99",
                ["Group"] = "Test Group 0",
                ["Hidden"] = true,
                ["JSLink"] = "clienttemplates.js",
                ["NoCrawl"] = true,
                ["NumberFormat"] = 2,
                ["OutputType"] = "Number",
                ["ShowAsPercentage"] = true,
                ["StaticName"] = "TestColumn0",
                ["Title"] = "Test Column 0",
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3[0],
                ["Hidden"] = false
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3[0]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0]
            }
        );
        var actual = result3[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_SetItemTextFromSite_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<Column>(
            "Add-KshColumnText",
            new Dictionary<string, object>()
            {
                ["Name"] = "TestColumn99",
                ["Title"] = "Test Column 99",
                ["AddColumnInternalNameHint"] = true
            }
        );
        var result2 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Add-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                ["Columns"] = new[]
                {
                    result1[0]
                },
                ["Formula"] = "=TestColumn99",
                ["Name"] = "TestColumn0",
                ["OutputType"] = "Boolean",
                ["Title"] = "Test Column 0",
                ["AddColumnInternalNameHint"] = true,
                ["AddToDefaultView"] = true
            }
        );
        var result3 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0],
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                ["Columns"] = new[]
                {
                    result1[0]
                },
                ["CustomFormatter"] = /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }",
                ["Description"] = "Test Column 0 Description",
                ["Direction"] = "none",
                ["Group"] = "Test Group 0",
                ["Formula"] = "=TestColumn99",
                ["Hidden"] = true,
                ["JSLink"] = "clienttemplates.js",
                ["NoCrawl"] = true,
                ["OutputType"] = "Boolean",
                ["StaticName"] = "TestColumn0",
                ["Title"] = "Test Column 0",
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3[0],
                ["Hidden"] = false
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3[0]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0]
            }
        );
        var actual = result3[0];
        Assert.That(actual, Is.Not.Null);
    }

}
