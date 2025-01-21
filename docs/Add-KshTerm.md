---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshTerm

## SYNOPSIS
Adds a new term to a term set or term.

## SYNTAX

### ParamSet1
```
Add-KshTerm [-TermSet] <TermSet> [-Id <Guid>] -Lcid <UInt32> -Name <String>
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Add-KshTerm [-Term] <Term> [-Id <Guid>] -Lcid <UInt32> -Name <String> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshTerm` cmdlet adds a new term to a term set or term.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshTerm -TermSet $termSet -Lcid 1033 -Name "Human Resources"
```

This example adds a new term named "Human Resources" to the specified term set.

### Example 2
```powershell
PS C:\> Add-KshTerm -Term $term -Lcid 1033 -Name "Accounts Payable"
```

This example adds a new term named "Accounts Payable" to the specified term.

## PARAMETERS

### -Id
Specifies the unique identifier of the term.

```yaml
Type: Guid
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Lcid
Specifies the language code identifier (LCID) for the term.

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
Specifies the name of the term.

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
Specifies the parent term to which the new term will be added.

```yaml
Type: Term
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -TermSet
Specifies the term set to which the new term will be added.

```yaml
Type: TermSet
Parameter Sets: ParamSet1
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

### Karamem0.SharePoint.PowerShell.Models.V1.TermSet
### Karamem0.SharePoint.PowerShell.Models.V1.Term
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.Term
## NOTES

## RELATED LINKS

