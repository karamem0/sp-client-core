---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshTermSet

## SYNOPSIS
Retrieves one or more term sets from the term store.

## SYNTAX

### ParamSet1
```
Get-KshTermSet [-Identity] <TermSet> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshTermSet [-TermGroup] <TermGroup> [-TermSetId] <Guid> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet3
```
Get-KshTermSet [-TermGroup] <TermGroup> [-TermSetName] <String> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet4
```
Get-KshTermSet [-TermGroup] <TermGroup> [-NoEnumerate] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshTermSet` cmdlet retrieves a term set from a term store based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshTermSet -Identity $termSet
```

This example retrieves a term set by identity.

### Example 2
```powershell
PS C:\> Get-KshTermSet -TermGroup $termGroup -TermSetId $termSetId
```

This example retrieves a term set by term group and term set ID.

### Example 3
```powershell
PS C:\> Get-KshTermSet -TermGroup $termGroup -TermSetName "TermSetName"
```

This example retrieves a term set by term group and term set name.

### Example 4
```powershell
PS C:\> Get-KshTermSet -TermGroup $termGroup
```

This example retrieves all term sets in a term group.

## PARAMETERS

### -Identity
Specifies the term set to retrieve.

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

### -NoEnumerate
Indicates that the cmdlet does not enumerate the term set.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet4
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TermGroup
Specifies the term group that contains the term set.

```yaml
Type: TermGroup
Parameter Sets: ParamSet2, ParamSet3, ParamSet4
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TermSetId
Specifies the ID of the term set to retrieve.

```yaml
Type: Guid
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TermSetName
Specifies the name of the term set to retrieve.

```yaml
Type: String
Parameter Sets: ParamSet3
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.TermSet
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.TermSet
## NOTES

## RELATED LINKS

