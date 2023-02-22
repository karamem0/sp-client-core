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
    public class AddSiteCommandTests
    {

        [TestMethod()]
        public void AddSite()
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
                "Add-KshSite",
                new Dictionary<string, object>()
                {
                    { "Description", "Test Site 0 Description" },
                    { "Lcid", 1033 },
                    { "ServerRelativeUrl", "TestSite0" },
                    { "Template", "SITEPAGEPUBLISHING#0" },
                    { "Title", "Test Site 0" },
                    { "UseSamePermissionsAsParentSite", true }
                }
            );
            var result3 = context.Runspace.InvokeCommand(
                "Remove-KshSite",
                new Dictionary<string, object>()
                {
                    { "Identity", result2.ElementAt(0) }
                }
            );
            var actual = result2.ElementAt(0);
        }

    }

}
