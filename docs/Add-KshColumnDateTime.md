---
Module Name: SPClientCore
external help file: SPClientCore.dll-Help.xml
schema: 2.0.0
---

# Add-KshColumnDateTime

## SYNOPSIS
Add a date/time column.

## SYNTAX

### ParamSet1
```
Add-KshColumnDateTime [-List] <List> [[-CalendarType] <CalendarType>] [[-ClientSideComponentId] <String>]
 [[-ClientSideComponentProperties] <String>] [[-CustomFormatter] <String>]
 [[-DateFormat] <ColumnDateTimeFormatType>] [[-DefaultFormula] <String>] [[-DefaultValue] <String>]
 [[-Description] <String>] [[-Direction] <String>] [[-EnforceUniqueValues] <Boolean>]
 [[-FriendlyFormat] <ColumnDateTimeFriendlyFormatType>] [[-Group] <String>] [[-Hidden] <Boolean>]
 [[-Id] <Guid>] [[-Indexed] <Boolean>] [[-JSLink] <String>] [-Name] <String> [[-NoCrawl] <Boolean>]
 [[-ReadOnly] <Boolean>] [[-Required] <Boolean>] [[-StaticName] <String>] [[-Title] <String>]
 [-AddToDefaultContentType] [-AddToNoContentType] [-AddToAllContentTypes] [-AddColumnInternalNameHint]
 [-AddColumnToDefaultView] [-AddColumnCheckDisplayName] [-AddToDefaultView] [-SelectAllProperties]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Add-KshColumnDateTime [[-CalendarType] <CalendarType>] [[-ClientSideComponentId] <String>]
 [[-ClientSideComponentProperties] <String>] [[-CustomFormatter] <String>]
 [[-DateFormat] <ColumnDateTimeFormatType>] [[-DefaultFormula] <String>] [[-DefaultValue] <String>]
 [[-Description] <String>] [[-Direction] <String>] [[-EnforceUniqueValues] <Boolean>]
 [[-FriendlyFormat] <ColumnDateTimeFriendlyFormatType>] [[-Group] <String>] [[-Hidden] <Boolean>]
 [[-Id] <Guid>] [[-Indexed] <Boolean>] [[-JSLink] <String>] [-Name] <String> [[-NoCrawl] <Boolean>]
 [[-ReadOnly] <Boolean>] [[-Required] <Boolean>] [[-StaticName] <String>] [[-Title] <String>]
 [-AddToDefaultContentType] [-AddToNoContentType] [-AddToAllContentTypes] [-AddColumnInternalNameHint]
 [-AddColumnToDefaultView] [-AddColumnCheckDisplayName] [-AddToDefaultView] [-SelectAllProperties]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Add-KshColumnDateTime [[-CalendarType] <CalendarType>] [[-ClientSideComponentId] <String>]
 [[-ClientSideComponentProperties] <String>] [[-CustomFormatter] <String>]
 [[-DateFormat] <ColumnDateTimeFormatType>] [[-DefaultFormula] <String>] [[-DefaultValue] <String>]
 [[-Description] <String>] [[-Direction] <String>] [[-EnforceUniqueValues] <Boolean>]
 [[-FriendlyFormat] <ColumnDateTimeFriendlyFormatType>] [[-Group] <String>] [[-Hidden] <Boolean>]
 [[-Id] <Guid>] [[-Indexed] <Boolean>] [[-JSLink] <String>] [-Name] <String> [[-NoCrawl] <Boolean>]
 [[-ReadOnly] <Boolean>] [[-Required] <Boolean>] [[-StaticName] <String>] [[-Title] <String>] [-WhatIf]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## PARAMETERS

### -AddColumnCheckDisplayName

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

### -CalendarType

```yaml
Type: CalendarType
Parameter Sets: (All)
Aliases:
Accepted values: None, Gregorian, Japan, Taiwan, Korea, Hijri, Thai, Hebrew, GregorianMEFrench, GregorianArabic, GregorianXLITEnglish, GregorianXLITFrench, KoreaJapanLunar, ChineseLunar, SakaEra, UmAlQura

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClientSideComponentId

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

### -DefaultFormula

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

### -FriendlyFormat

```yaml
Type: ColumnDateTimeFriendlyFormatType
Parameter Sets: (All)
Aliases:
Accepted values: Unspecified, Disabled, Relative

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Group

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

### -SelectAllProperties

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

### -StaticName

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

### Karamem0.SharePoint.PowerShell.Models.V1.ColumnDateTime

