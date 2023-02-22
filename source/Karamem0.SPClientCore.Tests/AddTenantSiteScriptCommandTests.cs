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
    public class AddTenantSiteScriptCommandTests
    {

        [TestMethod()]
        public void AddSiteScript()
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
            var result2 = context.Runspace.InvokeCommand<TenantSiteScript>(
                "Add-KshTenantSiteScript",
                new Dictionary<string, object>()
                {
                    { "Content", "{\"actions\":[{\"verb\":\"createSPList\",\"listName\":\"Test List 0\",\"templateType\":101,\"subactions\":[]}]}" },
                    { "Title", "Test Site Script 0" }
                }
            );
            var result3 = context.Runspace.InvokeCommand<HubSite>(
                "Remove-KshTenantSiteScript",
                new Dictionary<string, object>()
                {
                    { "Identity", result2.ElementAt(0) }
                }
            );
            var actual = result2.ElementAt(0);
        }

    }

}
