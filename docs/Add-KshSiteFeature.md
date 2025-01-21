---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshSiteFeature

## SYNOPSIS
Activates a feature in a site.

## SYNTAX

```
Add-KshSiteFeature -FeatureId <Guid> [-Force <Boolean>] [-Scope <FeatureDefinitionScope>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshSiteFeature` cmdlet activates a feature in the current site using the feature ID.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshSiteFeature -FeatureId "12345678-1234-1234-1234-1234567890ab" -Force $true
```

This example activates the feature with the specified feature ID in the site, forcing activation if necessary.

## PARAMETERS

### -FeatureId
Specifies the ID of the feature to add.

```yaml
Type: Guid
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Forces the addition of the feature, even if it is already activated.

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

### -Scope
Specifies the scope of the feature to add.

```yaml
Type: FeatureDefinitionScope
Parameter Sets: (All)
Aliases:
Accepted values: None, Farm, SiteCollection, Site

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

### System.Void
## NOTES

## RELATED LINKS

