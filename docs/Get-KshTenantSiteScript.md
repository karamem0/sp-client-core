---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshTenantSiteScript

## SYNOPSIS
Retrieves one or more site scripts from the tenant.

## SYNTAX

### ParamSet1
```
Get-KshTenantSiteScript [-Identity] <TenantSiteScript> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet2
```
Get-KshTenantSiteScript [-SiteScriptId] <Guid> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Get-KshTenantSiteScript [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshTenantSiteScript` cmdlet retrieves one or more site scripts from the tenant based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshTenantSiteScript -Identity $siteScript
```

This example retrieves a site script by identity.

### Example 2
```powershell
PS C:\> Get-KshTenantSiteScript -SiteScriptId "12345678-1234-1234-1234-1234567890ab"
```

This example retrieves a site script by site script ID.

### Example 3
```powershell
PS C:\> Get-KshTenantSiteScript
```

This example retrieves all site scripts.

## PARAMETERS

### -Identity
Specifies the site script to retrieve.

```yaml
Type: TenantSiteScript
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NoEnumerate
Indicates that the cmdlet does not enumerate the collection.

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

### -SiteScriptId
Specifies the ID of the site script to retrieve.

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

### Karamem0.SharePoint.PowerShell.Models.V1.TenantSiteScript
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.TenantSiteScript
## NOTES

## RELATED LINKS

