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
    public class GetTenantSiteCollectionCommandTests
    {

        [TestMethod()]
        public void GetTenantSiteCollections()
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
                }
            );
            var actual = result2.ToArray();
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void GetTenantSiteCollectionsByFilter()
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
                    { "GroupIdDefined", false },
                    { "IncludePersonalSite", true },
                    { "Template", "SPSPERS#10" }
                }
            );
            var actual = result2.ToArray();
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void GetTenantSiteCollectionByIdentity()
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
            var result3 = context.Runspace.InvokeCommand<TenantSiteCollection>(
                "Get-KshTenantSiteCollection",
                new Dictionary<string, object>()
                {
                    { "Identity", result2.ElementAt(0) }
                }
            );
            var actual = result2.ElementAt(0);
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void GetTenantSiteCollectionByUrl()
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
            var actual = result2.ElementAt(0);
            Assert.IsNotNull(actual);
        }

    }

}
