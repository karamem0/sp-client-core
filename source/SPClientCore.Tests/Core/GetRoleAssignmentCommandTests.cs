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
    public class GetRoleAssignmentCommandTests
    {

        [TestMethod()]
        [TestCategory("Web")]
        public void GetWebRoleAssignmentById()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<RoleAssignment>(
                    "Get-SPRoleAssignment",
                    new Dictionary<string, object>()
                    {
                        { "PrincipalId", context.AppSettings["WebRoleAssignment1Id"] }
                    }
                );
                var actual = result1.ToArray();
            }
        }

        [TestMethod()]
        [TestCategory("List")]
        public void GetListRoleAssignmentById()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<RoleAssignment>(
                    "Get-SPRoleAssignment",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "PrincipalId", context.AppSettings["ListRoleAssignment1Id"] }
                    }
                );
                var actual = result1.ToArray();
            }
        }

        [TestMethod()]
        [TestCategory("ListItem")]
        public void GetListItemRoleAssignmentById()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<RoleAssignment>(
                    "Get-SPRoleAssignment",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "ListItem", context.AppSettings["ListItem1Id"] },
                        { "PrincipalId", context.AppSettings["ListItemRoleAssignment1Id"] }
                    }
                );
                var actual = result1.ToArray();
            }
        }

    }

}
