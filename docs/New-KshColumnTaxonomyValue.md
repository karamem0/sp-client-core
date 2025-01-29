---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# New-KshColumnTaxonomyValue

## SYNOPSIS

Creates a new taxonomy column value.

## SYNTAX

```
New-KshColumnTaxonomyValue -Term <Term> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION

The `New-KshColumnTaxonomyValue` cmdlet creates a new taxonomy column value.

## EXAMPLES

### Example 1

```powershell
PS C:\> New-KshColumnTaxonomyValue -Term $term
```

This example creates a new taxonomy column value with the specified term.

## PARAMETERS

### -Term

Specifies the term to be used for the taxonomy column value.

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

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about\_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.ColumnTaxonomyValue

## NOTES

## RELATED LINKS
