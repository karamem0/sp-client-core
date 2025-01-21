---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshColumnMultiLineText

## SYNOPSIS
Creates a new MultiLineText column in a list or library.

## SYNTAX

### ParamSet1
```
Add-KshColumnMultiLineText [-List] <List> [-ClientSideComponentId <String>]
 [-ClientSideComponentProperties <String>] [-CustomFormatter <String>] [-DefaultFormula <String>]
 [-DefaultValue <String>] [-Description <String>] [-Direction <String>] [-Group <String>] [-Hidden <Boolean>]
 [-Id <Guid>] [-JSLink <String>] -Name <String> [-NoCrawl <Boolean>] [-NumberOfLines <Int32>]
 [-ReadOnly <Boolean>] [-Required <Boolean>] [-RestrictedMode <Boolean>] [-RichText <Boolean>]
 [-RichTextMode <RichTextMode>] [-StaticName <String>] [-Title <String>]
 [-UnlimitedLengthInDocumentLibrary <Boolean>] [-AddToDefaultContentType] [-AddToNoContentType]
 [-AddToAllContentTypes] [-AddColumnInternalNameHint] [-AddColumnToDefaultView] [-AddColumnCheckDisplayName]
 [-AddToDefaultView] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Add-KshColumnMultiLineText [-ClientSideComponentId <String>] [-ClientSideComponentProperties <String>]
 [-CustomFormatter <String>] [-DefaultFormula <String>] [-DefaultValue <String>] [-Description <String>]
 [-Direction <String>] [-Group <String>] [-Hidden <Boolean>] [-Id <Guid>] [-JSLink <String>] -Name <String>
 [-NoCrawl <Boolean>] [-NumberOfLines <Int32>] [-ReadOnly <Boolean>] [-Required <Boolean>]
 [-RestrictedMode <Boolean>] [-RichText <Boolean>] [-RichTextMode <RichTextMode>] [-StaticName <String>]
 [-Title <String>] [-UnlimitedLengthInDocumentLibrary <Boolean>] [-AddToDefaultContentType]
 [-AddToNoContentType] [-AddToAllContentTypes] [-AddColumnInternalNameHint] [-AddColumnToDefaultView]
 [-AddColumnCheckDisplayName] [-AddToDefaultView] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Add-KshColumnMultiLineText [-ClientSideComponentId <String>] [-ClientSideComponentProperties <String>]
 [-CustomFormatter <String>] [-DefaultFormula <String>] [-DefaultValue <String>] [-Description <String>]
 [-Direction <String>] [-Group <String>] [-Hidden <Boolean>] [-Id <Guid>] [-JSLink <String>] -Name <String>
 [-NoCrawl <Boolean>] [-NumberOfLines <Int32>] [-ReadOnly <Boolean>] [-Required <Boolean>]
 [-RestrictedMode <Boolean>] [-RichText <Boolean>] [-RichTextMode <RichTextMode>] [-StaticName <String>]
 [-Title <String>] [-UnlimitedLengthInDocumentLibrary <Boolean>] [-WhatIf] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshColumnMultiLineText` cmdlet adds a new MultiLineText column to a list or library. The column can store large amounts of text and can be configured to support rich text formatting.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshColumnMultiLineText -List $list -Name "Comments" -Title "Comments" -NumberOfLines 6 -RichText $true
```

This example creates a new MultiLineText column named "Comments" in the specified list with rich text enabled and a display name of "Comments".

### Example 2
```powershell
PS C:\> Add-KshColumnMultiLineText -Name "Notes" -Title "Notes" -NumberOfLines 10 -RichText $false
```

This example creates a new MultiLineText column named "Notes" as a site column with plain text and a display name of "Notes".

### Example 3
```powershell
PS C:\> Add-KshColumnMultiLineText -Name "Feedback" -Title "Feedback" -NumberOfLines 5 -RichText $true -WhatIf
```

This example shows what would happen if the cmdlet runs without actually creating the column. The column would be named "Feedback" with rich text enabled and a display name of "Feedback".

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
Specifies the direction of the text in the column.

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

### -Group
Specifies the group to which the column belongs.

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
Specifies the internal name of the column.

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
Specifies whether the column is excluded from search indexing.

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

### -NumberOfLines
Specifies the number of lines for the column.

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

### -RestrictedMode
Specifies whether the column is in restricted mode.

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

### -RichText
Specifies whether the column supports rich text.

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

### -RichTextMode
Specifies the rich text mode for the column.

```yaml
Type: RichTextMode
Parameter Sets: (All)
Aliases:
Accepted values: Compatible, FullHtml, HtmlAsXml, ThemeHtml

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
Specifies the display name of the column.

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

### -UnlimitedLengthInDocumentLibrary
Specifies whether the column has unlimited length in document libraries.

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

### Karamem0.SharePoint.PowerShell.Models.V1.ColumnMultiLineText
## NOTES

## RELATED LINKS

