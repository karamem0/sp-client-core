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
public class SetNavigationNodeCommandTests
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
                ["CertificatePassword"] = context.AppSettings["CertificatePassword"].ToSecureString()
            }
        );
        var result1 = context.Runspace.InvokeCommand<NavigationNode>(
            "Get-KshNavigationNode",
            new Dictionary<string, object>()
            {
                ["NavigationNodeId"] = context.AppSettings["NavigationNode1Id"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<NavigationNode>(
            "Add-KshNavigationNode",
            new Dictionary<string, object>()
            {
                ["NavigationNode"] = result1.ElementAt(0),
                ["Title"] = "Test Navigation Node 0",
                ["Url"] = "http://www.example.com"
            }
        );
        var result3 = context.Runspace.InvokeCommand<NavigationNode>(
            "Set-KshNavigationNode",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2.ElementAt(0),
                ["AudienceIds"] = null,
                ["IsVisible"] = true,
                ["Title"] = "Test Navigation Node 9",
                ["Url"] = "https://www.bing.com",
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshNavigationNode",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3.ElementAt(0)
            }
        );
        var actual = result3.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}
