//
// Copyright (c) 2023 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Tests.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests
{

    [TestClass()]
    public class GetTenantSiteScriptFromSiteCommandTests
    {

        [TestMethod()]
        public void GetTenantSiteScriptFromSite()
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
                "Get-KshTenantSiteScriptFromSite",
                new Dictionary<string, object>()
                {
                    { "SiteUrl", context.AppSettings["BaseUrl"] },
                    { "IncludeBranding", true },
                    { "IncludedLists", null },
                    { "IncludeLinksToExportedItems", false },
                    { "IncludeRegionalSettings", false },
                    { "IncludeSiteExternalSharingCapability", false },
                    { "IncludeTheme", false },
                }
            );
            var actual = result2.ElementAt(0);
            Assert.IsNotNull(actual);
        }

    }

}
