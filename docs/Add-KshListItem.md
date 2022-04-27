---
external help file: SPClientCore.dll-help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshListItem

## SYNOPSIS
Creates a new list item.

## SYNTAX

```
Add-KshListItem [-List] <List> [-Value] <PSObject[]> [-NoEnumerate] [<CommonParameters>]
```

## DESCRIPTION
The Add-KshListItem cmdlet adds a new list item to the specified list.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshListItem -List (Get-KshList -ListTitle 'Announcements') -Value @{ 'Title' = 'A Happy New Year' }
```

Creates a new list item.

## PARAMETERS

### -List
Specifies the list.

```yaml
Type: List
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NoEnumerate
If specified, suppresses to enumerate objects.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Value
Specifies the column values.

```yaml
Type: PSObject[]
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.List

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.ListItem

## NOTES

## RELATED LINKS
