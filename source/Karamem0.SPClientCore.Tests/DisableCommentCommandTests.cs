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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests
{

    [TestClass()]
    public class DisableCommentCommandTests
    {

        [TestMethod()]
        public void DisableComment()
        {
            using var context = new PSCmdletContext();
            var result1 = context.Runspace.InvokeCommand(
                "Connect-KshSite",
                new Dictionary<string, object>()
                {
                    { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"] },
                    { "Credential", PSCredentialFactory.CreateCredential(
                        context.AppSettings["LoginUserName"],
                        context.AppSettings["LoginPassword"])
                    }
                }
            );
            var result2 = context.Runspace.InvokeCommand<File>(
                "Get-KshFile",
                new Dictionary<string, object>()
                {
                    { "FileUrl", context.AppSettings["SitePage1Url"] }
                }
            );
            var result3 = context.Runspace.InvokeCommand<ListItem>(
                "Get-KshListItem",
                new Dictionary<string, object>()
                {
                    { "File", result2.ElementAt(0) }
                }
            );
            var result4 = context.Runspace.InvokeCommand(
                "Disable-KshComment",
                new Dictionary<string, object>()
                {
                    { "Identity", result3.ElementAt(0) }
                }
            );
            var result5 = context.Runspace.InvokeCommand<ListItem>(
                "Get-KshListItem",
                new Dictionary<string, object>()
                {
                    { "File", result2.ElementAt(0) }
                }
            );
            var actual = result5.ElementAt(0);
            Assert.IsNotNull(actual);
        }

    }

}
