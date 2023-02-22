---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshTenantSiteDesign

## SYNOPSIS
Creates a new site design.

## SYNTAX

```
Add-KshTenantSiteDesign [-Description <String>] [-DesignPackageId <Guid>] [-IsDefault <Boolean>]
 [-PreviewImageAltText <String>] [-PreviewImageUrl <String>] -SiteScriptIds <String[]> [-SiteTemplate <String>]
 [-ThumbnailUrl <String>] -Title <String> [<CommonParameters>]
```

## DESCRIPTION
The Add-KshTenantSiteDesign cmdlet adds a new site design to the tenant. This cmdlet can be used only when connected to the SharePoint admin center.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshTenantListDesign -Title "Custom Site Design" -SiteScriptIds "60729fc8-3ba5-4ea1-9a35-478932b26182"
```

Creates a new site design.

## PARAMETERS

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

### -DesignPackageId
Specifies the design package ID.

```yaml
Type: Guid
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsDefault
If specified, sets the site design as default.

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

### -PreviewImageAltText
Specifies the alternative preview image URL.

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

### -PreviewImageUrl
Specifies the preview image URL.

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

### -SiteScriptIds
Specifies the list of site script IDs.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SiteTemplate
Specifies the site template.

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

### -ThumbnailUrl
Specifies the thumbnail URL.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.TenantSiteDesign

## NOTES

## RELATED LINKS
