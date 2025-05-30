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
public class AddNavigationNodeCommandTests
{

    [Test()]
    public void InvokeCommand_AddItemToNavigationNode_ShouldSucceed()
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
                ["NavigationNode"] = result1[0],
                ["AsLastNode"] = true,
                ["IsExternal"] = true,
                ["Title"] = "Test Navigation Node 0",
                ["Url"] = "http://www.example.com"
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshNavigationNode",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0]
            }
        );
        var actual = result2[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_AddItemToQuickLaunch_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<NavigationNode>(
            "Add-KshNavigationNode",
            new Dictionary<string, object>()
            {
                ["QuickLaunch"] = true,
                ["AsLastNode"] = true,
                ["IsExternal"] = true,
                ["Title"] = "Test Navigation Node 0",
                ["Url"] = "http://www.example.com"
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshNavigationNode",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0]
            }
        );
        var actual = result1[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_AddItemToTopNavigationBar_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<NavigationNode>(
            "Add-KshNavigationNode",
            new Dictionary<string, object>()
            {
                ["TopNavigationBar"] = true,
                ["AsLastNode"] = true,
                ["IsExternal"] = true,
                ["Title"] = "Test Navigation Node 0",
                ["Url"] = "http://www.example.com"
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshNavigationNode",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0]
            }
        );
        var actual = result1[0];
        Assert.That(actual, Is.Not.Null);
    }

}
