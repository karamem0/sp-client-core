---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Move-KshViewColumn

## SYNOPSIS
Changes a view column index.

## SYNTAX

```
Move-KshViewColumn [-View] <View> [-Column] <Column> [-Index] <Int32> [<CommonParameters>]
```

## DESCRIPTION
The Move-KshViewColumn cmdlet moves a view column to the specified index.

## EXAMPLES

### Example 1
```powershell
PS C:> $list = Get-KshList -ListTitle 'Announcements'
PS C:> $view = Get-KshView -List $list -ViewTitle 'My Items'
PS C:> $column = Get-KshColumn -List $list -ColumnName 'Remarks'
PS C:> Move-KshViewColumn -View $view -Column $column -Index 0
```

Changes the view column index.

## PARAMETERS

### -Column
Specifies the column.

```yaml
Type: Column
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Index
Specifies the index.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -View
Specifies the view.

```yaml
Type: View
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### System.Void

## NOTES

## RELATED LINKS