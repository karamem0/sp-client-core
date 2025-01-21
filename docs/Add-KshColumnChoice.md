---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshColumnChoice

## SYNOPSIS
Adds a new Choice column to a list or library.

## SYNTAX

### ParamSet1
```
Add-KshColumnChoice [-List] <List> [-ChoiceFormat <ChoiceFormatType>] [-Choices <String[]>]
 [-ClientSideComponentId <String>] [-ClientSideComponentProperties <String>] [-CustomFormatter <String>]
 [-DefaultFormula <String>] [-DefaultValue <String>] [-Description <String>] [-Direction <String>]
 [-EnforceUniqueValues <Boolean>] [-FillInChoice <Boolean>] [-Group <String>] [-Hidden <Boolean>] [-Id <Guid>]
 [-Indexed <Boolean>] [-JSLink <String>] -Name <String> [-NoCrawl <Boolean>] [-ReadOnly <Boolean>]
 [-Required <Boolean>] [-StaticName <String>] [-Title <String>] [-AddToDefaultContentType]
 [-AddToNoContentType] [-AddToAllContentTypes] [-AddColumnInternalNameHint] [-AddColumnToDefaultView]
 [-AddColumnCheckDisplayName] [-AddToDefaultView] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Add-KshColumnChoice [-ChoiceFormat <ChoiceFormatType>] [-Choices <String[]>] [-ClientSideComponentId <String>]
 [-ClientSideComponentProperties <String>] [-CustomFormatter <String>] [-DefaultFormula <String>]
 [-DefaultValue <String>] [-Description <String>] [-Direction <String>] [-EnforceUniqueValues <Boolean>]
 [-FillInChoice <Boolean>] [-Group <String>] [-Hidden <Boolean>] [-Id <Guid>] [-Indexed <Boolean>]
 [-JSLink <String>] -Name <String> [-NoCrawl <Boolean>] [-ReadOnly <Boolean>] [-Required <Boolean>]
 [-StaticName <String>] [-Title <String>] [-AddToDefaultContentType] [-AddToNoContentType]
 [-AddToAllContentTypes] [-AddColumnInternalNameHint] [-AddColumnToDefaultView] [-AddColumnCheckDisplayName]
 [-AddToDefaultView] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Add-KshColumnChoice [-ChoiceFormat <ChoiceFormatType>] [-Choices <String[]>] [-ClientSideComponentId <String>]
 [-ClientSideComponentProperties <String>] [-CustomFormatter <String>] [-DefaultFormula <String>]
 [-DefaultValue <String>] [-Description <String>] [-Direction <String>] [-EnforceUniqueValues <Boolean>]
 [-FillInChoice <Boolean>] [-Group <String>] [-Hidden <Boolean>] [-Id <Guid>] [-Indexed <Boolean>]
 [-JSLink <String>] -Name <String> [-NoCrawl <Boolean>] [-ReadOnly <Boolean>] [-Required <Boolean>]
 [-StaticName <String>] [-Title <String>] [-WhatIf] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshColumnChoice` cmdlet adds a new Choice column to a list or library. This cmdlet allows you to specify various properties for the column, such as the choices available, the default value, and whether the column is required.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshColumnChoice -List $list -Name "Category" -Choices "High", "Medium", "Low" -Required $true
```

This example adds a new Choice column named "Category" to the specified list with the choices "High", "Medium", and "Low", and sets the column as required.

### Example 2
```powershell
PS C:\> Add-KshColumnChoice -Name "Priority" -Choices "Urgent", "Normal", "Low" -AddToDefaultView
```

This example adds a new Choice column named "Priority" as a site column with the choices "Urgent", "Normal", and "Low".

### Example 3
```powershell
PS C:\> Add-KshColumnChoice -Name "Status" -Choices "Open", "Closed" -WhatIf
```

This example shows what would happen if the cmdlet runs without actually creating the column. The column would be named "Status" with the choices "Open" and "Closed" is added.

## PARAMETERS

### -AddColumnCheckDisplayName
Specifies whether to check the display name of the column.

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

### -ChoiceFormat
Specifies the format of the choice field.

```yaml
Type: ChoiceFormatType
Parameter Sets: (All)
Aliases:
Accepted values: Dropdown, RadioButtons

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Choices
Specifies the choices available in the column.

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

### -ClientSideComponentId
Specifies the client-side component ID.

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
Specifies the client-side component properties.

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
Specifies the description of the column.

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
Specifies the direction of the column.

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

### -FillInChoice
Specifies whether to allow fill-in choices.

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
Specifies the group of the column.

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
Specifies the ID of the column.

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

### -Name
Specifies the name of the column.

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
Specifies the static name of the column.

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
Specifies the title of the column.

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

### Karamem0.SharePoint.PowerShell.Models.V1.List
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.ColumnChoice
## NOTES

## RELATED LINKS

