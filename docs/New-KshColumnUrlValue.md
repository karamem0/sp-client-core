---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# New-KshColumnUrlValue

## SYNOPSIS
Creates a URL column value.

## SYNTAX

```
New-KshColumnUrlValue [-Url] <String> [[-Description] <String>] [<CommonParameters>]
```

## DESCRIPTION
The New-KshColumnUrlValue cmdlet creates a new URL column value from URL.
This is provided for the [Add-KshListItem](Add-KshListItem.md) cmdlet and [Set-KshListItem](Set-KshListItem.md) cmdlet.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-KshColumnUrlValue -Url 'https://www.example.com'
```

Creates a new URL column value.

## PARAMETERS

### -Description
Specifies the description.

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

### -Url
Specifies the URL.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.ColumnUserValue

## NOTES

## RELATED LINKS
