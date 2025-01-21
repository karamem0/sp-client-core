---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshTermSet

## SYNOPSIS
Adds a new term set to a term group.

## SYNTAX

```
Add-KshTermSet [-TermGroup] <TermGroup> [-Id <Guid>] -Lcid <UInt32> -Name <String>
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshTermSet` cmdlet adds a new term set to a term group.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshTermSet -TermGroup $termGroup -Lcid 1033 -Name "New Term Set"
```

This example adds a new term set named "New Term Set" to the specified term group with the locale ID 1033.

## PARAMETERS

### -Id
Specifies the unique identifier of the term set.

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
Specifies the locale ID for the term set.

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
Specifies the name of the term set.

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

### -TermGroup
Specifies the term group to which the term set is added.

```yaml
Type: TermGroup
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

### Karamem0.SharePoint.PowerShell.Models.V1.TermGroup
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.TermSet
## NOTES

## RELATED LINKS

