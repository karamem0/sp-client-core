//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Tests.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests;

[TestClass()]
public class AddOrganizationSharingLinkCommandTests
{

    [TestMethod()]
    public void AddOrganizationSharingLink()
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
        var result3 = context.Runspace.InvokeCommand(
            "Remove-KshOrganizationSharingLink",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["File1Url"] },
                { "IsEditLink", true },
                { "RemoveAssociatedSharingLinkGroup", true }
            }
        );
        var actual = result2.ElementAt(0);
        Assert.IsNotNull(actual);
    }

}
