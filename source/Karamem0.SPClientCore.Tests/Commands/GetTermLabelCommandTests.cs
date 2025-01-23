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
public class GetTermLabelCommandTests
{

    [Test()]
    public void InvokeCommand_GetAll_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["BaseUrl"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["CertificatePassword"] = context.AppSettings["CertificatePassword"].ToSecureString()
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
                ["TermGroup"] = result1.ElementAt(0),
                ["TermSetId"] = context.AppSettings["TermSet1Id"]
            }
        );
        var result3 = context.Runspace.InvokeCommand<Term>(
            "Get-KshTerm",
            new Dictionary<string, object>()
            {
                ["TermSet"] = result2.ElementAt(0),
                ["TermId"] = context.AppSettings["Term1Id"],
            }
        );
        var result4 = context.Runspace.InvokeCommand<TermLabel>(
            "Get-KshTermLabel",
            new Dictionary<string, object>()
            {
                ["Term"] = result3.ElementAt(0)
            }
        );
        var actual = result4.ToArray();
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_GetByIdentity_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["BaseUrl"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["CertificatePassword"] = context.AppSettings["CertificatePassword"].ToSecureString()
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
                ["TermGroup"] = result1.ElementAt(0),
                ["TermSetId"] = context.AppSettings["TermSet1Id"]
            }
        );
        var result3 = context.Runspace.InvokeCommand<Term>(
            "Get-KshTerm",
            new Dictionary<string, object>()
            {
                ["TermSet"] = result2.ElementAt(0),
                ["TermId"] = context.AppSettings["Term1Id"],
            }
        );
        var result4 = context.Runspace.InvokeCommand<TermLabel>(
            "Get-KshTermLabel",
            new Dictionary<string, object>()
            {
                ["Term"] = result3.ElementAt(0),
                ["LabelName"] = context.AppSettings["Term1Name"]
            }
        );
        var result5 = context.Runspace.InvokeCommand<TermLabel>(
            "Get-KshTermLabel",
            new Dictionary<string, object>()
            {
                ["Identity"] = result4.ElementAt(0)
            }
        );
        var actual = result5.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_GetByLabelName_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["BaseUrl"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["CertificatePassword"] = context.AppSettings["CertificatePassword"].ToSecureString()
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
                ["TermGroup"] = result1.ElementAt(0),
                ["TermSetId"] = context.AppSettings["TermSet1Id"]
            }
        );
        var result3 = context.Runspace.InvokeCommand<Term>(
            "Get-KshTerm",
            new Dictionary<string, object>()
            {
                ["TermSet"] = result2.ElementAt(0),
                ["TermId"] = context.AppSettings["Term1Id"],
            }
        );
        var result4 = context.Runspace.InvokeCommand<TermLabel>(
            "Get-KshTermLabel",
            new Dictionary<string, object>()
            {
                ["Term"] = result3.ElementAt(0),
                ["LabelName"] = context.AppSettings["Term1Name"]
            }
        );
        var actual = result4.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}
