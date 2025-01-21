---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshSiteCollectionAppCatalog

## SYNOPSIS
Retrieves one or more site collection app catalogs from the tenant.

## SYNTAX

### ParamSet1
```
Get-KshSiteCollectionAppCatalog [-Identity] <SiteCollectionAppCatalog> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet2
```
Get-KshSiteCollectionAppCatalog [-SiteCollection] <SiteCollection> [-NoEnumerate]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Get-KshSiteCollectionAppCatalog [-SiteCollectionUrl] <Uri> [-NoEnumerate] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet4
```
Get-KshSiteCollectionAppCatalog [-SiteCollectionId] <Guid> [-NoEnumerate] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet5
```
Get-KshSiteCollectionAppCatalog [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshSiteCollectionAppCatalog` cmdlet retrieves one or more site collection apps catalogs from the tenant based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshSiteCollectionAppCatalog -Identity $appCatalog
```

This example retrieves a site collection app catalog by identity.

### Example 2
```powershell
PS C:\> Get-KshSiteCollectionAppCatalog -SiteCollection $siteCollection
```

This example retrieves a site collection app catalog by site collection.

### Example 3
```powershell
PS C:\> Get-KshSiteCollectionAppCatalog -SiteCollectionUrl "https://contoso.sharepoint.com/sites/sitecollection"
```

This example retrieves a site collection app catalog by site collection URL.

### Example 4
```powershell
PS C:\> Get-KshSiteCollectionAppCatalog -SiteCollectionId "00000000-0000-0000-0000-000000000000"
```

This example retrieves a site collection app catalog by site collection ID.

### Example 5
```powershell
PS C:\> Get-KshSiteCollectionAppCatalog
```

This example retrieves all site collection app catalogs.

## PARAMETERS

### -Identity
Specifies the app catalog to retrieve.

```yaml
Type: SiteCollectionAppCatalog
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NoEnumerate
Indicates that the cmdlet does not enumerate the collection.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet2, ParamSet3, ParamSet4, ParamSet5
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SiteCollection
Specifies the site collection object to retrieve the app catalog from.

```yaml
Type: SiteCollection
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SiteCollectionId
Specifies the ID of the site collection to retrieve the app catalog from.

```yaml
Type: Guid
Parameter Sets: ParamSet4
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SiteCollectionUrl
Specifies the URL of the site collection to retrieve the app catalog from.

```yaml
Type: Uri
Parameter Sets: ParamSet3
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

### Karamem0.SharePoint.PowerShell.Models.V1.SiteCollectionAppCatalog
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.SiteCollectionAppCatalog
## NOTES

## RELATED LINKS

