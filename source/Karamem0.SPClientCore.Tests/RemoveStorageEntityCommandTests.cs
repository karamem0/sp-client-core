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
    [TestCategory("Remove-KshStorageEntity")]
    public class RemoveStorageEntityTests
    {

        [TestMethod()]
        public void RemoveStorageEntity()
        {
            using var context = new PSCmdletContext();
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
            var result2 = context.Runspace.InvokeCommand(
                "Add-KshStorageEntity",
                new Dictionary<string, object>()
                {
                    { "Key", "Test Entity 0" },
                    { "Value", "Test Value 0" }
                }
            );
            var result3 = context.Runspace.InvokeCommand(
                "Remove-KshStorageEntity",
                new Dictionary<string, object>()
                {
                    { "Key", "Test Entity 0" }
                }
            );
        }

    }

}
