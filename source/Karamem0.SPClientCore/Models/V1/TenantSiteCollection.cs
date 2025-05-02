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

[ClientObject(Name = "Microsoft.Online.SharePoint.TenantAdministration.SiteProperties", Id = "{fe9ac193-96fa-4090-b460-5dbf1d5fbdf1}")]
[JsonObject()]
public class TenantSiteCollection : ClientObject
{

    [JsonProperty()]
    public virtual bool AllowDownloadingNonWebViewableFiles { get; set; }

    [JsonProperty()]
    public virtual bool AllowEditing { get; set; }

    [JsonProperty()]
    public virtual bool AllowSelfServiceUpgrade { get; set; }

    [JsonProperty()]
    public virtual int AnonymousLinkExpirationInDays { get; set; }

    [JsonProperty("AuthContextStrength")]
    public virtual string? AuthenticationContextStrength { get; set; }

    [JsonProperty()]
    public virtual string? AuthenticationContextName { get; set; }

    [JsonProperty()]
    public virtual int AverageResourceUsage { get; set; }

    [JsonProperty()]
    public virtual bool AuthenticationContextLimitedAccess { get; set; }

    [JsonProperty()]
    public virtual BlockDownloadLinksFileType? BlockDownloadLinksFileType { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyList<Guid>? BlockDownloadMicrosoft365GroupIds { get; set; }

    [JsonProperty()]
    public virtual bool BlockDownloadPolicy { get; set; }

    [JsonProperty()]
    public virtual bool BlockGuestsAsSiteAdmin { get; set; }

    [JsonProperty()]
    public virtual bool ClearRestrictedAccessControl { get; set; }

    [JsonProperty()]
    public virtual bool CommentsOnSitePagesDisabled { get; set; }

    [JsonProperty()]
    public virtual int CompatibilityLevel { get; set; }

    [JsonProperty()]
    public virtual ConditionalAccessPolicyType? ConditionalAccessPolicy { get; set; }

    [JsonProperty()]
    public virtual double? CurrentResourceUsage { get; set; }

    [JsonProperty()]
    public virtual SharingPermissionType? DefaultLinkPermission { get; set; }

    [JsonProperty()]
    public virtual bool DefaultLinkToExistingAccess { get; set; }

    [JsonProperty()]
    public virtual bool DefaultLinkToExistingAccessReset { get; set; }

    [JsonProperty("DefaultShareLinkRole")]
    public virtual RoleType? DefaultSharingLinkRole { get; set; }

    [JsonProperty("DefaultShareLinkScope")]
    public virtual SharingScope? DefaultSharingLinkScope { get; set; }

    [JsonProperty()]
    public virtual SharingLinkType? DefaultSharingLinkType { get; set; }

    [JsonProperty()]
    public virtual DenyAddAndCustomizePagesStatus? DenyAddAndCustomizePages { get; set; }

    [JsonProperty()]
    public virtual string? Description { get; set; }

    [JsonProperty()]
    public virtual AppViewsPolicy? DisableAppViews { get; set; }

    [JsonProperty()]
    public virtual CompanyWideSharingLinksPolicyType? DisableCompanyWideSharingLinks { get; set; }

    [JsonProperty()]
    public virtual FlowsPolicyType? DisableFlows { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<Guid>? ExcludedBlockDownloadGroupIds { get; set; }

    [JsonProperty()]
    public virtual bool ExcludeBlockDownloadPolicySiteOwners { get; set; }

    [JsonProperty()]
    public virtual int ExternalUserExpirationInDays { get; set; }

    [JsonProperty()]
    public virtual Guid GroupId { get; set; }

    [JsonProperty()]
    public virtual string? GroupOwnerLoginName { get; set; }

    [JsonProperty()]
    public virtual bool HasHolds { get; set; }

    [JsonProperty()]
    public virtual Guid HubSiteId { get; set; }

    [JsonProperty("IBMode")]
    public virtual string? InformationBarriersMode { get; set; }

    [JsonProperty("IBSegments")]
    public virtual IReadOnlyList<Guid>? InformationBarriersSegments { get; set; }

    [JsonProperty("IBSegmentsToAdd")]
    public virtual IReadOnlyList<Guid>? InformationBarriersSegmentsToAdd { get; set; }

    [JsonProperty("IBSegmentsToRemove")]
    public virtual IReadOnlyList<Guid>? InformationBarriersSegmentsToRemove { get; set; }

    [JsonProperty("IsGroupOwnerSiteAdmin")]
    public virtual bool IsGroupOwnerSiteCollectionAdmin { get; set; }

    [JsonProperty()]
    public virtual bool IsHubSite { get; set; }

    [JsonProperty()]
    public virtual bool IsTeamsChannelConnected { get; set; }

    [JsonProperty()]
    public virtual bool IsTeamsConnected { get; set; }

    [JsonProperty()]
    public virtual DateTime LastContentModifiedDate { get; set; }

    [JsonProperty()]
    public virtual uint Lcid { get; set; }

    [JsonProperty()]
    public virtual LimitedAccessFileType? LimitedAccessFileType { get; set; }

    [JsonProperty()]
    public virtual string? LockIssue { get; set; }

    [JsonProperty()]
    public virtual string? LockState { get; set; }

    [JsonProperty()]
    public virtual RoleType? LoopDefaultSharingLinkRole { get; set; }

    [JsonProperty()]
    public virtual SharingScope? LoopDefaultSharingLinkScope { get; set; }

    [JsonProperty()]
    public virtual MediaTranscriptionPolicyType? MediaTranscription { get; set; }

    [JsonProperty()]
    public virtual SiteUserInfoVisibilityPolicyType? OverrideBlockUserInfoVisibility { get; set; }

    [JsonProperty()]
    public virtual bool OverrideSharingCapability { get; set; }

    [JsonProperty()]
    public virtual bool OverrideTenantAnonymousLinkExpirationPolicy { get; set; }

    [JsonProperty()]
    public virtual bool OverrideTenantExternalUserExpirationPolicy { get; set; }

    [JsonProperty()]
    public virtual string? Owner { get; set; }

    [JsonProperty()]
    public virtual string? OwnerEmail { get; set; }

    [JsonProperty()]
    public virtual string? OwnerLoginName { get; set; }

    [JsonProperty()]
    public virtual string? OwnerName { get; set; }

    [JsonProperty()]
    public virtual PWAEnabledStatus? PWAEnabled { get; set; }

    [JsonProperty()]
    public virtual bool ReadOnlyAccessPolicy { get; set; }

    [JsonProperty()]
    public virtual bool ReadOnlyForBlockDownloadPolicy { get; set; }

    [JsonProperty()]
    public virtual bool ReadOnlyForUnmanagedDevices { get; set; }

    [JsonProperty()]
    public virtual Guid RelatedGroupId { get; set; }

    [JsonProperty()]
    public virtual bool RequestFilesLinkEnabled { get; set; }

    [JsonProperty()]
    public virtual int RequestFilesLinkExpirationInDays { get; set; }

    [JsonProperty()]
    public virtual bool RestrictedAccessControl { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<Guid>? RestrictedAccessControlGroups { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<Guid>? RestrictedAccessControlGroupsToAdd { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<Guid>? RestrictedAccessControlGroupsToRemove { get; set; }

    [JsonProperty()]
    public virtual RestrictedToRegion? RestrictedToRegion { get; set; }

    [JsonProperty()]
    public virtual SandboxedCodeActivationCapabilities? SandboxedCodeActivationCapability { get; set; }

    [JsonProperty()]
    public virtual Guid SensitivityLabel { get; set; }

    [JsonProperty()]
    public virtual string? SensitivityLabel2 { get; set; }

    [JsonProperty()]
    public virtual bool SetOwnerWithoutUpdatingSecondaryAdmin { get; set; }

    [JsonProperty()]
    public virtual string? SharingAllowedDomainList { get; set; }

    [JsonProperty()]
    public virtual string? SharingBlockedDomainList { get; set; }

    [JsonProperty()]
    public virtual SharingCapabilities? SharingCapability { get; set; }

    [JsonProperty()]
    public virtual SharingDomainRestrictionMode? SharingDomainRestrictionMode { get; set; }

    [JsonProperty()]
    public virtual bool SharingLockDownCanBeCleared { get; set; }

    [JsonProperty()]
    public virtual bool SharingLockDownEnabled { get; set; }

    [JsonProperty()]
    public virtual bool ShowPeoplePickerSuggestionsForGuestUsers { get; set; }

    [JsonProperty()]
    public virtual SharingCapabilities? SiteDefinedSharingCapability { get; set; }

    [JsonProperty()]
    public virtual bool SocialBarOnSitePagesDisabled { get; set; }

    [JsonProperty()]
    public virtual string? Status { get; set; }

    [JsonProperty()]
    public virtual int StorageMaximumLevel { get; set; }

    [JsonProperty()]
    public virtual string? StorageQuotaType { get; set; }

    [JsonProperty()]
    public virtual int StorageUsage { get; set; }

    [JsonProperty()]
    public virtual int StorageWarningLevel { get; set; }

    [JsonProperty()]
    public virtual TeamsChannelType? TeamsChannelType { get; set; }

    [JsonProperty()]
    public virtual string? Template { get; set; }

    [JsonProperty()]
    public virtual int TimeZoneId { get; set; }

    [JsonProperty()]
    public virtual string? Title { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<ResourceEntry>? TitleTranslations { get; set; }

    [JsonProperty()]
    public virtual string? Url { get; set; }

    [JsonProperty()]
    public virtual int UserCodeMaximumLevel { get; set; }

    [JsonProperty()]
    public virtual int UserCodeWarningLevel { get; set; }

    [JsonProperty()]
    public virtual int WebsCount { get; set; }

}
