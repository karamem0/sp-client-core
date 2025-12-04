//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;

namespace Karamem0.SharePoint.PowerShell.Models.V1;

[ClientObject(Name = "Microsoft.Online.SharePoint.TenantAdministration.SiteProperties", Id = "{fe9ac193-96fa-4090-b460-5dbf1d5fbdf1}")]
[JsonObject()]
public class TenantSiteCollection : ClientObject
{

    [JsonProperty()]
    public virtual bool AllowDownloadingNonWebViewableFiles { get; protected set; }

    [JsonProperty()]
    public virtual bool AllowEditing { get; protected set; }

    [JsonProperty()]
    public virtual bool AllowFileArchive { get; protected set; }

    [JsonProperty()]
    public virtual bool AllowSelfServiceUpgrade { get; protected set; }

    [JsonProperty()]
    public virtual bool AllowWebPropertyBagUpdateWhenDenyAddAndCustomizePagesIsEnabled { get; protected set; }

    [JsonProperty()]
    public virtual int AnonymousLinkExpirationInDays { get; protected set; }

    [JsonProperty()]
    public virtual bool ApplyToExistingDocumentLibraries { get; protected set; }

    [JsonProperty()]
    public virtual bool ApplyToNewDocumentLibraries { get; protected set; }

    [JsonProperty()]
    public virtual string? ArchivedBy { get; protected set; }

    [JsonProperty()]
    public virtual int ArchivedFileDiskUsed { get; protected set; }

    [JsonProperty()]
    public virtual DateTime ArchivedTime { get; protected set; }

    [JsonProperty()]
    public virtual string? ArchiveStatus { get; protected set; }

    [JsonProperty("AuthContextStrength")]
    public virtual string? AuthenticationContextStrength { get; protected set; }

    [JsonProperty()]
    public virtual string? AuthenticationContextName { get; protected set; }

    [JsonProperty()]
    public virtual int AverageResourceUsage { get; protected set; }

    [JsonProperty()]
    public virtual bool AuthenticationContextLimitedAccess { get; protected set; }

    [JsonProperty()]
    public virtual BlockDownloadLinksFileType BlockDownloadLinksFileType { get; protected set; }

    [JsonProperty()]
    public virtual IReadOnlyList<Guid>? BlockDownloadMicrosoft365GroupIds { get; protected set; }

    [JsonProperty()]
    public virtual bool BlockDownloadPolicy { get; protected set; }

