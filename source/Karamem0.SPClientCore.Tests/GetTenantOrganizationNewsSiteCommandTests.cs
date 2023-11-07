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
    public class GetTenantOrganizationNewsSiteCommandTests
    {

        [TestMethod()]
        public void GetOrganizationNewsSites()
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
                "Add-KshTenantSiteCollection",
                new Dictionary<string, object>()
                {
                    { "Owner", context.AppSettings["LoginUserName"] },
                    { "Template", "SITEPAGEPUBLISHING#0" },
                    { "Url", context.AppSettings["AuthorityUrl"] + "/sites/TestSite0" }
                }
            );
            var result3 = context.Runspace.InvokeCommand(
                "Add-KshTenantOrganizationNewsSite",
                new Dictionary<string, object>()
                {
                    { "Url", result2.ElementAt(0).Url }
                }
            );
            var result4 = context.Runspace.InvokeCommand<string>(
                "Get-KshTenantOrganizationNewsSite",
                new Dictionary<string, object>()
                {
                }
            );
            var result5 = context.Runspace.InvokeCommand(
                "Remove-KshTenantOrganizationNewsSite",
                new Dictionary<string, object>()
                {
                    { "Url", result2.ElementAt(0).Url }
                }
            );
            var result6 = context.Runspace.InvokeCommand(
                "Remove-KshTenantSiteCollection",
                new Dictionary<string, object>()
                {
                    { "Identity", result2.ElementAt(0) }
                }
            );
            var result7 = context.Runspace.InvokeCommand<TenantDeletedSiteCollection>(
                "Get-KshTenantDeletedSiteCollection",
                new Dictionary<string, object>()
                {
                    { "SiteCollectionUrl", result2.ElementAt(0).Url }
                }
            );
            var result8 = context.Runspace.InvokeCommand(
                "Remove-KshTenantDeletedSiteCollection",
                new Dictionary<string, object>()
                {
                    { "Identity", result7.ElementAt(0) }
                }
            );
            var actual = result4.ElementAt(0);
            Assert.IsNotNull(actual);
        }

    }

}
