---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshViewColumn

## SYNOPSIS
Adds a view column.

## SYNTAX

### ParamSet1
```
Add-KshViewColumn [-View] <View> [-Column] <Column> [<CommonParameters>]
```

### ParamSet2
```
Add-KshViewColumn [-View] <View> [-ColumnName] <String> [<CommonParameters>]
```

## DESCRIPTION
The Add-KshViewColumn cmdlet add a column to the specified view.

## EXAMPLES

### Example 1
```powershell
PS C:> $list = Get-KshList -ListTitle 'Announcements'
PS C:> $view = Get-KshView -List $list -ViewTitle 'My Items'
PS C:> $column = Get-KshColumn -List $list -ColumnName 'Remarks'
PS C:> Add-KshViewColumn -View $view -Column $column
```

Adds a view column.

## PARAMETERS

### -Column
Specifies the column.

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
Specifies the column name.

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

### Karamem0.SharePoint.PowerShell.Models.View

## OUTPUTS

### System.Void

## NOTES

## RELATED LINKS
