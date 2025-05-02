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

[ClientObject(Name = "Microsoft.Online.SharePoint.TenantAdministration.Tenant", Id = "{268004ae-ef6b-4e9b-8425-127220d84719}")]
[JsonObject()]
public class Tenant : ClientObject
{

    [JsonProperty()]
    public virtual RoleType? AddressbarLinkPermission { get; set; }

    [JsonProperty()]
    public virtual string? AIBuilderDefaultPowerAppsEnvironment { get; set; }

    [JsonProperty()]
    public virtual bool AIBuilderEnabled { get; set; }

    [JsonProperty()]
    public virtual int AIBuilderEnabledInContentCenter { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<SiteInfoForSitePicker>? AIBuilderSiteInfoList { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<Guid>? AIBuilderSiteList { get; set; }

    [JsonProperty()]
    public virtual string? AIBuilderSiteListFileName { get; set; }

    [JsonProperty()]
    public virtual Guid AllOrganizationSecurityGroupId { get; set; }

    [JsonProperty()]
    public virtual SharingState? AllowAnonymousMeetingParticipantsToAccessWhiteboards { get; set; }

    [JsonProperty()]
    public virtual bool AllowCommentsTextOnEmailEnabled { get; set; }

    [JsonProperty()]
    public virtual bool AllowDownloadingNonWebViewableFiles { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<Guid>? AllowedDomainListForSyncClient { get; set; }

    [JsonProperty()]
    public virtual bool AllowEditing { get; set; }

    [JsonProperty()]
    public virtual bool AllowEveryoneExceptExternalUsersClaimInPrivateSite { get; set; }

    [JsonProperty()]
    public virtual bool AllowGuestUserShareToUsersNotInSiteCollection { get; set; }

    [JsonProperty()]
    public virtual bool AllowLimitedAccessOnUnmanagedDevices { get; set; }

    [JsonProperty()]
    public virtual bool AllowOverrideForBlockUserInfoVisibility { get; set; }

    [JsonProperty("AllowSelectSecurityGroupsInSPSitesList")]
    public virtual bool AllowSelectSecurityGroupsInSharePointSitesList { get; set; }

    [JsonProperty("AllowSelectSGsInODBListInTenant")]
    public virtual IReadOnlyCollection<string>? AllowSelectSecurityGroupsInOneDriveListInTenant { get; set; }

    [JsonProperty()]
    public virtual bool AllowSensitivityLabelOnRecords { get; set; }

    [JsonProperty()]
    public virtual bool AllowSharingOutsideRestrictedAccessControlGroups { get; set; }

    [JsonProperty()]
    public virtual bool AllowWebPropertyBagUpdateWhenDenyAddAndCustomizePagesIsEnabled { get; set; }

    [JsonProperty()]
    public virtual string? AmplifyAdminSettings { get; set; }

    [JsonProperty()]
    public virtual bool AnyoneLinkTrackUsers { get; set; }

    [JsonProperty()]
    public virtual bool AppBypassInformationBarriers { get; set; }

    [JsonProperty()]
    public virtual bool ApplyAppEnforcedRestrictionsToAdHocRecipients { get; set; }

    [JsonProperty()]
    public virtual bool AppOnlyBypassPeoplePickerPolicies { get; set; }

    [JsonProperty()]
    public virtual string? ArchiveRedirectUrl { get; set; }

    [JsonProperty("AuthContextResilienceMode")]
    public virtual ResilienceMode? AuthenticationContextResilienceMode { get; set; }

    [JsonProperty()]
    public virtual bool AutofillColumnsEnabled { get; set; }

    [JsonProperty()]
    public virtual string? AutofillColumnsSiteListFileName { get; set; }

    [JsonProperty()]
    public virtual bool BccExternalSharingInvitations { get; set; }

    [JsonProperty()]
    public virtual string? BccExternalSharingInvitationsList { get; set; }

    [JsonProperty()]
    public virtual bool BlockAccessOnUnmanagedDevices { get; set; }

    [JsonProperty()]
    public virtual bool BlockAppAccessWithAuthenticationContext { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<string>? BlockDownloadFileTypeIds { get; set; }

    [JsonProperty()]
    public virtual bool BlockDownloadFileTypePolicy { get; set; }

    [JsonProperty()]
    public virtual BlockDownloadLinksFileType? BlockDownloadLinksFileType { get; set; }

    [JsonProperty()]
    public virtual bool BlockDownloadOfAllFilesForGuests { get; set; }

    [JsonProperty()]
    public virtual bool BlockDownloadOfAllFilesOnUnmanagedDevices { get; set; }

    [JsonProperty()]
    public virtual bool BlockDownloadOfViewableFilesForGuests { get; set; }

    [JsonProperty()]
    public virtual bool BlockDownloadOfViewableFilesOnUnmanagedDevices { get; set; }

    [JsonProperty()]
    public virtual bool BlockMacSync { get; set; }

    [JsonProperty()]
    public virtual bool BlockSendLabelMismatchEmail { get; set; }

    [JsonProperty()]
    public virtual string? BlockUserInfoVisibility { get; set; }

    [JsonProperty()]
    public virtual TenantBrowseUserInfoPolicyType? BlockUserInfoVisibilityInOneDrive { get; set; }

    [JsonProperty()]
    public virtual TenantBrowseUserInfoPolicyType? BlockUserInfoVisibilityInSharePoint { get; set; }

    [JsonProperty()]
    public virtual long BonusStorageQuotaMB { get; set; }

    [JsonProperty()]
    public virtual bool BusinessConnectivityServiceDisabled { get; set; }

    [JsonProperty()]
    public virtual bool CommentsOnFilesDisabled { get; set; }

    [JsonProperty()]
    public virtual bool CommentsOnListItemsDisabled { get; set; }

    [JsonProperty()]
    public virtual bool CommentsOnSitePagesDisabled { get; set; }

    [JsonProperty()]
    public virtual string? CompatibilityRange { get; set; }

    [JsonProperty()]
    public virtual ConditionalAccessPolicyType? ConditionalAccessPolicy { get; set; }

    [JsonProperty()]
    public virtual string? ConditionalAccessPolicyErrorHelpLink { get; set; }

    [JsonProperty()]
    public virtual bool ContentSecurityPolicyConfigSynced { get; set; }

    [JsonProperty()]
    public virtual bool ContentSecurityPolicyEnforcement { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<string>? ContentTypeSyncSiteTemplatesList { get; set; }

    [JsonProperty()]
    public virtual int CoreBlockGuestsAsSiteAdmin { get; set; }

    [JsonProperty()]
    public virtual bool CoreDefaultLinkToExistingAccess { get; set; }

    [JsonProperty("CoreDefaultShareLinkRole")]
    public virtual RoleType? CoreDefaultSharingLinkRole { get; set; }

    [JsonProperty("CoreDefaultShareLinkScope")]
    public virtual SharingScope? CoreDefaultSharingLinkScope { get; set; }

    [JsonProperty()]
    public virtual RoleType? CoreLoopDefaultSharingLinkRole { get; set; }

    [JsonProperty()]
    public virtual SharingScope? CoreLoopDefaultSharingLinkScope { get; set; }

    [JsonProperty()]
    public virtual SharingCapabilities? CoreLoopSharingCapability { get; set; }

    [JsonProperty()]
    public virtual bool CoreRequestFilesLinkEnabled { get; set; }

    [JsonProperty()]
    public virtual int CoreRequestFilesLinkExpirationInDays { get; set; }

    [JsonProperty()]
    public virtual SharingCapabilities? CoreSharingCapability { get; set; }

    [JsonProperty()]
    public virtual string? CustomizedExternalSharingServiceUrl { get; set; }

    [JsonProperty()]
    public virtual bool DataverseUsageConsentEnabled { get; set; }

    [JsonProperty()]
    public virtual SiteInfoForSitePicker? DefaultContentCenterSite { get; set; }

    [JsonProperty()]
    public virtual SharingPermissionType? DefaultLinkPermission { get; set; }

    [JsonProperty("DefaultODBMode")]
    public virtual string? DefaultOneDriveMode { get; set; }

    [JsonProperty()]
    public virtual SharingLinkType? DefaultSharingLinkType { get; set; }

    [JsonProperty()]
    public virtual bool DelayDenyAddAndCustomizePagesEnforcement { get; set; }

    [JsonProperty()]
    public virtual bool DelegateRestrictedAccessControlConfiguration { get; set; }

    [JsonProperty()]
    public virtual bool DelegateRestrictedContentDiscoveryConfiguration { get; set; }

    [JsonProperty("DenySelectSecurityGroupsInSPSitesList")]
    public virtual bool DenySelectSecurityGroupsInSharePointSitesList { get; set; }

    [JsonProperty("DenySelectSGsInODBListInTenant")]
    public virtual bool DenySelectSecurityGroupsInOneDriveListInTenant { get; set; }

    [JsonProperty()]
    public virtual bool DisableAddToOneDrive { get; set; }

    [JsonProperty()]
    public virtual bool DisabledAdaptiveCardExtensionIds { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<Guid>? DisabledModernListTemplateIds { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<Guid>? DisabledWebPartIds { get; set; }

    [JsonProperty()]
    public virtual bool DisableBackToClassic { get; set; }

    [JsonProperty()]
    public virtual bool DisableCustomAppAuthentication { get; set; }

    [JsonProperty()]
    public virtual bool DisableDocumentLibraryDefaultLabeling { get; set; }

    [JsonProperty()]
    public virtual bool DisableOutlookPSTVersionTrimming { get; set; }

    [JsonProperty()]
    public virtual bool DisablePersonalListCreation { get; set; }

    [JsonProperty()]
    public virtual bool DisableReportProblemDialog { get; set; }

    [JsonProperty()]
    public virtual bool DisableSharePointStoreAccess { get; set; }

    [JsonProperty()]
    public virtual bool DisableSpacesActivation { get; set; }

    [JsonProperty()]
    public virtual bool DisableVivaConnectionsAnalytics { get; set; }

    [JsonProperty()]
    public virtual bool DisallowInfectedFileDownload { get; set; }

    [JsonProperty()]
    public virtual bool DisplayNamesOfFileViewers { get; set; }

    [JsonProperty("DisplayNamesOfFileViewersInSpo")]
    public virtual bool DisplayNamesOfFileViewersInSharePoint { get; set; }

    [JsonProperty()]
    public virtual bool DisplayStartASiteOption { get; set; }

    [JsonProperty()]
    public virtual bool DocumentUnderstandingEnabled { get; set; }

    [JsonProperty()]
    public virtual int DocumentUnderstandingEnabledInContentCenter { get; set; }

    [JsonProperty()]
    public virtual string? DocumentUnderstandingSiteListFileName { get; set; }

    [JsonProperty()]
    public virtual bool EmailAttestationEnabled { get; set; }

    [JsonProperty()]
    public virtual int EmailAttestationReAuthDays { get; set; }

    [JsonProperty()]
    public virtual bool EmailAttestationRequired { get; set; }

    [JsonProperty()]
    public virtual bool EnableAIPIntegration { get; set; }

    [JsonProperty()]
    public virtual bool EnableAutoExpirationVersionTrim { get; set; }

    [JsonProperty()]
    public virtual bool EnableAutoNewsDigest { get; set; }

    [JsonProperty("EnableAzureADB2BIntegration")]
    public virtual bool EnableAzureAdB2BIntegration { get; set; }

    [JsonProperty()]
    public virtual bool EnableDirectToCustomerBilling { get; set; }

    [JsonProperty()]
    public virtual bool EnableDiscoverableByOrganizationForVideos { get; set; }

    [JsonProperty("EnabledFlightAllowAADB2BSkipCheckingOTP")]
    public virtual bool EnabledFlightAllowAzureAdB2BSkipCheckingOneTimePassword { get; set; }

    [JsonProperty()]
    public virtual bool EnableGuestSignInAcceleration { get; set; }

    [JsonProperty()]
    public virtual bool EnableMediaReactions { get; set; }

    [JsonProperty()]
    public virtual bool EnableMinimumVersionRequirement { get; set; }

    [JsonProperty()]
    public virtual bool EnableMipSiteLabel { get; set; }

    [JsonProperty()]
    public virtual bool EnablePromotedFileHandlers { get; set; }

    [JsonProperty()]
    public virtual bool EnableRestrictedAccessControl { get; set; }

    [JsonProperty()]
    public virtual bool EnableSensitivityLabelForPDF { get; set; }

    [JsonProperty()]
    public virtual bool EnableSiteArchive { get; set; }

    [JsonProperty()]
    public virtual bool EnableTenantRestrictionsInsights { get; set; }

    [JsonProperty()]
    public virtual bool EnforceRequestDigest { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<string>? ESignatureAppList { get; set; }

    [JsonProperty()]
    public virtual bool ESignatureEnabled { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<string>? ESignatureSiteList { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<string>? ESignatureThirdPartyProviderInfoList { get; set; }

    [JsonProperty()]
    public virtual bool ExemptNativeUsersFromTenantLevelRestricedAccessControl { get; set; }

    [JsonProperty()]
    public virtual bool ExtendPermissionsToUnprotectedFiles { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<Guid>? ExcludedBlockDownloadGroupIds { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<string>? ExcludedFileExtensionsForSyncClient { get; set; }

    [JsonProperty()]
    public virtual int ExpireVersionsAfterDays { get; set; }

    [JsonProperty()]
    public virtual bool ExternalServicesEnabled { get; set; }

    [JsonProperty()]
    public virtual bool ExternalUserExpirationRequired { get; set; }

    [JsonProperty()]
    public virtual int ExternalUserExpireInDays { get; set; }

    [JsonProperty()]
    public virtual AnonymousLinkType? FileAnonymousLinkType { get; set; }

    [JsonProperty()]
    public virtual bool FilePickerExternalImageSearchEnabled { get; set; }

    [JsonProperty()]
    public virtual string? FileVersionPolicyXml { get; set; }

    [JsonProperty()]
    public virtual AnonymousLinkType? FolderAnonymousLinkType { get; set; }

    [JsonProperty()]
    public virtual string? GuestSharingGroupAllowListInTenant { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<string>? GuestSharingGroupAllowListInTenantByGroupId { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<string>? GuestSharingGroupAllowListInTenantByPrincipalIdentity { get; set; }

    [JsonProperty()]
    public virtual bool HasAdminCompletedCUConfiguration { get; set; }

    [JsonProperty()]
    public virtual bool HasIntelligentContentServicesCapability { get; set; }

    [JsonProperty()]
    public virtual bool HasTopicExperiencesCapability { get; set; }

    [JsonProperty()]
    public virtual bool HideDefaultThemes { get; set; }

    [JsonProperty()]
    public virtual bool HideSyncButtonOnDocLib { get; set; }

    [JsonProperty("HideSyncButtonOnODB")]
    public virtual bool HideSyncButtonOnOneDrive { get; set; }

    [JsonProperty()]
    public virtual ImageTaggingChoice? ImageTaggingOption { get; set; }

    [JsonProperty()]
    public virtual string? ImageTaggingSiteListFileName { get; set; }

    [JsonProperty()]
    public virtual bool IncludeAtAGlanceInShareEmails { get; set; }

    [JsonProperty("IBImplicitGroupBased")]
    public virtual bool InformationBarriersImplicitGroupBased { get; set; }

    [JsonProperty()]
    public virtual bool InformationBarriersSuspension { get; set; }

    [JsonProperty()]
    public virtual string? IPAddressAllowList { get; set; }

    [JsonProperty()]
    public virtual bool IPAddressEnforcement { get; set; }

    [JsonProperty("IPAddressWACTokenLifetime")]
    public virtual int IPAddressWacTokenLifetime { get; set; }

    [JsonProperty()]
    public virtual bool IsAppBarTemporarilyDisabled { get; set; }

    [JsonProperty()]
    public virtual bool IsCollabMeetingNotesFluidEnabled { get; set; }

    [JsonProperty()]
    public virtual bool IsDataAccessInCardDesignerEnabled { get; set; }

    [JsonProperty()]
    public virtual bool IsEnableAppAuthPopUpEnabled { get; set; }

    [JsonProperty()]
    public virtual bool IsFluidEnabled { get; set; }

    [JsonProperty()]
    public virtual bool IsHubSitesMultiGeoFlightEnabled { get; set; }

    [JsonProperty()]
    public virtual bool IsLoopEnabled { get; set; }

    [JsonProperty()]
    public virtual bool IsMnAFlightEnabled { get; set; }

    [JsonProperty()]
    public virtual bool IsMultiGeo { get; set; }

    [JsonProperty()]
    public virtual bool IsMultipleHomeSitesFlightEnabled { get; set; }

    [JsonProperty()]
    public virtual bool IsMultipleVivaConnectionsFlightEnabled { get; set; }

    [JsonProperty()]
    public virtual bool IsUnmanagedSyncClientForTenantRestricted { get; set; }

    [JsonProperty()]
    public virtual bool IsUnmanagedSyncClientRestrictionFlightEnabled { get; set; }

    [JsonProperty()]
    public virtual bool IsVivaHomeFlightEnabled { get; set; }

    [JsonProperty()]
    public virtual bool IsVivaHomeGAFlightEnabled { get; set; }

    [JsonProperty("IsWBFluidEnabled")]
    public virtual bool IsWhiteboardFluidEnabled { get; set; }

    [JsonProperty()]
    public virtual string? LabelMismatchEmailHelpLink { get; set; }

    [JsonProperty()]
    public virtual bool LegacyBrowserAuthProtocolsEnabled { get; set; }

    [JsonProperty()]
    public virtual bool LegacyAuthProtocolsEnabled { get; set; }

    [JsonProperty()]
    public virtual LimitedAccessFileType? LimitedAccessFileType { get; set; }

    [JsonProperty()]
    public virtual bool MachineLearningCaptureEnabled { get; set; }

    [JsonProperty()]
    public virtual bool MarkAllFilesAsSensitiveByDefault { get; set; }

    [JsonProperty()]
    public virtual bool MassDeleteNotificationDisabled { get; set; }

    [JsonProperty()]
    public virtual int MajorVersionLimit { get; set; }

    [JsonProperty()]
    public virtual SensitiveByDefaultState? MarkNewFilesSensitiveByDefault { get; set; }

    [JsonProperty()]
    public virtual MediaTranscriptionPolicyType? MediaTranscription { get; set; }

    [JsonProperty()]
    public virtual MediaTranscriptionAutomaticFeaturesPolicyType MediaTranscriptionAutomaticFeatures { get; set; }

    [JsonProperty()]
    public virtual bool MobileFriendlyUrlEnabledInTenant { get; set; }

    [JsonProperty()]
    public virtual string? NoAccessRedirectUrl { get; set; }

    [JsonProperty("NotificationsInOneDriveForBusinessEnabled")]
    public virtual bool NotificationsInOneDriveEnabled { get; set; }

    [JsonProperty()]
    public virtual bool NotificationsInSharePointEnabled { get; set; }

    [JsonProperty()]
    public virtual bool NotifyOwnersWhenInvitationsAccepted { get; set; }

    [JsonProperty()]
    public virtual bool NotifyOwnersWhenItemsReshared { get; set; }

    [JsonProperty()]
    public virtual string? OCRAdminSiteListFileName { get; set; }

    [JsonProperty()]
    public virtual string? OCRComplianceSiteListFileName { get; set; }

    [JsonProperty()]
    public virtual int OCRModeForAdminSites { get; set; }

    [JsonProperty("OCRModeForComplianceODBs")]
    public virtual int OCRModeForComplianceOneDrives { get; set; }

    [JsonProperty()]
    public virtual int OCRModeForComplianceSites { get; set; }

    [JsonProperty("OfficeClientADALDisabled")]
    public virtual bool OfficeClientAdalDisabled { get; set; }

    [JsonProperty("ODBAccessRequests")]
    public virtual SharingState? OneDriveAccessRequests { get; set; }

    [JsonProperty()]
    public virtual int OneDriveBlockGuestsAsSiteAdmin { get; set; }

    [JsonProperty()]
    public virtual bool OneDriveDefaultLinkToExistingAccess { get; set; }

    [JsonProperty("OneDriveDefaultShareLinkRole")]
    public virtual RoleType? OneDriveDefaultSharingLinkRole { get; set; }

    [JsonProperty("OneDriveDefaultShareLinkScope")]
    public virtual SharingScope? OneDriveDefaultSharingLinkScope { get; set; }

    [JsonProperty()]
    public virtual bool OneDriveForGuestsEnabled { get; set; }

    [JsonProperty()]
    public virtual RoleType? OneDriveLoopDefaultSharingLinkRole { get; set; }

    [JsonProperty()]
    public virtual SharingScope? OneDriveLoopDefaultSharingLinkScope { get; set; }

    [JsonProperty()]
    public virtual SharingCapabilities? OneDriveLoopSharingCapability { get; set; }

    [JsonProperty("ODBMembersCanShare")]
    public virtual SharingState? OneDriveMembersCanShare { get; set; }

    [JsonProperty()]
    public virtual bool OneDriveRequestFilesLinkEnabled { get; set; }

    [JsonProperty()]
    public virtual int OneDriveRequestFilesLinkExpirationInDays { get; set; }

    [JsonProperty("ODBSensitivityRefreshWindowInHours")]
    public virtual int OneDriveSensitivityRefreshWindowInHours { get; set; }

    [JsonProperty("ODBSharingCapability")]
    public virtual SharingCapabilities? OneDriveSharingCapability { get; set; }

    [JsonProperty()]
    public virtual long OneDriveStorageQuota { get; set; }

    [JsonProperty("ODBTranslationEnabled")]
    public virtual bool OneDriveTranslationEnabled { get; set; }

    [JsonProperty()]
    public virtual bool OptOutOfGrooveBlock { get; set; }

    [JsonProperty()]
    public virtual bool OptOutOfGrooveSoftBlock { get; set; }

    [JsonProperty()]
    public virtual string? OrgNewsSiteUrl { get; set; }

    [JsonProperty()]
    public virtual int OrphanedPersonalSitesRetentionPeriod { get; set; }

    [JsonProperty()]
    public virtual bool OwnerAnonymousNotification { get; set; }

    [JsonProperty()]
    public virtual bool PermissiveBrowserFileHandlingOverride { get; set; }

    [JsonProperty()]
    public virtual bool PrebuiltEnabled { get; set; }

    [JsonProperty()]
    public virtual int PrebuiltEnabledInContentCenter { get; set; }

    [JsonProperty()]
    public virtual string? PrebuiltSiteListFileName { get; set; }

    [JsonProperty()]
    public virtual bool PreventExternalUsersFromResharing { get; set; }

    [JsonProperty()]
    public virtual bool ProvisionSharedWithEveryoneFolder { get; set; }

    [JsonProperty()]
    public virtual string? PublicCdnAllowedFileTypes { get; set; }

    [JsonProperty()]
    public virtual bool PublicCdnEnabled { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<string>? PublicCdnOrigins { get; set; }

    [JsonProperty()]
    public virtual int RecycleBinRetentionPeriod { get; set; }

    [JsonProperty()]
    public virtual bool ReduceTempTokenLifetimeEnabled { get; set; }

    [JsonProperty()]
    public virtual int ReduceTempTokenLifetimeValue { get; set; }

    [JsonProperty()]
    public virtual bool RequireAcceptingAccountMatchInvitedAccount { get; set; }

    [JsonProperty()]
    public virtual int RequireAnonymousLinksExpireInDays { get; set; }

    [JsonProperty()]
    public virtual string? RestrictedAccessControlForOneDriveErrorHelpLink { get; set; }

    [JsonProperty()]
    public virtual string? RestrictedAccessControlforSitesErrorHelpLink { get; set; }

    [JsonProperty()]
    public virtual bool RestrictedOneDriveLicense { get; set; }

    [JsonProperty()]
    public virtual bool RestrictedSharePointLicense { get; set; }

    [JsonProperty()]
    public virtual double? ResourceQuota { get; set; }

    [JsonProperty()]
    public virtual double? ResourceQuotaAllocated { get; set; }

    [JsonProperty()]
    public virtual string? RootSiteUrl { get; set; }

    [JsonProperty()]
    public virtual bool SelfServiceSiteCreationDisabled { get; set; }

    [JsonProperty("SearchResolveExactEmailOrUPN")]
    public virtual bool SearchResolveExactEmailOrUpn { get; set; }

    [JsonProperty()]
    public virtual bool SharePointAddInsDisabled { get; set; }

    [JsonProperty()]
    public virtual string? SharingAllowedDomainList { get; set; }

    [JsonProperty()]
    public virtual string? SharingBlockedDomainList { get; set; }

    [JsonProperty()]
    public virtual SharingCapabilities? SharingCapability { get; set; }

    [JsonProperty()]
    public virtual SharingDomainRestrictionMode? SharingDomainRestrictionMode { get; set; }

    [JsonProperty()]
    public virtual bool ShowAllUsersClaim { get; set; }

    [JsonProperty()]
    public virtual bool ShowEveryoneClaim { get; set; }

    [JsonProperty()]
    public virtual bool ShowEveryoneExceptExternalUsersClaim { get; set; }

    [JsonProperty()]
    public virtual bool ShowOpenInDesktopOptionForSyncedFiles { get; set; }

    [JsonProperty("ShowNGSCDialogForSyncOnODB")]
    public virtual bool ShowNextGenerationSyncClientDialogForSyncOnOneDrive { get; set; }

    [JsonProperty()]
    public virtual bool ShowPeoplePickerSuggestionsForGuestUsers { get; set; }

    [JsonProperty("ShowPeoplePickerGroupSuggestionsForIB")]
    public virtual bool ShowPeoplePickerGroupSuggestionsForInformationBarriers { get; set; }

    [JsonProperty()]
    public virtual string? SignInAccelerationDomain { get; set; }

    [JsonProperty()]
    public virtual bool SiteOwnerManageLegacyServicePrincipalEnabled { get; set; }

    [JsonProperty()]
    public virtual bool SocialBarOnSitePagesDisabled { get; set; }

    [JsonProperty()]
    public virtual SpecialCharactersState? SpecialCharactersStateInFileFolderNames { get; set; }

    [JsonProperty()]
    public virtual string? StartASiteFormUrl { get; set; }

    [JsonProperty()]
    public virtual bool StopNew2010Workflows { get; set; }

    [JsonProperty()]
    public virtual bool StopNew2013Workflows { get; set; }

    [JsonProperty()]
    public virtual int StreamLaunchConfig { get; set; }

    [JsonProperty()]
    public virtual DateTime StreamLaunchConfigLastUpdated { get; set; }

    [JsonProperty()]
    public virtual int StreamLaunchConfigUpdateCount { get; set; }

    [JsonProperty()]
    public virtual long StorageQuota { get; set; }

    [JsonProperty()]
    public virtual long StorageQuotaAllocated { get; set; }

    [JsonProperty()]
    public virtual bool SyncPrivacyProfileProperties { get; set; }

    [JsonProperty()]
    public virtual SyntexBillingContext? SyntexBillingSubscriptionSettings { get; set; }

    [JsonProperty()]
    public virtual bool TaxonomyTaggingEnabled { get; set; }

    [JsonProperty()]
    public virtual string? TaxonomyTaggingSiteListFileName { get; set; }

    [JsonProperty()]
    public virtual int TlsTokenBindingPolicyValue { get; set; }

    [JsonProperty()]
    public virtual bool TranslationEnabled { get; set; }

    [JsonProperty()]
    public virtual string? TranslationSiteListFileName { get; set; }

    [JsonProperty("UnlicensedOdbSyntexBillingEnabled")]
    public virtual bool UnlicensedOneDriveSyntexBillingEnabled { get; set; }

    [JsonProperty()]
    public virtual bool UniversalAnnotationDisabled { get; set; }

    [JsonProperty()]
    public virtual bool UseFindPeopleInPeoplePicker { get; set; }

    [JsonProperty()]
    public virtual bool UsePersistentCookiesForExplorerView { get; set; }

    [JsonProperty()]
    public virtual bool ViewersCanCommentOnMediaDisabled { get; set; }

    [JsonProperty()]
    public virtual bool ViewInFileExplorerEnabled { get; set; }

    [JsonProperty()]
    public virtual string? WhoCanShareAllowListInTenant { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<string>? WhoCanShareAllowListInTenantByGroupId { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<string>? WhoCanShareAllowListInTenantByPrincipalIdentity { get; set; }

    [JsonProperty()]
    public virtual bool Workflow2010Disabled { get; set; }

    [JsonProperty()]
    public virtual Workflows2013State? Workflows2013State { get; set; }

}
