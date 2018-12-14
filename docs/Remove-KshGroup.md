---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Remove-KshGroup

## SYNOPSIS
Removes a group.

## SYNTAX

```
Remove-KshGroup [-Identity] <Group> [<CommonParameters>]
```

## DESCRIPTION
The Remove-KshGroup cmdlet removes a group from the current site.

## EXAMPLES

### Example 1
```powershell
PS C:\> $group = Get-KshGroup -GroupName 'Blog Owners'
PS C:\> Remove-KshGroup -Identity $group
```

Removes a group.

## PARAMETERS

### -Identity
Specifies the group.

```yaml
Type: Group
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.Models.Group

## OUTPUTS

### System.Void

## NOTES

## RELATED LINKS
