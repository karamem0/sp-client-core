---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshTenantCdnOrigin

## SYNOPSIS
Adds a new Office 365 CDN origin to the tenant.

## SYNTAX

### ParamSet1
```
Add-KshTenantCdnOrigin [-Public] -Origin <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Add-KshTenantCdnOrigin [-Private] -Origin <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshTenantCdnOrigin` cmdlet adds a new Office 365 CDN origin to the tenant. You can specify whether the origin is public or private.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshTenantCdnOrigin -Public -Origin "/sites/site1/folder1"
```

This example adds a Office 365 public CDN origin to the tenant with the specified URL.

### Example 2
```powershell
PS C:\> Add-KshTenantCdnOrigin -Private -Origin "/sites/site1/folder1"
```

This example adds a Office 365 private CDN origin to the tenant with the specified URL.

## PARAMETERS

### -Origin
Specifies the URL of the Office 365 CDN origin to add to the tenant.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Private
Indicates that the Office 365 CDN is private.

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

### -Public
Indicates that the Office 365 CDN is public.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1
Aliases:

Required: True
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

### System.Void
## NOTES

## RELATED LINKS

