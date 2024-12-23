---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Set-KshTenantSiteCollection

## SYNOPSIS
{{ Fill in the Synopsis }}

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
{{ Fill in the Description }}

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

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

### -AnonymousLinkExpirationInDays
{{ Fill AnonymousLinkExpirationInDays Description }}

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
{{ Fill AuthenticationContextName Description }}

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
{{ Fill AuthenticationContextStrength Description }}

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

### -BlockDownloadMicrosoft365GroupIds
{{ Fill BlockDownloadMicrosoft365GroupIds Description }}

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
{{ Fill BlockDownloadPolicy Description }}

```yaml
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

### -DefaultLinkToExistingAccess
{{ Fill DefaultLinkToExistingAccess Description }}

```yaml
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

### -DenyAddAndCustomizePages
{{ Fill DenyAddAndCustomizePages Description }}

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
{{ Fill DisableAppViews Description }}

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
{{ Fill DisableCompanyWideSharingLinks Description }}

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
{{ Fill DisableFlows Description }}

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
{{ Fill ExcludedBlockDownloadGroupIds Description }}

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
{{ Fill ExternalUserExpirationInDays Description }}

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
{{ Fill Identity Description }}

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
{{ Fill InformationBarriersMode Description }}

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
{{ Fill InformationBarriersSegments Description }}

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
{{ Fill InformationBarriersSegmentsToAdd Description }}

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
{{ Fill InformationBarriersSegmentsToRemove Description }}

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

### -NoWait
{{ Fill NoWait Description }}

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
{{ Fill OverrideBlockUserInfoVisibility Description }}

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
{{ Fill OverrideTenantAnonymousLinkExpirationPolicy Description }}

```yaml
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
{{ Fill OverrideTenantExternalUserExpirationPolicy Description }}

```yaml
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
{{ Fill Owner Description }}

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
{{ Fill PWAEnabled Description }}

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
{{ Fill PassThru Description }}

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
{{ Fill ReadOnlyAccessPolicy Description }}

```yaml
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
{{ Fill ReadOnlyForUnmanagedDevices Description }}

```yaml
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
{{ Fill RequestFilesLinkEnabled Description }}

```yaml
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
{{ Fill RequestFilesLinkExpirationInDays Description }}

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
{{ Fill RestrictedAccessControl Description }}

```yaml
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
{{ Fill RestrictedToRegion Description }}

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
{{ Fill SandboxedCodeActivationCapability Description }}

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
{{ Fill SensitivityLabel Description }}

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
{{ Fill SensitivityLabel2 Description }}

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

### -StorageMaximumLevel
{{ Fill StorageMaximumLevel Description }}

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
{{ Fill StorageWarningLevel Description }}

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
{{ Fill TimeZoneId Description }}

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
{{ Fill Title Description }}

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
{{ Fill TitleTranslations Description }}

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
{{ Fill UserCodeMaximumLevel Description }}

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
{{ Fill UserCodeWarningLevel Description }}

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

### Karamem0.SharePoint.PowerShell.Models.V1.TenantSiteCollection
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.TenantSiteCollection
## NOTES

## RELATED LINKS

