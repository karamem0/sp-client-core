//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/spclientcore/blob/master/LICENSE
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
    [TestCategory("Unpublish-KshTenantApp")]
    public class UnpublishTenantAppCommandTests
    {

        [TestMethod()]
        public void UnpublishApp()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand(
                    "Connect-KshSite",
                    new Dictionary<string, object>()
                    {
                        { "Url", context.AppSettings["TenantAppCatalogUrl"] },
                        { "Credential", PSCredentialFactory.CreateCredential(
                            context.AppSettings["LoginUserName"],
                            context.AppSettings["LoginPassword"])
                        }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<App>(
                    "New-KshTenantApp",
                    new Dictionary<string, object>()
                    {
                        { "Content", System.IO.File.OpenRead(context.AppSettings["App0Path"]) },
                        { "FileName", "TestApp0.sppkg" },
                        { "Overwrite", false }
                    }
                );
                var result3 = context.Runspace.InvokeCommand(
                    "Publish-KshTenantApp",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result2.ElementAt(0) }
                    }
                );
                var result4 = context.Runspace.InvokeCommand(
                    "Unpublish-KshTenantApp",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result2.ElementAt(0) }
                    }
                );
                var result5 = context.Runspace.InvokeCommand<App>(
                    "Get-KshTenantApp",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result2.ElementAt(0) }
                    }
                );
                var result6 = context.Runspace.InvokeCommand(
                    "Remove-KshTenantApp",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result5.ElementAt(0) }
                    }
                );
                var actual = result5.ElementAt(0);
            }
        }

    }

}
