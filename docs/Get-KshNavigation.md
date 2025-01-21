---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshNavigation

## SYNOPSIS
Retrieves the navigation settings for the current site.

## SYNTAX

```
Get-KshNavigation [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshNavigation` cmdlet retrieves the navigation settings for the current site.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshNavigation
```

This example retrieves the navigation settings.

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

### Karamem0.SharePoint.PowerShell.Models.V1.Navigation
Returns the navigation object that was processed.

## NOTES

## RELATED LINKS

