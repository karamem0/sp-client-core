---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshTenantCdnEnabled

## SYNOPSIS
Retrieves the value whether the Office 365 CDN is enabled.

## SYNTAX

### ParamSet1
```
Get-KshTenantCdnEnabled [-Public] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshTenantCdnEnabled [-Private] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshTenantCdnEnabled` cmdlet retrieves the value whether the Office 365 CDN is enabled.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshTenantCdnEnabled -Public
```

This example retrieves the value of the Office 365 public CDN.

### Example 2
```powershell
PS C:\> Get-KshTenantCdnEnabled -Private
```

This example retrieves the value of the Office 365 private CDN.

## PARAMETERS

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

### System.Boolean
Returns a Boolean value indicating whether the Tenant CDN is enabled.

## NOTES

## RELATED LINKS

