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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands.Test;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class AddTermCommandTests
{

    [Test()]
    public void InvokeCommand_AddItemToTermSet_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<TermGroup>(
            "Get-KshTermGroup",
            new Dictionary<string, object>()
            {
                ["TermGroupId"] = context.AppSettings["TermGroup1Id"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<TermSet>(
            "Get-KshTermSet",
            new Dictionary<string, object>()
            {
                ["TermGroup"] = result1[0],
                ["TermSetId"] = context.AppSettings["TermSet1Id"]
            }
        );
        var result3 = context.Runspace.InvokeCommand<Term>(
            "Add-KshTerm",
            new Dictionary<string, object>()
            {
                ["TermSet"] = result2[0],
                ["Id"] = "f58b9b97-b519-4d37-bbc5-7abdadad704e",
                ["Lcid"] = 1033,
                ["Name"] = "Test Term 0"
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshTerm",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3[0]
            }
        );
        var actual = result3[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_AddItemToTerm_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<TermGroup>(
            "Get-KshTermGroup",
            new Dictionary<string, object>()
            {
                ["TermGroupId"] = context.AppSettings["TermGroup1Id"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<TermSet>(
            "Get-KshTermSet",
            new Dictionary<string, object>()
            {
                ["TermGroup"] = result1[0],
                ["TermSetId"] = context.AppSettings["TermSet1Id"]
            }
        );
        var result3 = context.Runspace.InvokeCommand<Term>(
            "Get-KshTerm",
            new Dictionary<string, object>()
            {
                ["TermSet"] = result2[0],
                ["TermId"] = context.AppSettings["Term1Id"]
            }
        );
        var result4 = context.Runspace.InvokeCommand<Term>(
            "Add-KshTerm",
            new Dictionary<string, object>()
            {
                ["Term"] = result3[0],
                ["Id"] = "f58b9b97-b519-4d37-bbc5-7abdadad704e",
                ["Lcid"] = 1033,
                ["Name"] = "Test Term 0"
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshTerm",
            new Dictionary<string, object>()
            {
                ["Identity"] = result4[0]
            }
        );
        var actual = result4[0];
        Assert.That(actual, Is.Not.Null);
    }

}
