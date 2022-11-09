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
    public class RemoveTenantSiteCollectionCommandTests
    {

        [TestMethod()]
        public void RemoveTenantSiteCollection()
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
                "Remove-KshTenantSiteCollection",
                new Dictionary<string, object>()
                {
                    { "Identity", result2.ElementAt(0) }
                }
            );
            var result4 = context.Runspace.InvokeCommand<TenantDeletedSiteCollection>(
                "Get-KshTenantDeletedSiteCollection",
                new Dictionary<string, object>()
                {
                    { "SiteCollectionUrl", result2.ElementAt(0).Url }
                }
            );
            var result5 = context.Runspace.InvokeCommand(
                "Remove-KshTenantDeletedSiteCollection",
                new Dictionary<string, object>()
                {
                    { "Identity", result4.ElementAt(0) }
                }
            );
        }

    }

}
