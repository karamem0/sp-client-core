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
New-KshColumnLookupValue [-LookupId] <Int32> [[-LookupValue] <String>] [<CommonParameters>]
```

## DESCRIPTION
The New-KshColumnLookupValue cmdlet creates a new lookup column value from item ID.
This is provided for the [Add-KshListItem](Add-KshListItem.md) cmdlet and [Set-KshListItem](Set-KshListItem.md) cmdlet.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-KshColumnLookupValue -LookupId 1
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
Accept pipeline input: False
Accept wildcard characters: False
```

### -LookupValue
Specifies the item value.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.ColumnLookupValue

## NOTES

## RELATED LINKS
