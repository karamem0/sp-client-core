---
Module Name: SPClientCore
external help file: SPClientCore.dll-Help.xml
schema: 2.0.0
---

# Add-KshSiteCollectionAppCatalog

## SYNOPSIS
Add a site collection app catalog.

## SYNTAX

### ParamSet1
```
Add-KshSiteCollectionAppCatalog [-SiteCollection] <SiteCollection> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet2
```
Add-KshSiteCollectionAppCatalog [-TenantSiteCollection] <TenantSiteCollection>
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Add-KshSiteCollectionAppCatalog [-SiteCollectionUrl] <Uri> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## PARAMETERS

### -SiteCollection

```yaml
Type: SiteCollection
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SiteCollectionUrl

```yaml
Type: Uri
Parameter Sets: ParamSet3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TenantSiteCollection

```yaml
Type: TenantSiteCollection
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction

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

