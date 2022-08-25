//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Tests.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests
{

    [TestClass()]
    public class SetTenantCommandTests
    {

        [TestMethod()]
        public void SetTenant()
        {
            using var context = new PSCmdletContext();
            var result1 = context.Runspace.InvokeCommand(
                "Connect-KshSite",
                new Dictionary<string, object>()
                {
                    { "Url", context.AppSettings["AdminUrl"] },
                    { "Credential", PSCredentialFactory.CreateCredential(
                        context.AppSettings["LoginUserName"],
                        context.AppSettings["LoginPassword"])
                    }
                }
            );
            var result2 = context.Runspace.InvokeCommand(
                "Set-KshTenant",
                new Dictionary<string, object>()
                {
                    // { "AddressbarLinkPermission", "None" },
                    // { "AIBuilderDefaultPowerAppsEnvironment", null },
                    // { "AIBuilderEnabled", false },
                    // { "AIBuilderEnabledInContentCenter", 0 },
                    // { "AIBuilderSiteInfoList", null },
                    // { "AIBuilderSiteList", null },
                    // { "AIBuilderSiteListFileName", null },
                    // { "AllowAnonymousMeetingParticipantsToAccessWhiteboards", "Unspecified" },
                    // { "AllowCommentsTextOnEmailEnabled", true },
                    // { "AllowDownloadingNonWebViewableFiles", true },
                    // { "AllowedDomainListForSyncClient", Array.Empty<Guid>() },
                    // { "AllowEditing", true },
                    // { "AllowGuestUserShareToUsersNotInSiteCollection", false },
                    // { "AllowLimitedAccessOnUnmanagedDevices", false },
                    // { "AllowOverrideForBlockUserInfoVisibility", false },
                    // { "AllowSelectSharingGroupsInOneDriveListInTenant", null },
                    // { "AnyoneLinkTrackUsers", false },
                    // { "ApplyAppEnforcedRestrictionsToAdHocRecipients", true },
                    // { "AuthenticationContextResilienceMode", "Default" },
                    // { "BccExternalSharingInvitations", false },
                    // { "BccExternalSharingInvitationsList", null },
                    // { "BlockAccessOnUnmanagedDevices", false },
                    // { "BlockDownloadLinksFileType", "WebPreviewableFiles" },
                    // { "BlockDownloadOfAllFilesForGuests", false },
                    // { "BlockDownloadOfAllFilesOnUnmanagedDevices", false },
                    // { "BlockDownloadOfViewableFilesForGuests", false },
                    // { "BlockDownloadOfViewableFilesOnUnmanagedDevices", false },
                    // { "BlockMacSync", false },
                    // { "BlockSendLabelMismatchEmail", false },
                    // { "BlockUserInfoVisibility", "None" },
                    // { "BlockUserInfoVisibilityInOneDrive", "ApplyToNoUsers" },
                    // { "BlockUserInfoVisibilityInSharePoint", "ApplyToNoUsers" },
                    // { "ChannelMeetingRecordingPermission", "Editable" },
                    // { "CommentsOnFilesDisabled", false },
                    // { "CommentsOnListItemsDisabled", false },
                    // { "CommentsOnSitePagesDisabled", false },
                    // { "CompatibilityRange", "15,15" },
                    // { "ConditionalAccessPolicy", "AllowFullAccess" },
                    // { "ConditionalAccessPolicyErrorHelpLink", null },
                    // { "ContentTypeSyncSiteTemplatesList", Array.Empty<string>() },
                    // { "CoreLoopDefaultSharingLinkRole", "None" },
                    // { "CoreLoopDefaultSharingLinkScope", "Uninitialized" },
                    // { "CoreLoopSharingCapability", "ExternalUserAndGuestSharing" },
                    // { "CoreRequestFilesLinkEnabled", true },
                    // { "CoreRequestFilesLinkExpirationInDays", -1 },
                    // { "CoreSharingCapability", "ExternalUserAndGuestSharing" },
                    // { "CustomizedExternalSharingServiceUrl", null },
                    // { "DefaultContentCenterSite", null },
                    // { "DefaultLinkPermission", "Edit" },
                    // { "DefaultOneDriveMode", null },
                    // { "DefaultSharingLinkType", "Internal" },
                    // { "DisableAddToOneDrive", false },
                    // { "DisableBackToClassic", false },
                    // { "DisableCustomAppAuthentication", true },
                    // { "DisableListSync", false },
                    // { "DisabledModernListTemplateIds", Array.Empty<Guid>() },
                    // { "DisabledWebPartIds", Array.Empty<Guid>() },
                    // { "DisableOutlookPSTVersionTrimming", false },
                    // { "DisablePersonalListCreation", false },
                    // { "DisableReportProblemDialog", false },
                    // { "DisableSpacesActivation", false },
                    // { "DisallowInfectedFileDownload", false },
                    // { "DisplayNamesOfFileViewers", true },
                    // { "DisplayNamesOfFileViewersInSharePoint", true },
                    // { "DisplayStartASiteOption", true },
                    // { "EmailAttestationEnabled", false },
                    // { "EmailAttestationReAuthDays", 30 },
                    // { "EmailAttestationRequired", false },
                    // { "EnableAIPIntegration", false },
                    // { "EnableAutoNewsDigest", true },
                    // { "EnableAzureAdB2BIntegration", false },
                    // { "EnableGuestSignInAcceleration", false },
                    // { "EnableMinimumVersionRequirement", true },
                    // { "EnableMipSiteLabel", false },
                    // { "EnablePromotedFileHandlers", true },
                    // { "EnableRestrictedAccessControl", false },
                    // { "ExcludedFileExtensionsForSyncClient", Array.Empty<string>() },
                    // { "ExternalServicesEnabled", true },
                    // { "ExternalUserExpirationRequired", false },
                    // { "ExternalUserExpireInDays", 60 },
                    // { "FileAnonymousLinkType", "Edit" },
                    // { "FilePickerExternalImageSearchEnabled", true },
                    // { "FolderAnonymousLinkType", "Edit" },
                    // { "GuestSharingGroupAllowListInTenant", null },
                    // { "GuestSharingGroupAllowListInTenantByPrincipalIdentity", Array.Empty<string>() },
                    // { "HasAdminCompletedCUConfiguration", false },
                    // { "HasIntelligentContentServicesCapability", false },
                    // { "HasTopicExperiencesCapability", false },
                    // { "HideDefaultThemes", false },
                    // { "HideSyncButtonOnDocLib", false },
                    // { "HideSyncButtonOnOneDrive", false },
                    // { "ImageTaggingOption", "Basic" },
                    // { "IncludeAtAGlanceInShareEmails", true },
                    // { "InformationBarriersImplicitGroupBased", false },
                    // { "InformationBarriersSuspension", true },
                    // { "IPAddressAllowList", null },
                    // { "IPAddressEnforcement", false },
                    // { "IPAddressWacTokenLifetime", 15 },
                    // { "IsAppBarTemporarilyDisabled", false },
                    // { "IsCollabMeetingNotesFluidEnabled", true },
                    // { "IsFluidEnabled", true },
                    // { "IsLoopEnabled", true },
                    // { "IsUnmanagedSyncClientForTenantRestricted", false },
                    // { "IsWhiteboardFluidEnabled", true },
                    // { "LabelMismatchEmailHelpLink", null },
                    // { "LegacyAuthProtocolsEnabled", false },
                    // { "LimitedAccessFileType", "WebPreviewableFiles" },
                    // { "MachineLearningCaptureEnabled", false },
                    // { "MarkNewFilesSensitiveByDefault", "AllowExternalSharing" },
                    // { "MediaTranscription", "Enabled" },
                    // { "MobileFriendlyUrlEnabledInTenant", false },
                    // { "NoAccessRedirectUrl", null },
                    // { "NotificationsInOneDriveEnabled", true },
                    // { "NotificationsInSharePointEnabled", true },
                    // { "NotifyOwnersWhenInvitationsAccepted", true },
                    // { "NotifyOwnersWhenItemsReshared", true },
                    // { "OCRAdminEnabled", false },
                    // { "OfficeClientAdalDisabled", false },
                    // { "OneDriveAccessRequests", "Unspecified" },
                    // { "OneDriveForGuestsEnabled", false },
                    // { "OneDriveLoopDefaultSharingLinkRole", "None" },
                    // { "OneDriveLoopDefaultSharingLinkScope", "Uninitialized" },
                    // { "OneDriveLoopSharingCapability", "ExternalUserAndGuestSharing" },
                    // { "OneDriveMembersCanShare", "Unspecified" },
                    // { "OneDriveRequestFilesLinkEnabled", true },
                    // { "OneDriveRequestFilesLinkExpirationInDays", -1 },
                    // { "OneDriveSharingCapability", "ExternalUserAndGuestSharing" },
                    // { "OneDriveStorageQuota", 1048576 },
                    // { "OptOutOfGrooveBlock", false },
                    // { "OptOutOfGrooveSoftBlock", false },
                    // { "OrphanedPersonalSitesRetentionPeriod", 30 },
                    // { "OwnerAnonymousNotification", true },
                    // { "PermissiveBrowserFileHandlingOverride", false },
                    // { "PreventExternalUsersFromResharing", false },
                    // { "ProvisionSharedWithEveryoneFolder", false },
                    // { "ReduceTempTokenLifetimeEnabled", false },
                    // { "ReduceTempTokenLifetimeValue", 15 },
                    // { "RequireAcceptingAccountMatchInvitedAccount", false },
                    // { "RequireAnonymousLinksExpireInDays", -1 },
                    // { "SearchResolveExactEmailOrUpn", false },
                    // { "SharingAllowedDomainList", "example.com" },
                    // { "SharingBlockedDomainList", "example.com" },
                    // { "SharingCapability", "ExternalUserAndGuestSharing" },
                    // { "SharingDomainRestrictionMode", "None" },
                    // { "ShowAllUsersClaim", false },
                    // { "ShowEveryoneClaim", false },
                    // { "ShowEveryoneExceptExternalUsersClaim", true },
                    // { "ShowOpenInDesktopOptionForSyncedFiles", false },
                    // { "ShowPeoplePickerSuggestionsForGuestUsers", false },
                    // { "ShowPeoplePickerGroupSuggestionsForInformationBarriers", false },
                    // { "SignInAccelerationDomain", null },
                    // { "SocialBarOnSitePagesDisabled", false },
                    // { "SpecialCharactersStateInFileFolderNames", "Allowed" },
                    // { "StartASiteFormUrl", null },
                    // { "StopNew2010Workflows", false },
                    // { "StopNew2013Workflows", false },
                    // { "StreamLaunchConfig", 0 },
                    // { "StreamLaunchConfigLastUpdated", null },
                    // { "SyncAzureAdB2BManagementPolicy", true },
                    // { "SyncPrivacyProfileProperties", true },
                    // { "UseFindPeopleInPeoplePicker", false },
                    // { "UsePersistentCookiesForExplorerView", false },
                    // { "ViewersCanCommentOnMediaDisabled", false },
                    // { "ViewInFileExplorerEnabled", false },
                    // { "WhoCanShareAllowListInTenant", null },
                    // { "WhoCanShareAllowListInTenantByPrincipalIdentity", Array.Empty<string>() },
                    // { "Workflow2010Disabled", true }
                }
            );
        }

    }

}
