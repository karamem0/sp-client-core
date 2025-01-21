---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshTenantSiteDesign

## SYNOPSIS
Adds a new site design to the tenant.

## SYNTAX

```
Add-KshTenantSiteDesign [-Description <String>] [-DesignPackageId <Guid>] [-IsDefault <Boolean>]
 [-PreviewImageAltText <String>] [-PreviewImageUrl <String>] -SiteScriptIds <String[]> [-SiteTemplate <String>]
 [-ThumbnailUrl <String>] -Title <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshTenantSiteDesign` cmdlet adds a new site design to the tenant with the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshTenantSiteDesign -Title "Contoso Site Design" -SiteScriptIds "12345678-1234-1234-1234-1234567890ab" -Description "A site design for Contoso"
```

This example adds a new tenant site design with the title "Contoso Site Design" and the specified site script IDs.

## PARAMETERS

### -Description
Specifies the description of the site design.

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
Specifies the design package ID of the site design.

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
Indicates whether the site design is the default design.

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
Specifies the alternative text for the preview image.

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
Specifies the URL of the preview image.

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
Specifies the IDs of the site scripts to be included in the site design.

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
Specifies the site template to be used for the site design.

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
Specifies the URL of the thumbnail image.

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
Specifies the title of the site design.

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

### Karamem0.SharePoint.PowerShell.Models.V1.TenantSiteDesign
## NOTES

## RELATED LINKS

