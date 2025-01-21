---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshTenantHomeSite

## SYNOPSIS
Retrieves the home site of the tenant.

## SYNTAX

```
Get-KshTenantHomeSite [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshTenantHomeSite` cmdlet retrieves the home site of the tenant.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshTenantHomeSite
```

This example retrieves the home site of the tenant.

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

### System.String
The home site URL of the tenant.

## NOTES

## RELATED LINKS

