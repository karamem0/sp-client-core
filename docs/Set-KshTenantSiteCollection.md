---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Set-KshTenantSiteCollection

## SYNOPSIS
Updates a site collection.

## SYNTAX

### ParamSet1
```
Set-KshTenantSiteCollection [-Identity] <TenantSiteCollection>
 [-AllowAnonymousMeetingParticipantsToAccessWhiteboards <SharingState>]
 [-AllowDownloadingNonWebViewableFiles <Boolean>] [-AllowEditing <Boolean>]
 [-AnonymousLinkExpirationInDays <Int32>] [-AuthenticationContextStrength <String>]
 [-AuthenticationContextName <String>] [-BlockDownloadLinksFileType <BlockDownloadLinksFileType>]
 [-BlockDownloadMicrosoft365GroupIds <Guid[]>] [-BlockDownloadPolicy <Boolean>]
 [-CommentsOnSitePagesDisabled <Boolean>] [-ConditionalAccessPolicy <ConditionalAccessPolicyType>]
 [-DefaultLinkPermission <SharingPermissionType>] [-DefaultLinkToExistingAccess <Boolean>]
 [-DefaultSharingLinkType <SharingLinkType>] [-DenyAddAndCustomizePages <DenyAddAndCustomizePagesStatus>]
 [-DisableAppViews <AppViewsPolicy>] [-DisableCompanyWideSharingLinks <CompanyWideSharingLinksPolicyType>]
 [-DisableFlows <FlowsPolicyType>] [-ExcludedBlockDownloadGroupIds <Guid[]>]
 [-ExternalUserExpirationInDays <Int32>] [-InformationBarriersMode <String>]
 [-InformationBarriersSegments <Guid[]>] [-InformationBarriersSegmentsToAdd <Guid[]>]
 [-InformationBarriersSegmentsToRemove <Guid[]>] [-LimitedAccessFileType <LimitedAccessFileType>]
 [-MediaTranscription <MediaTranscriptionPolicyType>]
 [-OverrideBlockUserInfoVisibility <SiteUserInfoVisibilityPolicyType>]
 [-OverrideTenantAnonymousLinkExpirationPolicy <Boolean>]
 [-OverrideTenantExternalUserExpirationPolicy <Boolean>] [-Owner <String>] [-PWAEnabled <PWAEnabledStatus>]
 [-ReadOnlyAccessPolicy <Boolean>] [-ReadOnlyForUnmanagedDevices <Boolean>]
 [-RequestFilesLinkEnabled <Boolean>] [-RequestFilesLinkExpirationInDays <Int32>]
 [-RestrictedAccessControl <Boolean>] [-RestrictedToRegion <RestrictedToRegion>]
 [-SandboxedCodeActivationCapability <SandboxedCodeActivationCapabilities>] [-SensitivityLabel <Guid>]
 [-SensitivityLabel2 <String>] [-SharingAllowedDomainList <String>] [-SharingBlockedDomainList <String>]
 [-SharingCapability <SharingCapabilities>] [-SharingDomainRestrictionMode <SharingDomainRestrictionMode>]
 [-ShowPeoplePickerSuggestionsForGuestUsers <Boolean>] [-SocialBarOnSitePagesDisabled <Boolean>]
 [-StorageMaximumLevel <Int64>] [-StorageWarningLevel <Int64>] [-TimeZoneId <Int32>] [-Title <String>]
 [-TitleTranslations <ResourceEntry[]>] [-UserCodeMaximumLevel <Double>] [-UserCodeWarningLevel <Double>]
 [-PassThru] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Set-KshTenantSiteCollection [-Identity] <TenantSiteCollection>
 [-AllowAnonymousMeetingParticipantsToAccessWhiteboards <SharingState>]
 [-AllowDownloadingNonWebViewableFiles <Boolean>] [-AllowEditing <Boolean>]
 [-AnonymousLinkExpirationInDays <Int32>] [-AuthenticationContextStrength <String>]
 [-AuthenticationContextName <String>] [-BlockDownloadLinksFileType <BlockDownloadLinksFileType>]
 [-BlockDownloadMicrosoft365GroupIds <Guid[]>] [-BlockDownloadPolicy <Boolean>]
 [-CommentsOnSitePagesDisabled <Boolean>] [-ConditionalAccessPolicy <ConditionalAccessPolicyType>]
 [-DefaultLinkPermission <SharingPermissionType>] [-DefaultLinkToExistingAccess <Boolean>]
 [-DefaultSharingLinkType <SharingLinkType>] [-DenyAddAndCustomizePages <DenyAddAndCustomizePagesStatus>]
 [-DisableAppViews <AppViewsPolicy>] [-DisableCompanyWideSharingLinks <CompanyWideSharingLinksPolicyType>]
 [-DisableFlows <FlowsPolicyType>] [-ExcludedBlockDownloadGroupIds <Guid[]>]
 [-ExternalUserExpirationInDays <Int32>] [-InformationBarriersMode <String>]
 [-InformationBarriersSegments <Guid[]>] [-InformationBarriersSegmentsToAdd <Guid[]>]
 [-InformationBarriersSegmentsToRemove <Guid[]>] [-LimitedAccessFileType <LimitedAccessFileType>]
 [-MediaTranscription <MediaTranscriptionPolicyType>]
 [-OverrideBlockUserInfoVisibility <SiteUserInfoVisibilityPolicyType>]
 [-OverrideTenantAnonymousLinkExpirationPolicy <Boolean>]
 [-OverrideTenantExternalUserExpirationPolicy <Boolean>] [-Owner <String>] [-PWAEnabled <PWAEnabledStatus>]
 [-ReadOnlyAccessPolicy <Boolean>] [-ReadOnlyForUnmanagedDevices <Boolean>]
 [-RequestFilesLinkEnabled <Boolean>] [-RequestFilesLinkExpirationInDays <Int32>]
 [-RestrictedAccessControl <Boolean>] [-RestrictedToRegion <RestrictedToRegion>]
 [-SandboxedCodeActivationCapability <SandboxedCodeActivationCapabilities>] [-SensitivityLabel <Guid>]
 [-SensitivityLabel2 <String>] [-SharingAllowedDomainList <String>] [-SharingBlockedDomainList <String>]
 [-SharingCapability <SharingCapabilities>] [-SharingDomainRestrictionMode <SharingDomainRestrictionMode>]
 [-ShowPeoplePickerSuggestionsForGuestUsers <Boolean>] [-SocialBarOnSitePagesDisabled <Boolean>]
 [-StorageMaximumLevel <Int64>] [-StorageWarningLevel <Int64>] [-TimeZoneId <Int32>] [-Title <String>]
 [-TitleTranslations <ResourceEntry[]>] [-UserCodeMaximumLevel <Double>] [-UserCodeWarningLevel <Double>]
 [-NoWait] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The Set-KshTenantSiteCollection cmdlet updates properties of the site collection. This cmdlet can be used only when connected to the SharePoint admin center.

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-KshTenantSiteCollection -Identity (Get-KshTenantSiteCollection -SiteCollectionUrl 'https://example.sharepoint.com/sites/hub') -Owner 'admin@example.onmicrosoft.com'
```

