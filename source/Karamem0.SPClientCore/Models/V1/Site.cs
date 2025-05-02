//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.V1;

[ClientObject(Name = "SP.Web", Id = "{a489add2-5d3a-4de8-9445-49259462dceb}")]
[JsonObject()]
public class Site : SecurableObject
{

    [JsonProperty()]
    public virtual bool AllowAutomaticASPXPageIndexing { get; set; }

    [JsonProperty()]
    public virtual bool AllowCreateDeclarativeWorkflowForCurrentUser { get; set; }

    [JsonProperty()]
    public virtual bool AllowDesignerForCurrentUser { get; set; }

    [JsonProperty()]
    public virtual bool AllowMasterPageEditingForCurrentUser { get; set; }

    [JsonProperty()]
    public virtual bool AllowRevertFromTemplateForCurrentUser { get; set; }

    [JsonProperty()]
    public virtual bool AllowRssFeeds { get; set; }

    [JsonProperty()]
    public virtual bool AllowSaveDeclarativeWorkflowAsTemplateForCurrentUser { get; set; }

    [JsonProperty()]
    public virtual bool AllowSavePublishDeclarativeWorkflowForCurrentUser { get; set; }

    [JsonProperty()]
    public virtual string? AlternateCssUrl { get; set; }

    [JsonProperty()]
    public virtual Guid AppInstanceId { get; set; }

    [JsonProperty()]
    public virtual User? Author { get; set; }

    [JsonProperty()]
    public virtual string? ClassicWelcomePage { get; set; }

    [JsonProperty()]
    public virtual bool CommentsOnSitePagesDisabled { get; set; }

    [JsonProperty()]
    public virtual int Configuration { get; set; }

    [JsonProperty()]
    public virtual bool ContainsConfidentialInfo { get; set; }

    [JsonProperty()]
    public virtual DateTime Created { get; set; }

    [JsonProperty()]
    public virtual ChangeToken? CurrentChangeToken { get; set; }

    [JsonProperty()]
    public virtual string? CustomMasterUrl { get; set; }

    [JsonProperty()]
    public virtual string? Description { get; set; }

    [JsonProperty()]
    public virtual string? DesignerDownloadUrlForCurrentUser { get; set; }

    [JsonProperty()]
    public virtual Guid DesignPackageId { get; set; }

    [JsonProperty()]
    public virtual bool DisableAppViews { get; set; }

    [JsonProperty()]
    public virtual bool DisableFlows { get; set; }

    [JsonProperty()]
    public virtual bool DocumentLibraryCalloutOfficeWebAppPreviewersDisabled { get; set; }

    [JsonProperty()]
    public virtual bool EnableMinimalDownload { get; set; }

    [JsonProperty()]
    public virtual bool ExcludeFromOfflineClient { get; set; }

    [JsonProperty()]
    public virtual FooterVariantThemeType? FooterEmphasis { get; set; }

    [JsonProperty()]
    public virtual bool FooterEnabled { get; set; }

    [JsonProperty()]
    public virtual FooterLayoutType? FooterLayout { get; set; }

    [JsonProperty()]
    public override bool HasUniqueRoleAssignments { get; set; }

    [JsonProperty()]
    public virtual VariantThemeType? HeaderEmphasis { get; set; }

    [JsonProperty()]
    public virtual HeaderLayoutType? HeaderLayout { get; set; }

    [JsonProperty()]
    public virtual bool HideTitleInHeader { get; set; }

    [JsonProperty()]
    public virtual bool HorizontalQuickLaunch { get; set; }

    [JsonProperty()]
    public virtual Guid Id { get; set; }

    [JsonProperty()]
    public virtual bool IsEduClass { get; set; }

    [JsonProperty()]
    public virtual bool IsHomepageModernized { get; set; }

    [JsonProperty()]
    public virtual bool IsMultilingual { get; set; }

    [JsonProperty()]
    public virtual bool IsRevertHomepageLinkHidden { get; set; }

    [JsonProperty()]
    public virtual DateTime LastItemModifiedDate { get; set; }

    [JsonProperty()]
    public virtual DateTime LastItemUserModifiedDate { get; set; }

    [JsonProperty("Language")]
    public virtual uint Lcid { get; set; }

    [JsonProperty()]
    public virtual LogoAlignment? LogoAlignment { get; set; }

    [JsonProperty()]
    public virtual string? MasterUrl { get; set; }

    [JsonProperty()]
    public virtual bool MembersCanShare { get; set; }

    [JsonProperty()]
    public virtual bool MegaMenuEnabled { get; set; }

    [JsonProperty()]
    public virtual bool NavAudienceTargetingEnabled { get; set; }

    [JsonProperty()]
    public virtual bool NoCrawl { get; set; }

    [JsonProperty("NotificationsInOneDriveForBusinessEnabled")]
    public virtual bool NotificationsInOneDriveEnabled { get; set; }

    [JsonProperty()]
    public virtual bool NotificationsInSharePointEnabled { get; set; }

    [JsonProperty()]
    public virtual bool ObjectCacheEnabled { get; set; }

    [JsonProperty()]
    public virtual bool OverwriteTranslationsOnChange { get; set; }

    [JsonProperty()]
    public virtual bool QuickLaunchEnabled { get; set; }

    [JsonProperty()]
    public virtual bool RecycleBinEnabled { get; set; }

    [JsonProperty()]
    public virtual ResourcePath? ResourcePath { get; set; }

    [JsonProperty()]
    public virtual string? RequestAccessEmail { get; set; }

    [JsonProperty()]
    public virtual bool SaveSiteAsTemplateEnabled { get; set; }

    [JsonProperty()]
    public virtual SearchScopeType? SearchScope { get; set; }

    [JsonProperty()]
    public virtual string? ServerRelativeUrl { get; set; }

    [JsonProperty()]
    public virtual bool ShowUrlStructureForCurrentUser { get; set; }

    [JsonProperty()]
    public virtual string? SiteLogoDescription { get; set; }

    [JsonProperty()]
    public virtual string? SiteLogoUrl { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<int>? SupportedUILanguageIds { get; set; }

    [JsonProperty()]
    public virtual bool SyndicationEnabled { get; set; }

    [JsonProperty("WebTemplate")]
    public virtual string? Template { get; set; }

    [JsonProperty()]
    public virtual bool TenantTagPolicyEnabled { get; set; }

    [JsonProperty()]
    public virtual bool TenantAdminMembersCanShare { get; set; }

    [JsonProperty()]
    public virtual string? ThemedCssFolderUrl { get; set; }

    [JsonProperty()]
    public virtual bool ThirdPartyMdmEnabled { get; set; }

    [JsonProperty()]
    public virtual string? Title { get; set; }

    [JsonProperty()]
    public virtual bool TreeViewEnabled { get; set; }

    [JsonProperty()]
    public virtual int UIVersion { get; set; }

    [JsonProperty()]
    public virtual bool UIVersionConfigurationEnabled { get; set; }

    [JsonProperty()]
    public virtual string? Url { get; set; }

    [JsonProperty()]
    public virtual string? WelcomePage { get; set; }

}
