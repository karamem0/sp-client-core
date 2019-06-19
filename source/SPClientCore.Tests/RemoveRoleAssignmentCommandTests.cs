//
// Copyright (c) 2019 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
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
    [TestCategory("Remove-KshRoleAssignment")]
    public class RemoveRoleAssignmentCommandTests
    {

        [TestMethod()]
        public void RemoveCurrentSiteRoleAssignment()
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
                var result2 = context.Runspace.InvokeCommand<User>(
                    "New-KshUser",
                    new Dictionary<string, object>()
                    {
                        { "Email", "testuser0@" + context.AppSettings["LoginDomainName"] },
                        { "LoginName", "i:0#.f|membership|testuser0@" + context.AppSettings["LoginDomainName"] },
                        { "Title", "Test User 0" }
                    }
                );
                var result3 = context.Runspace.InvokeCommand<RoleDefinition>(
                    "Get-KshRoleDefinition",
                    new Dictionary<string, object>()
                    {
                        { "RoleDefinitionId", context.AppSettings["RoleDefinition1Id"] }
                    }
                );
                var result4 = context.Runspace.InvokeCommand<RoleAssignment>(
                    "New-KshRoleAssignment",
                    new Dictionary<string, object>()
                    {
                        { "Principal", result2.ElementAt(0) },
                        { "RoleDefinition", result3.ElementAt(0) }
                    }
                );
                var result5 = context.Runspace.InvokeCommand(
                    "Remove-KshRoleAssignment",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result4.ElementAt(0) }
                    }
                );
                var result6 = context.Runspace.InvokeCommand(
                    "Remove-KshUser",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result2.ElementAt(0) }
                    }
                );
            }
        }


    }

}
