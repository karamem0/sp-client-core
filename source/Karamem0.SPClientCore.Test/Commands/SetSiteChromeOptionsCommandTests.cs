//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Test.Utility;
using NUnit.Framework;

namespace Karamem0.SharePoint.PowerShell.Commands.Test;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class SetSiteChromeOptionsCommandTests
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
                ["PrivateKey"] = Convert.FromBase64String(context.AppSettings["PrivateKey"])
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshSiteChromeOptions",
            new Dictionary<string, object>()
            {
                ["HeaderLayout"] = 2,
                ["HeaderEmphasis"] = 0,
                ["MegaMenuEnabled"] = false,
                ["FooterEnabled"] = false,
                ["FooterLayout"] = 0,
                ["FooterEmphasis"] = 0,
                ["HideTitleInHeader"] = false,
                ["LogoAlignment"] = 0,
                ["FooterAlignment"] = 0,
                ["FooterOverlayColor"] = -1,
                ["FooterOverlayOpacity"] = 0,
                ["FooterOverlayGradientDirection"] = 0,
                ["HeaderOverlayColor"] = -1,
                ["HeaderOverlayOpacity"] = 0,
                ["HeaderOverlayGradientDirection"] = 0,
                ["FontOptionForSiteTitle"] = null,
                ["FontOptionForSiteNav"] = null,
                ["FontOptionForSiteFooterTitle"] = null,
                ["FontOptionForSiteFooterNav"] = null,
                ["HorizontalQuickLaunch"] = false,
                ["HeaderColorIndexInLightMode"] = -1,
                ["HeaderColorIndexInDarkMode"] = -1,
                ["FooterColorIndexInLightMode"] = -1,
                ["FooterColorIndexInDarkMode"] = -1
            }
        );
    }

}
