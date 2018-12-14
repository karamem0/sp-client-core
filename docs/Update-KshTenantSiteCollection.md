---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Update-KshTenantSiteCollection

## SYNOPSIS
Updates a site collection.

## SYNTAX

### ParamSet1
```
Update-KshTenantSiteCollection [-Identity] <TenantSiteCollection>
 [-AllowDownloadingNonWebViewableFiles <Boolean>] [-DisableAppViews <AppViewsPolicy>]
 [-DisableCompanyWideSharingLinks <CompanyWideSharingLinksPolicy>] [-DisableFlows <FlowsPolicy>]
 [-Owner <String>] [-PWAEnabled <PWAEnabledStatus>] [-RestrictedToRegion <RestrictedToRegion>]
 [-SandboxedCodeActivationCapability <SandboxedCodeActivationCapabilities>] [-StorageMaxLevel <Int64>]
 [-StorageWarningLevel <Int64>] [-Title <String>] [-UserCodeMaxLevel <Double>] [-UserCodeWarningLevel <Double>]
 [-PassThru] [<CommonParameters>]
```

### ParamSet2
```
Update-KshTenantSiteCollection [-Identity] <TenantSiteCollection>
 [-AllowDownloadingNonWebViewableFiles <Boolean>] [-DisableAppViews <AppViewsPolicy>]
 [-DisableCompanyWideSharingLinks <CompanyWideSharingLinksPolicy>] [-DisableFlows <FlowsPolicy>]
 [-Owner <String>] [-PWAEnabled <PWAEnabledStatus>] [-RestrictedToRegion <RestrictedToRegion>]
 [-SandboxedCodeActivationCapability <SandboxedCodeActivationCapabilities>] [-StorageMaxLevel <Int64>]
 [-StorageWarningLevel <Int64>] [-Title <String>] [-UserCodeMaxLevel <Double>] [-UserCodeWarningLevel <Double>]
 [-NoWait] [<CommonParameters>]
```

## DESCRIPTION
The Update-KshTenantSiteCollection cmdlet updates properties of the site collection.
This cmdlet can be used only when connected to the SharePoint admin center.

## EXAMPLES

### Example 1
```powershell
PS C:\> $siteCollection = Get-KshTenantSiteCollection -SiteCollectionUrl 'https://example.sharepoint.com/sites/hub'
PS C:\> Update-KshTenantSiteCollection -Identity $siteCollection -Owner 'admin@example.onmicrosoft.com'
```

Updates property values of the site collection.

## PARAMETERS

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
Type: CompanyWideSharingLinksPolicy
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
Type: FlowsPolicy
Parameter Sets: (All)
Aliases:
Accepted values: Unknown, Disabled, NotDisabled

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

### -StorageMaxLevel
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

### -UserCodeMaxLevel
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.Models.TenantSiteCollection

## OUTPUTS

### System.Void

## NOTES

## RELATED LINKS
