---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Copy-KshTerm

## SYNOPSIS
Copies a term to a new location.

## SYNTAX

```
Copy-KshTerm [-Identity] <Term> [-CopyChildren] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Copy-KshTerm` cmdlet copies a term to a new location. You can specify whether to include child terms in the copy operation.

## EXAMPLES

### Example 1
```powershell
PS C:\> Copy-KshTerm -Identity $term -CopyChildren
```

This example copies the specified term and its child terms to a new location.

## PARAMETERS

### -CopyChildren
Indicates whether to copy child terms.

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

### -Identity
Specifies the term to copy.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.Term
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.Term
## NOTES

## RELATED LINKS

