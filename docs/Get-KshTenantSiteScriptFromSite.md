---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshTenantSiteScriptFromSite

## SYNOPSIS
Retrieves a site script from a site.

## SYNTAX

```
Get-KshTenantSiteScriptFromSite [-SiteUrl] <String> [-IncludeBranding] [-IncludedLists <String[]>]
 [-IncludeLinksToExportedItems] [-IncludeRegionalSettings] [-IncludeSiteExternalSharingCapability]
 [-IncludeTheme] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshTenantSiteScriptFromSite` cmdlet retrieves a site script a specified site.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshTenantSiteScriptFromSite -SiteUrl "https://contoso.sharepoint.com/sites/site1"
```

This example retrieves the site script by site URL.

## PARAMETERS

### -IncludeBranding
Includes branding settings in the site script.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeLinksToExportedItems
Includes links to exported items in the site script.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeRegionalSettings
Includes regional settings in the site script.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeSiteExternalSharingCapability
Includes site external sharing capability settings in the site script.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeTheme
Includes theme settings in the site script.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludedLists
Specifies the lists to include in the site script.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SiteUrl
Specifies the URL of the site from which to retrieve the site script.

```yaml
Type: String
Parameter Sets: (All)
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

### System.String
## NOTES

## RELATED LINKS

