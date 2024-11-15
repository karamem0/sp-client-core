---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshTenantSiteScript

## SYNOPSIS
Creates a new site script.

## SYNTAX

```
Add-KshTenantSiteScript -Content <String> [-Description <String>] -Title <String>
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The Add-KshTenantSiteScript cmdlet adds a new site script to the tenant. This cmdlet can be used only when connected to the SharePoint admin center.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshTenantSiteScript -Title "Custom Site Script" -Content (Get-KshTenantSiteScriptFromSite -SiteUrl "https://example.sharepoint.com/sites/japan" -IncludeBranding -IncludeRegionalSettings -IncludeTheme)
```

Creates a new site script.

## PARAMETERS

### -Content
Specifies the content.

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

### -Description
Specifies the description.

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

### -Title
Specifies the title.

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
Determines how PowerShell responds to progress updates generated by a script, cmdlet, or provider.

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

### Karamem0.SharePoint.PowerShell.Models.V1.TenantSiteScript

## NOTES

## RELATED LINKS

