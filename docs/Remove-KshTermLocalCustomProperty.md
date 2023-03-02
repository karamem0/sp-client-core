---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Remove-KshTermLocalCustomProperty

## SYNOPSIS
Removes a local custom property of the term.

## SYNTAX

```
Remove-KshTermLocalCustomProperty [-Term] <Term> [-Name] <String> [<CommonParameters>]
```

## DESCRIPTION
The Remove-KshTermLocalCustomProperty cmdlet removes a local custom property from the term.

## EXAMPLES

### Example 1
```powershell
PS C:\> Remove-KshTermLocalCustomProperty -Term (Get-KshTerm -TermSet (Get-KshTermSet -TermGroup (Get-KshTermGroup -TermGroupName 'Company') -TermSetName 'Department') -TermName 'Human Resources') -Name 'Hierarchy'
```

Removes a local custom property.

## PARAMETERS

### -Name
Specifies the name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Term
Specifies the term.

```yaml
Type: Term
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

### None

## NOTES

## RELATED LINKS
