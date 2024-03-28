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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests;

[TestClass()]
public class SetColumnTaxonomyValueCommandTests
{

    [TestMethod()]
    public void SetColumnTaxonomyValue()
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
        var result3 = context.Runspace.InvokeCommand<TermGroup>(
            "Get-KshTermGroup",
            new Dictionary<string, object>()
            {
                { "TermGroupId", context.AppSettings["TermGroup1Id"] }
            }
        );
        var result4 = context.Runspace.InvokeCommand<TermSet>(
            "Get-KshTermSet",
            new Dictionary<string, object>()
            {
                { "TermGroup", result3.ElementAt(0) },
                { "TermSetId", context.AppSettings["TermSet1Id"] }
            }
        );
        var result5 = context.Runspace.InvokeCommand<Term>(
            "Get-KshTerm",
            new Dictionary<string, object>()
            {
                { "TermSet", result4.ElementAt(0) },
                { "TermId", context.AppSettings["Term1Id"] }
            }
        );
        var result6 = context.Runspace.InvokeCommand<Column>(
            "Add-KshColumnTaxonomy",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "AllowMultipleValues", true },
                { "Name", "TestColumn0" },
                { "TermSet", result4.ElementAt(0) },
                { "Title", "Test Column 0" },
                { "AddColumnInternalNameHint", true },
                { "AddToDefaultView", true }
            }
        );
        var result7 = context.Runspace.InvokeCommand<ListItem>(
            "Add-KshListItem",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "Value", new Hashtable() }
            }
        );
        var result8 = context.Runspace.InvokeCommand(
            "Set-KshColumnTaxonomyValue",
            new Dictionary<string, object>()
            {
                { "Column", result6.ElementAt(0) },
                { "ListItem", result7.ElementAt(0) },
                { "Value", result5.ElementAt(0) },
                { "Lcid", 1033 }
            }
        );
        var result9 = context.Runspace.InvokeCommand(
            "Remove-KshListItem",
            new Dictionary<string, object>()
            {
                { "Identity", result7.ElementAt(0) }
            }
        );
        var result10 = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                { "Identity", result6.ElementAt(0) }
            }
        );
    }

}
