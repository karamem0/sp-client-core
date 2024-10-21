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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests.Commands;

public class GetNavigationNodeCommandTests
{

    [Test()]
    public void GetNavigationNodes()
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
        var result2 = context.Runspace.InvokeCommand<NavigationNode>(
            "Get-KshNavigationNode",
            new Dictionary<string, object>()
            {
                { "NavigationNodeId", context.AppSettings["NavigationNode1Id"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<NavigationNode>(
            "Get-KshNavigationNode",
            new Dictionary<string, object>()
            {
                { "NavigationNode", result2.ElementAt(0) }
            }
        );
        var actual = result3.ToArray();
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void GetNavigationNodeByIdentity()
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
        var result2 = context.Runspace.InvokeCommand<NavigationNode>(
            "Get-KshNavigationNode",
            new Dictionary<string, object>()
            {
                { "NavigationNodeId", context.AppSettings["NavigationNode1Id"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<NavigationNode>(
            "Get-KshNavigationNode",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void GetNavigationByNavigationNodeId()
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
        var result2 = context.Runspace.InvokeCommand<NavigationNode>(
            "Get-KshNavigationNode",
            new Dictionary<string, object>()
            {
                { "NavigationNodeId", context.AppSettings["NavigationNode1Id"] }
            }
        );
        var actual = result2.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}