    [JsonProperty()]
    public virtual int BlockGuestsAsSiteAdmin { get; protected set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<int>? BlockDownloadPolicyFileTypeIds { get; protected set; }

    [JsonProperty()]
    public virtual int BonusDiskQuota { get; protected set; }

    [JsonProperty()]
    public virtual bool ClearGroupId { get; protected set; }

    [JsonProperty()]
    public virtual bool ClearRestrictedAccessControl { get; protected set; }

    [JsonProperty()]
    public virtual bool CommentsOnSitePagesDisabled { get; protected set; }

    [JsonProperty()]
    public virtual int CompatibilityLevel { get; protected set; }

    [JsonProperty()]
    public virtual ConditionalAccessPolicyType ConditionalAccessPolicy { get; protected set; }

    [JsonProperty("CreatedTime")]
    public virtual DateTime Created { get; protected set; }

    [JsonProperty()]
    public virtual double CurrentResourceUsage { get; protected set; }

    [JsonProperty()]
    public virtual SharingPermissionType DefaultLinkPermission { get; protected set; }

    [JsonProperty()]
    public virtual bool DefaultLinkToExistingAccess { get; protected set; }

    [JsonProperty()]
    public virtual bool DefaultLinkToExistingAccessReset { get; protected set; }

    [JsonProperty("DefaultShareLinkRole")]
    public virtual RoleType DefaultSharingLinkRole { get; protected set; }

    [JsonProperty("DefaultShareLinkScope")]
    public virtual SharingScope DefaultSharingLinkScope { get; protected set; }

    [JsonProperty()]
    public virtual SharingLinkType DefaultSharingLinkType { get; protected set; }

    [JsonProperty()]
    public virtual DenyAddAndCustomizePagesStatus DenyAddAndCustomizePages { get; protected set; }

    [JsonProperty()]
    public virtual string? Description { get; protected set; }

    [JsonProperty()]
    public virtual AppViewsPolicy DisableAppViews { get; protected set; }

    [JsonProperty()]
    public virtual CompanyWideSharingLinksPolicyType DisableCompanyWideSharingLinks { get; protected set; }

    [JsonProperty()]
    public virtual FlowsPolicyType DisableFlows { get; protected set; }

    [JsonProperty()]
    public virtual bool DisableSiteBranding { get; protected set; }

    [JsonProperty()]
    public virtual bool EnableAutoExpirationVersionTrim { get; protected set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<Guid>? ExcludedBlockDownloadGroupIds { get; protected set; }

    [JsonProperty()]
    public virtual bool ExcludeBlockDownloadPolicySiteOwners { get; protected set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<string>? ExcludeBlockDownloadSharePointGroups { get; protected set; }

    [JsonProperty()]
    public virtual int ExpireVersionsAfterDays { get; protected set; }

    [JsonProperty()]
    public virtual int ExternalUserExpirationInDays { get; protected set; }

    [JsonProperty()]
    public virtual string? FileTypesForVersionExpiration { get; protected set; }

    [JsonProperty()]
    public virtual Guid GroupId { get; protected set; }

    [JsonProperty()]
    public virtual string? GroupOwnerLoginName { get; protected set; }

    [JsonProperty()]
    public virtual bool HasHolds { get; protected set; }

    [JsonProperty()]
    public virtual bool HidePeoplePreviewingFiles { get; protected set; }

    [JsonProperty()]
    public virtual bool HidePeopleWhoHaveListsOpen { get; protected set; }

    [JsonProperty()]
    public virtual Guid HubSiteId { get; protected set; }

    [JsonProperty("IBMode")]
    public virtual string? InformationBarriersMode { get; protected set; }

    [JsonProperty("IBSegments")]
    public virtual IReadOnlyList<Guid>? InformationBarriersSegments { get; protected set; }

    [JsonProperty("IBSegmentsToAdd")]
    public virtual IReadOnlyList<Guid>? InformationBarriersSegmentsToAdd { get; protected set; }

    [JsonProperty("IBSegmentsToRemove")]
    public virtual IReadOnlyList<Guid>? InformationBarriersSegmentsToRemove { get; protected set; }

    [JsonProperty()]
    public virtual bool InheritVersionPolicyFromTenant { get; protected set; }

    [JsonProperty()]
    public virtual bool IsAuthoritative { get; protected set; }

    [JsonProperty("IsGroupOwnerSiteAdmin")]
    public virtual bool IsGroupOwnerSiteCollectionAdmin { get; protected set; }

    [JsonProperty()]
    public virtual bool IsHubSite { get; protected set; }

    [JsonProperty()]
    public virtual bool IsTeamsChannelConnected { get; protected set; }

    [JsonProperty()]
    public virtual bool IsTeamsConnected { get; protected set; }

    [JsonProperty()]
    public virtual DateTime LastContentModifiedDate { get; protected set; }

    [JsonProperty()]
    public virtual uint Lcid { get; protected set; }

    [JsonProperty()]
    public virtual LimitedAccessFileType LimitedAccessFileType { get; protected set; }

    [JsonProperty()]
    public virtual bool ListsShowHeaderAndNavigation { get; protected set; }

    [JsonProperty()]
    public virtual string? LockIssue { get; protected set; }

    [JsonProperty()]
    public virtual int LockReason { get; protected set; }

    [JsonProperty()]
    public virtual string? LockState { get; protected set; }

    [JsonProperty()]
    public virtual RoleType LoopDefaultSharingLinkRole { get; protected set; }

    [JsonProperty()]
    public virtual SharingScope LoopDefaultSharingLinkScope { get; protected set; }

    [JsonProperty()]
    public virtual int MajorVersionLimit { get; protected set; }

    [JsonProperty()]
    public virtual int MajorWithMinorVersionsLimit { get; protected set; }

    [JsonProperty()]
    public virtual MediaTranscriptionPolicyType MediaTranscription { get; protected set; }

    [JsonProperty()]
    public virtual int OrganizationLinkMaxExpirationInDays { get; protected set; }

    [JsonProperty()]
    public virtual int OrganizationLinkRecommendedExpirationInDays { get; protected set; }

    [JsonProperty()]
    public virtual SiteUserInfoVisibilityPolicyType OverrideBlockUserInfoVisibility { get; protected set; }

    [JsonProperty()]
    public virtual bool OverrideSharingCapability { get; protected set; }

    [JsonProperty()]
    public virtual bool OverrideTenantAnonymousLinkExpirationPolicy { get; protected set; }

    [JsonProperty()]
    public virtual bool OverrideTenantExternalUserExpirationPolicy { get; protected set; }

    [JsonProperty()]
    public virtual bool OverrideTenantOrganizationLinkExpirationPolicy { get; protected set; }

    [JsonProperty()]
    public virtual string? Owner { get; protected set; }

    [JsonProperty()]
    public virtual string? OwnerEmail { get; protected set; }

    [JsonProperty()]
    public virtual string? OwnerLoginName { get; protected set; }

    [JsonProperty()]
    public virtual string? OwnerName { get; protected set; }

    [JsonProperty()]
    public virtual PWAEnabledStatus PWAEnabled { get; protected set; }

    [JsonProperty()]
    public virtual bool ReadOnlyAccessPolicy { get; protected set; }

    [JsonProperty()]
    public virtual bool ReadOnlyForBlockDownloadPolicy { get; protected set; }

    [JsonProperty()]
    public virtual bool ReadOnlyForUnmanagedDevices { get; protected set; }

    [JsonProperty()]
    public virtual Guid RelatedGroupId { get; protected set; }

    [JsonProperty()]
    public virtual string? RemoveVersionExpirationFileTypeOverride { get; protected set; }

    [JsonProperty()]
    public virtual bool RequestFilesLinkEnabled { get; protected set; }

    [JsonProperty()]
    public virtual int RequestFilesLinkExpirationInDays { get; protected set; }

    [JsonProperty()]
    public virtual bool RestrictContentOrgWideSearch { get; protected set; }

    [JsonProperty()]
    public virtual bool RestrictedAccessControl { get; protected set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<Guid>? RestrictedAccessControlGroups { get; protected set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<Guid>? RestrictedAccessControlGroupsToAdd { get; protected set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<Guid>? RestrictedAccessControlGroupsToRemove { get; protected set; }

    [JsonProperty()]
    public virtual bool RestrictedContentDiscoveryforCopilotAndAgents { get; protected set; }

    [JsonProperty()]
    public virtual RestrictedToRegion RestrictedToRegion { get; protected set; }

    [JsonProperty()]
    public virtual SandboxedCodeActivationCapabilities SandboxedCodeActivationCapability { get; protected set; }

    [JsonProperty()]
    public virtual Guid SensitivityLabel { get; protected set; }

    [JsonProperty()]
    public virtual string? SensitivityLabel2 { get; protected set; }

    [JsonProperty()]
    public virtual bool SetOwnerWithoutUpdatingSecondaryAdmin { get; protected set; }

    [JsonProperty()]
    public virtual string? SharingAllowedDomainList { get; protected set; }

    [JsonProperty()]
    public virtual string? SharingBlockedDomainList { get; protected set; }

    [JsonProperty()]
    public virtual SharingCapabilities SharingCapability { get; protected set; }

    [JsonProperty()]
    public virtual SharingDomainRestrictionMode SharingDomainRestrictionMode { get; protected set; }

    [JsonProperty()]
    public virtual bool SharingLockDownCanBeCleared { get; protected set; }

    [JsonProperty()]
    public virtual bool SharingLockDownEnabled { get; protected set; }

    [JsonProperty()]
    public virtual bool ShowPeoplePickerSuggestionsForGuestUsers { get; protected set; }

    [JsonProperty()]
    public virtual SharingCapabilities SiteDefinedSharingCapability { get; protected set; }

    [JsonProperty()]
    public virtual Guid SiteId { get; protected set; }

    [JsonProperty()]
    public virtual bool SocialBarOnSitePagesDisabled { get; protected set; }

    [JsonProperty()]
    public virtual string? Status { get; protected set; }

    [JsonProperty()]
    public virtual int StorageMaximumLevel { get; protected set; }

    [JsonProperty()]
    public virtual string? StorageQuotaType { get; protected set; }

    [JsonProperty()]
    public virtual int StorageUsage { get; protected set; }

    [JsonProperty()]
    public virtual int StorageWarningLevel { get; protected set; }

    [JsonProperty()]
    public virtual TeamsChannelType TeamsChannelType { get; protected set; }

    [JsonProperty()]
    public virtual string? Template { get; protected set; }

    [JsonProperty()]
    public virtual int TimeZoneId { get; protected set; }

    [JsonProperty()]
    public virtual string? Title { get; protected set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<ResourceEntry>? TitleTranslations { get; protected set; }

    [JsonProperty()]
    public virtual Uri? Url { get; protected set; }

    [JsonProperty()]
    public virtual int UserCodeMaximumLevel { get; protected set; }

    [JsonProperty()]
    public virtual int UserCodeWarningLevel { get; protected set; }

    [JsonProperty()]
    public virtual int VersionCount { get; protected set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<string>? VersionPolicyFileTypeOverride { get; protected set; }

    [JsonProperty()]
    public virtual int VersionSize { get; protected set; }

    [JsonProperty()]
    public virtual int WebsCount { get; protected set; }

}
