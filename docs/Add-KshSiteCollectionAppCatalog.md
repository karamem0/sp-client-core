---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshSiteCollectionAppCatalog

## SYNOPSIS
Adds a new app catalog to a site collection.

## SYNTAX

### ParamSet1
```
Add-KshSiteCollectionAppCatalog -SiteCollection <SiteCollection> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet2
```
Add-KshSiteCollectionAppCatalog -TenantSiteCollection <TenantSiteCollection>
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Add-KshSiteCollectionAppCatalog -SiteCollectionUrl <Uri> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshSiteCollectionAppCatalog` cmdlet adds an app catalog to a site collection.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshSiteCollectionAppCatalog -SiteCollectionUrl "https://contoso.sharepoint.com/sites/site1"
```

This example adds a new app catalog to the site collection at the specified URL.

### Example 2
```powershell
PS C:\> Add-KshSiteCollectionAppCatalog -SiteCollection $siteCollection
```

This example adds an app catalog to the specified site collection.

### Example 3
```powershell
PS C:\> Add-KshSiteCollectionAppCatalog -TenantSiteCollection $tenantSiteCollection
```

This example adds an app catalog to the specified tenant site collection.

## PARAMETERS

### -SiteCollection
Specifies the site collection to which the app catalog is added.

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
Specifies the URL of the site collection to which the app catalog is added.

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
Specifies the tenant site collection to which the app catalog is added.

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

