---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Open-KshFile

## SYNOPSIS

Opens a specified file and returns its content as a stream.

## SYNTAX

```
Open-KshFile [-Identity] <File> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION

The `Open-KshFile` cmdlet opens a specified file and returns its content as a stream.

## EXAMPLES

### Example 1

```powershell
PS C:\> Open-KshFile -Identity $file
```

This example opens the specified file and returns its content as a stream.

## PARAMETERS

### -Identity

Specifies the file to open.

```yaml
Type: File
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProgressAction

Specifies the action to take when displaying progress.

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

### Karamem0.SharePoint.PowerShell.Models.V1.File

## OUTPUTS

### System.IO.Stream

## NOTES

## RELATED LINKS
