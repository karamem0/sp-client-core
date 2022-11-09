//
// Copyright (c) 2022 karamem0
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
    public class GetRoleDefinitionCommandTests
    {

        [TestMethod()]
        public void GetRoleDefinitions()
        {
            using var context = new PSCmdletContext();
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
            var result2 = context.Runspace.InvokeCommand<RoleDefinition>(
                "Get-KshRoleDefinition",
                new Dictionary<string, object>()
                {
                }
            );
            var actual = result2.ToArray();
        }

        [TestMethod()]
        public void GetRoleDefinitionByIdentity()
        {
            using var context = new PSCmdletContext();
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
            var result2 = context.Runspace.InvokeCommand<RoleDefinition>(
                "Get-KshRoleDefinition",
                new Dictionary<string, object>()
                {
                    { "RoleDefinitionId", context.AppSettings["RoleDefinition1Id"] }
                }
            );
            var result3 = context.Runspace.InvokeCommand<RoleDefinition>(
                "Get-KshRoleDefinition",
                new Dictionary<string, object>()
                {
                    { "Identity", result2.ElementAt(0) }
                }
            );
            var actual = result3.ElementAt(0);
        }

        [TestMethod()]
        public void GetRoleDefinitionByRoleDefinitionId()
        {
            using var context = new PSCmdletContext();
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
            var result2 = context.Runspace.InvokeCommand<RoleDefinition>(
                "Get-KshRoleDefinition",
                new Dictionary<string, object>()
                {
                    { "RoleDefinitionId", context.AppSettings["RoleDefinition1Id"] }
                }
            );
            var actual = result2.ElementAt(0);
        }

        [TestMethod()]
        public void GetRoleDefinitionByRoleDefinitionName()
        {
            using var context = new PSCmdletContext();
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
            var result2 = context.Runspace.InvokeCommand<RoleDefinition>(
                "Get-KshRoleDefinition",
                new Dictionary<string, object>()
                {
                    { "RoleDefinitionName", context.AppSettings["RoleDefinition1Name"] }
                }
            );
            var actual = result2.ElementAt(0);
        }

    }

}
