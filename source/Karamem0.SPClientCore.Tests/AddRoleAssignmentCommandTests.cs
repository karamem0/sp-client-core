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
    public class AddRoleAssignmentCommandTests
    {

        [TestMethod()]
        public void AddSiteRoleAssignment()
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
            var result2 = context.Runspace.InvokeCommand<User>(
                "Add-KshUser",
                new Dictionary<string, object>()
                {
                    { "Email", "testuser000@" + context.AppSettings["LoginDomainName"] },
                    { "LoginName", "i:0#.f|membership|testuser000@" + context.AppSettings["LoginDomainName"] },
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
                "Add-KshRoleAssignment",
                new Dictionary<string, object>()
                {
                    { "Site", true },
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
            var actual = result4.ElementAt(0);
        }

        [TestMethod()]
        public void AddListRoleAssignment()
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
            var result2 = context.Runspace.InvokeCommand<List>(
                "Get-KshList",
                new Dictionary<string, object>()
                {
                    { "ListId", context.AppSettings["List1Id"] }
                }
            );
            var result3 = context.Runspace.InvokeCommand<User>(
                "Add-KshUser",
                new Dictionary<string, object>()
                {
                    { "Email", "testuser000@" + context.AppSettings["LoginDomainName"] },
                    { "LoginName", "i:0#.f|membership|testuser000@" + context.AppSettings["LoginDomainName"] },
                    { "Title", "Test User 0" }
                }
            );
            var result4 = context.Runspace.InvokeCommand<RoleDefinition>(
                "Get-KshRoleDefinition",
                new Dictionary<string, object>()
                {
                    { "RoleDefinitionId", context.AppSettings["RoleDefinition1Id"] }
                }
            );
            var result5 = context.Runspace.InvokeCommand<RoleAssignment>(
                "Add-KshRoleAssignment",
                new Dictionary<string, object>()
                {
                    { "List", result2.ElementAt(0) },
                    { "Principal", result3.ElementAt(0) },
                    { "RoleDefinition", result4.ElementAt(0) }
                }
            );
            var result6 = context.Runspace.InvokeCommand(
                "Remove-KshRoleAssignment",
                new Dictionary<string, object>()
                {
                    { "Identity", result5.ElementAt(0) }
                }
            );
            var result7 = context.Runspace.InvokeCommand(
                "Remove-KshUser",
                new Dictionary<string, object>()
                {
                    { "Identity", result3.ElementAt(0) }
                }
            );
            var actual = result5.ElementAt(0);
        }

        [TestMethod()]
        public void AddListItemRoleAssignment()
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
            var result2 = context.Runspace.InvokeCommand<List>(
                "Get-KshList",
                new Dictionary<string, object>()
                {
                    { "ListId", context.AppSettings["List1Id"] }
                }
            );
            var result3 = context.Runspace.InvokeCommand<ListItem>(
                "Get-KshListItem",
                new Dictionary<string, object>()
                {
                    { "List", result2.ElementAt(0) },
                    { "ItemId", context.AppSettings["ListItem1Id"] }
                }
            );
            var result4 = context.Runspace.InvokeCommand<User>(
                "Add-KshUser",
                new Dictionary<string, object>()
                {
                    { "Email", "testuser000@" + context.AppSettings["LoginDomainName"] },
                    { "LoginName", "i:0#.f|membership|testuser000@" + context.AppSettings["LoginDomainName"] },
                    { "Title", "Test User 0" }
                }
            );
            var result5 = context.Runspace.InvokeCommand<RoleDefinition>(
                "Get-KshRoleDefinition",
                new Dictionary<string, object>()
                {
                    { "RoleDefinitionId", context.AppSettings["RoleDefinition1Id"] }
                }
            );
            var result6 = context.Runspace.InvokeCommand<RoleAssignment>(
                "Add-KshRoleAssignment",
                new Dictionary<string, object>()
                {
                    { "ListItem", result3.ElementAt(0) },
                    { "Principal", result4.ElementAt(0) },
                    { "RoleDefinition", result5.ElementAt(0) }
                }
            );
            var result7 = context.Runspace.InvokeCommand(
                "Remove-KshRoleAssignment",
                new Dictionary<string, object>()
                {
                    { "Identity", result6.ElementAt(0) }
                }
            );
            var result8 = context.Runspace.InvokeCommand(
                "Remove-KshUser",
                new Dictionary<string, object>()
                {
                    { "Identity", result4.ElementAt(0) }
                }
            );
            var actual = result6.ElementAt(0);
        }

    }

}
