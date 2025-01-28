---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Set-KshTenant

## SYNOPSIS
Updates the tenant properties.

## SYNTAX

```
Set-KshTenant [-AddressbarLinkPermission <RoleType>]
 [-AllowAnonymousMeetingParticipantsToAccessWhiteboards <SharingState>]
 [-AllowCommentsTextOnEmailEnabled <Boolean>] [-AllowDownloadingNonWebViewableFiles <Boolean>]
 [-AllowedDomainListForSyncClient <Guid[]>] [-AllowEditing <Boolean>]
 [-AllowEveryoneExceptExternalUsersClaimInPrivateSite <Boolean>]
 [-AllowGuestUserShareToUsersNotInSiteCollection <Boolean>] [-AllowLimitedAccessOnUnmanagedDevices <Boolean>]
 [-AllowOverrideForBlockUserInfoVisibility <Boolean>] [-AnyoneLinkTrackUsers <Boolean>]
 [-ApplyAppEnforcedRestrictionsToAdHocRecipients <Boolean>]
 [-AuthenticationContextResilienceMode <ResilienceMode>] [-BccExternalSharingInvitations <Boolean>]
 [-BccExternalSharingInvitationsList <String>] [-BlockAccessOnUnmanagedDevices <Boolean>]
 [-BlockDownloadLinksFileType <BlockDownloadLinksFileType>] [-BlockMacSync <Boolean>]
 [-BlockSendLabelMismatchEmail <Boolean>] [-BlockUserInfoVisibility <String>]
 [-BlockUserInfoVisibilityInOneDrive <TenantBrowseUserInfoPolicyType>]
 [-BlockUserInfoVisibilityInSharePoint <TenantBrowseUserInfoPolicyType>] [-CommentsOnFilesDisabled <Boolean>]
 [-CommentsOnListItemsDisabled <Boolean>] [-CommentsOnSitePagesDisabled <Boolean>]
 [-CompatibilityRange <String>] [-ConditionalAccessPolicy <ConditionalAccessPolicyType>]
 [-ConditionalAccessPolicyErrorHelpLink <String>] [-ContentTypeSyncSiteTemplatesList <String[]>]
 [-CoreLoopDefaultSharingLinkRole <RoleType>] [-CoreLoopDefaultSharingLinkScope <SharingScope>]
 [-CoreLoopSharingCapability <SharingCapabilities>] [-CoreRequestFilesLinkEnabled <Boolean>]
 [-CoreRequestFilesLinkExpirationInDays <Int32>] [-CoreSharingCapability <SharingCapabilities>]
 [-CustomizedExternalSharingServiceUrl <String>] [-DefaultContentCenterSite <SiteInfoForSitePicker>]
 [-DefaultLinkPermission <SharingPermissionType>] [-DefaultOneDriveMode <String>]
 [-DefaultSharingLinkType <SharingLinkType>] [-DisableAddToOneDrive <Boolean>]
 [-DisableBackToClassic <Boolean>] [-DisableCustomAppAuthentication <Boolean>]
 [-DisabledModernListTemplateIds <Guid[]>] [-DisabledWebPartIds <Guid[]>]
 [-DisableOutlookPSTVersionTrimming <Boolean>] [-DisablePersonalListCreation <Boolean>]
 [-DisableReportProblemDialog <Boolean>] [-DisableSpacesActivation <Boolean>]
 [-DisallowInfectedFileDownload <Boolean>] [-DisplayNamesOfFileViewers <Boolean>]
 [-DisplayNamesOfFileViewersInSharePoint <Boolean>] [-DisplayStartASiteOption <Boolean>]
 [-EmailAttestationEnabled <Boolean>] [-EmailAttestationReAuthDays <Int32>]
 [-EmailAttestationRequired <Boolean>] [-EnableAIPIntegration <Boolean>] [-EnableAutoNewsDigest <Boolean>]
 [-EnableAzureAdB2BIntegration <Boolean>] [-EnableGuestSignInAcceleration <Boolean>]
 [-EnableMinimumVersionRequirement <Boolean>] [-EnableMipSiteLabel <Boolean>]
 [-EnablePromotedFileHandlers <Boolean>] [-EnableRestrictedAccessControl <Boolean>]
 [-ExcludedFileExtensionsForSyncClient <String[]>] [-ExternalServicesEnabled <Boolean>]
 [-ExternalUserExpirationRequired <Boolean>] [-ExternalUserExpireInDays <Int32>]
 [-FileAnonymousLinkType <AnonymousLinkType>] [-FilePickerExternalImageSearchEnabled <Boolean>]
 [-FolderAnonymousLinkType <AnonymousLinkType>] [-GuestSharingGroupAllowListInTenant <String>]
 [-GuestSharingGroupAllowListInTenantByPrincipalIdentity <String[]>]
 [-HasAdminCompletedCUConfiguration <Boolean>] [-HideDefaultThemes <Boolean>]
 [-HideSyncButtonOnDocLib <Boolean>] [-HideSyncButtonOnOneDrive <Boolean>]
 [-ImageTaggingOption <ImageTaggingChoice>] [-IncludeAtAGlanceInShareEmails <Boolean>]
 [-InformationBarriersImplicitGroupBased <Boolean>] [-InformationBarriersSuspension <Boolean>]
 [-IPAddressAllowList <String>] [-IPAddressEnforcement <Boolean>] [-IPAddressWacTokenLifetime <Int32>]
 [-IsAppBarTemporarilyDisabled <Boolean>] [-IsCollabMeetingNotesFluidEnabled <Boolean>]
 [-IsFluidEnabled <Boolean>] [-IsLoopEnabled <Boolean>] [-IsUnmanagedSyncClientForTenantRestricted <Boolean>]
 [-IsVivaHomeFlightEnabled <Boolean>] [-IsWhiteboardFluidEnabled <Boolean>]
 [-LabelMismatchEmailHelpLink <String>] [-LegacyBrowserAuthProtocolsEnabled <Boolean>]
 [-LegacyAuthProtocolsEnabled <Boolean>] [-LimitedAccessFileType <LimitedAccessFileType>]
 [-MachineLearningCaptureEnabled <Boolean>] [-MajorVersionLimit <Int32>]
 [-MarkNewFilesSensitiveByDefault <SensitiveByDefaultState>]
 [-MediaTranscription <MediaTranscriptionPolicyType>] [-MobileFriendlyUrlEnabledInTenant <Boolean>]
 [-NoAccessRedirectUrl <String>] [-NotificationsInOneDriveEnabled <Boolean>]
 [-NotificationsInSharePointEnabled <Boolean>] [-NotifyOwnersWhenInvitationsAccepted <Boolean>]
 [-NotifyOwnersWhenItemsReshared <Boolean>] [-OfficeClientAdalDisabled <Boolean>]
 [-OneDriveAccessRequests <SharingState>] [-OneDriveForGuestsEnabled <Boolean>]
 [-OneDriveLoopDefaultSharingLinkRole <RoleType>] [-OneDriveLoopDefaultSharingLinkScope <SharingScope>]
 [-OneDriveLoopSharingCapability <SharingCapabilities>] [-OneDriveMembersCanShare <SharingState>]
 [-OneDriveRequestFilesLinkEnabled <Boolean>] [-OneDriveRequestFilesLinkExpirationInDays <Int32>]
 [-OneDriveSharingCapability <SharingCapabilities>] [-OneDriveStorageQuota <Int64>]
 [-OptOutOfGrooveBlock <Boolean>] [-OptOutOfGrooveSoftBlock <Boolean>]
 [-OrphanedPersonalSitesRetentionPeriod <Int32>] [-OwnerAnonymousNotification <Boolean>]
 [-PermissiveBrowserFileHandlingOverride <Boolean>] [-PreventExternalUsersFromResharing <Boolean>]
 [-ProvisionSharedWithEveryoneFolder <Boolean>] [-ReduceTempTokenLifetimeEnabled <Boolean>]
 [-ReduceTempTokenLifetimeValue <Int32>] [-RequireAcceptingAccountMatchInvitedAccount <Boolean>]
 [-RequireAnonymousLinksExpireInDays <Int32>] [-SearchResolveExactEmailOrUpn <Boolean>]
 [-SelfServiceSiteCreationDisabled <Boolean>] [-SharePointAddInsDisabled <Boolean>]
 [-SharingAllowedDomainList <String>] [-SharingBlockedDomainList <String>]
 [-SharingCapability <SharingCapabilities>] [-SharingDomainRestrictionMode <SharingDomainRestrictionMode>]
 [-ShowAllUsersClaim <Boolean>] [-ShowEveryoneClaim <Boolean>]
 [-ShowEveryoneExceptExternalUsersClaim <Boolean>] [-ShowPeoplePickerSuggestionsForGuestUsers <Boolean>]
 [-ShowPeoplePickerGroupSuggestionsForInformationBarriers <Boolean>] [-SignInAccelerationDomain <String>]
 [-SiteOwnerManageLegacyServicePrincipalEnabled <Boolean>] [-SocialBarOnSitePagesDisabled <Boolean>]
 [-SpecialCharactersStateInFileFolderNames <SpecialCharactersState>] [-StartASiteFormUrl <String>]
 [-StopNew2010Workflows <Boolean>] [-StopNew2013Workflows <Boolean>] [-SyncPrivacyProfileProperties <Boolean>]
 [-TaxonomyTaggingEnabled <Boolean>] [-TaxonomyTaggingSiteListFileName <String>]
 [-TranslationEnabled <Boolean>] [-TranslationSiteListFileName <String>]
 [-UniversalAnnotationDisabled <Boolean>] [-UseFindPeopleInPeoplePicker <Boolean>]
 [-UsePersistentCookiesForExplorerView <Boolean>] [-ViewersCanCommentOnMediaDisabled <Boolean>]
 [-ViewInFileExplorerEnabled <Boolean>] [-WhoCanShareAllowListInTenant <String>]
 [-WhoCanShareAllowListInTenantByPrincipalIdentity <String[]>] [-Workflow2010Disabled <Boolean>] [-PassThru]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Set-KshTenant` cmdlet updates the properties of the tenant.

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-KshTenant -AllowEditing $true
```

This example enables editing for the tenant.

## PARAMETERS

### -AddressbarLinkPermission
Specifies the permission level for links in the address bar.

```yaml
Type: RoleType
Parameter Sets: (All)
Aliases:
Accepted values: None, View, Edit, Owner, LimitedView, LimitedEdit, Review, RestrictedView, Submit, ManageList

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AllowAnonymousMeetingParticipantsToAccessWhiteboards
Specifies whether anonymous meeting participants can access whiteboards.

