//
// Copyright (c) 2018-2025 karamem0
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
public class GetSubscriptionCommandTests
{

    [Test()]
    public void InvokeCommand_GetAll_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"] },
                { "ClientId", context.AppSettings["ClientId"] },
                { "CertificatePath", context.AppSettings["CertificatePath"] },
                { "CertificatePassword", context.AppSettings["CertificatePassword"].ToSecureString() }
            }
        );
        var result1 = context.Runspace.InvokeCommand<List>(
            "Get-KshList",
            new Dictionary<string, object>()
            {
                { "ListId", context.AppSettings["List1Id"] }
            }
        );
        var result2 = context.Runspace.InvokeCommand<Subscription>(
            "Get-KshSubscription",
            new Dictionary<string, object>()
            {
                { "List", result1.ElementAt(0) }
            }
        );
        var actual = result2.ToArray();
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_GetByIdentity_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"] },
                { "ClientId", context.AppSettings["ClientId"] },
                { "CertificatePath", context.AppSettings["CertificatePath"] },
                { "CertificatePassword", context.AppSettings["CertificatePassword"].ToSecureString() }
            }
        );
        var result1 = context.Runspace.InvokeCommand<List>(
            "Get-KshList",
            new Dictionary<string, object>()
            {
                { "ListId", context.AppSettings["List1Id"] }
            }
        );
        var result2 = context.Runspace.InvokeCommand<Subscription>(
            "Add-KshSubscription",
            new Dictionary<string, object>()
            {
                { "List", result1.ElementAt(0) },
                { "NotificationUrl", "https://prod-27.southeastasia.logic.azure.com:443/workflows/e0484ceabd3047589d7e2918850edc19/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=czHX2Z5ZeAwjttKjZLqcZgs095WwJqirWY84jIsFLvI" },
                { "ExpirationDateTime", DateTime.UtcNow.AddDays(1) }
            }
        );
        var result3 = context.Runspace.InvokeCommand<Subscription>(
            "Get-KshSubscription",
            new Dictionary<string, object>()
            {
                { "List", result1.ElementAt(0) },
                { "SubscriptionId", result2.ElementAt(0).Id }
            }
        );
        var result4 = context.Runspace.InvokeCommand<Subscription>(
            "Get-KshSubscription",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshSubscription",
            new Dictionary<string, object>()
            {
                { "Identity", result4.ElementAt(0) }
            }
        );
        var actual = result4.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_GetBySubscriptionId_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"] },
                { "ClientId", context.AppSettings["ClientId"] },
                { "CertificatePath", context.AppSettings["CertificatePath"] },
                { "CertificatePassword", context.AppSettings["CertificatePassword"].ToSecureString() }
            }
        );
        var result1 = context.Runspace.InvokeCommand<List>(
            "Get-KshList",
            new Dictionary<string, object>()
            {
                { "ListId", context.AppSettings["List1Id"] }
            }
        );
        var result2 = context.Runspace.InvokeCommand<Subscription>(
            "Add-KshSubscription",
            new Dictionary<string, object>()
            {
                { "List", result1.ElementAt(0) },
                { "NotificationUrl", "https://prod-27.southeastasia.logic.azure.com:443/workflows/e0484ceabd3047589d7e2918850edc19/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=czHX2Z5ZeAwjttKjZLqcZgs095WwJqirWY84jIsFLvI" },
                { "ExpirationDateTime", DateTime.UtcNow.AddDays(1) }
            }
        );
        var result3 = context.Runspace.InvokeCommand<Subscription>(
            "Get-KshSubscription",
            new Dictionary<string, object>()
            {
                { "List", result1.ElementAt(0) },
                { "SubscriptionId", result2.ElementAt(0).Id }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshSubscription",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}
