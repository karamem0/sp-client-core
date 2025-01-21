---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshColumn

## SYNOPSIS
Retrieves one or more columns from a list or content type.

## SYNTAX

### ParamSet1
```
Get-KshColumn [-Identity] <Column> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshColumn [-ContentType] <ContentType> [-ColumnId] <Guid> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet3
```
Get-KshColumn [-ContentType] <ContentType> [-ColumnTitle] <String> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet4
```
Get-KshColumn [-ContentType] <ContentType> [-NoEnumerate] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet5
```
Get-KshColumn [-List] <List> [-ColumnId] <Guid> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet6
```
Get-KshColumn [-List] <List> [-ColumnTitle] <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet7
```
Get-KshColumn [-List] <List> [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet8
```
Get-KshColumn [-ColumnId] <Guid> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet9
```
Get-KshColumn [-ColumnTitle] <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet10
```
Get-KshColumn [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshColumn` cmdlet retrieves one or more columns from a list or content type based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshColumn -Identity $column
```

This example retrieves a column by identity.

### Example 2
```powershell
PS C:\> Get-KshColumn -ContentType $contentType -ColumnId $columnId
```

This example retrieves a content type column by column ID.

### Example 3
```powershell
PS C:\> Get-KshColumn -ContentType $contentType -ColumnTitle "Title"
```

This example retrieves a content type column by column title.

### Example 4
```powershell
PS C:\> Get-KshColumn -ContentType $contentType
```

This example retrieves all content type columns.

### Example 5
```powershell
PS C:\> Get-KshColumn -List $list -ColumnId $columnId
```

This example retrieves a list column by column ID.

### Example 6
```powershell
PS C:\> Get-KshColumn -List $list -ColumnTitle "Title"
```

This example retrieves a list column by column title.

### Example 7
```powershell
PS C:\> Get-KshColumn -List $list -NoEnumerate
```

This example retrieves all list column.

### Example 8
```powershell
PS C:\> Get-KshColumn -ColumnId $columnId
```

This example retrieves a site column by column ID.

### Example 9
```powershell
PS C:\> Get-KshColumn -ColumnTitle "Title"
```

This example retrieves a site column by column title.

### Example 10
```powershell
PS C:\> Get-KshColumn
```

This example retrieves all site columns.

## PARAMETERS

### -ColumnId
Specifies the ID of the column to retrieve.

```yaml
Type: Guid
Parameter Sets: ParamSet2, ParamSet5, ParamSet8
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ColumnTitle
Specifies the title of the column to retrieve.

```yaml
Type: String
Parameter Sets: ParamSet3, ParamSet6, ParamSet9
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContentType
Specifies the content type that contains the column.

```yaml
Type: ContentType
Parameter Sets: ParamSet2, ParamSet3, ParamSet4
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Identity
Specifies the column to retrieve.

```yaml
Type: Column
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -List
Specifies the list that contains the column.

```yaml
Type: List
Parameter Sets: ParamSet5, ParamSet6, ParamSet7
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoEnumerate
Indicates that the cmdlet does not enumerate the collection.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet4, ParamSet7, ParamSet10
Aliases:

Required: False
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

### Karamem0.SharePoint.PowerShell.Models.V1.Column
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.ContentType
## NOTES

## RELATED LINKS

