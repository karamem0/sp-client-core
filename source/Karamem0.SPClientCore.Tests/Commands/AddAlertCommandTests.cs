//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Tests.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands.Tests;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class AddAlertCommandTests
{

    [Test()]
    public void AddListAlert()
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
        var result3 = context.Runspace.InvokeCommand<User>(
            "Get-KshUser",
            new Dictionary<string, object>()
            {
                { "UserId", context.AppSettings["User1Id"] }
            }
        );
        var result4 = context.Runspace.InvokeCommand<Alert>(
            "Add-KshAlert",
            new Dictionary<string, object>()
            {
                { "AlertFrequency", "Daily" },
                { "AlertTemplateName", "SPAlertTemplateType.GenericList" },
                { "AlertTime", DateTime.UtcNow.Date },
                { "AlertType", "List" },
                { "AlwaysNotify", true },
                { "DeliveryChannels", "Email" },
                { "EventType", "All" },
                { "Filter", "" },
                { "List", result2.ElementAt(0) },
                { "Properties", new Dictionary<string, string>()
                    {
                        { "siteurl", context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"] }
                    }
                },
                { "Status", "On" },
                { "Title", "Test Alert 0" },
                { "User", result3.ElementAt(0) }
            }
        );
        var result5 = context.Runspace.InvokeCommand(
            "Remove-KshAlert",
            new Dictionary<string, object>()
            {
                { "Identity", result4.ElementAt(0) }
            }
        );
        var actual = result4.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void AddListItemAlert()
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
        var result3 = context.Runspace.InvokeCommand<ListItem>(
            "Get-KshListItem",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "ItemId", context.AppSettings["ListItem1Id"] }
            }
        );
        var result4 = context.Runspace.InvokeCommand<User>(
            "Get-KshUser",
            new Dictionary<string, object>()
            {
                { "UserId", context.AppSettings["User1Id"] }
            }
        );
        var result5 = context.Runspace.InvokeCommand<Alert>(
            "Add-KshAlert",
            new Dictionary<string, object>()
            {
                { "AlertFrequency", "Daily" },
                { "AlertTemplateName", "SPAlertTemplateType.GenericList" },
                { "AlertTime", DateTime.UtcNow.Date },
                { "AlertType", "ListItem" },
                { "AlwaysNotify", true },
                { "DeliveryChannels", "Email" },
                { "EventType", "All" },
                { "Filter", "" },
                { "List", result2.ElementAt(0) },
                { "ListItem", result3.ElementAt(0) },
                { "Properties", new Dictionary<string, string>()
                    {
                        { "siteurl", context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"] }
                    }
                },
                { "Status", "On" },
                { "Title", "Test Alert 0" },
                { "User", result4.ElementAt(0) }
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
        Assert.That(actual, Is.Not.Null);
    }

}
