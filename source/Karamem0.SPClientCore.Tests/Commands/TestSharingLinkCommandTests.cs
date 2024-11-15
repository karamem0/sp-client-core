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
public class TestSharingLinkKindCommandTests
{

    [Test()]
    public void CheckAnonymousLink()
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
        var result2 = context.Runspace.InvokeCommand<string>(
            "Add-KshAnonymousLink",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["File1Url"] },
                { "IsEditLink", true }
            }
        );
        var result3 = context.Runspace.InvokeCommand<SharingLinkKind>(
            "Test-KshSharingLink",
            new Dictionary<string, object>()
            {
                { "Url", result2.ElementAt(0) }
            }
        );
        var result4 = context.Runspace.InvokeCommand(
            "Remove-KshAnonymousLink",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["File1Url"] },
                { "IsEditLink", true },
                { "RemoveAssociatedSharingLinkGroup", true }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.That(actual, Is.Not.Default);
    }

    [Test()]
    public void CheckOrganizationSharingLink()
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
        var result2 = context.Runspace.InvokeCommand<string>(
            "Add-KshOrganizationSharingLink",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["File1Url"] },
                { "IsEditLink", true }
            }
        );
        var result3 = context.Runspace.InvokeCommand<SharingLinkKind>(
            "Test-KshSharingLink",
            new Dictionary<string, object>()
            {
                { "Url", result2.ElementAt(0) }
            }
        );
        var result4 = context.Runspace.InvokeCommand(
            "Remove-KshOrganizationSharingLink",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["File1Url"] },
                { "IsEditLink", true },
                { "RemoveAssociatedSharingLinkGroup", true }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.That(actual, Is.Not.Default);
    }

}
