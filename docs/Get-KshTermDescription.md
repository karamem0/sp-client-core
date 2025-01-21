---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshTermDescription

## SYNOPSIS
Retrieves the description of a term.

## SYNTAX

```
Get-KshTermDescription [-Identity] <Term> -Lcid <UInt32> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshTermDescription` cmdlet retrieves the description of a term for a given language code identifier (LCID).

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshTermDescription -Identity $term -Lcid 1033
```

This example retrieves the description of the specified term in English (LCID 1033).

## PARAMETERS

### -Identity
Specifies the term for which to retrieve the description.

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

### -Lcid
Specifies the language code identifier (LCID) for the term description.

```yaml
Type: UInt32
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.Term
## OUTPUTS

### System.String
## NOTES

## RELATED LINKS

