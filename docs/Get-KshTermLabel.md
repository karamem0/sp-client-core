---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshTermLabel

## SYNOPSIS
Retrieves one or more term labels from the term store.

## SYNTAX

### ParamSet1
```
Get-KshTermLabel [-Identity] <TermLabel> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshTermLabel [-Term] <Term> [-LabelName] <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Get-KshTermLabel [-Term] <Term> [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshTermLabel` cmdlet retrieves one or more term labels from the term store based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshTermLabel -Identity $termLabel
```

This example retrieves the term label by identity.

### Example 2
```powershell
PS C:\> Get-KshTermLabel -Term $term -LabelName "LabelName"
```

This example retrieves the term label by term and label name.

### Example 3
```powershell
PS C:\> Get-KshTermLabel -Term $term
```

This example retrieves the term labels for the specified term.

## PARAMETERS

### -Identity
Specifies the term label to retrieve.

```yaml
Type: TermLabel
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LabelName
Specifies the name of the label to retrieve.

```yaml
Type: String
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoEnumerate
Indicates that the cmdlet does not enumerate the term labels.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet3
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Term
Specifies the term from which to retrieve the label.

```yaml
Type: Term
Parameter Sets: ParamSet2, ParamSet3
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

### Karamem0.SharePoint.PowerShell.Models.V1.TermLabel
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.TermLabel
## NOTES

## RELATED LINKS

