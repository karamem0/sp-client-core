//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests
{

    [TestClass()]
    public class StopRoleInheritanceCommandTests
    {

        [TestMethod()]
        [TestCategory("Web")]
        public void BreakWebRoleInheritance()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<Web>(
                    "New-SPWeb",
                    new Dictionary<string, object>()
                    {
                        { "Url", "TestWeb0" }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<Web>(
                    "Select-SPWeb",
                    new Dictionary<string, object>()
                    {
                        { "Web", result1.ElementAt(0).Id }
                    }
                );
                var result3 = context.Runspace.InvokeCommand(
                    "Stop-SPRoleInheritance",
                    new Dictionary<string, object>()
                    {
                        { "CopyRoleAssignments", true },
                        { "ClearSubscopes", true }
                    }
                );
                var result4 = context.Runspace.InvokeCommand<Web>(
                    "Get-SPWeb",
                    new Dictionary<string, object>()
                    {
                    }
                );
                var result5 = context.Runspace.InvokeCommand(
                    "Remove-SPWeb",
                    new Dictionary<string, object>()
                    {
                    }
                );
                var actual = result4.ElementAt(0);
            }
        }

        [TestMethod()]
        [TestCategory("List")]
        public void BreakListRoleInheritance()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<List>(
                    "New-SPList",
                    new Dictionary<string, object>()
                    {
                        { "BaseTemplate", 100 },
                        { "Title", "TestList0" }
                    }
                );
                var result2 = context.Runspace.InvokeCommand(
                    "Stop-SPRoleInheritance",
                    new Dictionary<string, object>()
                    {
                        { "List", result1.ElementAt(0).Id },
                        { "CopyRoleAssignments", true },
                        { "ClearSubscopes", true }
                    }
                );
                var result3 = context.Runspace.InvokeCommand<List>(
                    "Get-SPList",
                    new Dictionary<string, object>()
                    {
                        { "List", result1.ElementAt(0).Id }
                    }
                );
                var result4 = context.Runspace.InvokeCommand(
                    "Remove-SPList",
                    new Dictionary<string, object>()
                    {
                        { "List", result1.ElementAt(0).Id }
                    }
                );
                var actual = result3.ElementAt(0);
            }
        }

        [TestMethod()]
        [TestCategory("ListItem")]
        public void BreakListItemRoleInheritance()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<ListItem>(
                    "New-SPListItem",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "FieldValue", new Dictionary<string, object>()
                            {
                                { "Title", "Test List Item 0" }
                            }
                        }
                    }
                );
                var result2 = context.Runspace.InvokeCommand(
                    "Stop-SPRoleInheritance",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "ListItem", result1.ElementAt(0).Id },
                        { "CopyRoleAssignments", true },
                        { "ClearSubscopes", true }
                    }
                );
                var result3 = context.Runspace.InvokeCommand<ListItem>(
                    "Get-SPListItem",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "ListItem", result1.ElementAt(0).Id }
                    }
                );
                var result4 = context.Runspace.InvokeCommand(
                    "Remove-SPListItem",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "ListItem", result1.ElementAt(0).Id }
                    }
                );
                var actual = result3.ElementAt(0);
            }
        }

    }

}
