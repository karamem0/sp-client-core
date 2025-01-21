---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshSiteCollectionFeature

## SYNOPSIS
Retrieves one or more features of a site collection.

## SYNTAX

### ParamSet1
```
Get-KshSiteCollectionFeature [-Identity] <Feature> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshSiteCollectionFeature [-FeatureId] <Guid> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Get-KshSiteCollectionFeature [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshSiteCollectionFeature` cmdlet retrieves one or more features of a site collection based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshSiteCollectionFeature -Identity $feature
```

This example retrieves a site collection feature by identity.

### Example 2
```powershell
PS C:\> Get-KshSiteCollectionFeature -FeatureId $featureId
```

This example retrieves a site collection feature by feature ID.

### Example 3
```powershell
PS C:\> Get-KshSiteCollectionFeature
```

This example retrieves all site collection features.

## PARAMETERS

### -FeatureId
Specifies the ID of the feature to retrieve.

```yaml
Type: Guid
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Identity
Specifies the feature to retrieve.

```yaml
Type: Feature
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NoEnumerate
Indicates that the cmdlet does not enumerate the features.

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

### Karamem0.SharePoint.PowerShell.Models.V1.Feature
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.Feature
## NOTES

## RELATED LINKS

