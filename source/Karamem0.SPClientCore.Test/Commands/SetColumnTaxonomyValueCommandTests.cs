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
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands.Test;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class SetColumnTaxonomyValueCommandTests
{

    [Test()]
    public void InvokeCommand_SetItem_ShouldSucceed()
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
        var result2 = context.Runspace.InvokeCommand<TermGroup>(
            "Get-KshTermGroup",
            new Dictionary<string, object>()
            {
                ["TermGroupId"] = context.AppSettings["TermGroup1Id"]
            }
        );
        var result3 = context.Runspace.InvokeCommand<TermSet>(
            "Get-KshTermSet",
            new Dictionary<string, object>()
            {
                ["TermGroup"] = result2[0],
                ["TermSetId"] = context.AppSettings["TermSet1Id"]
            }
        );
        var result4 = context.Runspace.InvokeCommand<Term>(
            "Get-KshTerm",
            new Dictionary<string, object>()
            {
                ["TermSet"] = result3[0],
                ["TermId"] = context.AppSettings["Term1Id"]
            }
        );
        var result5 = context.Runspace.InvokeCommand<Column>(
            "Add-KshColumnTaxonomy",
            new Dictionary<string, object>()
            {
                ["List"] = result1[0],
                ["AllowMultipleValues"] = true,
                ["Name"] = "TestColumn0",
                ["TermSet"] = result3[0],
                ["Title"] = "Test Column 0",
                ["AddColumnInternalNameHint"] = true,
                ["AddToDefaultView"] = true
            }
        );
        var result6 = context.Runspace.InvokeCommand<ListItem>(
            "Add-KshListItem",
            new Dictionary<string, object>()
            {
                ["List"] = result1[0],
                ["Value"] = new Hashtable()
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshColumnTaxonomyValue",
            new Dictionary<string, object>()
            {
                ["Column"] = result5[0],
                ["ListItem"] = result6[0],
                ["Value"] = result4[0],
                ["Lcid"] = 1033
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshListItem",
            new Dictionary<string, object>()
            {
                ["Identity"] = result6[0]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshColumn",
            new Dictionary<string, object>()
            {
                ["Identity"] = result5[0]
            }
        );
    }

}
