---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Merge-KshTerm

## SYNOPSIS

Merges two terms into one.

## SYNTAX

```
Merge-KshTerm [-Identity] <Term> [-ToMerge] <Term> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION

The `Merge-KshTerm` cmdlet merges two terms into one.

## EXAMPLES

### Example 1

```powershell
PS C:\> Merge-KshTerm -Identity $term1 -ToMerge $term2
```

This example merges the term into the specified term.

## PARAMETERS

### -Identity

Specifies the term that will remain after the merge.

```yaml
Type: Term
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ToMerge

Specifies the term that will be merged into the identity term.

```yaml
Type: Term
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
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

### Karamem0.SharePoint.PowerShell.Models.V1.Term

## OUTPUTS

### System.Void

## NOTES

## RELATED LINKS
