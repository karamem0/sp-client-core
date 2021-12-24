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
    [TestCategory("Select-KshSite")]
    public class SelectSiteCommandTests
    {

        [TestMethod()]
        public void SelectSite()
        {
            using var context = new PSCmdletContext();
            var result1 = context.Runspace.InvokeCommand(
                "Connect-KshSite",
                new Dictionary<string, object>()
                {
                    { "Url", context.AppSettings["BaseUrl"] },
                    { "Credential", PSCredentialFactory.CreateCredential(
                        context.AppSettings["LoginUserName"],
                        context.AppSettings["LoginPassword"])
                    }
                }
            );
            var result2 = context.Runspace.InvokeCommand<Site>(
                "Get-KshSite",
                new Dictionary<string, object>()
                {
                    { "SiteId", context.AppSettings["Site1Id"] }
                }
            );
            var result3 = context.Runspace.InvokeCommand<Site>(
                "Select-KshSite",
                new Dictionary<string, object>()
                {
                    { "Identity", result2.ElementAt(0) },
                    { "PassThru", true }
                }
            );
            var actual = result3.ElementAt(0);
        }

    }

}
