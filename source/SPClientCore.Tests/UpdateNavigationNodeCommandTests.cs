//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/spclientcore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Tests.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests
{

    [TestClass()]
    [TestCategory("Update-KshNavigationNode")]
    public class UpdateNavigationNodeCommandTests
    {

        [TestMethod()]
        public void UpdateNavigationNode()
        {
            using (var context = new PSCmdletContext())
            {
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
                    "New-KshNavigationNode",
                    new Dictionary<string, object>()
                    {
                        { "NavigationNode", result2.ElementAt(0) },
                        { "Title", "Test Navigation Node 0" },
                        { "Url", "http://www.example.com" }
                    }
                );
                var result4 = context.Runspace.InvokeCommand<NavigationNode>(
                    "Update-KshNavigationNode",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result3.ElementAt(0) },
                        { "IsVisible", true },
                        { "Title", "Test Navigation Node 9" },
                        { "Url", "https://www.bing.com" },
                        { "PassThru", true }
                    }
                );
                var result5 = context.Runspace.InvokeCommand(
                    "Remove-KshNavigationNode",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result4.ElementAt(0) }
                    }
                );
                var actual = result4.ElementAt(0);
            }
        }

    }

}
