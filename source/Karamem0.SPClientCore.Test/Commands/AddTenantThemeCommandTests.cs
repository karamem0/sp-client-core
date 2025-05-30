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
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands.Test;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class AddTenantThemeCommandTests
{

    [Test()]
    public void InvokeCommand_AddItem_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["AdminUrl"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKeyPath"] = context.AppSettings["PrivateKeyPath"]
            }
        );
        var result1 = context.Runspace.InvokeCommand<TenantTheme>(
            "Add-KshTenantTheme",
            new Dictionary<string, object>()
            {
                ["IsInverted"] = true,
                ["Name"] = "Test Theme 0",
                ["Palette"] = new Hashtable()
                {
                    ["themePrimary"] = "#0078d4",
                    ["themeLighterAlt"] = "#eff6fc",
                    ["themeLighter"] = "#deecf9",
                    ["themeLight"] = "#c7e0f4",
                    ["themeTertiary"] = "#71afe5",
                    ["themeSecondary"] = "#2b88d8",
                    ["themeDarkAlt"] = "#106ebe",
                    ["themeDark"] = "#005a9e",
                    ["themeDarker"] = "#004578",
                    ["neutralLighterAlt"] = "#f8f8f8",
                    ["neutralLighter"] = "#f4f4f4",
                    ["neutralLight"] = "#eaeaea",
                    ["neutralQuaternaryAlt"] = "#dadada",
                    ["neutralQuaternary"] = "#d0d0d0",
                    ["neutralTertiaryAlt"] = "#c8c8c8",
                    ["neutralTertiary"] = "#c2c2c2",
                    ["neutralSecondary"] = "#858585",
                    ["neutralPrimaryAlt"] = "#4b4b4b",
                    ["neutralPrimary"] = "#333",
                    ["neutralDark"] = "#272727",
                    ["black"] = "#1d1d1d",
                    ["white"] = "#fff"
                }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshTenantTheme",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0]
            }
        );
        var actual = result1[0];
        Assert.That(actual, Is.Not.Null);
    }

}
