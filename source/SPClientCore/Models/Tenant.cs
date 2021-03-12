//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models
{

    [ClientObject(Name = "Microsoft.Online.SharePoint.TenantAdministration.Tenant", Id = "{268004ae-ef6b-4e9b-8425-127220d84719}")]
    [JsonObject()]
    public class Tenant : ClientObject
    {

        public Tenant()
        {
        }

        [JsonProperty()]
        public virtual bool AllowDownloadingNonWebViewableFiles { get; protected set; }

        [JsonProperty()]
        public virtual IReadOnlyCollection<Guid> AllowedDomainListForSyncClient { get; protected set; }

        [JsonProperty()]
        public virtual bool AllowEditing { get; protected set; }

        [JsonProperty()]
        public virtual bool AllowLimitedAccessOnUnmanagedDevices { get; protected set; }

        [JsonProperty()]
        public virtual string AllowSelectSGsInOdbListInTenant { get; protected set; }

        [JsonProperty()]
        public virtual bool ApplyAppEnforcedRestrictionsToAdHocRecipients { get; protected set; }

        [JsonProperty()]
        public virtual bool BccExternalSharingInvitations { get; protected set; }

        [JsonProperty()]
        public virtual string BccExternalSharingInvitationsList { get; protected set; }

        [JsonProperty()]
        public virtual bool BlockAccessOnUnmanagedDevices { get; protected set; }

        [JsonProperty()]
        public virtual bool BlockDownloadOfAllFilesForGuests { get; protected set; }

        [JsonProperty()]
        public virtual bool BlockDownloadOfAllFilesOnUnmanagedDevices { get; protected set; }

        [JsonProperty()]
        public virtual bool BlockDownloadOfViewableFilesForGuests { get; protected set; }

        [JsonProperty()]
        public virtual bool BlockDownloadOfViewableFilesOnUnmanagedDevices { get; protected set; }

        [JsonProperty()]
        public virtual bool BlockMacSync { get; protected set; }

        [JsonProperty()]
        public virtual bool CommentsOnFilesDisabled { get; protected set; }

        [JsonProperty()]
        public virtual bool CommentsOnSitePagesDisabled { get; protected set; }

        [JsonProperty()]
        public virtual string CompatibilityRange { get; protected set; }

        [JsonProperty()]
        public virtual ConditionalAccessPolicyType ConditionalAccessPolicy { get; protected set; }

        [JsonProperty()]
        public virtual SharingPermissionType DefaultLinkPermission { get; protected set; }

        [JsonProperty()]
        public virtual SharingLinkType DefaultSharingLinkType { get; protected set; }

        [JsonProperty()]
        public virtual IReadOnlyCollection<Guid> DisabledWebPartIds { get; protected set; }

        [JsonProperty()]
        public bool DisableReportProblemDialog { get; protected set; }

        [JsonProperty()]
        public virtual bool DisallowInfectedFileDownload { get; protected set; }

        [JsonProperty()]
        public virtual bool DisplayNamesOfFileViewers { get; protected set; }

        [JsonProperty()]
        public virtual bool DisplayStartASiteOption { get; protected set; }

        [JsonProperty()]
        public virtual bool EmailAttestationEnabled { get; protected set; }

        [JsonProperty()]
        public virtual int EmailAttestationReAuthDays { get; protected set; }

        [JsonProperty()]
        public virtual bool EmailAttestationRequired { get; protected set; }

        [JsonProperty()]
        public virtual bool EnableAipIntegration { get; protected set; }

        [JsonProperty()]
        public virtual bool EnableGuestSignInAcceleration { get; protected set; }

        [JsonProperty()]
        public virtual bool EnableMinimumVersionRequirement { get; protected set; }

        [JsonProperty()]
        public virtual IReadOnlyCollection<string> ExcludedFileExtensionsForSyncClient { get; protected set; }

        [JsonProperty()]
        public virtual bool ExternalServicesEnabled { get; protected set; }

        [JsonProperty()]
        public virtual AnonymousLinkType FileAnonymousLinkType { get; protected set; }

        [JsonProperty()]
        public virtual bool FilePickerExternalImageSearchEnabled { get; protected set; }

        [JsonProperty()]
        public virtual AnonymousLinkType FolderAnonymousLinkType { get; protected set; }

        [JsonProperty()]
        public virtual string GuestSharingGroupAllowListInTenant { get; protected set; }

        [JsonProperty()]
        public virtual bool HideSyncButtonOnOdb { get; protected set; }

        [JsonProperty()]
        public virtual string IpAddressAllowList { get; protected set; }

        [JsonProperty()]
        public virtual bool IpAddressEnforcement { get; protected set; }

        [JsonProperty()]
        public virtual int IpAddressWacTokenLifetime { get; protected set; }

        [JsonProperty()]
        public virtual bool IsHubSitesMultiGeoFlightEnabled { get; protected set; }

        [JsonProperty()]
        public virtual bool IsMultiGeo { get; protected set; }

        [JsonProperty()]
        public virtual bool IsUnmanagedSyncClientForTenantRestricted { get; protected set; }

        [JsonProperty()]
        public virtual bool IsUnmanagedSyncClientRestrictionFlightEnabled { get; protected set; }

        [JsonProperty()]
        public virtual bool LegacyAuthProtocolsEnabled { get; protected set; }

        [JsonProperty()]
        public virtual int LimitedAccessFileType { get; protected set; }

        [JsonProperty()]
        public virtual int MarkNewFilesSensitiveByDefault { get; protected set; }

        [JsonProperty()]
        public virtual bool MobileFriendlyUrlEnabledInTenant { get; protected set; }

        [JsonProperty()]
        public virtual string NoAccessRedirectUrl { get; protected set; }

        [JsonProperty()]
        public virtual bool NotificationsInOneDriveForBusinessEnabled { get; protected set; }

        [JsonProperty()]
        public virtual bool NotificationsInSharePointEnabled { get; protected set; }

        [JsonProperty()]
        public virtual bool NotifyOwnersWhenInvitationsAccepted { get; protected set; }

        [JsonProperty()]
        public virtual bool NotifyOwnersWhenItemsReshared { get; protected set; }

        [JsonProperty()]
        public virtual SharingState OdbAccessRequests { get; protected set; }

        [JsonProperty()]
        public virtual SharingState OdbMembersCanShare { get; protected set; }

        [JsonProperty()]
        public virtual int OdbSharingCapability { get; protected set; }

        [JsonProperty()]
        public virtual bool OfficeClientAdalDisabled { get; protected set; }

        [JsonProperty()]
        public virtual bool OneDriveForGuestsEnabled { get; protected set; }

        [JsonProperty()]
        public virtual int OneDriveStorageQuota { get; protected set; }

        [JsonProperty()]
        public virtual bool OptOutOfGrooveBlock { get; protected set; }

        [JsonProperty()]
        public virtual bool OptOutOfGrooveSoftBlock { get; protected set; }

        [JsonProperty()]
        public virtual string OrgNewsSiteUrl { get; protected set; }

        [JsonProperty()]
        public virtual int OrphanedPersonalSitesRetentionPeriod { get; protected set; }

        [JsonProperty()]
        public virtual bool OwnerAnonymousNotification { get; protected set; }

        [JsonProperty()]
        public virtual bool PermissiveBrowserFileHandlingOverride { get; protected set; }

        [JsonProperty()]
        public virtual bool PreventExternalUsersFromResharing { get; protected set; }

        [JsonProperty()]
        public virtual bool ProvisionSharedWithEveryoneFolder { get; protected set; }

        [JsonProperty()]
        public virtual string PublicCdnAllowedFileTypes { get; protected set; }

        [JsonProperty()]
        public virtual bool PublicCdnEnabled { get; protected set; }

        [JsonProperty()]
        public virtual IReadOnlyCollection<string> PublicCdnOrigins { get; protected set; }

        [JsonProperty()]
        public virtual bool RequireAcceptingAccountMatchInvitedAccount { get; protected set; }

        [JsonProperty()]
        public virtual int RequireAnonymousLinksExpireInDays { get; protected set; }

        [JsonProperty()]
        public virtual int ResourceQuota { get; protected set; }

        [JsonProperty()]
        public virtual double ResourceQuotaAllocated { get; protected set; }

        [JsonProperty()]
        public virtual string RootSiteUrl { get; protected set; }

        [JsonProperty()]
        public virtual bool SearchResolveExactEmailOrUpn { get; protected set; }

        [JsonProperty()]
        public virtual string SharingAllowedDomainList { get; protected set; }

        [JsonProperty()]
        public virtual string SharingBlockedDomainList { get; protected set; }

        [JsonProperty()]
        public virtual SharingCapabilities SharingCapability { get; protected set; }

        [JsonProperty()]
        public virtual SharingDomainRestrictionMode SharingDomainRestrictionMode { get; protected set; }

        [JsonProperty()]
        public virtual bool ShowAllUsersClaim { get; protected set; }

        [JsonProperty()]
        public virtual bool ShowEveryoneClaim { get; protected set; }

        [JsonProperty()]
        public virtual bool ShowEveryoneExceptExternalUsersClaim { get; protected set; }

        [JsonProperty()]
        public virtual bool ShowNgscDialogForSyncOnOdb { get; protected set; }

        [JsonProperty()]
        public virtual bool ShowPeoplePickerSuggestionsForGuestUsers { get; protected set; }

        [JsonProperty()]
        public virtual string SignInAccelerationDomain { get; protected set; }

        [JsonProperty()]
        public virtual bool SocialBarOnSitePagesDisabled { get; protected set; }

        [JsonProperty()]
        public virtual SpecialCharactersState SpecialCharactersStateInFileFolderNames { get; protected set; }

        [JsonProperty()]
        public virtual string StartASiteFormUrl { get; protected set; }

        [JsonProperty()]
        public virtual long StorageQuota { get; protected set; }

        [JsonProperty()]
        public virtual long StorageQuotaAllocated { get; protected set; }

        [JsonProperty()]
        public virtual bool SyncPrivacyProfileProperties { get; protected set; }

        [JsonProperty()]
        public virtual bool UseFindPeopleInPeoplePicker { get; protected set; }

        [JsonProperty()]
        public virtual bool UsePersistentCookiesForExplorerView { get; protected set; }

        [JsonProperty()]
        public virtual bool UserVoiceForFeedbackEnabled { get; protected set; }

        [JsonProperty()]
        public virtual string WhoCanShareAllowListInTenant { get; protected set; }

    }

}
