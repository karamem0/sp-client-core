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
    [TestCategory("Role")]
    public class GetRoleDefinitionCommandTests
    {

        [TestMethod()]
        public void GetRoleDefinitionByObject()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<RoleDefinition>(
                    "Get-SPRoleDefinition",
                    new Dictionary<string, object>()
                    {
                        { "RoleDefinition", context.AppSettings["RoleDefinition1Id"] }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<RoleDefinition>(
                    "Get-SPRoleDefinition",
                    new Dictionary<string, object>()
                    {
                        { "RoleDefinition", result1.ElementAt(0) }
                    }
                );
                var actual = result2.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetRoleDefinitionById()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<RoleDefinition>(
                    "Get-SPRoleDefinition",
                    new Dictionary<string, object>()
                    {
                        { "RoleDefinition", context.AppSettings["RoleDefinition1Id"] }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetRoleDefinitionByName()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<RoleDefinition>(
                    "Get-SPRoleDefinition",
                    new Dictionary<string, object>()
                    {
                        { "RoleDefinition", context.AppSettings["RoleDefinition1Name"] }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetRoleDefinitionByType()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<RoleDefinition>(
                    "Get-SPRoleDefinition",
                    new Dictionary<string, object>()
                    {
                        { "RoleDefinition", RoleTypeKind.Administrator }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

    }

}