Updates property values of the site collection.

## PARAMETERS

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

### -AllowDownloadingNonWebViewableFiles
Specifies whether to allow to download files.

```yaml
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
Specifies whether to allow editing Office files in the browser.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AnonymousLinkExpirationInDays
Specifies the days that anonymous link to be expired.

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

### -AuthenticationContextName
Specifies the authentication context name.

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

### -AuthenticationContextStrength
Specifies the authentication context strength.

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

### -BlockDownloadLinksFileType
Specifies the block download links file type.

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

### -BlockDownloadMicrosoft365GroupIds
Specifies the Microsoft 365 group IDs to block download.

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

### -BlockDownloadPolicy
Specifies whether to block download.

```yaml
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
Specifies whether to disable comments on the site.

```yaml
Type: Boolean
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

### -DefaultLinkToExistingAccess
Specifies whether to override default sharing link as existing access link.

```yaml
Type: Boolean
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

### -DenyAddAndCustomizePages
Specifies whether to deny to add and customize pages.

```yaml
Type: DenyAddAndCustomizePagesStatus
Parameter Sets: (All)
Aliases:
Accepted values: Unknown, Disabled, Enabled

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisableAppViews
Specifies the app views policy.

```yaml
Type: AppViewsPolicy
Parameter Sets: (All)
Aliases:
Accepted values: Unknown, Disabled, NotDisabled

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisableCompanyWideSharingLinks
Specifies the company-wide sharing links policy.

