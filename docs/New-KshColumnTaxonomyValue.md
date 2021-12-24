---
external help file: SPClientCore.dll-help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# New-KshColumnTaxonomyValue

## SYNOPSIS
Creates a taxonomy column value.

## SYNTAX

```
New-KshColumnTaxonomyValue -Term <Term> [<CommonParameters>]
```

## DESCRIPTION
The New-KshColumnTaxonomyValue cmdlet creates a new taxonomy column value from term.
This is provided for the [Add-KshListItem](Add-KshListItem.md) cmdlet and [Set-KshListItem](Set-KshListItem.md) cmdlet.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-KshColumnTaxonomyValue -Term (Get-KshTerm -TermSet (Get-KshTermSet -TermGroup (Get-KshTermGroup -TermGroupName 'Company') -TermSetName 'Department') -TermId '4e45662f-c021-41fd-b413-967bf413d369')
```

Creates a new taxonomy column value.

## PARAMETERS

### -Term
Specifies the term.

```yaml
Type: Term
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.ColumnTaxonomyValue

## NOTES

## RELATED LINKS
