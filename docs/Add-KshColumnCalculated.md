---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshColumnCalculated

## SYNOPSIS
Creates a new Calculated column to a list or library.

## SYNTAX

### ParamSet1
```
Add-KshColumnCalculated [-List] <List> [-ClientSideComponentId <String>]
 [-ClientSideComponentProperties <String>] -Columns <Column[]> [-CurrencyLcid <UInt32>]
 [-CustomFormatter <String>] [-DateFormat <ColumnDateTimeFormatType>] [-Description <String>]
 [-Direction <String>] -Formula <String> [-Group <String>] [-Hidden <Boolean>] [-Id <Guid>] [-JSLink <String>]
 -Name <String> [-NoCrawl <Boolean>] [-NumberFormat <Int32>] -OutputType <ColumnType>
 [-ShowAsPercentage <Boolean>] [-StaticName <String>] [-Title <String>] [-AddToDefaultContentType]
 [-AddToNoContentType] [-AddToAllContentTypes] [-AddColumnInternalNameHint] [-AddColumnToDefaultView]
 [-AddColumnCheckDisplayName] [-AddToDefaultView] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Add-KshColumnCalculated [-ClientSideComponentId <String>] [-ClientSideComponentProperties <String>]
 -Columns <Column[]> [-CurrencyLcid <UInt32>] [-CustomFormatter <String>]
 [-DateFormat <ColumnDateTimeFormatType>] [-Description <String>] [-Direction <String>] -Formula <String>
 [-Group <String>] [-Hidden <Boolean>] [-Id <Guid>] [-JSLink <String>] -Name <String> [-NoCrawl <Boolean>]
 [-NumberFormat <Int32>] -OutputType <ColumnType> [-ShowAsPercentage <Boolean>] [-StaticName <String>]
 [-Title <String>] [-AddToDefaultContentType] [-AddToNoContentType] [-AddToAllContentTypes]
 [-AddColumnInternalNameHint] [-AddColumnToDefaultView] [-AddColumnCheckDisplayName] [-AddToDefaultView]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Add-KshColumnCalculated [-ClientSideComponentId <String>] [-ClientSideComponentProperties <String>]
 -Columns <Column[]> [-CurrencyLcid <UInt32>] [-CustomFormatter <String>]
 [-DateFormat <ColumnDateTimeFormatType>] [-Description <String>] [-Direction <String>] -Formula <String>
 [-Group <String>] [-Hidden <Boolean>] [-Id <Guid>] [-JSLink <String>] -Name <String> [-NoCrawl <Boolean>]
 [-NumberFormat <Int32>] -OutputType <ColumnType> [-ShowAsPercentage <Boolean>] [-StaticName <String>]
 [-Title <String>] [-WhatIf] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshColumnCalculated` cmdlet adds a new Calculated column to a list or library. The column can be configured with various parameters such as formula, output type, and formatting options.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshColumnCalculated -List $list -Name "Total" -Formula "=[Quantity]*[Price]" -OutputType Number
```

This example adds a new Calculated column named "Total" in the specified list. The column calculates the total by multiplying the values of the "Quantity" and "Price" columns.

### Example 2
```powershell
PS C:\> Add-KshColumnCalculated -Columns $columns -Name "Total" -Formula "=[Quantity]*[Price]" -OutputType Number
```

This example adds a new Calculated column named "Total" as a site column. The column calculates the total by multiplying the values of the "Quantity" and "Price" columns.

### Example 3
```powershell
PS C:\> Add-KshColumnCalculated -Columns $columns -Name "Total" -Formula "=[Quantity]*[Price]" -OutputType Number -WhatIf
```

This example shows what would happen if the cmdlet runs without actually creating the column. The column would calculate the total by multiplying the values of the "Quantity" and "Price" columns.

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

### -Columns
Specifies the columns to be included in the calculation.

```yaml
Type: Column[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CurrencyLcid
Specifies the locale ID for currency formatting.

```yaml
Type: UInt32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomFormatter
Specifies a custom formatter for the column.

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

### -DateFormat
Specifies the date format for the column.

```yaml
Type: ColumnDateTimeFormatType
Parameter Sets: (All)
Aliases:
Accepted values: DateOnly, DateTime

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

### -Formula
Specifies the formula for the calculated column.

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
Specifies the list where the column will be added.

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
Specifies whether the column should be excluded from search indexing.

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

### -NumberFormat
Specifies the number format for the column.

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

### -OutputType
Specifies the output type of the calculated column.

```yaml
Type: ColumnType
Parameter Sets: (All)
Aliases:
Accepted values: Invalid, Integer, Text, Note, DateTime, Counter, Choice, Lookup, Boolean, Number, Currency, URL, Computed, Threading, Guid, MultiChoice, GridChoice, Calculated, File, Attachments, User, Recurrence, CrossProjectLink, ModStat, Error, ContentTypeId, PageSeparator, ThreadIndex, WorkflowStatus, AllDayEvent, WorkflowEventType, Geolocation, OutcomeChoice, Location, Thumbnail, MaxItems

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShowAsPercentage
Specifies whether to show the calculated value as a percentage.

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
Specifies the action to take on progress.

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

### Karamem0.SharePoint.PowerShell.Models.V1.ColumnCalculated
## NOTES

## RELATED LINKS

