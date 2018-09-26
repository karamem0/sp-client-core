//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.Core
{

    [JsonObject(Id = "SP.Web")]
    public class Web : SecurableObject
    {

        public Web()
        {
        }

        [JsonProperty()]
        public ClientObjectCollection<Alert> Alerts { get; private set; }

        [JsonProperty()]
        public bool? AllowMasterPageEditingForCurrentUser { get; private set; }

        [JsonProperty()]
        public bool? AllowRevertFromTemplateForCurrentUser { get; private set; }

        [JsonProperty()]
        public bool? AllowRssFeeds { get; private set; }

        [JsonProperty()]
        public bool? AllowSaveDeclarativeWorkflowAsTemplateForCurrentUser { get; private set; }

        [JsonProperty()]
        public bool? AllowSavePublishDeclarativeWorkflowForCurrentUser { get; private set; }

        [JsonProperty()]
        public PropertyValues AllProperties { get; private set; }

        [JsonProperty()]
        public string AlternateCssUrl { get; private set; }

        [JsonProperty()]
        public Guid? AppInstanceId { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<AppTile> AppTiles { get; private set; }

        [JsonProperty()]
        public Group AssociatedMemberGroup { get; private set; }

        [JsonProperty()]
        public Group AssociatedOwnerGroup { get; private set; }

        [JsonProperty()]
        public Group AssociatedVisitorGroup { get; private set; }

        [JsonProperty()]
        public User Author { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<ContentType> AvailableContentTypes { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<Field> AvailableFields { get; private set; }

        [JsonProperty()]
        public short? Configuration { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<ContentType> ContentTypes { get; private set; }

        [JsonProperty()]
        public DateTime? Created { get; private set; }

        [JsonProperty()]
        public ChangeToken CurrentChangeToken { get; private set; }

        [JsonProperty()]
        public User CurrentUser { get; private set; }

        [JsonProperty()]
        public string CustomMasterUrl { get; private set; }

        [JsonProperty()]
        public DataLeakagePreventionStatusInfo DataLeakagePreventionStatusInfo { get; private set; }

        [JsonProperty()]
        public string Description { get; private set; }

        [JsonProperty()]
        public Guid? DesignPackageId { get; private set; }

        [JsonProperty()]
        public string DesignerDownloadUrlForCurrentUser { get; private set; }

        [JsonProperty()]
        public bool? DocumentLibraryCalloutOfficeWebAppPreviewersDisabled { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<BasePermissions> EffectiveBasePermissions { get; private set; }

        [JsonProperty()]
        public bool? EnableMinimalDownload { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<EventReceiverDefinition> EventReceivers { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<Feature> Features { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<Field> Fields { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<Folder> Folders { get; private set; }

        [JsonProperty()]
        public bool? FooterEnabled { get; private set; }

        [JsonProperty()]
        public VariantThemeType? HeaderEmphasis { get; private set; }

        [JsonProperty()]
        public HeaderLayoutType? HeaderLayout { get; private set; }

        [JsonProperty()]
        public bool? HideSiteLogo { get; private set; }

        [JsonProperty()]
        public bool? HideSiteTitle { get; private set; }

        [JsonProperty()]
        public bool? HorizontalQuickLaunch { get; private set; }

        [JsonProperty()]
        public Guid? Id { get; private set; }

        [JsonProperty()]
        public bool? IsMultilingual { get; private set; }

        [JsonProperty()]
        public int? Language { get; private set; }

        [JsonProperty()]
        public DateTime? LastItemModifiedDate { get; private set; }

        [JsonProperty()]
        public DateTime? LastItemUserModifiedDate { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<List> Lists { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<ListTemplate> ListTemplates { get; private set; }

        [JsonProperty()]
        public string MasterUrl { get; private set; }

        [JsonProperty()]
        public bool? MegaMenuEnabled { get; private set; }

        [JsonProperty()]
        public Navigation Navigation { get; private set; }

        [JsonProperty()]
        public bool? NoCrawl { get; private set; }

        [JsonProperty()]
        public bool? ObjectCacheEnabled { get; private set; }

        [JsonProperty()]
        public bool? OverwriteTranslationsOnChange { get; private set; }

        [JsonProperty()]
        public Web ParentWeb { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<PushNotificationSubscriber> PushNotificationSubscribers { get; private set; }

        [JsonProperty()]
        public bool? QuickLaunchEnabled { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<RecycleBinItem> RecycleBin { get; private set; }

        [JsonProperty()]
        public bool? RecycleBinEnabled { get; private set; }

        [JsonProperty()]
        public RegionalSettings RegionalSettings { get; private set; }

        [JsonProperty()]
        public ResourcePath ResourcePath { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<RoleDefinition> RoleDefinitions { get; private set; }

        [JsonProperty()]
        public Folder RootFolder { get; private set; }

        [JsonProperty()]
        public bool? SaveSiteAsTemplateEnabled { get; private set; }

        [JsonProperty()]
        public string ServerRelativeUrl { get; private set; }

        [JsonProperty()]
        public bool? ShowUrlStructureForCurrentUser { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<Group> SiteGroups { get; private set; }

        [JsonProperty()]
        public string SiteLogoUrl { get; private set; }

        [JsonProperty()]
        public List SiteUserInfoList { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<User> SiteUsers { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<int> SupportedUILanguageIds { get; private set; }

        [JsonProperty()]
        public bool? SyndicationEnabled { get; private set; }

        [JsonProperty()]
        public TenantCorporateCatalogAccessor TenantAppCatalog { get; private set; }

        [JsonProperty()]
        public ThemeInfo ThemeInfo { get; private set; }

        [JsonProperty()]
        public string Title { get; private set; }

        [JsonProperty()]
        public bool? TreeViewEnabled { get; private set; }

        [JsonProperty()]
        public int? UIVersion { get; private set; }

        [JsonProperty()]
        public bool? UIVersionConfigurationEnabled { get; private set; }

        [JsonProperty()]
        public string Url { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<UserCustomAction> UserCustomActions { get; private set; }

        [JsonProperty()]
        public WebInformation WebInfos { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<Web> Webs { get; private set; }

        [JsonProperty()]
        public string WebTemplate { get; private set; }

        [JsonProperty()]
        public string WelcomePage { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<WorkflowAssociation> WorkflowAssociations { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<WorkflowTemplate> WorkflowTemplates { get; private set; }

    }

}
