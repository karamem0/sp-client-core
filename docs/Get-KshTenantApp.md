---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshTenantApp

## SYNOPSIS
Retrieves one or more tenant apps.

## SYNTAX

### ParamSet1
```
Get-KshTenantApp [-Identity] <App> [<CommonParameters>]
```

### ParamSet2
```
Get-KshTenantApp [-AppId] <Guid> [<CommonParameters>]
```

### ParamSet3
```
Get-KshTenantApp [-NoEnumerate] [<CommonParameters>]
```

## DESCRIPTION
The Get-KshTenantApp cmdlet retrieves apps in the tenant app catalog.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshTenantApp -AppId 'fdee2390-48bf-409e-956a-20f11a0add59'
```

Retrieves an app by app ID.

### Example 2
```powershell
PS C:\> Get-KshTenantApp
```

Retrieves all apps.

## PARAMETERS

### -AppId
Specifies the app ID.

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

### -Identity
Specifies the app.

```yaml
Type: App
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NoEnumerate
If specified, suppresses to enumerate objects.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet3
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.App

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.App

## NOTES

## RELATED LINKS
