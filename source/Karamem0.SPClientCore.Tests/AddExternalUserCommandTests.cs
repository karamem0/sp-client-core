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
    public class AddExternalUserCommandTests
    {

        [TestMethod()]
        public void AddSiteExternalUser()
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
            var result2 = context.Runspace.InvokeCommand<UserSharingResult>(
                "Add-KshExternalUser",
                new Dictionary<string, object>()
                {
                    { "Site", true },
                    { "UserId", new[] { context.AppSettings["ExternalUserName"] }},
                    { "Role", "View" },
                }
            );
            var result3 = context.Runspace.InvokeCommand<User>(
                "Get-KshUser",
                new Dictionary<string, object>()
                {
                    { "UserName", result2.ElementAt(0).UserId },
                }
            );
            var result4 = context.Runspace.InvokeCommand(
                "Remove-KshUser",
                new Dictionary<string, object>()
                {
                    { "Identity", result3.ElementAt(0) },
                }
            );
            var actual = result2.ElementAt(0);
        }

        [TestMethod()]
        public void AddFileExternalUser()
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
            var result2 = context.Runspace.InvokeCommand<File>(
                "Get-KshFile",
                new Dictionary<string, object>()
                {
                    { "FileUrl", context.AppSettings["File1Url"] }
                }
            );
            var result3 = context.Runspace.InvokeCommand<UserSharingResult>(
                "Add-KshExternalUser",
                new Dictionary<string, object>()
                {
                    { "File", result2.ElementAt(0) },
                    { "UserId", new[] { context.AppSettings["ExternalUserName"] }},
                    { "Role", "View" },
                    { "AdditivePermission", true },
                    { "CustomMessage", "TestFile1.txt" },
                    { "IncludeAnonymousLinksInNotification", true },
                    { "PropagateAcl", true },
                    { "SendServerManagedNotification", true },
                    { "ValidateExistingPermissions", true }
                }
            );
            var actual = result3.ElementAt(0);
        }

        [TestMethod()]
        public void AddFolderExternalUser()
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
            var result2 = context.Runspace.InvokeCommand<Folder>(
                "Get-KshFolder",
                new Dictionary<string, object>()
                {
                    { "FolderUrl", context.AppSettings["Folder1Url"] }
                }
            );
            var result3 = context.Runspace.InvokeCommand<UserSharingResult>(
                "Add-KshExternalUser",
                new Dictionary<string, object>()
                {
                    { "Folder", result2.ElementAt(0) },
                    { "UserId", new[] { context.AppSettings["ExternalUserName"] }},
                    { "Role", "View" },
                    { "AdditivePermission", true },
                    { "CustomMessage", "TestFile1.txt" },
                    { "IncludeAnonymousLinksInNotification", true },
                    { "PropagateAcl", true },
                    { "SendServerManagedNotification", true },
                    { "ValidateExistingPermissions", true }
                }
            );
            var actual = result3.ElementAt(0);
        }

    }

}
