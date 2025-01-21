---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshTenantSiteTemplate

## SYNOPSIS
Retrieves one or more site template from the tenant.

## SYNTAX

### ParamSet1
```
Get-KshTenantSiteTemplate -CompatibilityLevel <Int32> -Lcid <UInt32> [-NoEnumerate]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshTenantSiteTemplate [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshTenantSiteTemplate` cmdlet retrieves one or more site template from the tenant based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshTenantSiteTemplate -CompatibilityLevel 15 -Lcid 1033
```

This example retrieves site templates by compatibility level and LCID.

### Example 2
```powershell
PS C:\> Get-KshTenantSiteTemplate
```

This example retrieves all site templates.

## PARAMETERS

### -CompatibilityLevel
Specifies the compatibility level of the site template.

```yaml
Type: Int32
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Lcid
Specifies the locale ID (LCID) of the site template.

```yaml
Type: UInt32
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoEnumerate
Indicates that the cmdlet does not enumerate the collection.

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

### None
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.TenantSiteTemplate
## NOTES

## RELATED LINKS

