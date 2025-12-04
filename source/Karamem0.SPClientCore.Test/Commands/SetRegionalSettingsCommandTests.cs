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
public class SetRegionalSettingsCommandTests
{

    [Test()]
    public void InvokeCommand_SetItem_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<Site>(
            "Add-KshSite",
            new Dictionary<string, object>()
            {
                ["Description"] = "Test Site 0 Description",
                ["ServerRelativeUrl"] = "TestSite0",
                ["Title"] = "Test Site 0"
            }
        );
        var result2 = context.Runspace.InvokeCommand<Site>(
            "Select-KshSite",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["PassThru"] = true
            }
        );
        var result3 = context.Runspace.InvokeCommand<RegionalSettings>(
            "Get-KshRegionalSettings",
            new Dictionary<string, object>()
            {
            }
        );
        var result4 = context.Runspace.InvokeCommand<RegionalSettings>(
            "Set-KshRegionalSettings",
            new Dictionary<string, object>()
            {
                ["AdjustHijriDays"] = 1,
                ["AlternateCalendarType"] = 1,
                ["CalendarType"] = 1,
                ["Collation"] = 1,
                ["FirstDayOfWeek"] = 1,
                ["FirstWeekOfYear"] = 1,
                ["Lcid"] = 1041,
                ["ShowWeeks"] = true,
                ["Time24"] = true,
                ["TimeZone"] = result3[0]
                    .TimeZones.FirstOrDefault(),
                ["WorkDayEndHour"] = 60,
                ["WorkDays"] = 1,
                ["WorkDayStartHour"] = 60,
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshSite",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0]
            }
        );
        var actual = result4[0];
        Assert.That(actual, Is.Not.Null);
    }

}
