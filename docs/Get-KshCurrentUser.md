---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshCurrentUser

## SYNOPSIS
Retrieves the current user.

## SYNTAX

```
Get-KshCurrentUser [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshCurrentUser` cmdlet retrieves the current user.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshCurrentUser
```

This example retrieves the current user.

## PARAMETERS

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

### Karamem0.SharePoint.PowerShell.Models.V1.User
Returns the user object that was processed.

## NOTES

## RELATED LINKS

