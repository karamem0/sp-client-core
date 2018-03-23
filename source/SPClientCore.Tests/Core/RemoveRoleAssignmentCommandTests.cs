//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.Core;
using Karamem0.SharePoint.PowerShell.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Core.Tests
{

    [TestClass()]
    public class RemoveRoleAssignmentCommandTests
    {

        [TestMethod()]
        [TestCategory("Web")]
        public void RemoveWebRoleAssignment()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand(
                    "Add-SPRoleAssignment",
                    new Dictionary<string, object>()
                    {
                        { "PrincipalId", context.AppSettings["User1Id"] },
                        { "RoleDefinitionId", context.AppSettings["RoleDefinition1Id"] }
                    }
                );
                var result2 = context.Runspace.InvokeCommand(
                    "Remove-SPRoleAssignment",
                    new Dictionary<string, object>()
                    {
                        { "PrincipalId", context.AppSettings["User1Id"] },
                        { "RoleDefinitionId", context.AppSettings["RoleDefinition1Id"] }
                    }
                );
            }
        }

        [TestMethod()]
        [TestCategory("List")]
        public void RemoveListRoleAssignment()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand(
                    "Add-SPRoleAssignment",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "PrincipalId", context.AppSettings["User1Id"] },
                        { "RoleDefinitionId", context.AppSettings["RoleDefinition1Id"] }
                    }
                );
                var result2 = context.Runspace.InvokeCommand(
                    "Remove-SPRoleAssignment",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "PrincipalId", context.AppSettings["User1Id"] },
                        { "RoleDefinitionId", context.AppSettings["RoleDefinition1Id"] }
                    }
                );
            }
        }

        [TestMethod()]
        [TestCategory("ListItem")]
        public void RemoveListItemRoleAssignment()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand(
                    "Add-SPRoleAssignment",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "ListItem", context.AppSettings["ListItem1Id"] },
                        { "PrincipalId", context.AppSettings["User1Id"] },
                        { "RoleDefinitionId", context.AppSettings["RoleDefinition1Id"] }
                    }
                );
                var result2 = context.Runspace.InvokeCommand(
                    "Remove-SPRoleAssignment",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "ListItem", context.AppSettings["ListItem1Id"] },
                        { "PrincipalId", context.AppSettings["User1Id"] },
                        { "RoleDefinitionId", context.AppSettings["RoleDefinition1Id"] }
                    }
                );
            }
        }

    }

}
