---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Set-KshTenantCdnEnabled

## SYNOPSIS
Changes whether Office 365 CDN is enabled.

## SYNTAX

### ParamSet1
```
Set-KshTenantCdnEnabled [-Public] [-Enabled] [<CommonParameters>]
```

### ParamSet2
```
Set-KshTenantCdnEnabled [-Public] [-Disabled] [<CommonParameters>]
```

### ParamSet3
```
Set-KshTenantCdnEnabled [-Private] [-Enabled] [<CommonParameters>]
```

### ParamSet4
```
Set-KshTenantCdnEnabled [-Private] [-Disabled] [<CommonParameters>]
```

## DESCRIPTION
The Set-KshTenantCdnEnabled cmdlet changes whether Office 365 CDN is enabled in the tenant.

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-KshTenantCdnEnabled -Public -Enabled
```

Enables Office 365 Public CDN.

### Example 2
```powershell
PS C:\> Set-KshTenantCdnEnabled -Private -Enabled
```

Enables the Office 365 Private CDN.

## PARAMETERS

### -Disabled
If specified, Office 365 CDN is disabled.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet2, ParamSet4
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Enabled
If specified, Office 365 CDN is enabled.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1, ParamSet3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Private
If specified, targets Office 365 Private CDN.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet3, ParamSet4
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Public
If specified, targets Office 365 Public CDN.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1, ParamSet2
Aliases:

Required: True
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
