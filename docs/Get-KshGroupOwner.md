---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshGroupOwner

## SYNOPSIS
Retrieves the a group owner from a group.

## SYNTAX

```
Get-KshGroupOwner [-Group] <Group> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshGroupOwner` cmdlet retrieves the group owner from a group.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshGroupOwner -Group $group
```

This example retrieves the group owner.

## PARAMETERS

### -Group
Specifies the group for which to retrieve the owner.

```yaml
Type: Group
Parameter Sets: (All)
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

### None
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.Principal
Returns the Principal object that represents the owner of the group.

## NOTES

## RELATED LINKS

