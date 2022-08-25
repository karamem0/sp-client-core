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
    public class AddTenantUserCommandTests
    {

        [TestMethod()]
        public void AddUserBySiteCollection()
        {
            using var context = new PSCmdletContext();
            var result1 = context.Runspace.InvokeCommand(
                "Connect-KshSite",
                new Dictionary<string, object>()
                {
                    { "Url", context.AppSettings["AdminUrl"] },
                    { "Credential", PSCredentialFactory.CreateCredential(
                        context.AppSettings["LoginUserName"],
                        context.AppSettings["LoginPassword"])
                    }
                }
            );
            var result2 = context.Runspace.InvokeCommand<TenantSiteCollection>(
                "Get-KshTenantSiteCollection",
                new Dictionary<string, object>()
                {
                    { "SiteCollectionUrl", context.AppSettings["BaseUrl"] }
                }
            );
            var result3 = context.Runspace.InvokeCommand<User>(
                "Add-KshTenantUser",
                new Dictionary<string, object>()
                {
                    { "SiteCollection", result2.ElementAt(0) },
                    { "Email", "testuser000@" + context.AppSettings["LoginDomainName"] },
                    { "LoginName", "i:0#.f|membership|testuser000@" + context.AppSettings["LoginDomainName"] },
                    { "Title", "Test User 0" }
                }
            );
            var result4 = context.Runspace.InvokeCommand(
                "Remove-KshTenantUser",
                new Dictionary<string, object>()
                {
                    { "SiteCollection", result2.ElementAt(0) },
                    { "User", result3.ElementAt(0) }
                }
            );
            var actual = result3.ElementAt(0);
        }

        [TestMethod()]
        public void AddUserBySiteCollectionUrl()
        {
            using var context = new PSCmdletContext();
            var result1 = context.Runspace.InvokeCommand(
                "Connect-KshSite",
                new Dictionary<string, object>()
                {
                    { "Url", context.AppSettings["AdminUrl"] },
                    { "Credential", PSCredentialFactory.CreateCredential(
                        context.AppSettings["LoginUserName"],
                        context.AppSettings["LoginPassword"])
                    }
                }
            );
            var result2 = context.Runspace.InvokeCommand<User>(
                "Add-KshTenantUser",
                new Dictionary<string, object>()
                {
                    { "SiteCollectionUrl", context.AppSettings["BaseUrl"] },
                    { "Email", "testuser000@" + context.AppSettings["LoginDomainName"] },
                    { "LoginName", "i:0#.f|membership|testuser000@" + context.AppSettings["LoginDomainName"] },
                    { "Title", "Test User 0" }
                }
            );
            var result3 = context.Runspace.InvokeCommand(
                "Remove-KshTenantUser",
                new Dictionary<string, object>()
                {
                    { "SiteCollectionUrl", context.AppSettings["BaseUrl"] },
                    { "User", result2.ElementAt(0) }
                }
            );
            var actual = result2.ElementAt(0);
        }

    }

}
