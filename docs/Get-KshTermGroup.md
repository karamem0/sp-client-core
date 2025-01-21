---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshTermGroup

## SYNOPSIS
Retrieves one or more term groups from a term store.

## SYNTAX

### ParamSet1
```
Get-KshTermGroup [-Identity] <TermGroup> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshTermGroup [-TermGroupId] <Guid> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Get-KshTermGroup [-TermGroupName] <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet4
```
Get-KshTermGroup [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshTermGroup` cmdlet retrieves a term group from a term store based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshTermGroup -Identity $termGroup
```

This example retrieves a term group by identity.

### Example 2
```powershell
PS C:\> Get-KshTermGroup -TermGroupId "12345678-1234-1234-1234-1234567890ab"
```

This example retrieves a term group by GUID.

### Example 3
```powershell
PS C:\> Get-KshTermGroup -TermGroupName "Organization"
```

This example retrieves a term group by name.

### Example 4
```powershell
PS C:\> Get-KshTermGroup
```

This example retrieves all term groups.

## PARAMETERS

### -Identity
Specifies the term group to retrieve.

```yaml
Type: TermGroup
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NoEnumerate
Indicates that the cmdlet does not enumerate the term groups.

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

### -TermGroupId
Specifies the term group by its GUID.

```yaml
Type: Guid
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TermGroupName
Specifies the term group by its name.

```yaml
Type: String
Parameter Sets: ParamSet3
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
Specifies the action preference for progress.

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

### Karamem0.SharePoint.PowerShell.Models.V1.TermGroup
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.TermGroup
## NOTES

## RELATED LINKS

