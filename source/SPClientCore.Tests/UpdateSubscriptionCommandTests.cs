//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
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
    [TestCategory("Update-KshSubscription")]
    public class UpdateSubscriptionCommandTests
    {

        [TestMethod()]
        public void UpdateSubscription()
        {
            using (var context = new PSCmdletContext())
            {
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
                    "New-KshSubscription",
                    new Dictionary<string, object>()
                    {
                        { "List", result2.ElementAt(0) },
                        { "NotificationUrl", "https://pnp-functions.azurewebsites.net/api/spwebhookfunction" },
                        { "ExpirationDateTime", DateTime.UtcNow.AddDays(1) }
                    }
                );
                var result4 = context.Runspace.InvokeCommand<Subscription>(
                    "Update-KshSubscription",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result3.ElementAt(0) },
                        { "ExpirationDateTime", DateTime.UtcNow.AddDays(2) },
                        { "PassThru", true }
                    }
                );
                var result5 = context.Runspace.InvokeCommand(
                    "Remove-KshSubscription",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result4.ElementAt(0) }
                    }
                );
                var actual = result4.ElementAt(0);
            }
        }

    }

}
