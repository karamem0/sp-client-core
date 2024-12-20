---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# ConvertTo-KshLocalTime

## SYNOPSIS
Converts to a local time.

## SYNTAX

```
ConvertTo-KshLocalTime [-Value] <DateTime> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Converts a universal time to a local time as defined by the site.

## EXAMPLES

### Example 1
```powershell
PS C:\> ConvertTo-KshLocalTime -Value '2001-01-01:00:00:00Z'
```

Converts a universal time to a local time.

## PARAMETERS

### -Value
Specified the date/time.

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
Determines how PowerShell responds to progress updates generated by a script, cmdlet, or provider.

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

