---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# New-KshColumnCurrency

## SYNOPSIS
Creates a column of currency type.

## SYNTAX

### ParamSet1
```
New-KshColumnCurrency [-List] <List> [-ClientSideComponentId <String>]
 [-ClientSideComponentProperties <String>] [-CurrencyLcid <UInt32>] [-CustomFormatter <String>]
 [-DefaultFormula <String>] [-DefaultValue <String>] [-Description <String>] [-Direction <String>]
 [-EnforceUniqueValues <Boolean>] [-Group <String>] [-Hidden <Boolean>] [-Id <Guid>] [-Indexed <Boolean>]
 [-JSLink <String>] [-MaxValue <Double>] [-MinValue <Double>] -Name <String> [-NoCrawl <Boolean>]
 [-NumberFormat <Int32>] [-ReadOnly <Boolean>] [-Required <Boolean>] [-StaticName <String>] [-Title <String>]
 [-AddColumnOptions <AddColumnOptions>] [-AddToDefaultView] [<CommonParameters>]
```

### ParamSet2
```
New-KshColumnCurrency [-ClientSideComponentId <String>] [-ClientSideComponentProperties <String>]
 [-CurrencyLcid <UInt32>] [-CustomFormatter <String>] [-DefaultFormula <String>] [-DefaultValue <String>]
 [-Description <String>] [-Direction <String>] [-EnforceUniqueValues <Boolean>] [-Group <String>]
 [-Hidden <Boolean>] [-Id <Guid>] [-Indexed <Boolean>] [-JSLink <String>] [-MaxValue <Double>]
 [-MinValue <Double>] -Name <String> [-NoCrawl <Boolean>] [-NumberFormat <Int32>] [-ReadOnly <Boolean>]
 [-Required <Boolean>] [-StaticName <String>] [-Title <String>] [-AddColumnOptions <AddColumnOptions>]
 [-AddToDefaultView] [<CommonParameters>]
```

### ParamSet3
```
New-KshColumnCurrency [-ClientSideComponentId <String>] [-ClientSideComponentProperties <String>]
 [-CurrencyLcid <UInt32>] [-CustomFormatter <String>] [-DefaultFormula <String>] [-DefaultValue <String>]
 [-Description <String>] [-Direction <String>] [-EnforceUniqueValues <Boolean>] [-Group <String>]
 [-Hidden <Boolean>] [-Id <Guid>] [-Indexed <Boolean>] [-JSLink <String>] [-MaxValue <Double>]
 [-MinValue <Double>] -Name <String> [-NoCrawl <Boolean>] [-NumberFormat <Int32>] [-ReadOnly <Boolean>]
 [-Required <Boolean>] [-StaticName <String>] [-Title <String>] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The New-KshColumnCurrency cmdlet adds new currency column to the current site or the specified list.

## EXAMPLES

### Example 1
```powershell
PS C:\> $currencyColumn = New-KshColumnCurrency -MinimumValue 0 -MaximumValue 1000 -Name 'CurrencyColumn'
```

Creates a new column.

## PARAMETERS

### -AddColumnOptions
Specifies the control settings while adding a column.

```yaml
Type: AddColumnOptions
Parameter Sets: ParamSet1, ParamSet2
Aliases:
Accepted values: DefaultValue, AddToDefaultContentType, AddToNoContentType, AddToAllContentTypes, AddColumnInternalNameHint, AddColumnToDefaultView, AddColumnCheckDisplayName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AddToDefaultView
Specifies whether to New a column to the default view.

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
Specifies the ID of the client-side component.

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
Specifies the JSON string that the propeties of the client-side component.

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

### -CurrencyLcid
Specifies the locale ID.
For more information, see [reference](https://msdn.microsoft.com/en-us/library/cc233965.aspx).

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
Specifies the JSON string of custom format.

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
Specifies the default formula.

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
Specifies the default value.

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

### -Direction
Specifies the direction.

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
Specifies whether the column must to have unique value.

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
Specifies the name for grouping.

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
Specifies whether to hide the column from users.

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
Specifies the ID.

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
Specifies whether to the column is indexed.

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
Specifies the JSLink URL.

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
Specifies the list.

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

### -MaxValue
Specifies the maximum value.

```yaml
Type: Double
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MinValue
Specifies the minimum value.

```yaml
Type: Double
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Specifies the name.

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
Specifies whether to suppress to search crawling.

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
Specifies the number of decimals.

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

### -ReadOnly
Specifies whether changes to the column properties are denied.

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
Specifies whether a value is required.

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
Specifies the static name.

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

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.ColumnCurrency

## NOTES

## RELATED LINKS