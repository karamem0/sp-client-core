//
// Copyright (c) 2019 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Tests.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests
{

    [TestClass()]
    [TestCategory("Update-KshTenantSiteCollection")]
    public class UpdateTenantSiteCollectionCommandTests
    {

        [TestMethod()]
        public void UpdateTenantSiteCollection()
        {
            using (var context = new PSCmdletContext())
            {
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
                    "New-KshTenantSiteCollection",
                    new Dictionary<string, object>()
                    {
                        { "Owner", context.AppSettings["LoginUserName"] },
                        { "Template", "STS#0" },
                        { "Url", context.AppSettings["AuthorityUrl"] + "/sites/TestSite0" }
                    }
                );
                var result3 = context.Runspace.InvokeCommand<TenantSiteCollection>(
                    "Update-KshTenantSiteCollection",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result2.ElementAt(0) },
                        { "AllowDownloadingNonWebViewableFiles", true },
                        { "DisableAppViews", "NotDisabled" },
                        { "DisableCompanyWideSharingLinks", "NotDisabled" },
                        { "DisableFlows", "NotDisabled" },
                        { "Owner", context.AppSettings["User1Email"] },
                        { "PWAEnabled", "Enabled" },
                        { "RestrictedToRegion", "BlockFull" },
                        { "SandboxedCodeActivationCapability", "Enabled" },
                        { "StorageMaxLevel", 26214400 },
                        { "StorageWarningLevel", 25574400 },
                        { "Title", "Test Site 9" },
                        { "UserCodeMaxLevel", 300 },
                        { "UserCodeWarningLevel", 100 },
                        { "PassThru", true }
                    }
                );
                var result4 = context.Runspace.InvokeCommand(
                    "Remove-KshTenantSiteCollection",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result2.ElementAt(0) }
                    }
                );
                var result5 = context.Runspace.InvokeCommand<TenantDeletedSiteCollection>(
                    "Get-KshTenantDeletedSiteCollection",
                    new Dictionary<string, object>()
                    {
                        { "SiteCollectionUrl", result2.ElementAt(0).Url }
                    }
                );
                var result6 = context.Runspace.InvokeCommand(
                    "Remove-KshTenantDeletedSiteCollection",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result5.ElementAt(0) }
                    }
                );
                var actual = result3.ElementAt(0);
            }
        }

    }

}
