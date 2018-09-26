---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Update-SPWeb

## SYNOPSIS
Updates a site.

## SYNTAX

```
Update-SPWeb [-AllowCreateDeclarativeWorkflowForCurrentUser <Boolean>]
 [-AllowSavePublishDeclarativeWorkflowForCurrentUser <Boolean>] [-AlternateCssUrl <String>]
 [-AssociatedMemberGroup <Group>] [-AssociatedOwnerGroup <Group>] [-AssociatedVisitorGroup <Group>]
 [-CustomMasterUrl <String>] [-Description <String>] [-EnableMinimalDownload <Boolean>]
 [-FooterEnabled <Boolean>] [-HeaderEmphasis <VariantThemeType>] [-HeaderLayout <HeaderLayoutType>]
 [-HideSiteLogo <Boolean>] [-HideSiteTitle <Boolean>] [-HorizontalQuickLaunch <Boolean>]
 [-MegaMenuEnabled <Boolean>] [-MasterUrl <String>] [-NoCrawl <Boolean>] [-ObjectCacheEnabled <Boolean>]
 [-OverwriteTranslationsOnChange <Boolean>] [-QuickLaunchEnabled <Boolean>]
 [-SaveSiteAsTemplateEnabled <Boolean>] [-ServerRelativeUrl <String>] [-SiteLogoUrl <String>]
 [-SyndicationEnabled <Boolean>] [-Title <String>] [-TreeViewEnabled <Boolean>] [-UIVersion <Int32>]
 [-UIVersionConfigurationEnabled <Boolean>] [-WelcomePage <String>] [-PassThru] [-Includes <String[]>]
 [<CommonParameters>]
```

## DESCRIPTION
The Update-SPWeb cmdlet updates the current site property.

## EXAMPLES

### Example 1
```
PS C:\> Update-SPWeb -Title 'My Team'
```

Updates display name of the current site.

## PARAMETERS

### -AlternateCssUrl
Indicates the alternate style sheet URL.

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

### -AssociatedMemberGroup
@{Text=}

```yaml
Type: Group
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AssociatedOwnerGroup
@{Text=}

```yaml
Type: Group
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AssociatedVisitorGroup
@{Text=}

```yaml
Type: Group
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomMasterUrl
Indicates the custom master page URL.

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

### -Description
Indicates the description.

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

### -EnableMinimalDownload
Indicates the value whether to use Minimal Download Strategy.

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

### -FooterEnabled
Indicates the value whether to use a footer.

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

### -HeaderEmphasis
@{Text=}

```yaml
Type: VariantThemeType
Parameter Sets: (All)
Aliases:
Accepted values: None, Neutral, Soft, Strong

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HeaderLayout
@{Text=}

```yaml
Type: HeaderLayoutType
Parameter Sets: (All)
Aliases:
Accepted values: None, Standard, Compact, Minimal

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HideSiteLogo
Indicates the value whether to hide the site logo.

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

### -HideSiteTitle
Indicates the value whether to hide the site title.

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

### -HorizontalQuickLaunch
@{Text=}

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

### -Includes
Indicates the property name collection to include in the result object.

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

### -MasterUrl
Indicates the master page URL.

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

### -MegaMenuEnabled
@{Text=}

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

### -NoCrawl
Indicates the value whether to forbid to crawl the site.

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

### -ObjectCacheEnabled
@{Text=}

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

### -OverwriteTranslationsOnChange
@{Text=}

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

### -PassThru
If specified, returns the updated object.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -QuickLaunchEnabled
Indicates the value whether to use the quick launch.

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

### -SaveSiteAsTemplateEnabled
Indicates the value whether to allow to save the site as a template.

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

### -ServerRelativeUrl
Indicates the server relative URL.

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

### -SiteLogoUrl
Indicates the site logo URL.

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

### -SyndicationEnabled
@{Text=}

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

### -Title
Indicates the title.

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

### -TreeViewEnabled
Indicates the value whether to use the tree view.

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

### -UIVersion
Indicates the UI version.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UIVersionConfigurationEnabled
Indicates the value whether the settings UI for visual upgrade.

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

### -WelcomePage
Indicates the welcome page URL.

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

### -AllowCreateDeclarativeWorkflowForCurrentUser
{{Fill AllowCreateDeclarativeWorkflowForCurrentUser Description}}

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

### -AllowSavePublishDeclarativeWorkflowForCurrentUser
{{Fill AllowSavePublishDeclarativeWorkflowForCurrentUser Description}}

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.Core.Web
## NOTES

## RELATED LINKS
