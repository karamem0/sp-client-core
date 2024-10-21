//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests.Commands;

public class GetTermDescriptionCommandTests
{

    [Test()]
    public void GetTermDescription()
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
        var result4 = context.Runspace.InvokeCommand<Term>(
            "Get-KshTerm",
            new Dictionary<string, object>()
            {
                { "TermSet", result3.ElementAt(0) },
                { "TermId", context.AppSettings["Term1Id"] }
            }
        );
        var result5 = context.Runspace.InvokeCommand<string>(
            "Get-KshTermDescription",
            new Dictionary<string, object>()
            {
                { "Identity", result4.ElementAt(0) },
                { "Lcid", 1033 }
            }
        );
        var actual = result5.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}