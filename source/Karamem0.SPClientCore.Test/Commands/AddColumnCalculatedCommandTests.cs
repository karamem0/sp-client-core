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
public class AddColumnCalculatedCommandTests
{

    [Test()]
    public void InvokeCommand_AddBooleanToList_ShouldSucceed()
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
                ["Group"] = "Test Column 0 Group",
                ["Hidden"] = true,
                ["Id"] = "35aa78a6-66d7-472c-ab6b-d534193842af",
                ["JSLink"] = "clienttemplates.js",
                ["Name"] = "TestColumn0",
                ["NoCrawl"] = true,
                ["OutputType"] = "Boolean",
                ["StaticName"] = "TestColumn0",
                ["Title"] = "Test Column 0",
                ["AddColumnInternalNameHint"] = true,
                ["AddToDefaultView"] = true
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
                ["Identity"] = result2[0]
            }
        );
        _ = context.Runspace.InvokeCommand<Guid>(
            "Remove-KshList",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0]
            }
        );
        var actual = result2[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_AddCurrencyToList_ShouldSucceed()
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
                ["Group"] = "Test Column 0 Group",
                ["Hidden"] = true,
                ["Id"] = "35aa78a6-66d7-472c-ab6b-d534193842af",
                ["JSLink"] = "clienttemplates.js",
                ["Name"] = "TestColumn0",
                ["NoCrawl"] = true,
                ["NumberFormat"] = 2,
                ["OutputType"] = "Currency",
                ["StaticName"] = "TestColumn0",
                ["Title"] = "Test Column 0",
                ["AddColumnInternalNameHint"] = true,
                ["AddToDefaultView"] = true
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
                ["Identity"] = result2[0]
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
    public void InvokeCommand_AddDateTimeToList_ShouldSucceed()
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
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                ["Columns"] = new[]
                {
                    result2[0]
                },
                ["CustomFormatter"] = /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }",
                ["DateFormat"] = "DateTime",
                ["Description"] = "Test Column 0 Description",
                ["Direction"] = "none",
                ["Formula"] = "=[Test Column 9]",
                ["Group"] = "Test Column 0 Group",
                ["Hidden"] = true,
                ["Id"] = "35aa78a6-66d7-472c-ab6b-d534193842af",
                ["JSLink"] = "clienttemplates.js",
                ["Name"] = "TestColumn0",
                ["NoCrawl"] = true,
                ["OutputType"] = "DateTime",
                ["StaticName"] = "TestColumn0",
                ["Title"] = "Test Column 0",
                ["AddColumnInternalNameHint"] = true,
                ["AddToDefaultView"] = true
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
                ["Identity"] = result2[0]
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
    public void InvokeCommand_AddNumberToList_ShouldSucceed()
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
                ["Group"] = "Test Column 0 Group",
                ["Hidden"] = true,
                ["Id"] = "35aa78a6-66d7-472c-ab6b-d534193842af",
                ["JSLink"] = "clienttemplates.js",
                ["Name"] = "TestColumn0",
                ["NoCrawl"] = true,
                ["NumberFormat"] = 2,
                ["OutputType"] = "Number",
                ["ShowAsPercentage"] = true,
                ["StaticName"] = "TestColumn0",
                ["Title"] = "Test Column 0",
                ["AddColumnInternalNameHint"] = true,
                ["AddToDefaultView"] = true
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
                ["Identity"] = result2[0]
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
    public void InvokeCommand_AddTextToList_ShouldSucceed()
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
                ["Group"] = "Test Column 0 Group",
                ["Hidden"] = true,
                ["Id"] = "35aa78a6-66d7-472c-ab6b-d534193842af",
                ["JSLink"] = "clienttemplates.js",
                ["Name"] = "TestColumn0",
                ["NoCrawl"] = true,
                ["OutputType"] = "Text",
                ["StaticName"] = "TestColumn0",
                ["Title"] = "Test Column 0",
                ["AddColumnInternalNameHint"] = true,
                ["AddToDefaultView"] = true
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
                ["Identity"] = result2[0]
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
    public void InvokeCommand_AddBooleanToSite_ShouldSucceed()
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
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                ["ColumnId"] = context.AppSettings["Column10Id"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Add-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                ["Columns"] = new[]
                {
                    result1[0]
                },
                ["CustomFormatter"] = /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }",
                ["Description"] = "Test Column 0 Description",
                ["Direction"] = "none",
                ["Formula"] = "=TestColumn10",
                ["Group"] = "Test Column 0 Group",
                ["Hidden"] = true,
                ["Id"] = "35aa78a6-66d7-472c-ab6b-d534193842af",
                // { "JSLink", "clienttemplates.js" },
                ["Name"] = "TestColumn0",
                ["NoCrawl"] = true,
                ["OutputType"] = "Boolean",
                ["StaticName"] = "TestColumn0",
                ["Title"] = "Test Column 0",
                ["AddColumnInternalNameHint"] = true,
                ["AddToDefaultView"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0],
                ["Hidden"] = false
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

    [Test()]
    public void InvokeCommand_AddCurrencyToSite_ShouldSucceed()
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
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                ["ColumnId"] = context.AppSettings["Column6Id"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Add-KshColumnCalculated",
            new Dictionary<string, object>()
            {
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
                ["Formula"] = "=TestColumn6",
                ["Group"] = "Test Column 0 Group",
                ["Hidden"] = true,
                ["Id"] = "35aa78a6-66d7-472c-ab6b-d534193842af",
                // { "JSLink", "clienttemplates.js" },
                ["Name"] = "TestColumn0",
                ["NoCrawl"] = true,
                ["NumberFormat"] = 2,
                ["OutputType"] = "Currency",
                ["StaticName"] = "TestColumn0",
                ["Title"] = "Test Column 0",
                ["AddColumnInternalNameHint"] = true,
                ["AddToDefaultView"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0],
                ["Hidden"] = false
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

    [Test()]
    public void InvokeCommand_AddDateTimeToSite_ShouldSucceed()
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
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                ["ColumnId"] = context.AppSettings["Column7Id"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Add-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                ["Columns"] = new[]
                {
                    result1[0]
                },
                ["CustomFormatter"] = /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }",
                ["DateFormat"] = "DateTime",
                ["Description"] = "Test Column 0 Description",
                ["Direction"] = "none",
                ["Formula"] = "=TestColumn7",
                ["Group"] = "Test Column 0 Group",
                ["Hidden"] = true,
                ["Id"] = "35aa78a6-66d7-472c-ab6b-d534193842af",
                // { "JSLink", "clienttemplates.js" },
                ["Name"] = "TestColumn0",
                ["NoCrawl"] = true,
                ["OutputType"] = "DateTime",
                ["StaticName"] = "TestColumn0",
                ["Title"] = "Test Column 0",
                ["AddColumnInternalNameHint"] = true,
                ["AddToDefaultView"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0],
                ["Hidden"] = false
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

    [Test()]
    public void InvokeCommand_AddNumberToSite_ShouldSucceed()
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
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                ["ColumnId"] = context.AppSettings["Column5Id"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Add-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                ["Columns"] = new[]
                {
                    result1[0]
                },
                ["CustomFormatter"] = /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }",
                ["Description"] = "Test Column 0 Description",
                ["Direction"] = "none",
                ["Formula"] = "=TestColumn5",
                ["Group"] = "Test Column 0 Group",
                ["Hidden"] = true,
                ["Id"] = "35aa78a6-66d7-472c-ab6b-d534193842af",
                // { "JSLink", "clienttemplates.js" },
                ["Name"] = "TestColumn0",
                ["NoCrawl"] = true,
                ["NumberFormat"] = 2,
                ["OutputType"] = "Number",
                ["ShowAsPercentage"] = true,
                ["StaticName"] = "TestColumn0",
                ["Title"] = "Test Column 0",
                ["AddColumnInternalNameHint"] = true,
                ["AddToDefaultView"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0],
                ["Hidden"] = false
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

    [Test()]
    public void InvokeCommand_AddTextToSite_ShouldSucceed()
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
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                ["ColumnId"] = context.AppSettings["Column1Id"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                ["ColumnId"] = context.AppSettings["Column3Id"]
            }
        );
        var result3 = context.Runspace.InvokeCommand<ColumnCalculated>(
            "Add-KshColumnCalculated",
            new Dictionary<string, object>()
            {
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                ["Columns"] = new[]
                {
                    result1[0], result2[0]
                },
                ["CustomFormatter"] = /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }",
                ["Description"] = "Test Column 0 Description",
                ["Direction"] = "none",
                ["Formula"] = "=TestColumn1&TestColumn3",
                ["Group"] = "Test Column 0 Group",
                ["Hidden"] = true,
                ["Id"] = "35aa78a6-66d7-472c-ab6b-d534193842af",
                // { "JSLink", "clienttemplates.js" },
                ["Name"] = "TestColumn0",
                ["NoCrawl"] = true,
                ["OutputType"] = "Text",
                ["StaticName"] = "TestColumn0",
                ["Title"] = "Test Column 0",
                ["AddColumnInternalNameHint"] = true,
                ["AddToDefaultView"] = true
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
        var actual = result3[0];
        Assert.That(actual, Is.Not.Null);
    }

}