```yaml
Type: CompanyWideSharingLinksPolicyType
Parameter Sets: (All)
Aliases:
Accepted values: Unknown, Disabled, NotDisabled

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisableFlows
Specifies the Microsoft Flow policy.

```yaml
Type: FlowsPolicyType
Parameter Sets: (All)
Aliases:
Accepted values: Unknown, Disabled, NotDisabled

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExcludedBlockDownloadGroupIds
Specifies the excluded group IDs that blocked download.

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

### -ExternalUserExpirationInDays
Specifies the days that external user to be expired.

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

### -Identity
Specifies the site collection.

```yaml
Type: TenantSiteCollection
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InformationBarriersMode
Specifies the information barriers mode.

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

### -InformationBarriersSegments
Specifies the information barriers segments.

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

### -InformationBarriersSegmentsToAdd
Specifies the information barriers segments to add.

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

### -InformationBarriersSegmentsToRemove
Specifies the information barriers segments to remove.

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

### -MediaTranscription
Specifies the media transcription.

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

### -NoWait
If specified, continue executing script immediately.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OverrideBlockUserInfoVisibility
Specifies the block user info visibility to override.

```yaml
Type: SiteUserInfoVisibilityPolicyType
Parameter Sets: (All)
Aliases:
Accepted values: Default, ApplyToNoUsers, ApplyToGuestAndExternalUsers

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OverrideTenantAnonymousLinkExpirationPolicy
Specifies the tenant anonymous link expiration policy to override.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OverrideTenantExternalUserExpirationPolicy
Specifies the tenant external user expiration policy to override.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Owner
Specifies the owner.

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

### -PWAEnabled
Specifies the Project Web App status.

```yaml
Type: PWAEnabledStatus
Parameter Sets: (All)
Aliases:
Accepted values: Unknown, Disabled, Enabled

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
If specified, returns the updated object.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReadOnlyAccessPolicy
Specifies whether to enable read-only access policy.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReadOnlyForUnmanagedDevices
Specifies whether to make unmanaged devices to be read-only.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequestFilesLinkEnabled
Specifies whether to enable to request files link.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequestFilesLinkExpirationInDays
Specifies the days that request files link to be expired.

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

### -RestrictedAccessControl
Specifies the restricted access control.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RestrictedToRegion
Specifies the region restriction.

```yaml
Type: RestrictedToRegion
Parameter Sets: (All)
Aliases:
Accepted values: NoRestriction, BlockMoveOnly, BlockFull, Unknown

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SandboxedCodeActivationCapability
Specifies the sandboxed code capability.

```yaml
Type: SandboxedCodeActivationCapabilities
Parameter Sets: (All)
Aliases:
Accepted values: Unknown, Check, Disabled, Enabled

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SensitivityLabel
Specifies the sensitivity label.

```yaml
Type: Guid
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SensitivityLabel2
Specifies the sensitivity label.

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

### -SharingAllowedDomainList
Specifies the list of domains to allow sharing.

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
Specifies the list of domains to block sharing.

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

### -SocialBarOnSitePagesDisabled
Specifies whether to disable social bar on site.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageMaximumLevel
Specifies the maximum quota of the storage.

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

### -StorageWarningLevel
Specifies the warning quota of the storage.

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

### -TimeZoneId
Specifies the time zone ID.

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

### -Title
Specifies the title.

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

### -TitleTranslations
Specifies the title translations.

```yaml
Type: ResourceEntry[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserCodeMaximumLevel
Specifies the maximum quota of the server resource.

```yaml
Type: Double
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserCodeWarningLevel
Specifies the warning quota of the server resource.

```yaml
Type: Double
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
Determines how PowerShell responds to progress updates generated by a script, cmdlet, or provider.

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

### Karamem0.SharePoint.PowerShell.Models.V1.TenantSiteCollection

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.TenantSiteCollection

## NOTES

## RELATED LINKS

