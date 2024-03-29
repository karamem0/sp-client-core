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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests
{

    [TestClass()]
    public class GetTenantCdnEnabledCommandTests
    {

        [TestMethod()]
        public void GetTenantPublicCdnEnabled()
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
            var result2 = context.Runspace.InvokeCommand<bool>(
                "Get-KshTenantCdnEnabled",
                new Dictionary<string, object>()
                {
                    { "Public", true }
                }
            );
            var actual = result2.ElementAt(0);
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void GetTenantPrivateCdnEnabled()
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
            var result2 = context.Runspace.InvokeCommand<bool>(
                "Get-KshTenantCdnEnabled",
                new Dictionary<string, object>()
                {
                    { "Private", true }
                }
            );
            var actual = result2.ElementAt(0);
            Assert.IsNotNull(actual);
        }

    }

}
