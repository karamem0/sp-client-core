---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshSite

## SYNOPSIS
Retrieves one or more sites from the current site.

## SYNTAX

### ParamSet1
```
Get-KshSite [-Identity] <Site> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshSite [-SiteCollection] <SiteCollection> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Get-KshSite [-List] <List> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet4
```
Get-KshSite [-SiteId] <Guid> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet5
```
Get-KshSite [-SiteUrl] <Uri> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet6
```
Get-KshSite [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshSite` cmdlet retrieves one or more sites from the current site based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshSite -Identity $site
```

This example retrieves a site by identity.

### Example 2
```powershell
PS C:\> Get-KshSite -SiteCollection $siteCollection
```

This example retrieves a site by site collection.

### Example 3
```powershell
PS C:\> Get-KshSite -List $list
```

This example retrieves a site by list.

### Example 4
```powershell
PS C:\> Get-KshSite -SiteId $siteId
```

This example retrieves a site by site ID.

### Example 5
```powershell
PS C:\> Get-KshSite -SiteUrl $siteUrl
```

This example retrieves a site by site URL.

### Example 6
```powershell
PS C:\> Get-KshSite
```

This example retrieves all sites.

## PARAMETERS

### -Identity
Specifies the site to retrieve.

```yaml
Type: Site
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -List
Specifies the list to retrieve.

```yaml
Type: List
Parameter Sets: ParamSet3
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
Parameter Sets: ParamSet6
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SiteCollection
Specifies the site collection to retrieve.

```yaml
Type: SiteCollection
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SiteId
Specifies the GUID of the site to retrieve.

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

### -SiteUrl
Specifies the URL of the site to retrieve.

```yaml
Type: Uri
Parameter Sets: ParamSet5
Aliases:

Required: True
Position: 0
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

### Karamem0.SharePoint.PowerShell.Models.V1.Site
### Karamem0.SharePoint.PowerShell.Models.V1.SiteCollection
### Karamem0.SharePoint.PowerShell.Models.V1.List
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.Site
## NOTES

## RELATED LINKS

