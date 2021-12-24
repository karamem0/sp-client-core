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
    [TestCategory("Remove-KshSiteCollectionApp")]
    public class RemoveSiteCollectionAppCommandTests
    {

        [TestMethod()]
        public void RemoveApp()
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
            var result2 = context.Runspace.InvokeCommand<App>(
                "Add-KshSiteCollectionApp",
                new Dictionary<string, object>()
                {
                    { "Content", System.IO.File.OpenRead(context.AppSettings["App0Path"]) },
                    { "FileName", "TestApp0.sppkg" },
                    { "Overwrite", false }
                }
            );
            var result3 = context.Runspace.InvokeCommand(
                "Remove-KshSiteCollectionApp",
                new Dictionary<string, object>()
                {
                    { "Identity", result2.ElementAt(0) }
                }
            );
        }

    }

}
