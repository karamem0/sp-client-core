//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Set, "KshTenant")]
[OutputType(typeof(Tenant))]
public class SetTenantCommand : ClientObjectCmdlet<ITenantService>
{

    [Parameter(Mandatory = false)]
    public RoleType AddressbarLinkPermission { get; private set; }

    [Parameter(Mandatory = false)]
    public SharingState AllowAnonymousMeetingParticipantsToAccessWhiteboards { get; private set; }

    [Parameter(Mandatory = false)]
    public bool AllowCommentsTextOnEmailEnabled { get; private set; }

    [Parameter(Mandatory = false)]
    public bool AllowDownloadingNonWebViewableFiles { get; private set; }

    [Parameter(Mandatory = false)]
    public Guid[] AllowedDomainListForSyncClient { get; private set; }

    [Parameter(Mandatory = false)]
    public bool AllowEditing { get; private set; }

    [Parameter(Mandatory = false)]
    public bool AllowEveryoneExceptExternalUsersClaimInPrivateSite { get; private set; }

    [Parameter(Mandatory = false)]
    public bool AllowGuestUserShareToUsersNotInSiteCollection { get; private set; }

    [Parameter(Mandatory = false)]
    public bool AllowLimitedAccessOnUnmanagedDevices { get; private set; }

    [Parameter(Mandatory = false)]
    public bool AllowOverrideForBlockUserInfoVisibility { get; private set; }

    [Parameter(Mandatory = false)]
    public bool AnyoneLinkTrackUsers { get; private set; }

    [Parameter(Mandatory = false)]
    public bool ApplyAppEnforcedRestrictionsToAdHocRecipients { get; private set; }

    [Parameter(Mandatory = false)]
    public ResilienceMode AuthenticationContextResilienceMode { get; private set; }

    [Parameter(Mandatory = false)]
    public bool BccExternalSharingInvitations { get; private set; }

    [Parameter(Mandatory = false)]
    public string BccExternalSharingInvitationsList { get; private set; }

    [Parameter(Mandatory = false)]
    public bool BlockAccessOnUnmanagedDevices { get; private set; }

    [Parameter(Mandatory = false)]
    public BlockDownloadLinksFileType BlockDownloadLinksFileType { get; private set; }

    [Parameter(Mandatory = false)]
    public bool BlockMacSync { get; private set; }

    [Parameter(Mandatory = false)]
    public bool BlockSendLabelMismatchEmail { get; private set; }

    [Parameter(Mandatory = false)]
    public string BlockUserInfoVisibility { get; private set; }

    [Parameter(Mandatory = false)]
    public TenantBrowseUserInfoPolicyType BlockUserInfoVisibilityInOneDrive { get; private set; }

    [Parameter(Mandatory = false)]
    public TenantBrowseUserInfoPolicyType BlockUserInfoVisibilityInSharePoint { get; private set; }

    [Parameter(Mandatory = false)]
    public bool CommentsOnFilesDisabled { get; private set; }

    [Parameter(Mandatory = false)]
    public bool CommentsOnListItemsDisabled { get; private set; }

    [Parameter(Mandatory = false)]
    public bool CommentsOnSitePagesDisabled { get; private set; }

    [Parameter(Mandatory = false)]
    public string CompatibilityRange { get; private set; }

    [Parameter(Mandatory = false)]
    public ConditionalAccessPolicyType ConditionalAccessPolicy { get; private set; }

    [Parameter(Mandatory = false)]
    public string ConditionalAccessPolicyErrorHelpLink { get; private set; }

    [Parameter(Mandatory = false)]
    public string[] ContentTypeSyncSiteTemplatesList { get; private set; }

    [Parameter(Mandatory = false)]
    public RoleType CoreLoopDefaultSharingLinkRole { get; private set; }

    [Parameter(Mandatory = false)]
    public SharingScope CoreLoopDefaultSharingLinkScope { get; private set; }

    [Parameter(Mandatory = false)]
    public SharingCapabilities CoreLoopSharingCapability { get; private set; }

    [Parameter(Mandatory = false)]
    public bool CoreRequestFilesLinkEnabled { get; private set; }

    [Parameter(Mandatory = false)]
    public int CoreRequestFilesLinkExpirationInDays { get; private set; }

    [Parameter(Mandatory = false)]
    public SharingCapabilities CoreSharingCapability { get; private set; }

    [Parameter(Mandatory = false)]
    public string CustomizedExternalSharingServiceUrl { get; private set; }

    [Parameter(Mandatory = false)]
    public SiteInfoForSitePicker DefaultContentCenterSite { get; private set; }

