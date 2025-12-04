//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Test.Utility;
using NUnit.Framework;

namespace Karamem0.SharePoint.PowerShell.Commands.Test;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class AddAlertCommandTests
{

    [Test()]
    public void InvokeCommand_AddItemToList_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKeyPath"] = context.AppSettings["PrivateKeyPath"]
            }
        );
        var result1 = context.Runspace.InvokeCommand<List>(
            "Get-KshList",
            new Dictionary<string, object>()
            {
                ["ListId"] = context.AppSettings["List1Id"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<User>(
            "Get-KshUser",
            new Dictionary<string, object>()
            {
                ["UserId"] = context.AppSettings["User1Id"]
            }
        );
        var result3 = context.Runspace.InvokeCommand<Alert>(
            "Add-KshAlert",
            new Dictionary<string, object>()
            {
                ["AlertFrequency"] = "Daily",
                ["AlertTemplateName"] = "SPAlertTemplateType.GenericList",
                ["AlertTime"] = DateTime.UtcNow.Date,
                ["AlertType"] = "List",
                ["AlwaysNotify"] = true,
                ["DeliveryChannels"] = "Email",
                ["EventType"] = "All",
                ["Filter"] = "",
                ["List"] = result1[0],
                ["Properties"] = new Dictionary<string, string>()
                {
                    {
                        "siteurl", context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"]
                    }
                },
                ["Status"] = "On",
                ["Title"] = "Test Alert 0",
                ["User"] = result2[0]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshAlert",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3[0]
            }
        );
        var actual = result3[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_AddItemToListItem_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKeyPath"] = context.AppSettings["PrivateKeyPath"]
            }
        );
        var result1 = context.Runspace.InvokeCommand<List>(
            "Get-KshList",
            new Dictionary<string, object>()
            {
                ["ListId"] = context.AppSettings["List1Id"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<ListItem>(
            "Get-KshListItem",
            new Dictionary<string, object>()
            {
                ["List"] = result1[0],
                ["ItemId"] = context.AppSettings["ListItem1Id"]
            }
        );
        var result3 = context.Runspace.InvokeCommand<User>(
            "Get-KshUser",
            new Dictionary<string, object>()
            {
                ["UserId"] = context.AppSettings["User1Id"]
            }
        );
        var result4 = context.Runspace.InvokeCommand<Alert>(
            "Add-KshAlert",
            new Dictionary<string, object>()
            {
                ["AlertFrequency"] = "Daily",
                ["AlertTemplateName"] = "SPAlertTemplateType.GenericList",
                ["AlertTime"] = DateTime.UtcNow.Date,
                ["AlertType"] = "ListItem",
                ["AlwaysNotify"] = true,
                ["DeliveryChannels"] = "Email",
                ["EventType"] = "All",
                ["Filter"] = "",
                ["List"] = result1[0],
                ["ListItem"] = result2[0],
                ["Properties"] = new Dictionary<string, string>()
                {
                    {
                        "siteurl", context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"]
                    }
                },
                ["Status"] = "On",
                ["Title"] = "Test Alert 0",
                ["User"] = result3[0]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshAlert",
            new Dictionary<string, object>()
            {
                ["Identity"] = result4[0]
            }
        );
        var actual = result4[0];
        Assert.That(actual, Is.Not.Null);
    }

}
