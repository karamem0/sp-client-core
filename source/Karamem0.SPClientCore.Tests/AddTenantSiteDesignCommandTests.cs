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
    public class AddTenantSiteDesignCommandTests
    {

        [TestMethod()]
        public void AddSiteDesign()
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
            var result2 = context.Runspace.InvokeCommand<TenantSiteDesign>(
                "Add-KshTenantSiteDesign",
                new Dictionary<string, object>()
                {
                    { "Description", "Test Site Design 0" },
                    { "DesignPackageId", Guid.Empty },
                    { "IsDefault", false },
                    { "PreviewImageAltText", null },
                    { "PreviewImageUrl", null },
                    { "SiteScriptIds", new[] { context.AppSettings["SiteScript1Id"] } },
                    { "SiteTemplate", null },
                    { "ThumbnailUrl", null },
                    { "Title", "Test Site Design 0" },
                }
            );
            var result3 = context.Runspace.InvokeCommand(
                "Remove-KshTenantSiteDesign",
                new Dictionary<string, object>()
                {
                    { "Identity", result2.ElementAt(0) }
                }
            );
            var actual = result2.ElementAt(0);
            Assert.IsNotNull(actual);
        }

    }

}
