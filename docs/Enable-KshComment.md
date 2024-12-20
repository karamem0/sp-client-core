---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Enable-KshComment

## SYNOPSIS
Enables comments.

## SYNTAX

```
Enable-KshComment [-Identity] <ListItem> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The Enable-KshTerm cmdlet enables comments for the specified list item.

## EXAMPLES

### Example 1
```powershell
PS C:\> Enable-KshComment -Identity (Get-KshListItem -List (Get-KshList -ListTitle 'Site Pages') -ItemId 1)
```

Enables comments.

## PARAMETERS

### -Identity
Specifies the list item.

```yaml
Type: ListItem
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

### Karamem0.SharePoint.PowerShell.Models.V1.ListItem

## OUTPUTS

### None

## NOTES

## RELATED LINKS

