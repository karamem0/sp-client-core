---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# New-KshColumnLookupValue

## SYNOPSIS
Creates a lookup column value.

## SYNTAX

```
New-KshColumnLookupValue [-LookupId] <Int32> [<CommonParameters>]
```

## DESCRIPTION
The New-KshColumnLookupValue cmdlet creates a new lookup column value from item ID.
This is provided for the Add-KshListItem cmdlet and Update-KshListItem cmdlet .

## EXAMPLES

### Example 1
```powershell
PS C:\> $columnValue = New-KshColumnLookupValue -LookupId 1
```

Creates a new lookup column value.

## PARAMETERS

### -LookupId
Specifies the item ID.

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

### Karamem0.SharePoint.PowerShell.Models.ColumnLookupValue

## NOTES

## RELATED LINKS
