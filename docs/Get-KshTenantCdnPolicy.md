---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshTenantCdnPolicy

## SYNOPSIS
Retrieves the policy of the Office 365 CDN .

## SYNTAX

### ParamSet1
```
Get-KshTenantCdnPolicy [-Public] [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshTenantCdnPolicy [-Private] [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshTenantCdnPolicy` cmdlet retrieves the policy of the the Office 365 CDN.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshTenantCdnPolicy -Public
```

This example retrieves the the policy of the the Office 365 public CDN.

### Example 1
```powershell
PS C:\> Get-KshTenantCdnPolicy -Private
```

This example retrieves the the policy of the the Office 365 private CDN.

## PARAMETERS

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

### System.String
## NOTES

## RELATED LINKS

