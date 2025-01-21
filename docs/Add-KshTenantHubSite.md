---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshTenantHubSite

## SYNOPSIS
Adds a site collection as a hub site.

## SYNTAX

```
Add-KshTenantHubSite [-Description <String>] [-EnablePermissionsSync <Boolean>]
 [-HideNameInNavigation <Boolean>] [-LogoUrl <String>] -SiteCollectionId <Guid> -SiteCollectionUrl <String>
 -Title <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshTenantHubSite` cmdlet adds a site collection as a hub site. This allows you to create a hub site that can be used to organize and connect sites based on projects, departments, divisions, regions, etc.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshTenantHubSite -SiteCollectionId "00000000-0000-0000-0000-000000000000" -SiteCollectionUrl "https://contoso.sharepoint.com/sites/HubSite" -Title "Contoso Hub"
```

This example adds the site collection as a hub site with the specified ID, URL and title "Contoso Hub".

## PARAMETERS

### -Description
Specifies the description of the hub site.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnablePermissionsSync
Indicates whether to enable permissions synchronization for associated sites.

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

### -HideNameInNavigation
Indicates whether to hide the hub site name in the navigation.

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

### -LogoUrl
Specifies the URL of the logo for the hub site.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SiteCollectionId
Specifies the ID of the site collection to register as a hub site.

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

### -SiteCollectionUrl
Specifies the URL of the site collection to register as a hub site.

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

### -Title
Specifies the title of the hub site.

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

### Karamem0.SharePoint.PowerShell.Models.V1.HubSite
## NOTES

## RELATED LINKS

