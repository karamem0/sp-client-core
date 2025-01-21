---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshTermLabel

## SYNOPSIS
Adds a new label to a term.

## SYNTAX

```
Add-KshTermLabel [-Term] <Term> -Name <String> -Lcid <UInt32> -IsDefault <Boolean>
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshTermLabel` cmdlet adds a new label to a term with the name, language code identifier (LCID), and default status.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshTermLabel -Term $term -Name "NewLabel" -Lcid 1033 -IsDefault $true
```

This example adds a new default label "NewLabel" with LCID 1033 to the specified term.

## PARAMETERS

### -IsDefault
Specifies whether the label is the default label for the term.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Lcid
Specifies the language code identifier (LCID) for the label.

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

### -Name
Specifies the name of the label.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Term
Specifies the term to which the label is added.

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

### Karamem0.SharePoint.PowerShell.Models.V1.TermLabel
## NOTES

## RELATED LINKS

