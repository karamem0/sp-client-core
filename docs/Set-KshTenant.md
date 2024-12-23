---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Set-KshTenant

## SYNOPSIS
{{ Fill in the Synopsis }}

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
 [-EnableVersionExpirationSetting <Boolean>] [-ExcludedFileExtensionsForSyncClient <String[]>]
 [-ExternalServicesEnabled <Boolean>] [-ExternalUserExpirationRequired <Boolean>]
 [-ExternalUserExpireInDays <Int32>] [-FileAnonymousLinkType <AnonymousLinkType>]
 [-FilePickerExternalImageSearchEnabled <Boolean>] [-FolderAnonymousLinkType <AnonymousLinkType>]
 [-GuestSharingGroupAllowListInTenant <String>]
 [-GuestSharingGroupAllowListInTenantByPrincipalIdentity <String[]>]
 [-HasAdminCompletedCUConfiguration <Boolean>] [-HideDefaultThemes <Boolean>]
 [-HideSyncButtonOnDocLib <Boolean>] [-HideSyncButtonOnOneDrive <Boolean>]
 [-ImageTaggingOption <ImageTaggingChoice>] [-IncludeAtAGlanceInShareEmails <Boolean>]
 [-InformationBarriersImplicitGroupBased <Boolean>] [-InformationBarriersSuspension <Boolean>]
 [-IPAddressAllowList <String>] [-IPAddressEnforcement <Boolean>] [-IPAddressWacTokenLifetime <Int32>]
 [-IsAppBarTemporarilyDisabled <Boolean>] [-IsCollabMeetingNotesFluidEnabled <Boolean>]
 [-IsFluidEnabled <Boolean>] [-IsLoopEnabled <Boolean>] [-IsUnmanagedSyncClientForTenantRestricted <Boolean>]
 [-IsVivaHomeFlightEnabled <Boolean>] [-IsWhiteboardFluidEnabled <Boolean>]
 [-LabelMismatchEmailHelpLink <String>] [-LegacyAuthProtocolsEnabled <Boolean>]
 [-LimitedAccessFileType <LimitedAccessFileType>] [-MachineLearningCaptureEnabled <Boolean>]
 [-MajorVersionLimit <Int32>] [-MarkNewFilesSensitiveByDefault <SensitiveByDefaultState>]
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
 [-SharingAllowedDomainList <String>] [-SharingBlockedDomainList <String>]
 [-SharingCapability <SharingCapabilities>] [-SharingDomainRestrictionMode <SharingDomainRestrictionMode>]
 [-ShowAllUsersClaim <Boolean>] [-ShowEveryoneClaim <Boolean>]
 [-ShowEveryoneExceptExternalUsersClaim <Boolean>] [-ShowPeoplePickerSuggestionsForGuestUsers <Boolean>]
 [-ShowPeoplePickerGroupSuggestionsForInformationBarriers <Boolean>] [-SignInAccelerationDomain <String>]
 [-SocialBarOnSitePagesDisabled <Boolean>] [-SpecialCharactersStateInFileFolderNames <SpecialCharactersState>]
 [-StartASiteFormUrl <String>] [-StopNew2010Workflows <Boolean>] [-StopNew2013Workflows <Boolean>]
 [-SyncPrivacyProfileProperties <Boolean>] [-UseFindPeopleInPeoplePicker <Boolean>]
 [-UsePersistentCookiesForExplorerView <Boolean>] [-ViewersCanCommentOnMediaDisabled <Boolean>]
 [-ViewInFileExplorerEnabled <Boolean>] [-WhoCanShareAllowListInTenant <String>]
 [-WhoCanShareAllowListInTenantByPrincipalIdentity <String[]>] [-Workflow2010Disabled <Boolean>] [-PassThru]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
{{ Fill in the Description }}

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -AddressbarLinkPermission
{{ Fill AddressbarLinkPermission Description }}

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
{{ Fill AllowAnonymousMeetingParticipantsToAccessWhiteboards Description }}

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
{{ Fill AllowCommentsTextOnEmailEnabled Description }}

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
{{ Fill AllowDownloadingNonWebViewableFiles Description }}

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
{{ Fill AllowEditing Description }}

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
{{ Fill AllowEveryoneExceptExternalUsersClaimInPrivateSite Description }}

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
{{ Fill AllowGuestUserShareToUsersNotInSiteCollection Description }}

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
{{ Fill AllowLimitedAccessOnUnmanagedDevices Description }}

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
{{ Fill AllowOverrideForBlockUserInfoVisibility Description }}

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
{{ Fill AllowedDomainListForSyncClient Description }}

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
{{ Fill AnyoneLinkTrackUsers Description }}

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
{{ Fill ApplyAppEnforcedRestrictionsToAdHocRecipients Description }}

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
{{ Fill AuthenticationContextResilienceMode Description }}

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
{{ Fill BccExternalSharingInvitations Description }}

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
{{ Fill BccExternalSharingInvitationsList Description }}

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
{{ Fill BlockAccessOnUnmanagedDevices Description }}

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
{{ Fill BlockDownloadLinksFileType Description }}

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
{{ Fill BlockMacSync Description }}

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
{{ Fill BlockSendLabelMismatchEmail Description }}

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
{{ Fill BlockUserInfoVisibility Description }}

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
{{ Fill BlockUserInfoVisibilityInOneDrive Description }}

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
{{ Fill BlockUserInfoVisibilityInSharePoint Description }}

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
{{ Fill CommentsOnFilesDisabled Description }}

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
{{ Fill CommentsOnListItemsDisabled Description }}

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
{{ Fill CommentsOnSitePagesDisabled Description }}

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
{{ Fill CompatibilityRange Description }}

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
{{ Fill ConditionalAccessPolicy Description }}

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
{{ Fill ConditionalAccessPolicyErrorHelpLink Description }}

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
{{ Fill ContentTypeSyncSiteTemplatesList Description }}

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
{{ Fill CoreLoopDefaultSharingLinkRole Description }}

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
{{ Fill CoreLoopDefaultSharingLinkScope Description }}

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
{{ Fill CoreLoopSharingCapability Description }}

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
{{ Fill CoreRequestFilesLinkEnabled Description }}

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
{{ Fill CoreRequestFilesLinkExpirationInDays Description }}

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
{{ Fill CoreSharingCapability Description }}

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
{{ Fill CustomizedExternalSharingServiceUrl Description }}

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
{{ Fill DefaultContentCenterSite Description }}

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
{{ Fill DefaultLinkPermission Description }}

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
{{ Fill DefaultOneDriveMode Description }}

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
{{ Fill DefaultSharingLinkType Description }}

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
{{ Fill DisableAddToOneDrive Description }}

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
{{ Fill DisableBackToClassic Description }}

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
{{ Fill DisableCustomAppAuthentication Description }}

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
{{ Fill DisableOutlookPSTVersionTrimming Description }}

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
{{ Fill DisablePersonalListCreation Description }}

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
{{ Fill DisableReportProblemDialog Description }}

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
{{ Fill DisableSpacesActivation Description }}

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
{{ Fill DisabledModernListTemplateIds Description }}

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
{{ Fill DisabledWebPartIds Description }}

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
{{ Fill DisallowInfectedFileDownload Description }}

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
{{ Fill DisplayNamesOfFileViewers Description }}

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
{{ Fill DisplayNamesOfFileViewersInSharePoint Description }}

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
{{ Fill DisplayStartASiteOption Description }}

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
{{ Fill EmailAttestationEnabled Description }}

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
{{ Fill EmailAttestationReAuthDays Description }}

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
{{ Fill EmailAttestationRequired Description }}

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
{{ Fill EnableAIPIntegration Description }}

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
{{ Fill EnableAutoNewsDigest Description }}

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
{{ Fill EnableAzureAdB2BIntegration Description }}

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
{{ Fill EnableGuestSignInAcceleration Description }}

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
{{ Fill EnableMinimumVersionRequirement Description }}

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
{{ Fill EnableMipSiteLabel Description }}

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
{{ Fill EnablePromotedFileHandlers Description }}

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
{{ Fill EnableRestrictedAccessControl Description }}

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

