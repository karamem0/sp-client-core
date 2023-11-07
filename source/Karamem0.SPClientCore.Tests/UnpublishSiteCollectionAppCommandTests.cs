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
    public class UnpublishSiteCollectionAppCommandTests
    {

        [TestMethod()]
        public void UnpublishApp()
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
                "Publish-KshSiteCollectionApp",
                new Dictionary<string, object>()
                {
                    { "Identity", result2.ElementAt(0) }
                }
            );
            var result4 = context.Runspace.InvokeCommand(
                "Unpublish-KshSiteCollectionApp",
                new Dictionary<string, object>()
                {
                    { "Identity", result2.ElementAt(0) }
                }
            );
            var result5 = context.Runspace.InvokeCommand<App>(
                "Get-KshSiteCollectionApp",
                new Dictionary<string, object>()
                {
                    { "Identity", result2.ElementAt(0) }
                }
            );
            var result6 = context.Runspace.InvokeCommand(
                "Remove-KshSiteCollectionApp",
                new Dictionary<string, object>()
                {
                    { "Identity", result5.ElementAt(0) }
                }
            );
            var actual = result5.ElementAt(0);
            Assert.IsNotNull(actual);
        }

    }

}
