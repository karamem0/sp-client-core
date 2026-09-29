//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System.Management.Automation;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Set, "SiteChromeOptions")]
[OutputType(typeof(void))]
public class SetSiteChromeOptionsCommand : ClientObjectCmdlet<ISiteChromeOptionsService>
{

    [Parameter(Mandatory = false)]
    public HeaderLayoutType HeaderLayout { get; private set; }

    [Parameter(Mandatory = false)]
    public VariantThemeType HeaderEmphasis { get; private set; }

    [Parameter(Mandatory = false)]
    public bool MegaMenuEnabled { get; private set; }

    [Parameter(Mandatory = false)]
    public bool FooterEnabled { get; private set; }

    [Parameter(Mandatory = false)]
    public FooterLayoutType FooterLayout { get; private set; }

    [Parameter(Mandatory = false)]
    public FooterVariantThemeType FooterEmphasis { get; private set; }

    [Parameter(Mandatory = false)]
    public bool HideTitleInHeader { get; private set; }

    [Parameter(Mandatory = false)]
    public LogoAlignment LogoAlignment { get; private set; }

    [Parameter(Mandatory = false)]
    public int FooterAlignment { get; private set; }

    [Parameter(Mandatory = false)]
    public int FooterOverlayColor { get; private set; }

    [Parameter(Mandatory = false)]
    public int FooterOverlayOpacity { get; private set; }

    [Parameter(Mandatory = false)]
    public int FooterOverlayGradientDirection { get; private set; }

    [Parameter(Mandatory = false)]
    public int HeaderOverlayColor { get; private set; }

    [Parameter(Mandatory = false)]
    public int HeaderOverlayOpacity { get; private set; }

    [Parameter(Mandatory = false)]
    public int HeaderOverlayGradientDirection { get; private set; }

    [Parameter(Mandatory = false)]
    public string? FontOptionForSiteTitle { get; private set; }

    [Parameter(Mandatory = false)]
    public string? FontOptionForSiteNav { get; private set; }

    [Parameter(Mandatory = false)]
    public string? FontOptionForSiteFooterTitle { get; private set; }

    [Parameter(Mandatory = false)]
    public string? FontOptionForSiteFooterNav { get; private set; }

    [Parameter(Mandatory = false)]
    public bool HorizontalQuickLaunch { get; private set; }

    [Parameter(Mandatory = false)]
    public int HeaderColorIndexInLightMode { get; private set; }

    [Parameter(Mandatory = false)]
    public int HeaderColorIndexInDarkMode { get; private set; }

    [Parameter(Mandatory = false)]
    public int FooterColorIndexInLightMode { get; private set; }

    [Parameter(Mandatory = false)]
    public int FooterColorIndexInDarkMode { get; private set; }

    protected override async Task ProcessRecordAsync()
    {
        await this.Service.SetObjectAsync(this.MyInvocation.BoundParameters);
    }

}
