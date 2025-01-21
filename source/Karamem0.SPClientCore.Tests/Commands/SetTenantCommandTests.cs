//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Tests.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands.Tests;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class SetTenantCommandTests
{

    [Test()]
    public void InvokeCommand_SetItem_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["AdminUrl"] },
                { "ClientId", context.AppSettings["ClientId"] },
                { "CertificatePath", context.AppSettings["CertificatePath"] },
                { "CertificatePassword", context.AppSettings["CertificatePassword"].ToSecureString() }
            }
        );
        var result1 = context.Runspace.InvokeCommand<Tenant>(
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
                // { "AllowedDomainListForSyncClient", null },
                // { "AllowEditing", true },
                // { "AllowEveryoneExceptExternalUsersClaimInPrivateSite", true },
                // { "AllowGuestUserShareToUsersNotInSiteCollection", false },
                // { "AllowLimitedAccessOnUnmanagedDevices", false },
                // { "AllowOverrideForBlockUserInfoVisibility", false },
                // { "AllowSelectSecurityGroupsInSPSitesList", null },
                // { "AllowSelectSGsInODBListInTenant", null },
                // { "AnyoneLinkTrackUsers", false },
                // { "ApplyAppEnforcedRestrictionsToAdHocRecipients", true },
                // { "ArchiveRedirectUrl", null },
                // { "AuthenticationContextResilienceMode", "Default" },
                // { "BccExternalSharingInvitations", false },
                // { "BccExternalSharingInvitationsList", null },
                // { "BlockAccessOnUnmanagedDevices", false },
                // { "BlockDownloadFileTypeIds", null },
                // { "BlockDownloadFileTypePolicy", false },
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
                // { "CommentsOnFilesDisabled", false },
                // { "CommentsOnListItemsDisabled", false },
                // { "CommentsOnSitePagesDisabled", false },
                // { "CompatibilityRange", "15,15" },
                // { "ConditionalAccessPolicy", "AllowFullAccess" },
                // { "ConditionalAccessPolicyErrorHelpLink", null },
                // { "ContentTypeSyncSiteTemplatesList", null },
                // { "CoreBlockGuestsAsSiteAdmin", 0 },
                // { "CoreDefaultLinkToExistingAccess", false },
                // { "CoreDefaultSharingLinkRole", "None" },
                // { "CoreDefaultSharingLinkScope", "Anyone" },
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
                // { "DenySelectSecurityGroupsInSPSitesList", null },
                // { "DisableAddToOneDrive", false },
                // { "DisableBackToClassic", false },
                // { "DisableCustomAppAuthentication", true },
                // { "DisabledModernListTemplateIds", null },
                // { "DisableDocumentLibraryDefaultLabeling", false },
                // { "DisabledWebPartIds", null },
                // { "DisableListSync", false },
                // { "DisableOutlookPSTVersionTrimming", false },
                // { "DisablePersonalListCreation", false },
                // { "DisableReportProblemDialog", false },
                // { "DisableSpacesActivation", false },
                // { "DisableVivaConnectionsAnalytics", false },
                // { "DisallowInfectedFileDownload", false },
                // { "DisplayNamesOfFileViewers", true },
                // { "DisplayNamesOfFileViewersInSharePoint", true },
                // { "DisplayStartASiteOption", true },
                // { "EmailAttestationEnabled", false },
                // { "EmailAttestationReAuthDays", 30 },
                // { "EmailAttestationRequired", false },
                // { "EnableAIPIntegration", false },
                // { "EnableAutoExpirationVersionTrim", false },
                // { "EnableAutoNewsDigest", true },
                // { "EnableAzureAdB2BIntegration", false },
                // { "EnabledFlightAllowAzureAdB2BSkipCheckingOneTimePassword", true },
                // { "EnableGuestSignInAcceleration", false },
                // { "EnableMinimumVersionRequirement", true },
                // { "EnableMipSiteLabel", false },
                // { "EnablePromotedFileHandlers", true },
                // { "EnableRestrictedAccessControl", false },
                // { "EnableVersionExpirationSetting", false },
                // { "ExcludedBlockDownloadGroupIds", null },
                // { "ExcludedFileExtensionsForSyncClient", null },
                // { "ExpireVersionsAfterDays", 0 },
                // { "ExternalServicesEnabled", true },
                // { "ExternalUserExpirationRequired", false },
                // { "ExternalUserExpireInDays", 60 },
                // { "FileAnonymousLinkType", "Edit" },
                // { "FilePickerExternalImageSearchEnabled", true },
                // { "FileVersionPolicyXml", null },
                // { "FolderAnonymousLinkType", "Edit" },
                // { "GuestSharingGroupAllowListInTenant", null },
                // { "GuestSharingGroupAllowListInTenantByPrincipalIdentity", null },
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
                // { "IsEnableAppAuthPopUpEnabled", false },
                // { "IsFluidEnabled", true },
                // { "IsHubSitesMultiGeoFlightEnabled", true },
                // { "IsLoopEnabled", true },
                // { "IsMnAFlightEnabled", false },
                // { "IsMultiGeo", false },
                // { "IsMultipleHomeSitesFlightEnabled", false },
                // { "IsUnmanagedSyncClientForTenantRestricted", false },
                // { "IsUnmanagedSyncClientRestrictionFlightEnabled", true },
                // { "IsVivaHomeFlightEnabled", true },
                // { "IsVivaHomeGAFlightEnabled", false },
                // { "IsWhiteboardFluidEnabled", true },
                // { "LabelMismatchEmailHelpLink", null },
                // { "LegacyAuthProtocolsEnabled", false },
                // { "LimitedAccessFileType", "WebPreviewableFiles" },
                // { "MachineLearningCaptureEnabled", false },
                // { "MajorVersionLimit", 500 },
                // { "MarkNewFilesSensitiveByDefault", "AllowExternalSharing" },
                // { "MediaTranscription", "Enabled" },
                // { "MobileFriendlyUrlEnabledInTenant", false },
                // { "NoAccessRedirectUrl", null },
                // { "NotificationsInOneDriveEnabled", true },
                // { "NotificationsInSharePointEnabled", true },
                // { "NotifyOwnersWhenInvitationsAccepted", true },
                // { "NotifyOwnersWhenItemsReshared", true },
                // { "OfficeClientAdalDisabled", false },
                // { "OCRAdminSiteListFileName", null },
                // { "OCRComplianceSiteListFileName", null },
                // { "OCRModeForAdminSites", 0 },
                // { "OCRModeForComplianceODBs", 0 },
                // { "OCRModeForComplianceSites", 0 },
                // { "OneDriveAccessRequests", "Unspecified" },
                // { "OneDriveBlockGuestsAsSiteAdmin", 0 },
                // { "OneDriveDefaultLinkToExistingAccess", false },
                // { "OneDriveDefaultSharingLinkRole", "None" },
                // { "OneDriveDefaultSharingLinkScope", "Anyone" },
                // { "OneDriveForGuestsEnabled", false },
                // { "OneDriveLoopDefaultSharingLinkRole", "None" },
                // { "OneDriveLoopDefaultSharingLinkScope", "Anyone" },
                // { "OneDriveLoopSharingCapability", "ExternalUserAndGuestSharing" },
                // { "OneDriveMembersCanShare", "Unspecified" },
                // { "OneDriveRequestFilesLinkEnabled", true },
                // { "OneDriveRequestFilesLinkExpirationInDays", -1 },
                // { "OneDriveSharingCapability", "ExternalUserAndGuestSharing" },
                // { "OneDriveStorageQuota", 1048576 },
                // { "OptOutOfGrooveBlock", false },
                // { "OptOutOfGrooveSoftBlock", false },
                // { "OrgNewsSiteUrl", null },
                // { "OrphanedPersonalSitesRetentionPeriod", 30 },
                // { "OwnerAnonymousNotification", true },
                // { "PermissiveBrowserFileHandlingOverride", false },
                // { "PreventExternalUsersFromResharing", false },
                // { "ProvisionSharedWithEveryoneFolder", false },
                // { "PublicCdnAllowedFileTypes", "CSS, EOT, GIF, ICO, JPEG, JPG, JS, MAP, PNG, SVG, TTF, WOFF" },
                // { "PublicCdnEnabled", false },
                // { "PublicCdnOrigins", null },
                // { "ReduceTempTokenLifetimeEnabled", false },
                // { "ReduceTempTokenLifetimeValue", 15 },
                // { "RequireAcceptingAccountMatchInvitedAccount", false },
                // { "RequireAnonymousLinksExpireInDays", -1 },
                // { "ResourceQuota", 0 },
                // { "ResourceQuotaAllocated", 0 },
                // { "RestrictedOneDriveLicense", false },
                // { "RestrictedSharePointLicense", false },
                // { "RootSiteUrl", null },
                // { "SearchResolveExactEmailOrUpn", false },
                // { "SharingAllowedDomainList", "example.com" },
                // { "SharingBlockedDomainList", "example.com" },
                // { "SharingCapability", "ExternalUserAndGuestSharing" },
                // { "SharingDomainRestrictionMode", "None" },
                // { "ShowAllUsersClaim", false },
                // { "ShowEveryoneClaim", false },
                // { "ShowEveryoneExceptExternalUsersClaim", true },
                // { "ShowNextGenerationSyncClientDialogForSyncOnOneDrive", true },
                // { "ShowOpenInDesktopOptionForSyncedFiles", false },
                // { "ShowPeoplePickerSuggestionsForGuestUsers", false },
                // { "ShowPeoplePickerGroupSuggestionsForInformationBarriers", false },
                // { "SignInAccelerationDomain", null },
                // { "SocialBarOnSitePagesDisabled", false },
                // { "SpecialCharactersStateInFileFolderNames", "Allowed" },
                // { "StartASiteFormUrl", null },
                // { "StopNew2010Workflows", false },
                // { "StopNew2013Workflows", false },
                // { "StorageQuota", 1304576 },
                // { "StorageQuotaAllocated", 0 },
                // { "StreamLaunchConfig", 0 },
                // { "StreamLaunchConfigLastUpdated", null },
                // { "StreamLaunchConfigUpdateCount", 0 },
                // { "SyncPrivacyProfileProperties", true },
                // { "TlsTokenBindingPolicyValue", 0 },
                // { "UseFindPeopleInPeoplePicker", false },
                // { "UsePersistentCookiesForExplorerView", false },
                // { "ViewersCanCommentOnMediaDisabled", false },
                // { "ViewInFileExplorerEnabled", false },
                // { "WhoCanShareAllowListInTenant", null },
                // { "WhoCanShareAllowListInTenantByPrincipalIdentity", null },
                // { "Workflow2010Disabled", true },
                // { "Workflows2013State", 2 },
                { "PassThru", true }
            }
        );
        var actual = result1.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}
