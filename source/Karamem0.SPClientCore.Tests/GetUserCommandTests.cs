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
    public class GetUserCommandTests
    {

        [TestMethod()]
        public void GetUsers()
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
                "Get-KshUser",
                new Dictionary<string, object>()
                {
                }
            );
            var actual = result2.ToArray();
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void GetUserByIdentity()
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
                "Get-KshUser",
                new Dictionary<string, object>()
                {
                    { "UserId", context.AppSettings["User1Id"] }
                }
            );
            var result3 = context.Runspace.InvokeCommand<User>(
                "Get-KshUser",
                new Dictionary<string, object>()
                {
                    { "Identity", result2.ElementAt(0) }
                }
            );
            var actual = result3.ToArray();
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void GetUserByUserId()
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
                "Get-KshUser",
                new Dictionary<string, object>()
                {
                    { "UserId", context.AppSettings["User1Id"] }
                }
            );
            var actual = result2.ToArray();
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void GetUserByUserLoginName()
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
                "Get-KshUser",
                new Dictionary<string, object>()
                {
                    { "UserName", context.AppSettings["User1LoginName"] }
                }
            );
            var actual = result2.ToArray();
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void GetUserByUserEmail()
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
                "Get-KshUser",
                new Dictionary<string, object>()
                {
                    { "UserName", context.AppSettings["User1Email"] }
                }
            );
            var actual = result2.ToArray();
            Assert.IsNotNull(actual);
        }

    }

}
