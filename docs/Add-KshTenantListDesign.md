---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshTenantListDesign

## SYNOPSIS
Adds a new list design to the tenant.

## SYNTAX

```
Add-KshTenantListDesign [-Description <String>] [-ListColor <TenantListDesignColor>]
 [-ListIcon <TenantListDesignIcon>] -SiteScriptIds <Guid[]> [-TemplateFeatures <String[]>]
 [-ThumbnailUrl <String>] -Title <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshTenantListDesign` cmdlet adds a new list design to the tenant with the specified properties.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshTenantListDesign -Title "Project Tracker" -SiteScriptIds $siteScriptIds -Description "Tracks project tasks and milestones" -ListColor Blue -ListIcon ClipboardList
```

This example adds a new list design to the list with the specified site script IDs, description, color, icon and title "Project Tracker".

## PARAMETERS

### -Description
Specifies the description of the list design.

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

### -ListColor
Specifies the color of the list design.

```yaml
Type: TenantListDesignColor
Parameter Sets: (All)
Aliases:
Accepted values: DarkRed, Red, Orange, Green, DarkGreen, Teal, Blue, NavyBlue, BluePurple, DarkBlue, Lavendar, Pink

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ListIcon
Specifies the icon of the list design.

```yaml
Type: TenantListDesignIcon
Parameter Sets: (All)
Aliases:
Accepted values: Bug, Calendar, BullseyeTarget, ClipboardList, Airplane, Rocket, Color, Insights, CubeShape, TestBeakerSolid, Robot, Savings

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SiteScriptIds
Specifies the site script IDs associated with the list design.

```yaml
Type: Guid[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TemplateFeatures
Specifies the template features of the list design.

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

### -ThumbnailUrl
Specifies the URL of the thumbnail image for the list design.

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
Specifies the title of the list design.

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

### Karamem0.SharePoint.PowerShell.Models.V1.TenantListDesign
## NOTES

## RELATED LINKS

