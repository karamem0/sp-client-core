---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshColumnGuid

## SYNOPSIS
Adds a new GUID column to a list or library.

## SYNTAX

### ParamSet1
```
Add-KshColumnGuid [-List] <List> [-ClientSideComponentId <String>] [-ClientSideComponentProperties <String>]
 [-CustomFormatter <String>] [-DefaultFormula <String>] [-DefaultValue <String>] [-Description <String>]
 [-Direction <String>] [-EnforceUniqueValues <Boolean>] [-Group <String>] [-Hidden <Boolean>] [-Id <Guid>]
 [-Indexed <Boolean>] [-JSLink <String>] [-MaxLength <Int32>] -Name <String> [-NoCrawl <Boolean>]
 [-ReadOnly <Boolean>] [-Required <Boolean>] [-StaticName <String>] [-Title <String>]
 [-AddToDefaultContentType] [-AddToNoContentType] [-AddToAllContentTypes] [-AddColumnInternalNameHint]
 [-AddColumnToDefaultView] [-AddColumnCheckDisplayName] [-AddToDefaultView]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Add-KshColumnGuid [-ClientSideComponentId <String>] [-ClientSideComponentProperties <String>]
 [-CustomFormatter <String>] [-DefaultFormula <String>] [-DefaultValue <String>] [-Description <String>]
 [-Direction <String>] [-EnforceUniqueValues <Boolean>] [-Group <String>] [-Hidden <Boolean>] [-Id <Guid>]
 [-Indexed <Boolean>] [-JSLink <String>] [-MaxLength <Int32>] -Name <String> [-NoCrawl <Boolean>]
 [-ReadOnly <Boolean>] [-Required <Boolean>] [-StaticName <String>] [-Title <String>]
 [-AddToDefaultContentType] [-AddToNoContentType] [-AddToAllContentTypes] [-AddColumnInternalNameHint]
 [-AddColumnToDefaultView] [-AddColumnCheckDisplayName] [-AddToDefaultView]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Add-KshColumnGuid [-ClientSideComponentId <String>] [-ClientSideComponentProperties <String>]
 [-CustomFormatter <String>] [-DefaultFormula <String>] [-DefaultValue <String>] [-Description <String>]
 [-Direction <String>] [-EnforceUniqueValues <Boolean>] [-Group <String>] [-Hidden <Boolean>] [-Id <Guid>]
 [-Indexed <Boolean>] [-JSLink <String>] [-MaxLength <Int32>] -Name <String> [-NoCrawl <Boolean>]
 [-ReadOnly <Boolean>] [-Required <Boolean>] [-StaticName <String>] [-Title <String>] [-WhatIf]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshColumnGuid` cmdlet adds a new GUID column to a list or library. The column can be customized with various properties such as default value, description, and whether it is required or read-only.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshColumnGuid -List $list -Name "ProjectId" -Title "Project ID"
```

This example adds a new GUID column named "ProjectId" to the specified list with the title "Project ID".

### Example 2
```powershell
PS C:\> Add-KshColumnGuid -Name "ProjectId" -Title "Project ID" -ClientSideComponentId "00000000-0000-0000-0000-000000000000"
```

This example adds a new GUID column named "ProjectId" as a site column with the title "Project ID" and a specified client-side component ID.

### Example 3
```powershell
PS C:\> Add-KshColumnGuid -Name "ProjectId" -Title "Project ID" -WhatIf
```

This example shows what would happen if the cmdlet runs without actually creating the column. The column would be named "ProjectId" with the title "Project ID".

## PARAMETERS

### -AddColumnCheckDisplayName
Specifies whether to check for display name conflicts when adding the column.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1, ParamSet2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AddColumnInternalNameHint
Specifies whether to add an internal name hint for the column.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1, ParamSet2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AddColumnToDefaultView
Specifies whether to add the column to the default view.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1, ParamSet2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AddToAllContentTypes
Specifies whether to add the column to all content types.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1, ParamSet2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AddToDefaultContentType
Specifies whether to add the column to the default content type.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1, ParamSet2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AddToDefaultView
Specifies whether to add the column to the default view.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1, ParamSet2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AddToNoContentType
Specifies whether to add the column to no content type.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1, ParamSet2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClientSideComponentId
Specifies the client-side component ID for the column.

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

### -ClientSideComponentProperties
Specifies the client-side component properties for the column.

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

### -CustomFormatter
Specifies the custom formatter for the column.

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

### -DefaultFormula
Specifies the default formula for the column.

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

### -DefaultValue
Specifies the default value for the column.

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
Specifies the description for the column.

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

### -Direction
Specifies the direction for the column.

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

### -EnforceUniqueValues
Specifies whether to enforce unique values for the column.

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

### -Group
Specifies the group for the column.

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

### -Hidden
Specifies whether the column is hidden.

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

### -Id
Specifies the ID for the column.

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

### -Indexed
Specifies whether the column is indexed.

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

### -JSLink
Specifies the JSLink for the column.

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

### -List
Specifies the list to which the column is added.

```yaml
Type: List
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MaxLength
Specifies the maximum length for the column.

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

### -Name
Specifies the name for the column.

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

### -NoCrawl
Specifies whether to exclude the column from search indexing.

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

### -ReadOnly
Specifies whether the column is read-only.

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

### -Required
Specifies whether the column is required.

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

### -StaticName
Specifies the static name for the column.

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
Specifies the title for the column.

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

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet3
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

### Karamem0.SharePoint.PowerShell.Models.V1.List
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.ColumnGuid
## NOTES

## RELATED LINKS

