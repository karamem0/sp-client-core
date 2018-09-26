//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Core.Tests
{

    [TestClass()]
    [TestCategory("App")]
    public class GetAppCatalogUrlCommandTests
    {

        [TestMethod()]
        public void GetTenantAppCatalogUrl()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<string>(
                    "Get-SPAppCatalogUrl",
                    new Dictionary<string, object>()
                    {
                        { "Scope", "Tenant" }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetSiteCollectionAppCatalogUrl()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<string>(
                    "Get-SPAppCatalogUrl",
                    new Dictionary<string, object>()
                    {
                        { "Scope", "SiteCollection" }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

    }

}
