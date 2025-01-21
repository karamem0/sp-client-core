---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshTenantPersonalSite

## SYNOPSIS
Retrieves a personal site from the tenant.

## SYNTAX

### ParamSet1
```
Get-KshTenantPersonalSite [-User] <User> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshTenantPersonalSite [-UserId] <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshTenantPersonalSite` cmdlet retrieves a personal site from the tenant based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshTenantPersonalSite -User $user
```

This example retrieves a personal site by user.

### Example 2
```powershell
PS C:\> Get-KshTenantPersonalSite -UserId "user@example.com"
```

This example retrieves a personal site by user ID.

## PARAMETERS

### -User
Specifies the user object whose personal site is to be retrieved.

```yaml
Type: User
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserId
Specifies the user ID whose personal site is to be retrieved.

```yaml
Type: String
Parameter Sets: ParamSet2
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

### System.String
## NOTES

## RELATED LINKS

