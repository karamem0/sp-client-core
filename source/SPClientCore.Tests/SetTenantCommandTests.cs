//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Tests.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests
{

    [TestClass()]
    [TestCategory("Set-KshTenant")]
    public class SetTenantCommandTests
    {

        [TestMethod()]
        public void SetTenant()
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
                var result2 = context.Runspace.InvokeCommand(
                    "Set-KshTenant",
                    new Dictionary<string, object>()
                    {
                        { "DisplayStartASiteOption", true },
                        { "ExternalServicesEnabled", true },
                        // { "MaxCompatibilityLevel", 0 },
                        // { "MinCompatibilityLevel", 0 },
                        { "NoAccessRedirectUrl", null },
                        { "OfficeClientAdalDisabled", false },
                        { "ProvisionSharedWithEveryoneFolder", false },
                        { "RequireAcceptingAccountMatchInvitedAccount", false },
                        { "SearchResolveExactEmailOrUpn", false },
                        { "SharingCapability", "ExternalUserAndGuestSharing" },
                        { "ShowAllUsersClaim", false },
                        { "ShowEveryoneClaim", false },
                        { "ShowEveryoneExceptExternalUsersClaim", true },
                        { "SignInAccelerationDomain", null },
                        { "StartASiteFormUrl", null },
                        { "UsePersistentCookiesForExplorerView", false }
                    }
                );
            }
        }

    }

}
