---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshTenantSiteDesign

## SYNOPSIS
Retrieves one or more site designs from the site.

## SYNTAX

### ParamSet1
```
Get-KshTenantSiteDesign [-Identity] <TenantSiteDesign> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet2
```
Get-KshTenantSiteDesign [-SiteDesignId] <Guid> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Get-KshTenantSiteDesign [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshTenantSiteDesign` cmdlet retrieves one or more site designs from the site based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshTenantSiteDesign -Identity $siteDesign
```

This example retrieves a site design by identity.

### Example 2
```powershell
PS C:\> Get-KshTenantSiteDesign -SiteDesignId "12345678-1234-1234-1234-1234567890ab"
```

This example retrieves a site design by site design ID.

### Example 3
```powershell
PS C:\> Get-KshTenantSiteDesign
```

This example retrieves all site designs.

## PARAMETERS

### -Identity
Specifies the site design to retrieve.

```yaml
Type: TenantSiteDesign
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NoEnumerate
Indicates that the cmdlet does not enumerate the collection.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet3
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SiteDesignId
Specifies the site design to retrieve by its GUID.

```yaml
Type: Guid
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
Specifies the action preference for progress updates.

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

### Karamem0.SharePoint.PowerShell.Models.V1.TenantSiteDesign
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.TenantSiteDesign
## NOTES

## RELATED LINKS