### -EnableVersionExpirationSetting
{{ Fill EnableVersionExpirationSetting Description }}

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
{{ Fill ExcludedFileExtensionsForSyncClient Description }}

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
{{ Fill ExternalServicesEnabled Description }}

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
{{ Fill ExternalUserExpirationRequired Description }}

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
{{ Fill ExternalUserExpireInDays Description }}

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
{{ Fill FileAnonymousLinkType Description }}

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
{{ Fill FilePickerExternalImageSearchEnabled Description }}

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
{{ Fill FolderAnonymousLinkType Description }}

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
{{ Fill GuestSharingGroupAllowListInTenant Description }}

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
{{ Fill GuestSharingGroupAllowListInTenantByPrincipalIdentity Description }}

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
{{ Fill HasAdminCompletedCUConfiguration Description }}

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
{{ Fill HideDefaultThemes Description }}

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
{{ Fill HideSyncButtonOnDocLib Description }}

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
{{ Fill HideSyncButtonOnOneDrive Description }}

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
{{ Fill IPAddressAllowList Description }}

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
{{ Fill IPAddressEnforcement Description }}

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
{{ Fill IPAddressWacTokenLifetime Description }}

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
{{ Fill ImageTaggingOption Description }}

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
{{ Fill IncludeAtAGlanceInShareEmails Description }}

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
{{ Fill InformationBarriersImplicitGroupBased Description }}

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
{{ Fill InformationBarriersSuspension Description }}

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
{{ Fill IsAppBarTemporarilyDisabled Description }}

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
{{ Fill IsCollabMeetingNotesFluidEnabled Description }}

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
{{ Fill IsFluidEnabled Description }}

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
{{ Fill IsLoopEnabled Description }}

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
{{ Fill IsUnmanagedSyncClientForTenantRestricted Description }}

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
{{ Fill IsVivaHomeFlightEnabled Description }}

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
{{ Fill IsWhiteboardFluidEnabled Description }}

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
{{ Fill LabelMismatchEmailHelpLink Description }}

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
{{ Fill LegacyAuthProtocolsEnabled Description }}

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
{{ Fill LimitedAccessFileType Description }}

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
{{ Fill MachineLearningCaptureEnabled Description }}

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
{{ Fill MajorVersionLimit Description }}

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
{{ Fill MarkNewFilesSensitiveByDefault Description }}

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
{{ Fill MediaTranscription Description }}

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
{{ Fill MobileFriendlyUrlEnabledInTenant Description }}

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
{{ Fill NoAccessRedirectUrl Description }}

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
{{ Fill NotificationsInOneDriveEnabled Description }}

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
{{ Fill NotificationsInSharePointEnabled Description }}

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
{{ Fill NotifyOwnersWhenInvitationsAccepted Description }}

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
{{ Fill NotifyOwnersWhenItemsReshared Description }}

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
{{ Fill OfficeClientAdalDisabled Description }}

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
{{ Fill OneDriveAccessRequests Description }}

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
{{ Fill OneDriveForGuestsEnabled Description }}

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
{{ Fill OneDriveLoopDefaultSharingLinkRole Description }}

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
{{ Fill OneDriveLoopDefaultSharingLinkScope Description }}

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
{{ Fill OneDriveLoopSharingCapability Description }}

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
{{ Fill OneDriveMembersCanShare Description }}

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
{{ Fill OneDriveRequestFilesLinkEnabled Description }}

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
{{ Fill OneDriveRequestFilesLinkExpirationInDays Description }}

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
{{ Fill OneDriveSharingCapability Description }}

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
{{ Fill OneDriveStorageQuota Description }}

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
{{ Fill OptOutOfGrooveBlock Description }}

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
{{ Fill OptOutOfGrooveSoftBlock Description }}

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
{{ Fill OrphanedPersonalSitesRetentionPeriod Description }}

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
{{ Fill OwnerAnonymousNotification Description }}

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
{{ Fill PassThru Description }}

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
{{ Fill PermissiveBrowserFileHandlingOverride Description }}

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
{{ Fill PreventExternalUsersFromResharing Description }}

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
{{ Fill ProvisionSharedWithEveryoneFolder Description }}

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
{{ Fill ReduceTempTokenLifetimeEnabled Description }}

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
{{ Fill ReduceTempTokenLifetimeValue Description }}

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
{{ Fill RequireAcceptingAccountMatchInvitedAccount Description }}

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
{{ Fill RequireAnonymousLinksExpireInDays Description }}

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
{{ Fill SearchResolveExactEmailOrUpn Description }}

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
{{ Fill SharingAllowedDomainList Description }}

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
{{ Fill SharingBlockedDomainList Description }}

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
{{ Fill SharingCapability Description }}

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
{{ Fill SharingDomainRestrictionMode Description }}

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
{{ Fill ShowAllUsersClaim Description }}

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
{{ Fill ShowEveryoneClaim Description }}

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
{{ Fill ShowEveryoneExceptExternalUsersClaim Description }}

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
{{ Fill ShowPeoplePickerGroupSuggestionsForInformationBarriers Description }}

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
{{ Fill ShowPeoplePickerSuggestionsForGuestUsers Description }}

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
{{ Fill SignInAccelerationDomain Description }}

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

### -SocialBarOnSitePagesDisabled
{{ Fill SocialBarOnSitePagesDisabled Description }}

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
{{ Fill SpecialCharactersStateInFileFolderNames Description }}

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
{{ Fill StartASiteFormUrl Description }}

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
{{ Fill StopNew2010Workflows Description }}

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
{{ Fill StopNew2013Workflows Description }}

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
{{ Fill SyncPrivacyProfileProperties Description }}

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
{{ Fill UseFindPeopleInPeoplePicker Description }}

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
{{ Fill UsePersistentCookiesForExplorerView Description }}

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
{{ Fill ViewInFileExplorerEnabled Description }}

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
{{ Fill ViewersCanCommentOnMediaDisabled Description }}

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
{{ Fill WhoCanShareAllowListInTenant Description }}

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
{{ Fill WhoCanShareAllowListInTenantByPrincipalIdentity Description }}

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
{{ Fill Workflow2010Disabled Description }}

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
{{ Fill ProgressAction Description }}

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

