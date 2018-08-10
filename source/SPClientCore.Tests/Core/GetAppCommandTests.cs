//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.Core;
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
    public class GetAppCommandTests
    {

        [TestMethod()]
        public void GetSiteCollectionApp()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<CorporateCatalogAppMetadata>(
                    "Get-SPApp",
                    new Dictionary<string, object>()
                    {
                        { "App", context.AppSettings["App1Id"] },
                        { "Scope", "SiteCollection" }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

    }

}
