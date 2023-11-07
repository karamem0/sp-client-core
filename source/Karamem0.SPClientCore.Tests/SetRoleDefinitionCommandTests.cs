//
// Copyright (c) 2023 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Tests.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests
{

    [TestClass()]
    public class SetRoleDefinitionCommandTests
    {

        [TestMethod()]
        public void SetRoleDefinition()
        {
            using var context = new PSCmdletContext();
            var result1 = context.Runspace.InvokeCommand(
                "Connect-KshSite",
                new Dictionary<string, object>()
                {
                    { "Url", context.AppSettings["BaseUrl"] },
                    { "Credential", PSCredentialFactory.CreateCredential(
                        context.AppSettings["LoginUserName"],
                        context.AppSettings["LoginPassword"])
                    }
                }
            );
            var result2 = context.Runspace.InvokeCommand<BasePermission>(
                "New-KshBasePermission",
                new Dictionary<string, object>()
                {
                    { "Permission", "EmptyMask" }
                }
            );
            var result3 = context.Runspace.InvokeCommand<RoleDefinition>(
                "Add-KshRoleDefinition",
                new Dictionary<string, object>()
                {
                    { "BasePermission", result2.ElementAt(0) },
                    { "Name", "Test Role Definition 0" }
                }
            );
            var result4 = context.Runspace.InvokeCommand<BasePermission>(
                "New-KshBasePermission",
                new Dictionary<string, object>()
                {
                    { "Permission", "ViewListItems" }
                }
            );
            var result5 = context.Runspace.InvokeCommand<RoleDefinition>(
                "Set-KshRoleDefinition",
                new Dictionary<string, object>()
                {
                    { "Identity", result3.ElementAt(0) },
                    { "BasePermission", result4.ElementAt(0) },
                    { "Name", "Test Role Definition 0" },
                    { "Description", "Test Role Definition 9 Description" },
                    { "Order", 1 },
                    { "PassThru", true }
                }
            );
            var result6 = context.Runspace.InvokeCommand(
                "Remove-KshRoleDefinition",
                new Dictionary<string, object>()
                {
                    { "Identity", result5.ElementAt(0) }
                }
            );
            var actual = result5.ElementAt(0);
            Assert.IsNotNull(actual);
        }

    }

}
