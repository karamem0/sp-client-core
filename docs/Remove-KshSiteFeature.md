---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Remove-KshSiteFeature

## SYNOPSIS
Removes a site feature.

## SYNTAX

```
Remove-KshSiteFeature [-Identity] <Feature> [-Force <Boolean>] [<CommonParameters>]
```

## DESCRIPTION
The Remove-KshSiteFeature cmdlet removes a feature from the current site.

## EXAMPLES

### Example 1
```powershell
PS C:\> Remove-KshSiteFeature -Identity (Get-KshSiteFeature -FeatureId '99fe402e-89a0-45aa-9163-85342e865dc8')
```

Removes a feature.

## PARAMETERS

### -Force
Specifies whether to force removing.

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

### -Identity
Specifies the feature.

```yaml
Type: Feature
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.Feature

## OUTPUTS

### None

## NOTES

## RELATED LINKS
