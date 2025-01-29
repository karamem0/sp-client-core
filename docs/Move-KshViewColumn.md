---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Move-KshViewColumn

## SYNOPSIS

Moves a view column.

## SYNTAX

### ParamSet1

```
Move-KshViewColumn [-View] <View> [-Column] <Column> [-NewIndex] <Int32> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet2

```
Move-KshViewColumn [-View] <View> [-ColumnName] <String> [-NewIndex] <Int32>
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION

The `Move-KshViewColumn` cmdlet moves a column to a new index within a view.

## EXAMPLES

### Example 1

```powershell
PS C:\> Move-KshViewColumn -View $view -Column $column -NewIndex 2
```

This example moves the specified column to the new index position within the given view.

## PARAMETERS

### -Column

Specifies the column object to move.

```yaml
Type: Column
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ColumnName

Specifies the name of the column to move.

```yaml
Type: String
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NewIndex

Specifies the new index position for the column.

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

Specifies the view object that contains the column.

```yaml
Type: View
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
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

### System.Void

## NOTES

## RELATED LINKS
