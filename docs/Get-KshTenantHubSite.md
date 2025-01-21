---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshTenantHubSite

## SYNOPSIS
Retrieves one or more hub sites from the tenant.

## SYNTAX

### ParamSet1
```
Get-KshTenantHubSite [-HubSiteId] <Guid> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshTenantHubSite [-HubSiteUrl] <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Get-KshTenantHubSite [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshTenantHubSite` cmdletone or more hub sites from the tenant based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshTenantHubSite -HubSiteId "12345678-1234-1234-1234-1234567890ab"
```

This example retrieves a hub site by hub site ID.

### Example 2
```powershell
PS C:\> Get-KshTenantHubSite -HubSiteUrl "https://contoso.sharepoint.com/sites/HubSite"
```

This example retrieves a hub site by hub site URL.

### Example 3
```powershell
PS C:\> Get-KshTenantHubSite
```

This example retrieves all hub sites.

## PARAMETERS

### -HubSiteId
Specifies the ID of the hub site to retrieve.

```yaml
Type: Guid
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HubSiteUrl
Specifies the URL of the hub site to retrieve.

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

### -NoEnumerate
Indicates that the cmdlet does not enumerate the hub sites.

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

### Karamem0.SharePoint.PowerShell.Models.V1.HubSite
## NOTES

## RELATED LINKS

