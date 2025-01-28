//
// Copyright (c) 2018-2025 karamem0
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
public class SetColumnDateTimeCommandTests
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
        var result2 = context.Runspace.InvokeCommand<ColumnDateTime>(
            "Add-KshColumnDateTime",
            new Dictionary<string, object>()
            {
                ["List"] = result1.ElementAt(0),
                ["Name"] = "TestColumn0",
                ["Title"] = "Test Column 0",
                ["AddColumnInternalNameHint"] = true,
                ["AddToDefaultView"] = true
            }
        );
        var result3 = context.Runspace.InvokeCommand<ColumnDateTime>(
            "Set-KshColumnDateTime",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2.ElementAt(0),
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                ["ClientValidationFormula"] = "=FALSE",
                ["ClientValidationMessage"] = "ERROR",
                ["CustomFormatter"] = /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }",
                ["DefaultValue"] = "2010/12/15 15:00:00",
                ["Description"] = "Test Column 0 Description",
                ["Direction"] = "none",
                ["EnforceUniqueValues"] = false,
                ["Group"] = "Test Group 0",
                ["Hidden"] = true,
                ["Indexed"] = false,
                ["JSLink"] = "clienttemplates.js",
                ["NoCrawl"] = true,
                ["ReadOnly"] = true,
                ["Required"] = true,
                ["StaticName"] = "TestColumn0",
                ["Title"] = "Test Column 0",
                ["ValidationFormula"] = "=FALSE",
                ["ValidationMessage"] = "ERROR",
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshColumnDateTime",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3.ElementAt(0),
                ["Hidden"] = false,
                ["ReadOnly"] = false
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3.ElementAt(0)
            }
        );
        var actual = result3.ElementAt(0);
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
        var result1 = context.Runspace.InvokeCommand<ColumnDateTime>(
            "Add-KshColumnDateTime",
            new Dictionary<string, object>()
            {
                ["Name"] = "TestColumn0",
                ["Title"] = "Test Column 0",
                ["AddColumnInternalNameHint"] = true,
                ["AddToDefaultView"] = true
            }
        );
        var result2 = context.Runspace.InvokeCommand<ColumnDateTime>(
            "Set-KshColumnDateTime",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1.ElementAt(0),
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                ["ClientValidationFormula"] = "=FALSE",
                ["ClientValidationMessage"] = "ERROR",
                ["CalendarType"] = "Japan",
                ["CustomFormatter"] = /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }",
                ["DefaultValue"] = "2010/12/15 15:00:00",
                ["DateFormat"] = "DateTime",
                ["Description"] = "Test Column 0 Description",
                ["Direction"] = "none",
                ["EnforceUniqueValues"] = false,
                ["FriendlyFormat"] = "Disabled",
                ["Group"] = "Test Group 0",
                ["Hidden"] = true,
                ["Indexed"] = false,
                ["JSLink"] = "clienttemplates.js",
                ["NoCrawl"] = true,
                ["ReadOnly"] = true,
                ["Required"] = true,
                ["StaticName"] = "TestColumn0",
                ["Title"] = "Test Column 0",
                ["ValidationFormula"] = "=FALSE",
                ["ValidationMessage"] = "ERROR",
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshColumnDateTime",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2.ElementAt(0),
                ["Hidden"] = false,
                ["ReadOnly"] = false
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2.ElementAt(0)
            }
        );
        var actual = result2.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}
