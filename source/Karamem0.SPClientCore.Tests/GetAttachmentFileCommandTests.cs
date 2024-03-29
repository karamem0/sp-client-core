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
    public class GetAttachmentFileCommandTests
    {

        [TestMethod()]
        public void GetAttachmentFiles()
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
            var result4 = context.Runspace.InvokeCommand<AttachmentFile>(
                "Get-KshAttachmentFile",
                new Dictionary<string, object>()
                {
                    { "ListItem", result3.ElementAt(0) }
                }
            );
            var actual = result3.ToArray();
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void GetAttachmentFileByIdentity()
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
            var result4 = context.Runspace.InvokeCommand<AttachmentFile>(
                "Get-KshAttachmentFile",
                new Dictionary<string, object>()
                {
                    { "ListItem", result3.ElementAt(0) },
                    { "FileName", context.AppSettings["AttachmentFile1Name"] }
                }
            );
            var result5 = context.Runspace.InvokeCommand<AttachmentFile>(
                "Get-KshAttachmentFile",
                new Dictionary<string, object>()
                {
                    { "Identity", result4.ElementAt(0) }
                }
            );
            var actual = result5.ElementAt(0);
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void GetAttachmentFileByFileName()
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
            var result4 = context.Runspace.InvokeCommand<AttachmentFile>(
                "Get-KshAttachmentFile",
                new Dictionary<string, object>()
                {
                    { "ListItem", result3.ElementAt(0) },
                    { "FileName", context.AppSettings["AttachmentFile1Name"] }
                }
            );
            var actual = result4.ElementAt(0);
            Assert.IsNotNull(actual);
        }

    }

}
