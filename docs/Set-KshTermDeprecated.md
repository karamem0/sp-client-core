---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Set-KshTermDeprecated

## SYNOPSIS
Changes whether a term is deprecated.

## SYNTAX

```
Set-KshTermDeprecated [-Identity] <Term> [-Deprecated] <Boolean> [<CommonParameters>]
```

## DESCRIPTION
The Set-KshTermDeprecated cmdlet changes whether a term is deprecated.

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-KshTermDeprecated -Identity (Get-KshTerm -TermSet (Get-KshTermSet -TermGroup (Get-KshTermGroup -TermGroupName 'Company') -TermSetName 'Department') -TermName 'Human Resources') -Deprecated $true
```

Deprecates a term.

## PARAMETERS

### -Deprecated
Specifies whether a term is deprecated.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Identity
Specifies the term.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.Models.Term

## OUTPUTS

### System.Void

## NOTES

## RELATED LINKS
