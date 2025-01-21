---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshTerm

## SYNOPSIS
Retrieves a term from a term store.

## SYNTAX

### ParamSet1
```
Get-KshTerm [-Identity] <Term> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshTerm [-TermLabel] <TermLabel> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Get-KshTerm [-TermSet] <TermSet> [-TermId] <Guid> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet4
```
Get-KshTerm [-TermSet] <TermSet> [-TermName] <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet5
```
Get-KshTerm [-TermSet] <TermSet> [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet6
```
Get-KshTerm [-Term] <Term> [-TermId] <Guid> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet7
```
Get-KshTerm [-Term] <Term> [-TermName] <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet8
```
Get-KshTerm [-Term] <Term> [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshTerm` cmdlet retrieves a term from a term store based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshTerm -Identity $term
```

This example retrieves a term by identity.

### Example 2
```powershell
PS C:\> Get-KshTerm -TermLabel $termLabel
```

This example retrieves a term by term label.

### Example 3
```powershell
PS C:\> Get-KshTerm -TermSet $termSet -TermId $termId
```

This example retrieves a term by term set and term ID.

### Example 4
```powershell
PS C:\> Get-KshTerm -TermSet $termSet -TermName "Sales"
```

This example retrieves a term by term set and term name.

### Example 5
```powershell
PS C:\> Get-KshTerm -TermSet $termSet
```

This example retrieves terms in the specified term set.

### Example 6
```powershell
PS C:\> Get-KshTerm -Term $term -TermId $termId
```

This example retrieves a term by term and term ID.

### Example 7
```powershell
PS C:\> Get-KshTerm -Term $term -TermName "Sales"
```

This example retrieves a term by term and term name.

### Example 8
```powershell
PS C:\> Get-KshTerm -Term $term
```

This example retrieves terms in the specified term.

## PARAMETERS

### -Identity
Specifies the term to retrieve.

```yaml
Type: Term
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NoEnumerate
Indicates that the cmdlet does not enumerate the term set.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet5, ParamSet8
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Term
Specifies the term to retrieve.

```yaml
Type: Term
Parameter Sets: ParamSet6, ParamSet7, ParamSet8
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TermId
Specifies the ID of the term to retrieve.

```yaml
Type: Guid
Parameter Sets: ParamSet3, ParamSet6
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TermLabel
Specifies the label of the term to retrieve.

```yaml
Type: TermLabel
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -TermName
Specifies the name of the term to retrieve.

```yaml
Type: String
Parameter Sets: ParamSet4, ParamSet7
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TermSet
Specifies the term set that contains the term to retrieve.

```yaml
Type: TermSet
Parameter Sets: ParamSet3, ParamSet4, ParamSet5
Aliases:

Required: True
Position: 0
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
### Karamem0.SharePoint.PowerShell.Models.V1.TermLabel
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.Term
## NOTES

## RELATED LINKS

