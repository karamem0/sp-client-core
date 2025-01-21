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
public class AddColumnNumberCommandTests
{

    [Test()]
    public void InvokeCommand_AddItemToList_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"] },
                { "ClientId", context.AppSettings["ClientId"] },
                { "CertificatePath", context.AppSettings["CertificatePath"] },
                { "CertificatePassword", context.AppSettings["CertificatePassword"].ToSecureString() }
            }
        );
        var result1 = context.Runspace.InvokeCommand<List>(
            "Get-KshList",
            new Dictionary<string, object>()
            {
                { "ListId", context.AppSettings["List1Id"] }
            }
        );
        var result2 = context.Runspace.InvokeCommand<ColumnNumber>(
            "Add-KshColumnNumber",
            new Dictionary<string, object>()
            {
                { "List", result1.ElementAt(0) },
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                { "CustomFormatter", /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }" },
                { "DefaultValue", "50" },
                { "Description", "Test Column 0 Description" },
                { "Direction", "none" },
                { "EnforceUniqueValues", true },
                { "Group", "Test Column 0 Group" },
                { "Hidden", true },
                { "Id", "35aa78a6-66d7-472c-ab6b-d534193842af" },
                { "Indexed", true },
                { "JSLink", "clienttemplates.js" },
                { "MaxValue", 99 },
                { "MinValue", 1 },
                { "Name", "TestColumn0" },
                { "NoCrawl", true },
                { "NumberFormat", 2 },
                { "ReadOnly", true },
                { "Required", true },
                { "ShowAsPercentage", true },
                { "StaticName", "TestColumn0" },
                { "Title", "Test Column 0" },
                { "AddColumnInternalNameHint", true },
                { "AddToDefaultView", true }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshColumnNumber",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) },
                { "Hidden", false },
                { "ReadOnly", false }
            }
        );
        _ = context.Runspace.InvokeCommand(
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
    public void InvokeCommand_AddItemToSite_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"] },
                { "ClientId", context.AppSettings["ClientId"] },
                { "CertificatePath", context.AppSettings["CertificatePath"] },
                { "CertificatePassword", context.AppSettings["CertificatePassword"].ToSecureString() }
            }
        );
        var result1 = context.Runspace.InvokeCommand<ColumnNumber>(
            "Add-KshColumnNumber",
            new Dictionary<string, object>()
            {
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                { "CustomFormatter", /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }" },
                { "DefaultValue", "50" },
                { "Description", "Test Column 0 Description" },
                { "Direction", "none" },
                { "EnforceUniqueValues", true },
                { "Group", "Test Column 0 Group" },
                { "Hidden", true },
                { "Id", "35aa78a6-66d7-472c-ab6b-d534193842af" },
                { "Indexed", true },
                // { "JSLink", "clienttemplates.js" },
                { "MaxValue", 99 },
                { "MinValue", 1 },
                { "Name", "TestColumn0" },
                { "NoCrawl", true },
                { "NumberFormat", 2 },
                { "ReadOnly", true },
                { "Required", true },
                { "ShowAsPercentage", true },
                { "StaticName", "TestColumn0" },
                { "Title", "Test Column 0" },
                { "AddColumnInternalNameHint", true },
                { "AddToDefaultView", true }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshColumnNumber",
            new Dictionary<string, object>()
            {
                { "Identity", result1.ElementAt(0) },
                { "Hidden", false },
                { "ReadOnly", false }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                { "Identity", result1.ElementAt(0) }
            }
        );
        var actual = result1.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}
