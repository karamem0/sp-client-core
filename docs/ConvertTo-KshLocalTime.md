---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# ConvertTo-KshLocalTime

## SYNOPSIS
Converts a given DateTime value to local time.

## SYNTAX

```
ConvertTo-KshLocalTime [-Value] <DateTime> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `ConvertTo-KshLocalTime` cmdlet converts a given DateTime value to the local time using the current site settings.

## EXAMPLES

### Example 1
```powershell
PS C:\> ConvertTo-KshLocalTime -Value (Get-Date)
```

This example converts the current date and time to local time.

## PARAMETERS

### -Value
Specifies the DateTime value to convert to local time.

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
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

### System.DateTime
## OUTPUTS

### System.DateTime
## NOTES

## RELATED LINKS

