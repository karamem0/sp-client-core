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
    public class GetViewCommandTests
    {

        [TestMethod()]
        public void GetViews()
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
            var result3 = context.Runspace.InvokeCommand<View>(
                "Get-KshView",
                new Dictionary<string, object>()
                {
                    { "List", result2.ElementAt(0) }
                }
            );
            var actual = result3.ToArray();
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void GetViewByIdentity()
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
            var result3 = context.Runspace.InvokeCommand<View>(
                "Get-KshView",
                new Dictionary<string, object>()
                {
                    { "List", result2.ElementAt(0) },
                    { "ViewId", context.AppSettings["View1Id"] }
                }
            );
            var result4 = context.Runspace.InvokeCommand<View>(
                "Get-KshView",
                new Dictionary<string, object>()
                {
                    { "Identity", result3.ElementAt(0) }
                }
            );
            var actual = result4.ElementAt(0);
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void GetViewById()
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
            var result3 = context.Runspace.InvokeCommand<View>(
                "Get-KshView",
                new Dictionary<string, object>()
                {
                    { "List", result2.ElementAt(0) },
                    { "ViewId", context.AppSettings["View1Id"] }
                }
            );
            var actual = result3.ElementAt(0);
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void GetViewByTitle()
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
            var result3 = context.Runspace.InvokeCommand<View>(
                "Get-KshView",
                new Dictionary<string, object>()
                {
                    { "List", result2.ElementAt(0) },
                    { "ViewTitle", context.AppSettings["View1Title"] }
                }
            );
            var actual = result3.ElementAt(0);
            Assert.IsNotNull(actual);
        }

    }

}
