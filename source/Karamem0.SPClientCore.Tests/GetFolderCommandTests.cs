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
    public class GetFolderCommandTests
    {

        [TestMethod()]
        public void GetFolders()
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
                }
            );
            var actual = result2.ToArray();
        }

        [TestMethod()]
        public void GetFoldersByFolder()
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
            var result3 = context.Runspace.InvokeCommand<Folder>(
                "Get-KshFolder",
                new Dictionary<string, object>()
                {
                    { "Folder", result2.ElementAt(0) }
                }
            );
            var actual = result3.ToArray();
        }

        [TestMethod()]
        public void GetFolderByIdentity()
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
            var result3 = context.Runspace.InvokeCommand<Folder>(
                "Get-KshFolder",
                new Dictionary<string, object>()
                {
                    { "Identity", result2.ElementAt(0) }
                }
            );
            var actual = result3.ElementAt(0);
        }

        [TestMethod()]
        public void GetFolderByList()
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
            var result3 = context.Runspace.InvokeCommand<Folder>(
                "Get-KshFolder",
                new Dictionary<string, object>()
                {
                    { "List", result2.ElementAt(0) }
                }
            );
            var actual = result3.ElementAt(0);
        }

        [TestMethod()]
        public void GetFolderByListItem()
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
                    { "ListId", context.AppSettings["List2Id"] }
                }
            );
            var result3 = context.Runspace.InvokeCommand<ListItem>(
                "Get-KshListItem",
                new Dictionary<string, object>()
                {
                    { "List", result2.ElementAt(0) },
                    { "ItemId", context.AppSettings["Folder1ListItemId"] }
                }
            );
            var result4 = context.Runspace.InvokeCommand<Folder>(
                "Get-KshFolder",
                new Dictionary<string, object>()
                {
                    { "ListItem", result3.ElementAt(0) }
                }
            );
            var actual = result4.ElementAt(0);
        }

        [TestMethod()]
        public void GetFolderByFolderId()
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
            var result3 = context.Runspace.InvokeCommand<ListItem>(
                "Get-KshListItem",
                new Dictionary<string, object>()
                {
                    { "Folder", result2.ElementAt(0) }
                }
            );
            var result4 = context.Runspace.InvokeCommand<Folder>(
                "Get-KshFolder",
                new Dictionary<string, object>()
                {
                    { "FolderId", result3.ElementAt(0).UniqueId }
                }
            );
            var actual = result4.ElementAt(0);
        }

        [TestMethod()]
        public void GetFolderByFolderUrl()
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
            var actual = result2.ElementAt(0);
        }

        [TestMethod()]
        public void GetFolderByFolderName()
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
            var result3 = context.Runspace.InvokeCommand<Folder>(
                "Get-KshFolder",
                new Dictionary<string, object>()
                {
                    { "Folder", result2.ElementAt(0) },
                    { "FolderName", context.AppSettings["Folder2Name"] }
                }
            );
            var actual = result3.ElementAt(0);
        }

    }

}