    [Parameter(Mandatory = false)]
    public SharingPermissionType DefaultLinkPermission { get; private set; }

    [Parameter(Mandatory = false)]
    public string DefaultOneDriveMode { get; private set; }

    [Parameter(Mandatory = false)]
    public SharingLinkType DefaultSharingLinkType { get; private set; }

    [Parameter(Mandatory = false)]
    public bool DisableAddToOneDrive { get; private set; }

    [Parameter(Mandatory = false)]
    public bool DisableBackToClassic { get; private set; }

    [Parameter(Mandatory = false)]
    public bool DisableCustomAppAuthentication { get; private set; }

    [Parameter(Mandatory = false)]
    public Guid[] DisabledModernListTemplateIds { get; private set; }

    [Parameter(Mandatory = false)]
    public Guid[] DisabledWebPartIds { get; private set; }

    [Parameter(Mandatory = false)]
    public bool DisableOutlookPSTVersionTrimming { get; private set; }

    [Parameter(Mandatory = false)]
    public bool DisablePersonalListCreation { get; private set; }

    [Parameter(Mandatory = false)]
    public bool DisableReportProblemDialog { get; private set; }

    [Parameter(Mandatory = false)]
    public bool DisableSpacesActivation { get; private set; }

    [Parameter(Mandatory = false)]
    public bool DisallowInfectedFileDownload { get; private set; }

    [Parameter(Mandatory = false)]
    public bool DisplayNamesOfFileViewers { get; private set; }

    [Parameter(Mandatory = false)]
    public bool DisplayNamesOfFileViewersInSharePoint { get; private set; }

    [Parameter(Mandatory = false)]
    public bool DisplayStartASiteOption { get; private set; }

    [Parameter(Mandatory = false)]
    public bool EmailAttestationEnabled { get; private set; }

    [Parameter(Mandatory = false)]
    public int EmailAttestationReAuthDays { get; private set; }

    [Parameter(Mandatory = false)]
    public bool EmailAttestationRequired { get; private set; }

    [Parameter(Mandatory = false)]
    public bool EnableAIPIntegration { get; private set; }

    [Parameter(Mandatory = false)]
    public bool EnableAutoNewsDigest { get; private set; }

    [Parameter(Mandatory = false)]
    public bool EnableAzureAdB2BIntegration { get; private set; }

    [Parameter(Mandatory = false)]
    public bool EnableGuestSignInAcceleration { get; private set; }

    [Parameter(Mandatory = false)]
    public bool EnableMinimumVersionRequirement { get; private set; }

    [Parameter(Mandatory = false)]
    public bool EnableMipSiteLabel { get; private set; }

    [Parameter(Mandatory = false)]
    public bool EnablePromotedFileHandlers { get; private set; }

    [Parameter(Mandatory = false)]
    public bool EnableRestrictedAccessControl { get; private set; }

    [Parameter(Mandatory = false)]
    public string[] ExcludedFileExtensionsForSyncClient { get; private set; }

    [Parameter(Mandatory = false)]
    public bool ExternalServicesEnabled { get; private set; }

    [Parameter(Mandatory = false)]
    public bool ExternalUserExpirationRequired { get; private set; }

    [Parameter(Mandatory = false)]
    public int ExternalUserExpireInDays { get; private set; }

    [Parameter(Mandatory = false)]
    public AnonymousLinkType FileAnonymousLinkType { get; private set; }

    [Parameter(Mandatory = false)]
    public bool FilePickerExternalImageSearchEnabled { get; private set; }

    [Parameter(Mandatory = false)]
    public AnonymousLinkType FolderAnonymousLinkType { get; private set; }

    [Parameter(Mandatory = false)]
    public string GuestSharingGroupAllowListInTenant { get; private set; }

    [Parameter(Mandatory = false)]
    public string[] GuestSharingGroupAllowListInTenantByPrincipalIdentity { get; private set; }

    [Parameter(Mandatory = false)]
    public bool HasAdminCompletedCUConfiguration { get; private set; }

    [Parameter(Mandatory = false)]
    public bool HideDefaultThemes { get; private set; }

    [Parameter(Mandatory = false)]
    public bool HideSyncButtonOnDocLib { get; private set; }

    [Parameter(Mandatory = false)]
    public bool HideSyncButtonOnOneDrive { get; private set; }

    [Parameter(Mandatory = false)]
    public ImageTaggingChoice ImageTaggingOption { get; private set; }

    [Parameter(Mandatory = false)]
    public bool IncludeAtAGlanceInShareEmails { get; private set; }

