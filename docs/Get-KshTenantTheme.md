---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshTenantTheme

## SYNOPSIS
Retrieves one or more themes.

## SYNTAX

### ParamSet1
```
Get-KshTenantTheme -Identity <TenantTheme> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshTenantTheme -ThemeName <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Get-KshTenantTheme [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The Get-KshTenantSiteTemplate cmdlet retrieves themes. This cmdlet can be used only when connected to the SharePoint admin center.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshTenantSiteTemplate
```

Retrieves all themes.

### Example 1
```powershell
PS C:\> Get-KshTenantSiteTemplate -ThemeName 'Custom Theme'
```

Retrieves a theme by theme name.

## PARAMETERS

### -Identity
Specifies the theme.

```yaml
Type: TenantTheme
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoEnumerate
If specified, suppresses to enumerate objects.

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

### -ThemeName
Specifies the theme name.

```yaml
Type: String
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
Determines how PowerShell responds to progress updates generated by a script, cmdlet, or provider.

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

