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
    public class GetTenantPersonalSiteCommandTests
    {

        [TestMethod()]
        public void GetPersonalSiteByUser()
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
                "Get-KshTenantUser",
                new Dictionary<string, object>()
                {
                    { "SiteCollection", result2.ElementAt(0) },
                    { "UserId", context.AppSettings["User1Id"] }
                }
            );
            var result4 = context.Runspace.InvokeCommand<string>(
                "Get-KshTenantPersonalSite",
                new Dictionary<string, object>()
                {
                    { "User", result3.ElementAt(0) }
                }
            );
            var actual = result2.ElementAt(0);
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void GetPersonalSiteByUserId()
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
            var result2 = context.Runspace.InvokeCommand<string>(
                "Get-KshTenantPersonalSite",
                new Dictionary<string, object>()
                {
                    { "UserId", context.AppSettings["User1Email"] }
                }
            );
            var actual = result2.ElementAt(0);
            Assert.IsNotNull(actual);
        }

    }

}