    [Parameter(Mandatory = false)]
    public bool InformationBarriersImplicitGroupBased { get; private set; }

    [Parameter(Mandatory = false)]
    public bool InformationBarriersSuspension { get; private set; }

    [Parameter(Mandatory = false)]
    public string IPAddressAllowList { get; private set; }

    [Parameter(Mandatory = false)]
    public bool IPAddressEnforcement { get; private set; }

    [Parameter(Mandatory = false)]
    public int IPAddressWacTokenLifetime { get; private set; }

    [Parameter(Mandatory = false)]
    public bool IsAppBarTemporarilyDisabled { get; private set; }

    [Parameter(Mandatory = false)]
    public bool IsCollabMeetingNotesFluidEnabled { get; private set; }

    [Parameter(Mandatory = false)]
    public bool IsFluidEnabled { get; private set; }

    [Parameter(Mandatory = false)]
    public bool IsLoopEnabled { get; private set; }

    [Parameter(Mandatory = false)]
    public bool IsUnmanagedSyncClientForTenantRestricted { get; private set; }

    [Parameter(Mandatory = false)]
    public bool IsVivaHomeFlightEnabled { get; private set; }

    [Parameter(Mandatory = false)]
    public bool IsWhiteboardFluidEnabled { get; private set; }

    [Parameter(Mandatory = false)]
    public string LabelMismatchEmailHelpLink { get; private set; }

    [Parameter(Mandatory = false)]
    public bool LegacyBrowserAuthProtocolsEnabled { get; private set; }

    [Parameter(Mandatory = false)]
    public bool LegacyAuthProtocolsEnabled { get; private set; }

    [Parameter(Mandatory = false)]
    public LimitedAccessFileType LimitedAccessFileType { get; private set; }

    [Parameter(Mandatory = false)]
    public bool MachineLearningCaptureEnabled { get; private set; }

    [Parameter(Mandatory = false)]
    public int MajorVersionLimit { get; private set; }

    [Parameter(Mandatory = false)]
    public SensitiveByDefaultState MarkNewFilesSensitiveByDefault { get; private set; }

    [Parameter(Mandatory = false)]
    public MediaTranscriptionPolicyType MediaTranscription { get; private set; }

    [Parameter(Mandatory = false)]
    public bool MobileFriendlyUrlEnabledInTenant { get; private set; }

    [Parameter(Mandatory = false)]
    public string NoAccessRedirectUrl { get; private set; }

    [Parameter(Mandatory = false)]
    public bool NotificationsInOneDriveEnabled { get; private set; }

    [Parameter(Mandatory = false)]
    public bool NotificationsInSharePointEnabled { get; private set; }

    [Parameter(Mandatory = false)]
    public bool NotifyOwnersWhenInvitationsAccepted { get; private set; }

    [Parameter(Mandatory = false)]
    public bool NotifyOwnersWhenItemsReshared { get; private set; }

    [Parameter(Mandatory = false)]
    public bool OfficeClientAdalDisabled { get; private set; }

    [Parameter(Mandatory = false)]
    public SharingState OneDriveAccessRequests { get; private set; }

    [Parameter(Mandatory = false)]
    public bool OneDriveForGuestsEnabled { get; private set; }

    [Parameter(Mandatory = false)]
    public RoleType OneDriveLoopDefaultSharingLinkRole { get; private set; }

    [Parameter(Mandatory = false)]
    public SharingScope OneDriveLoopDefaultSharingLinkScope { get; private set; }

    [Parameter(Mandatory = false)]
    public SharingCapabilities OneDriveLoopSharingCapability { get; private set; }

    [Parameter(Mandatory = false)]
    public SharingState OneDriveMembersCanShare { get; private set; }

    [Parameter(Mandatory = false)]
    public bool OneDriveRequestFilesLinkEnabled { get; private set; }

    [Parameter(Mandatory = false)]
    public int OneDriveRequestFilesLinkExpirationInDays { get; private set; }

    [Parameter(Mandatory = false)]
    public SharingCapabilities OneDriveSharingCapability { get; private set; }

    [Parameter(Mandatory = false)]
    public long OneDriveStorageQuota { get; private set; }

    [Parameter(Mandatory = false)]
    public bool OptOutOfGrooveBlock { get; private set; }

    [Parameter(Mandatory = false)]
    public bool OptOutOfGrooveSoftBlock { get; private set; }

    [Parameter(Mandatory = false)]
    public int OrphanedPersonalSitesRetentionPeriod { get; private set; }

    [Parameter(Mandatory = false)]
    public bool OwnerAnonymousNotification { get; private set; }

