---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# New-KshColumnUserValue

## SYNOPSIS
Creates a user column value.

## SYNTAX

```
New-KshColumnUserValue [-LookupId] <Int32> [<CommonParameters>]
```

## DESCRIPTION
The New-KshColumnUserValue cmdlet creates a new user column value from user ID.
This is provided for the Add-KshListItem cmdlet and Update-KshListItem cmdlet .

## EXAMPLES

### Example 1
```powershell
PS C:\> $columnValue = New-KshColumnUserValue -LookupId 1
```

Creates a new user column value.

## PARAMETERS

### -LookupId
Specifies the user ID.

```yaml
Type: Int32
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

### System.Int32

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.ColumnUserValue

## NOTES

## RELATED LINKS
