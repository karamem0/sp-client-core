---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshCurrentConnection

## SYNOPSIS
Retrieves the current connection context.

## SYNTAX

```
Get-KshCurrentConnection [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshCurrentConnection` cmdlet retrieves the current connection context.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshCurrentConnection
```

This example retrieves the current connection context.

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

### Karamem0.SharePoint.PowerShell.Runtime.Services.ClientContext
Returns the `ClientContext` object that was processed.

## NOTES

## RELATED LINKS

