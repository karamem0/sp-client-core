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
public class SetColumnTaxonomyCommandTests
{

    [Test()]
    public void InvokeCommand_SetItemToList_ShouldSucceed()
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
        var result2 = context.Runspace.InvokeCommand<TermGroup>(
            "Get-KshTermGroup",
            new Dictionary<string, object>()
            {
                { "TermGroupId", context.AppSettings["TermGroup1Id"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<TermSet>(
            "Get-KshTermSet",
            new Dictionary<string, object>()
            {
                { "TermGroup", result2.ElementAt(0) },
                { "TermSetId", context.AppSettings["TermSet1Id"] }
            }
        );
        var result4 = context.Runspace.InvokeCommand<Column>(
            "Add-KshColumnTaxonomy",
            new Dictionary<string, object>()
            {
                { "List", result1.ElementAt(0) },
                { "Name", "TestColumn0" },
                { "TermSet", result3.ElementAt(0) },
                { "Title", "Test Column 0" },
                { "AddColumnInternalNameHint", true },
                { "AddToDefaultView", true }
            }
        );
        var result5 = context.Runspace.InvokeCommand<Column>(
            "Set-KshColumnTaxonomy",
            new Dictionary<string, object>()
            {
                { "Identity", result4.ElementAt(0) },
                { "AllowMultipleValues", true },
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                { "CustomFormatter", /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }" },
                { "DefaultValue", "TRUE" },
                { "Direction", "none" },
                { "Description", "Test Column 0 Description" },
                { "Group", "Test Group 0" },
                { "Hidden", true },
                { "JSLink", "clienttemplates.js" },
                { "NoCrawl", true },
                { "ReadOnly", true },
                { "Required", true },
                { "StaticName", "TestColumn0" },
                { "Title", "Test Column 0" },
                { "PassThru", true }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshColumnTaxonomy",
            new Dictionary<string, object>()
            {
                { "Identity", result5.ElementAt(0) },
                { "Hidden", false },
                { "ReadOnly", false }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                { "Identity", result5.ElementAt(0) }
            }
        );
        var actual = result5.ElementAt(0);
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
                { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"] },
                { "ClientId", context.AppSettings["ClientId"] },
                { "CertificatePath", context.AppSettings["CertificatePath"] },
                { "CertificatePassword", context.AppSettings["CertificatePassword"].ToSecureString() }
            }
        );
        var result1 = context.Runspace.InvokeCommand<TermGroup>(
            "Get-KshTermGroup",
            new Dictionary<string, object>()
            {
                { "TermGroupId", context.AppSettings["TermGroup1Id"] }
            }
        );
        var result2 = context.Runspace.InvokeCommand<TermSet>(
            "Get-KshTermSet",
            new Dictionary<string, object>()
            {
                { "TermGroup", result1.ElementAt(0) },
                { "TermSetId", context.AppSettings["TermSet1Id"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<Column>(
            "Add-KshColumnTaxonomy",
            new Dictionary<string, object>()
            {
                { "Name", "TestColumn0" },
                { "TermSet", result2.ElementAt(0) },
                { "Title", "Test Column 0" },
                { "AddColumnInternalNameHint", true },
                { "AddToDefaultView", true }
            }
        );
        var result4 = context.Runspace.InvokeCommand<Column>(
            "Set-KshColumnTaxonomy",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) },
                { "AllowMultipleValues", true },
                // { "ClientSideComponentId", null },
                // { "ClientSideComponentProperties", null },
                { "CustomFormatter", /*lang=json,strict*/ "{ \"txtContent\": \"@currentField\" }" },
                { "DefaultValue", "TRUE" },
                { "Direction", "none" },
                { "Description", "Test Column 0 Description" },
                { "Group", "Test Group 0" },
                { "Hidden", true },
                { "JSLink", "clienttemplates.js" },
                { "NoCrawl", true },
                { "ReadOnly", true },
                { "Required", true },
                { "StaticName", "TestColumn0" },
                { "Title", "Test Column 0" },
                { "PassThru", true }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshColumnTaxonomy",
            new Dictionary<string, object>()
            {
                { "Identity", result4.ElementAt(0) },
                { "Hidden", false },
                { "ReadOnly", false }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                { "Identity", result4.ElementAt(0) }
            }
        );
        var actual = result4.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}
