---
Module Name: SPClientCore
external help file: SPClientCore.dll-Help.xml
schema: 2.0.0
---

# Set-KshTenant

## SYNOPSIS
Set tenant.

## SYNTAX

```
Set-KshTenant [[-AddressbarLinkPermission] <RoleType>]
 [[-AllowAnonymousMeetingParticipantsToAccessWhiteboards] <SharingState>]
 [[-AllowCommentsTextOnEmailEnabled] <Boolean>] [[-AllowDownloadingNonWebViewableFiles] <Boolean>]
 [[-AllowedDomainListForSyncClient] <Guid[]>] [[-AllowEditing] <Boolean>]
 [[-AllowEveryoneExceptExternalUsersClaimInPrivateSite] <Boolean>]
 [[-AllowGuestUserShareToUsersNotInSiteCollection] <Boolean>]
 [[-AllowLimitedAccessOnUnmanagedDevices] <Boolean>] [[-AllowOverrideForBlockUserInfoVisibility] <Boolean>]
 [[-AnyoneLinkTrackUsers] <Boolean>] [[-ApplyAppEnforcedRestrictionsToAdHocRecipients] <Boolean>]
 [[-AuthenticationContextResilienceMode] <ResilienceMode>] [[-BccExternalSharingInvitations] <Boolean>]
 [[-BccExternalSharingInvitationsList] <String>] [[-BlockAccessOnUnmanagedDevices] <Boolean>]
 [[-BlockDownloadLinksFileType] <BlockDownloadLinksFileType>] [[-BlockMacSync] <Boolean>]
 [[-BlockSendLabelMismatchEmail] <Boolean>] [[-BlockUserInfoVisibility] <String>]
 [[-BlockUserInfoVisibilityInOneDrive] <TenantBrowseUserInfoPolicyType>]
 [[-BlockUserInfoVisibilityInSharePoint] <TenantBrowseUserInfoPolicyType>]
 [[-CommentsOnFilesDisabled] <Boolean>] [[-CommentsOnListItemsDisabled] <Boolean>]
 [[-CommentsOnSitePagesDisabled] <Boolean>] [[-CompatibilityRange] <String>]
 [[-ConditionalAccessPolicy] <ConditionalAccessPolicyType>] [[-ConditionalAccessPolicyErrorHelpLink] <String>]
 [[-ContentTypeSyncSiteTemplatesList] <String[]>] [[-CoreLoopDefaultSharingLinkRole] <RoleType>]
 [[-CoreLoopDefaultSharingLinkScope] <SharingScope>] [[-CoreLoopSharingCapability] <SharingCapabilities>]
 [[-CoreRequestFilesLinkEnabled] <Boolean>] [[-CoreRequestFilesLinkExpirationInDays] <Int32>]
 [[-CoreSharingCapability] <SharingCapabilities>] [[-CustomizedExternalSharingServiceUrl] <Uri>]
 [[-DefaultContentCenterSite] <SiteInfoForSitePicker>] [[-DefaultLinkPermission] <SharingPermissionType>]
 [[-DefaultOneDriveMode] <String>] [[-DefaultSharingLinkType] <SharingLinkType>]
 [[-DisableAddToOneDrive] <Boolean>] [[-DisableBackToClassic] <Boolean>]
 [[-DisableCustomAppAuthentication] <Boolean>] [[-DisabledModernListTemplateIds] <Guid[]>]
 [[-DisabledWebPartIds] <Guid[]>] [[-DisableOutlookPSTVersionTrimming] <Boolean>]
 [[-DisablePersonalListCreation] <Boolean>] [[-DisableReportProblemDialog] <Boolean>]
 [[-DisableSpacesActivation] <Boolean>] [[-DisallowInfectedFileDownload] <Boolean>]
 [[-DisplayNamesOfFileViewers] <Boolean>] [[-DisplayNamesOfFileViewersInSharePoint] <Boolean>]
 [[-DisplayStartASiteOption] <Boolean>] [[-EmailAttestationEnabled] <Boolean>]
 [[-EmailAttestationReAuthDays] <Int32>] [[-EmailAttestationRequired] <Boolean>]
 [[-EnableAIPIntegration] <Boolean>] [[-EnableAutoNewsDigest] <Boolean>]
 [[-EnableAzureAdB2BIntegration] <Boolean>] [[-EnableGuestSignInAcceleration] <Boolean>]
 [[-EnableMinimumVersionRequirement] <Boolean>] [[-EnableMipSiteLabel] <Boolean>]
 [[-EnablePromotedFileHandlers] <Boolean>] [[-EnableRestrictedAccessControl] <Boolean>]
 [[-ExcludedFileExtensionsForSyncClient] <String[]>] [[-ExternalServicesEnabled] <Boolean>]
 [[-ExternalUserExpirationRequired] <Boolean>] [[-ExternalUserExpireInDays] <Int32>]
 [[-FileAnonymousLinkType] <AnonymousLinkType>] [[-FilePickerExternalImageSearchEnabled] <Boolean>]
 [[-FolderAnonymousLinkType] <AnonymousLinkType>] [[-GuestSharingGroupAllowListInTenant] <String>]
 [[-GuestSharingGroupAllowListInTenantByPrincipalIdentity] <String[]>]
 [[-HasAdminCompletedCUConfiguration] <Boolean>] [[-HideDefaultThemes] <Boolean>]
 [[-HideSyncButtonOnDocLib] <Boolean>] [[-HideSyncButtonOnOneDrive] <Boolean>]
 [[-ImageTaggingOption] <ImageTaggingChoice>] [[-IncludeAtAGlanceInShareEmails] <Boolean>]
 [[-InformationBarriersImplicitGroupBased] <Boolean>] [[-InformationBarriersSuspension] <Boolean>]
 [[-IPAddressAllowList] <String>] [[-IPAddressEnforcement] <Boolean>] [[-IPAddressWacTokenLifetime] <Int32>]
 [[-IsAppBarTemporarilyDisabled] <Boolean>] [[-IsCollabMeetingNotesFluidEnabled] <Boolean>]
 [[-IsFluidEnabled] <Boolean>] [[-IsLoopEnabled] <Boolean>]
 [[-IsUnmanagedSyncClientForTenantRestricted] <Boolean>] [[-IsVivaHomeFlightEnabled] <Boolean>]
 [[-IsWhiteboardFluidEnabled] <Boolean>] [[-LabelMismatchEmailHelpLink] <String>]
 [[-LegacyBrowserAuthProtocolsEnabled] <Boolean>] [[-LegacyAuthProtocolsEnabled] <Boolean>]
 [[-LimitedAccessFileType] <LimitedAccessFileType>] [[-MachineLearningCaptureEnabled] <Boolean>]
 [[-MajorVersionLimit] <Int32>] [[-MarkNewFilesSensitiveByDefault] <SensitiveByDefaultState>]
 [[-MediaTranscription] <MediaTranscriptionPolicyType>] [[-MobileFriendlyUrlEnabledInTenant] <Boolean>]
 [[-NoAccessRedirectUrl] <Uri>] [[-NotificationsInOneDriveEnabled] <Boolean>]
 [[-NotificationsInSharePointEnabled] <Boolean>] [[-NotifyOwnersWhenInvitationsAccepted] <Boolean>]
 [[-NotifyOwnersWhenItemsReshared] <Boolean>] [[-OfficeClientAdalDisabled] <Boolean>]
 [[-OneDriveAccessRequests] <SharingState>] [[-OneDriveForGuestsEnabled] <Boolean>]
 [[-OneDriveLoopDefaultSharingLinkRole] <RoleType>] [[-OneDriveLoopDefaultSharingLinkScope] <SharingScope>]
 [[-OneDriveLoopSharingCapability] <SharingCapabilities>] [[-OneDriveMembersCanShare] <SharingState>]
 [[-OneDriveRequestFilesLinkEnabled] <Boolean>] [[-OneDriveRequestFilesLinkExpirationInDays] <Int32>]
 [[-OneDriveSharingCapability] <SharingCapabilities>] [[-OneDriveStorageQuota] <Int64>]
 [[-OptOutOfGrooveBlock] <Boolean>] [[-OptOutOfGrooveSoftBlock] <Boolean>]
 [[-OrphanedPersonalSitesRetentionPeriod] <Int32>] [[-OwnerAnonymousNotification] <Boolean>]
 [[-PermissiveBrowserFileHandlingOverride] <Boolean>] [[-PreventExternalUsersFromResharing] <Boolean>]
 [[-ProvisionSharedWithEveryoneFolder] <Boolean>] [[-ReduceTempTokenLifetimeEnabled] <Boolean>]
 [[-ReduceTempTokenLifetimeValue] <Int32>] [[-RequireAcceptingAccountMatchInvitedAccount] <Boolean>]
 [[-RequireAnonymousLinksExpireInDays] <Int32>] [[-SearchResolveExactEmailOrUpn] <Boolean>]
 [[-SelfServiceSiteCreationDisabled] <Boolean>] [[-SharePointAddInsDisabled] <Boolean>]
 [[-SharingAllowedDomainList] <String>] [[-SharingBlockedDomainList] <String>]
 [[-SharingCapability] <SharingCapabilities>] [[-SharingDomainRestrictionMode] <SharingDomainRestrictionMode>]
 [[-ShowAllUsersClaim] <Boolean>] [[-ShowEveryoneClaim] <Boolean>]
 [[-ShowEveryoneExceptExternalUsersClaim] <Boolean>] [[-ShowPeoplePickerSuggestionsForGuestUsers] <Boolean>]
 [[-ShowPeoplePickerGroupSuggestionsForInformationBarriers] <Boolean>] [[-SignInAccelerationDomain] <String>]
 [[-SiteOwnerManageLegacyServicePrincipalEnabled] <Boolean>] [[-SocialBarOnSitePagesDisabled] <Boolean>]
 [[-SpecialCharactersStateInFileFolderNames] <SpecialCharactersState>] [[-StartASiteFormUrl] <Uri>]
 [[-StopNew2010Workflows] <Boolean>] [[-StopNew2013Workflows] <Boolean>]
 [[-SyncPrivacyProfileProperties] <Boolean>] [[-TaxonomyTaggingEnabled] <Boolean>]
 [[-TaxonomyTaggingSiteListFileName] <String>] [[-TranslationEnabled] <Boolean>]
 [[-TranslationSiteListFileName] <String>] [[-UniversalAnnotationDisabled] <Boolean>]
 [[-UseFindPeopleInPeoplePicker] <Boolean>] [[-UsePersistentCookiesForExplorerView] <Boolean>]
 [[-ViewersCanCommentOnMediaDisabled] <Boolean>] [[-ViewInFileExplorerEnabled] <Boolean>]
 [[-WhoCanShareAllowListInTenant] <String>] [[-WhoCanShareAllowListInTenantByPrincipalIdentity] <String[]>]
 [[-Workflow2010Disabled] <Boolean>] [-PassThru] [-SelectAllProperties] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## PARAMETERS

### -AddressbarLinkPermission

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

```yaml
Type: Uri
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultContentCenterSite

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

```yaml
Type: Uri
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NotificationsInOneDriveEnabled

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

### -SelectAllProperties

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

### -SelfServiceSiteCreationDisabled

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

```yaml
Type: Uri
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StopNew2010Workflows

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

### Karamem0.SharePoint.PowerShell.Models.V1.Tenant

