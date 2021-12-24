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
    [TestCategory("Remove-KshSubscription")]
    public class RemoveSubscriptionCommandTests
    {

        [TestMethod()]
        public void RemoveSubscription()
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
            var result2 = context.Runspace.InvokeCommand<List>(
                "Get-KshList",
                new Dictionary<string, object>()
                {
                    { "ListId", context.AppSettings["List1Id"] }
                }
            );
            var result3 = context.Runspace.InvokeCommand<Subscription>(
                "Add-KshSubscription",
                new Dictionary<string, object>()
                {
                    { "List", result2.ElementAt(0) },
                    { "NotificationUrl", "https://prod-25.southeastasia.logic.azure.com/workflows/e9ff38cb65b448b19ebef87a615d7d5b/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=S3zpdmaFJ2HXhLVqsP1tPdbA9MEztwY5KjEDcSLO-tg" },
                    { "ExpirationDateTime", DateTime.UtcNow.AddDays(1) }
                }
            );
            var result4 = context.Runspace.InvokeCommand(
                "Remove-KshSubscription",
                new Dictionary<string, object>()
                {
                    { "Identity", result3.ElementAt(0) }
                }
            );
        }

    }

}
