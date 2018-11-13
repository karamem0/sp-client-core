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
    public class FindRoleDefinitionCommandTests
    {

        [TestMethod()]
        public void SkipAndTakeRoleDefinitions()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<RoleDefinition>(
                    "Find-SPRoleDefinition",
                    new Dictionary<string, object>()
                    {
                        { "OrderBy", "Name desc" },
                        { "Top", 1 },
                        { "Skip", 1 }
                    }
                );
                var actual = result1.ToArray();
            }
        }

        [TestMethod()]
        public void FilterRoleDefinitions()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<RoleDefinition>(
                    "Find-SPRoleDefinition",
                    new Dictionary<string, object>()
                    {
                        { "Filter", "Name eq '" + context.AppSettings["RoleDefinition2Name"] + "'" }
                    }
                );
                var actual = result1.ToArray();
            }
        }

    }

}