    [Parameter(Mandatory = false)]
    public bool PermissiveBrowserFileHandlingOverride { get; private set; }

    [Parameter(Mandatory = false)]
    public bool PreventExternalUsersFromResharing { get; private set; }

    [Parameter(Mandatory = false)]
    public bool ProvisionSharedWithEveryoneFolder { get; private set; }

    [Parameter(Mandatory = false)]
    public bool ReduceTempTokenLifetimeEnabled { get; private set; }

    [Parameter(Mandatory = false)]
    public int ReduceTempTokenLifetimeValue { get; private set; }

    [Parameter(Mandatory = false)]
    public bool RequireAcceptingAccountMatchInvitedAccount { get; private set; }

    [Parameter(Mandatory = false)]
    public int RequireAnonymousLinksExpireInDays { get; private set; }

    [Parameter(Mandatory = false)]
    public bool SearchResolveExactEmailOrUpn { get; private set; }

    [Parameter(Mandatory = false)]
    public bool SelfServiceSiteCreationDisabled { get; private set; }

    [Parameter(Mandatory = false)]
    public bool SharePointAddInsDisabled { get; private set; }

    [Parameter(Mandatory = false)]
    public string SharingAllowedDomainList { get; private set; }

    [Parameter(Mandatory = false)]
    public string SharingBlockedDomainList { get; private set; }

    [Parameter(Mandatory = false)]
    public SharingCapabilities SharingCapability { get; private set; }

    [Parameter(Mandatory = false)]
    public SharingDomainRestrictionMode SharingDomainRestrictionMode { get; private set; }

    [Parameter(Mandatory = false)]
    public bool ShowAllUsersClaim { get; private set; }

    [Parameter(Mandatory = false)]
    public bool ShowEveryoneClaim { get; private set; }

    [Parameter(Mandatory = false)]
    public bool ShowEveryoneExceptExternalUsersClaim { get; private set; }

    [Parameter(Mandatory = false)]
    public bool ShowPeoplePickerSuggestionsForGuestUsers { get; private set; }

    [Parameter(Mandatory = false)]
    public bool ShowPeoplePickerGroupSuggestionsForInformationBarriers { get; private set; }

    [Parameter(Mandatory = false)]
    public string SignInAccelerationDomain { get; private set; }

    [Parameter(Mandatory = false)]
    public bool SiteOwnerManageLegacyServicePrincipalEnabled { get; private set; }

    [Parameter(Mandatory = false)]
    public bool SocialBarOnSitePagesDisabled { get; private set; }

    [Parameter(Mandatory = false)]
    public SpecialCharactersState SpecialCharactersStateInFileFolderNames { get; private set; }

    [Parameter(Mandatory = false)]
    public string StartASiteFormUrl { get; private set; }

    [Parameter(Mandatory = false)]
    public bool StopNew2010Workflows { get; private set; }

    [Parameter(Mandatory = false)]
    public bool StopNew2013Workflows { get; private set; }

    [Parameter(Mandatory = false)]
    public bool SyncPrivacyProfileProperties { get; private set; }

    [Parameter(Mandatory = false)]
    public bool TaxonomyTaggingEnabled { get; private set; }

    [Parameter(Mandatory = false)]
    public string TaxonomyTaggingSiteListFileName { get; private set; }

    [Parameter(Mandatory = false)]
    public bool TranslationEnabled { get; private set; }

    [Parameter(Mandatory = false)]
    public string TranslationSiteListFileName { get; private set; }

    [Parameter(Mandatory = false)]
    public bool UniversalAnnotationDisabled { get; private set; }

    [Parameter(Mandatory = false)]
    public bool UseFindPeopleInPeoplePicker { get; private set; }

    [Parameter(Mandatory = false)]
    public bool UsePersistentCookiesForExplorerView { get; private set; }

    [Parameter(Mandatory = false)]
    public bool ViewersCanCommentOnMediaDisabled { get; private set; }

    [Parameter(Mandatory = false)]
    public bool ViewInFileExplorerEnabled { get; private set; }

    [Parameter(Mandatory = false)]
    public string WhoCanShareAllowListInTenant { get; private set; }

    [Parameter(Mandatory = false)]
    public string[] WhoCanShareAllowListInTenantByPrincipalIdentity { get; private set; }

    [Parameter(Mandatory = false)]
    public bool Workflow2010Disabled { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter PassThru { get; private set; }

    protected override void ProcessRecordCore()
    {
        this.Service.SetObject(this.MyInvocation.BoundParameters);
        if (this.PassThru)
        {
            this.Outputs.Add(this.Service.GetObject());
        }
    }

}
