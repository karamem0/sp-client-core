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
public class SetTermLabelCommandTests
{

    [Test()]
    public void InvokeCommand_SetItemByLcid_ShouldSucceed()
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
        var result3 = context.Runspace.InvokeCommand<Term>(
            "Get-KshTerm",
            new Dictionary<string, object>()
            {
                { "TermSet", result2.ElementAt(0) },
                { "TermId", context.AppSettings["Term1Id"] },
            }
        );
        var result4 = context.Runspace.InvokeCommand<TermLabel>(
            "Add-KshTermLabel",
            new Dictionary<string, object>()
            {
                { "Term", result3.ElementAt(0) },
                { "Name", "Test Term 0" },
                { "Lcid", 1033 },
                { "IsDefault", false }
            }
        );
        var result5 = context.Runspace.InvokeCommand<TermLabel>(
            "Set-KshTermLabel",
            new Dictionary<string, object>()
            {
                { "Identity", result4.ElementAt(0) },
                { "Lcid", 1041 },
                { "PassThru", true }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshTermLabel",
            new Dictionary<string, object>()
            {
                { "Identity", result5.ElementAt(0) }
            }
        );
        var actual = result5.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_SetItemByLabelName_ShouldSucceed()
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
        var result3 = context.Runspace.InvokeCommand<Term>(
            "Get-KshTerm",
            new Dictionary<string, object>()
            {
                { "TermSet", result2.ElementAt(0) },
                { "TermId", context.AppSettings["Term1Id"] },
            }
        );
        var result4 = context.Runspace.InvokeCommand<TermLabel>(
            "Add-KshTermLabel",
            new Dictionary<string, object>()
            {
                { "Term", result3.ElementAt(0) },
                { "Name", "Test Term 0" },
                { "Lcid", 1033 },
                { "IsDefault", false }
            }
        );
        var result5 = context.Runspace.InvokeCommand<TermLabel>(
            "Set-KshTermLabel",
            new Dictionary<string, object>()
            {
                { "Identity", result4.ElementAt(0) },
                { "Name", "Test Term 9" },
                { "PassThru", true }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshTermLabel",
            new Dictionary<string, object>()
            {
                { "Identity", result5.ElementAt(0) }
            }
        );
        var actual = result5.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_SetItemByIsDefault_ShouldSucceed()
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
        var result3 = context.Runspace.InvokeCommand<Term>(
            "Get-KshTerm",
            new Dictionary<string, object>()
            {
                { "TermSet", result2.ElementAt(0) },
                { "TermId", context.AppSettings["Term1Id"] },
            }
        );
        var result4 = context.Runspace.InvokeCommand<TermLabel>(
            "Add-KshTermLabel",
            new Dictionary<string, object>()
            {
                { "Term", result3.ElementAt(0) },
                { "Name", "Test Term 0" },
                { "Lcid", 1033 },
                { "IsDefault", false }
            }
        );
        var result5 = context.Runspace.InvokeCommand<TermLabel>(
            "Set-KshTermLabel",
            new Dictionary<string, object>()
            {
                { "Identity", result4.ElementAt(0) },
                { "IsDefault", true },
                { "PassThru", true }
            }
        );
        var result6 = context.Runspace.InvokeCommand<TermLabel>(
            "Get-KshTermLabel",
            new Dictionary<string, object>()
            {
                { "Term", result3.ElementAt(0) },
                { "LabelName", context.AppSettings["Term1Name"] }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshTermLabel",
            new Dictionary<string, object>()
            {
                { "Identity", result6.ElementAt(0) },
                { "IsDefault", true }
            }
        );
        var result7 = context.Runspace.InvokeCommand<TermLabel>(
            "Get-KshTermLabel",
            new Dictionary<string, object>()
            {
                { "Term", result3.ElementAt(0) },
                { "LabelName", "Test Term 0" }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshTermLabel",
            new Dictionary<string, object>()
            {
                { "Identity", result7.ElementAt(0) }
            }
        );
        var actual = result5.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}