```yaml
Type: SharingState
Parameter Sets: (All)
Aliases:
Accepted values: Unspecified, On, Off

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AllowCommentsTextOnEmailEnabled
Specifies whether comments text on email is enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AllowDownloadingNonWebViewableFiles
Specifies whether downloading non-web viewable files is allowed.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AllowEditing
Specifies whether editing is allowed.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AllowEveryoneExceptExternalUsersClaimInPrivateSite
Specifies whether everyone except external users claim is allowed in private sites.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AllowGuestUserShareToUsersNotInSiteCollection
Specifies whether guest users can share to users not in the site collection.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AllowLimitedAccessOnUnmanagedDevices
Specifies whether limited access is allowed on unmanaged devices.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AllowOverrideForBlockUserInfoVisibility
Specifies whether override for block user info visibility is allowed.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AllowedDomainListForSyncClient
Specifies the list of allowed domains for the sync client.

```yaml
Type: Guid[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AnyoneLinkTrackUsers
Specifies whether anyone link track users is enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApplyAppEnforcedRestrictionsToAdHocRecipients
Specifies whether app enforced restrictions apply to ad hoc recipients.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AuthenticationContextResilienceMode
Specifies the resilience mode for authentication context.

```yaml
Type: ResilienceMode
Parameter Sets: (All)
Aliases:
Accepted values: Default, Enabled, Disabled

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BccExternalSharingInvitations
Specifies whether BCC is enabled for external sharing invitations.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BccExternalSharingInvitationsList
Specifies the list of email addresses to BCC for external sharing invitations.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BlockAccessOnUnmanagedDevices
Specifies whether access is blocked on unmanaged devices.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BlockDownloadLinksFileType
Specifies the file types for which download links are blocked.

```yaml
Type: BlockDownloadLinksFileType
Parameter Sets: (All)
Aliases:
Accepted values: WebPreviewableFiles, ServerRenderedFilesOnly

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BlockMacSync
Specifies whether Mac sync is blocked.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BlockSendLabelMismatchEmail
Specifies whether sending label mismatch emails is blocked.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BlockUserInfoVisibility
Specifies the user info visibility settings.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BlockUserInfoVisibilityInOneDrive
Specifies the user info visibility settings in OneDrive.

```yaml
Type: TenantBrowseUserInfoPolicyType
Parameter Sets: (All)
Aliases:
Accepted values: ApplyToNoUsers, ApplyToGuestAndExternalUsers

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BlockUserInfoVisibilityInSharePoint
Specifies the user info visibility settings in SharePoint.

```yaml
Type: TenantBrowseUserInfoPolicyType
Parameter Sets: (All)
Aliases:
Accepted values: ApplyToNoUsers, ApplyToGuestAndExternalUsers

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommentsOnFilesDisabled
Specifies whether comments on files are disabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommentsOnListItemsDisabled
Specifies whether comments on list items are disabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommentsOnSitePagesDisabled
Specifies whether comments on site pages are disabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CompatibilityRange
Specifies the compatibility range.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConditionalAccessPolicy
Specifies the conditional access policy.

```yaml
Type: ConditionalAccessPolicyType
Parameter Sets: (All)
Aliases:
Accepted values: AllowFullAccess, AllowLimitedAccess, BlockAccess, AuthenticationContext

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConditionalAccessPolicyErrorHelpLink
Specifies the help link for conditional access policy errors.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContentTypeSyncSiteTemplatesList
Specifies the list of site templates for content type sync.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CoreLoopDefaultSharingLinkRole
Specifies the default sharing link role for Core Loop.

```yaml
Type: RoleType
Parameter Sets: (All)
Aliases:
Accepted values: None, View, Edit, Owner, LimitedView, LimitedEdit, Review, RestrictedView, Submit, ManageList

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CoreLoopDefaultSharingLinkScope
Specifies the default sharing link scope for Core Loop.

```yaml
Type: SharingScope
Parameter Sets: (All)
Aliases:
Accepted values: Anyone, Organization, SpecificPeople, Uninitialized

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CoreLoopSharingCapability
Specifies the sharing capability for Core Loop.

```yaml
Type: SharingCapabilities
Parameter Sets: (All)
Aliases:
Accepted values: Disabled, ExternalUserSharingOnly, ExternalUserAndGuestSharing, ExistingExternalUserSharingOnly

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CoreRequestFilesLinkEnabled
Specifies whether request files link is enabled for Core.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CoreRequestFilesLinkExpirationInDays
Specifies the expiration in days for request files link in Core.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CoreSharingCapability
Specifies the sharing capability for Core.

```yaml
Type: SharingCapabilities
Parameter Sets: (All)
Aliases:
Accepted values: Disabled, ExternalUserSharingOnly, ExternalUserAndGuestSharing, ExistingExternalUserSharingOnly

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomizedExternalSharingServiceUrl
Specifies the customized external sharing service URL.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultContentCenterSite
Specifies the default content center site.

```yaml
Type: SiteInfoForSitePicker
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultLinkPermission
Specifies the default link permission.

```yaml
Type: SharingPermissionType
Parameter Sets: (All)
Aliases:
Accepted values: None, View, Edit

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultOneDriveMode
Specifies the default OneDrive mode.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultSharingLinkType
Specifies the default sharing link type.

```yaml
Type: SharingLinkType
Parameter Sets: (All)
Aliases:
Accepted values: None, Direct, Internal, AnonymousAccess

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisableAddToOneDrive
Specifies whether Add to OneDrive is disabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisableBackToClassic
Specifies whether Back to Classic is disabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisableCustomAppAuthentication
Specifies whether custom app authentication is disabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisableOutlookPSTVersionTrimming
Specifies whether Outlook PST version trimming is disabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisablePersonalListCreation
Specifies whether personal list creation is disabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisableReportProblemDialog
Specifies whether the report problem dialog is disabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisableSpacesActivation
Specifies whether Spaces activation is disabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisabledModernListTemplateIds
Specifies the list of disabled modern list template IDs.

```yaml
Type: Guid[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisabledWebPartIds
Specifies the list of disabled web part IDs.

```yaml
Type: Guid[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisallowInfectedFileDownload
Specifies whether infected file download is disallowed.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayNamesOfFileViewers
Specifies whether the display names of file viewers are shown.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayNamesOfFileViewersInSharePoint
Specifies whether the display names of file viewers in SharePoint are shown.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayStartASiteOption
Specifies whether the Start a Site option is displayed.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EmailAttestationEnabled
Specifies whether email attestation is enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EmailAttestationReAuthDays
Specifies the re-authentication days for email attestation.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EmailAttestationRequired
Specifies whether email attestation is required.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableAIPIntegration
Specifies whether AIP integration is enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableAutoNewsDigest
Specifies whether auto news digest is enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableAzureAdB2BIntegration
Specifies whether Azure AD B2B integration is enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableGuestSignInAcceleration
Specifies whether guest sign-in acceleration is enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableMinimumVersionRequirement
Specifies whether minimum version requirement is enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableMipSiteLabel
Specifies whether MIP site label is enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnablePromotedFileHandlers
Specifies whether promoted file handlers are enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableRestrictedAccessControl
Specifies whether restricted access control is enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExcludedFileExtensionsForSyncClient
Specifies the list of excluded file extensions for the sync client.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExternalServicesEnabled
Specifies whether external services are enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExternalUserExpirationRequired
Specifies whether external user expiration is required.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExternalUserExpireInDays
Specifies the expiration in days for external users.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FileAnonymousLinkType
Specifies the anonymous link type for files.

```yaml
Type: AnonymousLinkType
Parameter Sets: (All)
Aliases:
Accepted values: None, View, Edit

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilePickerExternalImageSearchEnabled
Specifies whether external image search in file picker is enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FolderAnonymousLinkType
Specifies the anonymous link type for folders.

```yaml
Type: AnonymousLinkType
Parameter Sets: (All)
Aliases:
Accepted values: None, View, Edit

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GuestSharingGroupAllowListInTenant
Specifies the guest sharing group allow list in the tenant.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GuestSharingGroupAllowListInTenantByPrincipalIdentity
Specifies the guest sharing group allow list in the tenant by principal identity.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HasAdminCompletedCUConfiguration
Specifies whether the admin has completed CU configuration.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HideDefaultThemes
Specifies whether default themes are hidden.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HideSyncButtonOnDocLib
Specifies whether the sync button on document libraries is hidden.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HideSyncButtonOnOneDrive
Specifies whether the sync button on OneDrive is hidden.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IPAddressAllowList
Specifies the IP address allow list.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IPAddressEnforcement
Specifies whether IP address enforcement is enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IPAddressWacTokenLifetime
Specifies the WAC token lifetime for IP addresses.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageTaggingOption
Specifies the image tagging option.

```yaml
Type: ImageTaggingChoice
Parameter Sets: (All)
Aliases:
Accepted values: Disabled, Basic, Enhanced

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeAtAGlanceInShareEmails
Specifies whether to include "At a Glance" in share emails.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InformationBarriersImplicitGroupBased
Specifies whether information barriers implicit group-based is enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InformationBarriersSuspension
Specifies whether information barriers suspension is enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsAppBarTemporarilyDisabled
Specifies whether the app bar is temporarily disabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsCollabMeetingNotesFluidEnabled
Specifies whether collaboration meeting notes fluid is enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsFluidEnabled
Specifies whether fluid is enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsLoopEnabled
Specifies whether Loop is enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsUnmanagedSyncClientForTenantRestricted
Specifies whether unmanaged sync client for tenant is restricted.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsVivaHomeFlightEnabled
Specifies whether Viva Home flight is enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsWhiteboardFluidEnabled
Specifies whether whiteboard fluid is enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LabelMismatchEmailHelpLink
Specifies the help link for label mismatch emails.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LegacyAuthProtocolsEnabled
Specifies whether legacy auth protocols are enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LegacyBrowserAuthProtocolsEnabled
Specifies whether legacy browser auth protocols are enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LimitedAccessFileType
Specifies the limited access file type.

```yaml
Type: LimitedAccessFileType
Parameter Sets: (All)
Aliases:
Accepted values: OfficeOnlineFilesOnly, WebPreviewableFiles, OtherFiles

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MachineLearningCaptureEnabled
Specifies whether machine learning capture is enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MajorVersionLimit
Specifies the major version limit.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MarkNewFilesSensitiveByDefault
Specifies whether new files are marked sensitive by default.

```yaml
Type: SensitiveByDefaultState
Parameter Sets: (All)
Aliases:
Accepted values: AllowExternalSharing, BlockExternalSharing

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MediaTranscription
Specifies the media transcription policy.

```yaml
Type: MediaTranscriptionPolicyType
Parameter Sets: (All)
Aliases:
Accepted values: Enabled, Disabled

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MobileFriendlyUrlEnabledInTenant
Specifies whether mobile-friendly URL is enabled in the tenant.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoAccessRedirectUrl
Specifies the no access redirect URL.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NotificationsInOneDriveEnabled
Specifies whether notifications in OneDrive are enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NotificationsInSharePointEnabled
Specifies whether notifications in SharePoint are enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NotifyOwnersWhenInvitationsAccepted
Specifies whether owners are notified when invitations are accepted.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NotifyOwnersWhenItemsReshared
Specifies whether owners are notified when items are reshared.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OfficeClientAdalDisabled
Specifies whether Office client ADAL is disabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OneDriveAccessRequests
Specifies the access requests settings for OneDrive.

```yaml
Type: SharingState
Parameter Sets: (All)
Aliases:
Accepted values: Unspecified, On, Off

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OneDriveForGuestsEnabled
Specifies whether OneDrive for guests is enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OneDriveLoopDefaultSharingLinkRole
Specifies the default sharing link role for OneDrive Loop.

```yaml
Type: RoleType
Parameter Sets: (All)
Aliases:
Accepted values: None, View, Edit, Owner, LimitedView, LimitedEdit, Review, RestrictedView, Submit, ManageList

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OneDriveLoopDefaultSharingLinkScope
Specifies the default sharing link scope for OneDrive Loop.

```yaml
Type: SharingScope
Parameter Sets: (All)
Aliases:
Accepted values: Anyone, Organization, SpecificPeople, Uninitialized

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OneDriveLoopSharingCapability
Specifies the sharing capability for OneDrive Loop.

```yaml
Type: SharingCapabilities
Parameter Sets: (All)
Aliases:
Accepted values: Disabled, ExternalUserSharingOnly, ExternalUserAndGuestSharing, ExistingExternalUserSharingOnly

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OneDriveMembersCanShare
Specifies whether OneDrive members can share.

```yaml
Type: SharingState
Parameter Sets: (All)
Aliases:
Accepted values: Unspecified, On, Off

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OneDriveRequestFilesLinkEnabled
Specifies whether request files link is enabled for OneDrive.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OneDriveRequestFilesLinkExpirationInDays
Specifies the expiration in days for request files link in OneDrive.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OneDriveSharingCapability
Specifies the sharing capability for OneDrive.

```yaml
Type: SharingCapabilities
Parameter Sets: (All)
Aliases:
Accepted values: Disabled, ExternalUserSharingOnly, ExternalUserAndGuestSharing, ExistingExternalUserSharingOnly

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OneDriveStorageQuota
Specifies the storage quota for OneDrive.

```yaml
Type: Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptOutOfGrooveBlock
Specifies whether to opt out of Groove block.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptOutOfGrooveSoftBlock
Specifies whether to opt out of Groove soft block.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OrphanedPersonalSitesRetentionPeriod
Specifies the retention period for orphaned personal sites.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OwnerAnonymousNotification
Specifies whether owners are notified of anonymous access.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns the tenant object that was processed.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PermissiveBrowserFileHandlingOverride
Specifies whether permissive browser file handling override is enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PreventExternalUsersFromResharing
Specifies whether external users are prevented from resharing.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProvisionSharedWithEveryoneFolder
Specifies whether the "Shared with Everyone" folder is provisioned.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReduceTempTokenLifetimeEnabled
Specifies whether reducing temporary token lifetime is enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReduceTempTokenLifetimeValue
Specifies the value for reducing temporary token lifetime.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequireAcceptingAccountMatchInvitedAccount
Specifies whether the accepting account must match the invited account.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequireAnonymousLinksExpireInDays
Specifies the expiration in days for anonymous links.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SearchResolveExactEmailOrUpn
Specifies whether to resolve exact email or UPN in search.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SelfServiceSiteCreationDisabled
Specifies whether self-service site creation is disabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SharePointAddInsDisabled
Specifies whether SharePoint add-ins are disabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SharingAllowedDomainList
Specifies the list of allowed domains for sharing.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SharingBlockedDomainList
Specifies the list of blocked domains for sharing.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SharingCapability
Specifies the sharing capability.

```yaml
Type: SharingCapabilities
Parameter Sets: (All)
Aliases:
Accepted values: Disabled, ExternalUserSharingOnly, ExternalUserAndGuestSharing, ExistingExternalUserSharingOnly

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SharingDomainRestrictionMode
Specifies the sharing domain restriction mode.

```yaml
Type: SharingDomainRestrictionMode
Parameter Sets: (All)
Aliases:
Accepted values: None, AllowList, BlockList

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShowAllUsersClaim
Specifies whether to show all users claim.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShowEveryoneClaim
Specifies whether to show everyone claim.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShowEveryoneExceptExternalUsersClaim
Specifies whether to show everyone except external users claim.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShowPeoplePickerGroupSuggestionsForInformationBarriers
Specifies whether to show people picker group suggestions for information barriers.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShowPeoplePickerSuggestionsForGuestUsers
Specifies whether to show people picker suggestions for guest users.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SignInAccelerationDomain
Specifies the sign-in acceleration domain.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SiteOwnerManageLegacyServicePrincipalEnabled
Specifies whether site owners can manage legacy service principals.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SocialBarOnSitePagesDisabled
Specifies whether the social bar on site pages is disabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SpecialCharactersStateInFileFolderNames
Specifies the state of special characters in file and folder names.

```yaml
Type: SpecialCharactersState
Parameter Sets: (All)
Aliases:
Accepted values: NoPreference, Allowed, Disallowed

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartASiteFormUrl
Specifies the URL for the Start a Site form.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StopNew2010Workflows
Specifies whether new 2010 workflows are stopped.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StopNew2013Workflows
Specifies whether new 2013 workflows are stopped.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SyncPrivacyProfileProperties
Specifies whether to sync privacy profile properties.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TaxonomyTaggingEnabled
Specifies whether taxonomy tagging is enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TaxonomyTaggingSiteListFileName
Specifies the file name for the taxonomy tagging site list.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TranslationEnabled
Specifies whether translation is enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TranslationSiteListFileName
Specifies the file name for the translation site list.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UniversalAnnotationDisabled
Specifies whether universal annotation is disabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UseFindPeopleInPeoplePicker
Specifies whether to use Find People in People Picker.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UsePersistentCookiesForExplorerView
Specifies whether to use persistent cookies for Explorer view.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ViewInFileExplorerEnabled
Specifies whether View in File Explorer is enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ViewersCanCommentOnMediaDisabled
Specifies whether viewers can comment on media is disabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhoCanShareAllowListInTenant
Specifies the allow list for who can share in the tenant.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhoCanShareAllowListInTenantByPrincipalIdentity
Specifies the allow list for who can share in the tenant by principal identity.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Workflow2010Disabled
Specifies whether 2010 workflows are disabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
Specifies the action preference for progress.

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
## OUTPUTS

### System.Void
## NOTES

## RELATED LINKS

