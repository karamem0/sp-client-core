---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshSiteTemplate

## SYNOPSIS
Retrieves one or more site templates from the current site.

## SYNTAX

### ParamSet1
```
Get-KshSiteTemplate [-SiteTemplateName] <String> [-IncludeCrossLanguage] [[-Lcid] <UInt32>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshSiteTemplate [-IncludeCrossLanguage] [[-Lcid] <UInt32>] [-NoEnumerate]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshSiteTemplate` cmdlet retrieves one or more site templates from the current site based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshSiteTemplate -SiteTemplateName "STS#0"
```

This example retrieves a site template by site template name.

### Example 2
```powershell
PS C:\> Get-KshSiteTemplate -IncludeCrossLanguage
```

This example retrieves site templates including cross-language templates.

### Example 3
```powershell
PS C:\> Get-KshSiteTemplate -Lcid 1033
```

This example retrieves site templates with the locale ID 1033.

## PARAMETERS

### -IncludeCrossLanguage
Indicates whether to include cross-language site templates.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Lcid
Specifies the locale ID (LCID) of the site templates to retrieve.

```yaml
Type: UInt32
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoEnumerate
Indicates that the cmdlet does not enumerate the collection.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SiteTemplateName
Specifies the name of the site template to retrieve.

```yaml
Type: String
Parameter Sets: ParamSet1
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

### None
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.SiteTemplate
## NOTES

## RELATED LINKS

