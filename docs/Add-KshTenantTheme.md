---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshTenantTheme

## SYNOPSIS
Adds a new theme to the tenant.

## SYNTAX

```
Add-KshTenantTheme -IsInverted <Boolean> -Name <String> -Palette <Hashtable>
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshTenantTheme` cmdlet adds a new theme to the tenant.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshTenantTheme -IsInverted $false -Name "CustomTheme" -Palette $palette
```

This example adds a new custom theme named "CustomTheme" to the tenant with the specified color palette.

## PARAMETERS

### -IsInverted
Specifies whether the theme is inverted.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Specifies the name of the theme.

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

### -Palette
Specifies the color palette for the theme.

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
Specifies the action preference for progress.

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

### Karamem0.SharePoint.PowerShell.Models.V1.TenantTheme
## NOTES

## RELATED LINKS

