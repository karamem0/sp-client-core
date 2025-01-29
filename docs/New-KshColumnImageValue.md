---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# New-KshColumnImageValue

## SYNOPSIS

Creates a new column image value.

## SYNTAX

### ParamSet1

```
New-KshColumnImageValue -ImageItem <ImageItem> [-ColumnName <String>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet2

```
New-KshColumnImageValue [-ColumnName <String>] [-FileName <String>] [-ServerUrl <String>]
 [-ServerRelativeUrl <String>] [-Id <Guid>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION

The `New-KshColumnImageValue` cmdlet creates a new column image value.

## EXAMPLES

### Example 1

```powershell
PS C:\> New-KshColumnImageValue -ImageItem $imageItem -ColumnName "ImageColumn"
```

This example creates a new column image value with the specified image item and column name.

## PARAMETERS

### -ColumnName

Specifies the name of the column.

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

### -FileName

Specifies the name of the file.

```yaml
Type: String
Parameter Sets: ParamSet2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id

Specifies the ID of the image item.

```yaml
Type: Guid
Parameter Sets: ParamSet2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageItem

Specifies the image item to use.

```yaml
Type: ImageItem
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerRelativeUrl

Specifies the server-relative URL of the image item.

```yaml
Type: String
Parameter Sets: ParamSet2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerUrl

Specifies the server URL of the image item.

```yaml
Type: String
Parameter Sets: ParamSet2
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

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about\_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.ColumnImageValue

## NOTES

## RELATED LINKS
