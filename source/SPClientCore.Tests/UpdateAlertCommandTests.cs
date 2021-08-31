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
    [TestCategory("Update-KshAlert")]
    public class UpdateAlertCommandTests
    {

        [TestMethod()]
        public void UpdateAlert()
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
                var result3 = context.Runspace.InvokeCommand<User>(
                    "Get-KshUser",
                    new Dictionary<string, object>()
                    {
                        { "UserId", context.AppSettings["User1Id"] }
                    }
                );
                var result4 = context.Runspace.InvokeCommand<Alert>(
                    "New-KshAlert",
                    new Dictionary<string, object>()
                    {
                        { "AlertFrequency", "Immediate" },
                        { "AlertType", "List" },
                        { "List", result2.ElementAt(0) },
                        { "User", result3.ElementAt(0) }
                    }
                );
                var result5 = context.Runspace.InvokeCommand<Alert>(
                    "Update-KshAlert",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result4.ElementAt(0) },
                        { "AlertFrequency", "Daily" },
                        { "AlertTime", DateTime.UtcNow.Date },
                        { "AlwaysNotify", true },
                        { "DeliveryChannels", "Email" },
                        { "Filter", "<Query><Eq><FieldRef Name='ID'/><Value Type='Number'>1</Value></Eq></Query>" },
                        { "Status", "Off" },
                        { "Title", "Test Alert 9" },
                        { "PassThru", true }
                    }
                );
                var result6 = context.Runspace.InvokeCommand(
                    "Remove-KshAlert",
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
