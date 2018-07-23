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
    [TestCategory("CatalogApp")]
    public class NewCatalogAppCommandTests
    {

        [TestMethod()]
        public void CreateSiteCatalogApp()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand(
                    "Select-SPWeb",
                    new Dictionary<string, object>()
                    {
                        { "Web", context.AppSettings["SiteUrl"] }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<CatalogApp>(
                    "New-SPCatalogApp",
                    new Dictionary<string, object>()
                    {
                        { "Name", "SharePointAddIn0.sppkg" },
                        { "Content", new System.IO.MemoryStream(System.IO.File.ReadAllBytes(context.AppSettings["App0Path"])) },
                        { "Overwrite", true },
                        { "Scope", "Site" }
                    }
                );
                var result3 = context.Runspace.InvokeCommand(
                    "Remove-SPCatalogApp",
                    new Dictionary<string, object>()
                    {
                        { "CatalogApp", result2.ElementAt(0).Id },
                        { "Scope", "Site" }
                    }
                );
                var actual = result2.ElementAt(0);
            }
        }

    }

}
