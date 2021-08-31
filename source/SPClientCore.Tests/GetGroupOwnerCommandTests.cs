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
    [TestCategory("Get-KshGroupOwner")]
    public class GetGroupOwnerCommandTests
    {

        [TestMethod()]
        public void GetGroupOwner()
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
                var result2 = context.Runspace.InvokeCommand<Group>(
                    "New-KshGroup",
                    new Dictionary<string, object>()
                    {
                        { "Title", "Test Group 0" }
                    }
                );
                var result3 = context.Runspace.InvokeCommand<Principal>(
                    "Get-KshGroupOwner",
                    new Dictionary<string, object>()
                    {
                        { "Group", result2.ElementAt(0) }
                    }
                );
                var result4 = context.Runspace.InvokeCommand(
                    "Remove-KshGroup",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result2.ElementAt(0) }
                    }
                );
                var actual = result3.ElementAt(0);
            }
        }

    }

}
