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
    [TestCategory("RoleDefinition")]
    public class RemoveRoleDefinitionCommandTests
    {

        [TestMethod()]
        public void RemoveRoleDefinition()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<Web>(
                    "Select-SPWeb",
                    new Dictionary<string, object>()
                    {
                        { "Web", context.AppSettings["LoginUrl"] }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<RoleDefinition>(
                    "New-SPRoleDefinition",
                    new Dictionary<string, object>()
                    {
                        { "BasePermissions", "ViewListItems" },
                        { "Name", "Test Role Definition 0" }
                    }
                );
                var result3 = context.Runspace.InvokeCommand(
                    "Remove-SPRoleDefinition",
                    new Dictionary<string, object>()
                    {
                        { "RoleDefinition", result2.ElementAt(0).Id }
                    }
                );
            }
        }

    }

}
