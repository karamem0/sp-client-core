//
// Copyright (c) 2018-2024 karamem0
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
public class SetTermGroupCommandTests
{

    [Test()]
    public void SetTermGroup()
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
            "Add-KshTermGroup",
            new Dictionary<string, object>()
            {
                { "Name", "Test Term Group 0" }
            }
        );
        var result3 = context.Runspace.InvokeCommand<TermGroup>(
            "Set-KshTermGroup",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) },
                { "Description", "Test Term Group 9" },
                { "Name", "Test Term Group 9" },
                { "PassThru", true }
            }
        );
        var result4 = context.Runspace.InvokeCommand(
            "Remove-KshTermGroup",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}
