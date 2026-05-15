//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;

namespace Karamem0.SharePoint.PowerShell.Models.V1;

[JsonObject()]
public class ChromeOptionsRequestPayload : ClientValueObject
{

    [JsonProperty("headerLayout")]
    public virtual HeaderLayoutType HeaderLayout { get; protected set; }

    [JsonProperty("headerEmphasis")]
    public virtual VariantThemeType HeaderEmphasis { get; protected set; }

    [JsonProperty("megaMenuEnabled")]
    public virtual bool MegaMenuEnabled { get; protected set; }

    [JsonProperty("footerEnabled")]
    public virtual bool FooterEnabled { get; protected set; }

    [JsonProperty("footerLayout")]
    public virtual FooterLayoutType FooterLayout { get; protected set; }

    [JsonProperty("footerEmphasis")]
    public virtual FooterVariantThemeType FooterEmphasis { get; protected set; }

    [JsonProperty("hideTitleInHeader")]
    public virtual bool HideTitleInHeader { get; protected set; }

    [JsonProperty("logoAlignment")]
    public virtual LogoAlignment LogoAlignment { get; protected set; }

    [JsonProperty("footerAlignment")]
    public virtual int FooterAlignment { get; protected set; }

    [JsonProperty("footerOverlayColor")]
    public virtual int FooterOverlayColor { get; protected set; }

    [JsonProperty("footerOverlayOpacity")]
    public virtual int FooterOverlayOpacity { get; protected set; }

    [JsonProperty("footerOverlayGradientDirection")]
    public virtual int FooterOverlayGradientDirection { get; protected set; }

    [JsonProperty("headerOverlayColor")]
    public virtual int HeaderOverlayColor { get; protected set; }

    [JsonProperty("headerOverlayOpacity")]
    public virtual int HeaderOverlayOpacity { get; protected set; }

    [JsonProperty("headerOverlayGradientDirection")]
    public virtual int HeaderOverlayGradientDirection { get; protected set; }

    [JsonProperty("fontOptionForSiteTitle")]
    public virtual string? FontOptionForSiteTitle { get; protected set; }

    [JsonProperty("fontOptionForSiteNav")]
    public virtual string? FontOptionForSiteNav { get; protected set; }

    [JsonProperty("fontOptionForSiteFooterTitle")]
    public virtual string? FontOptionForSiteFooterTitle { get; protected set; }

    [JsonProperty("fontOptionForSiteFooterNav")]
    public virtual string? FontOptionForSiteFooterNav { get; protected set; }

    [JsonProperty("horizontalQuickLaunch")]
    public virtual bool HorizontalQuickLaunch { get; protected set; }

    [JsonProperty("headerColorIndexInLightMode")]
    public virtual int HeaderColorIndexInLightMode { get; protected set; }

    [JsonProperty("headerColorIndexInDarkMode")]
    public virtual int HeaderColorIndexInDarkMode { get; protected set; }

    [JsonProperty("footerColorIndexInLightMode")]
    public virtual int FooterColorIndexInLightMode { get; protected set; }

    [JsonProperty("footerColorIndexInDarkMode")]
    public virtual int FooterColorIndexInDarkMode { get; protected set; }

}
