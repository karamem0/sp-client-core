---
Module Name: SPClientCore
external help file: SPClientCore.dll-Help.xml
schema: 2.0.0
---

# Set-KshTenantSiteCollection

## SYNOPSIS
Set tenant site collection.

## SYNTAX

### ParamSet1
```
Set-KshTenantSiteCollection [-Identity] <TenantSiteCollection>
 [[-AllowAnonymousMeetingParticipantsToAccessWhiteboards] <SharingState>]
 [[-AllowDownloadingNonWebViewableFiles] <Boolean>] [[-AllowEditing] <Boolean>]
 [[-AnonymousLinkExpirationInDays] <Int32>] [[-AuthenticationContextStrength] <String>]
 [[-AuthenticationContextName] <String>] [[-BlockDownloadLinksFileType] <BlockDownloadLinksFileType>]
 [[-BlockDownloadMicrosoft365GroupIds] <Guid[]>] [[-BlockDownloadPolicy] <Boolean>]
 [[-CommentsOnSitePagesDisabled] <Boolean>] [[-ConditionalAccessPolicy] <ConditionalAccessPolicyType>]
 [[-DefaultLinkPermission] <SharingPermissionType>] [[-DefaultLinkToExistingAccess] <Boolean>]
 [[-DefaultSharingLinkType] <SharingLinkType>] [[-DenyAddAndCustomizePages] <DenyAddAndCustomizePagesStatus>]
 [[-DisableAppViews] <AppViewsPolicy>] [[-DisableCompanyWideSharingLinks] <CompanyWideSharingLinksPolicyType>]
 [[-DisableFlows] <FlowsPolicyType>] [[-ExcludedBlockDownloadGroupIds] <Guid[]>]
 [[-ExternalUserExpirationInDays] <Int32>] [[-InformationBarriersMode] <String>]
 [[-InformationBarriersSegments] <Guid[]>] [[-InformationBarriersSegmentsToAdd] <Guid[]>]
 [[-InformationBarriersSegmentsToRemove] <Guid[]>] [[-LimitedAccessFileType] <LimitedAccessFileType>]
 [[-MediaTranscription] <MediaTranscriptionPolicyType>]
 [[-OverrideBlockUserInfoVisibility] <SiteUserInfoVisibilityPolicyType>]
 [[-OverrideTenantAnonymousLinkExpirationPolicy] <Boolean>]
 [[-OverrideTenantExternalUserExpirationPolicy] <Boolean>] [[-Owner] <String>]
 [[-PWAEnabled] <PWAEnabledStatus>] [[-ReadOnlyAccessPolicy] <Boolean>]
 [[-ReadOnlyForUnmanagedDevices] <Boolean>] [[-RequestFilesLinkEnabled] <Boolean>]
 [[-RequestFilesLinkExpirationInDays] <Int32>] [[-RestrictedAccessControl] <Boolean>]
 [[-RestrictedToRegion] <RestrictedToRegion>]
 [[-SandboxedCodeActivationCapability] <SandboxedCodeActivationCapabilities>] [[-SensitivityLabel] <Guid>]
 [[-SensitivityLabel2] <String>] [[-SharingAllowedDomainList] <String>] [[-SharingBlockedDomainList] <String>]
 [[-SharingCapability] <SharingCapabilities>] [[-SharingDomainRestrictionMode] <SharingDomainRestrictionMode>]
 [[-ShowPeoplePickerSuggestionsForGuestUsers] <Boolean>] [[-SocialBarOnSitePagesDisabled] <Boolean>]
 [[-StorageMaximumLevel] <Int64>] [[-StorageWarningLevel] <Int64>] [[-TimeZoneId] <Int32>] [[-Title] <String>]
 [[-TitleTranslations] <ResourceEntry[]>] [[-UserCodeMaximumLevel] <Double>] [[-UserCodeWarningLevel] <Double>]
 [-PassThru] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Set-KshTenantSiteCollection [-Identity] <TenantSiteCollection>
 [[-AllowAnonymousMeetingParticipantsToAccessWhiteboards] <SharingState>]
 [[-AllowDownloadingNonWebViewableFiles] <Boolean>] [[-AllowEditing] <Boolean>]
 [[-AnonymousLinkExpirationInDays] <Int32>] [[-AuthenticationContextStrength] <String>]
 [[-AuthenticationContextName] <String>] [[-BlockDownloadLinksFileType] <BlockDownloadLinksFileType>]
 [[-BlockDownloadMicrosoft365GroupIds] <Guid[]>] [[-BlockDownloadPolicy] <Boolean>]
 [[-CommentsOnSitePagesDisabled] <Boolean>] [[-ConditionalAccessPolicy] <ConditionalAccessPolicyType>]
 [[-DefaultLinkPermission] <SharingPermissionType>] [[-DefaultLinkToExistingAccess] <Boolean>]
 [[-DefaultSharingLinkType] <SharingLinkType>] [[-DenyAddAndCustomizePages] <DenyAddAndCustomizePagesStatus>]
 [[-DisableAppViews] <AppViewsPolicy>] [[-DisableCompanyWideSharingLinks] <CompanyWideSharingLinksPolicyType>]
 [[-DisableFlows] <FlowsPolicyType>] [[-ExcludedBlockDownloadGroupIds] <Guid[]>]
 [[-ExternalUserExpirationInDays] <Int32>] [[-InformationBarriersMode] <String>]
 [[-InformationBarriersSegments] <Guid[]>] [[-InformationBarriersSegmentsToAdd] <Guid[]>]
 [[-InformationBarriersSegmentsToRemove] <Guid[]>] [[-LimitedAccessFileType] <LimitedAccessFileType>]
 [[-MediaTranscription] <MediaTranscriptionPolicyType>]
 [[-OverrideBlockUserInfoVisibility] <SiteUserInfoVisibilityPolicyType>]
 [[-OverrideTenantAnonymousLinkExpirationPolicy] <Boolean>]
 [[-OverrideTenantExternalUserExpirationPolicy] <Boolean>] [[-Owner] <String>]
 [[-PWAEnabled] <PWAEnabledStatus>] [[-ReadOnlyAccessPolicy] <Boolean>]
 [[-ReadOnlyForUnmanagedDevices] <Boolean>] [[-RequestFilesLinkEnabled] <Boolean>]
 [[-RequestFilesLinkExpirationInDays] <Int32>] [[-RestrictedAccessControl] <Boolean>]
 [[-RestrictedToRegion] <RestrictedToRegion>]
 [[-SandboxedCodeActivationCapability] <SandboxedCodeActivationCapabilities>] [[-SensitivityLabel] <Guid>]
 [[-SensitivityLabel2] <String>] [[-SharingAllowedDomainList] <String>] [[-SharingBlockedDomainList] <String>]
 [[-SharingCapability] <SharingCapabilities>] [[-SharingDomainRestrictionMode] <SharingDomainRestrictionMode>]
 [[-ShowPeoplePickerSuggestionsForGuestUsers] <Boolean>] [[-SocialBarOnSitePagesDisabled] <Boolean>]
 [[-StorageMaximumLevel] <Int64>] [[-StorageWarningLevel] <Int64>] [[-TimeZoneId] <Int32>] [[-Title] <String>]
 [[-TitleTranslations] <ResourceEntry[]>] [[-UserCodeMaximumLevel] <Double>] [[-UserCodeWarningLevel] <Double>]
 [-NoWait] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## PARAMETERS

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

### -AnonymousLinkExpirationInDays

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

```yaml
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

### -DefaultLinkToExistingAccess

```yaml
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

```yaml
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

```yaml
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

```yaml
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

```yaml
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

```yaml
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

```yaml
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

### -StorageMaximumLevel

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

