---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshTenantDeletedPersonalSiteCollection

## SYNOPSIS
Retrieves one or more deleted personal site collections from the tenant.

## SYNTAX

### ParamSet1
```
Get-KshTenantDeletedPersonalSiteCollection [-SiteCollectionUrl] <Uri> [-NoEnumerate]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshTenantDeletedPersonalSiteCollection [-NoEnumerate] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshTenantDeletedPersonalSiteCollection` cmdlet retrieves one or more deleted personal site collections from the tenant based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshTenantDeletedPersonalSiteCollection -SiteCollectionUrl "https://contoso-my.sharepoint.com/personal/meganb_contoso_onmicrosoft_com"
```

This example retrieves a deleted personal site collection by URL.

### Example 2
```powershell
PS C:\> Get-KshTenantDeletedPersonalSiteCollection
```

This example retrieves all deleted personal site collections.

## PARAMETERS

### -NoEnumerate
Indicates that the cmdlet does not enumerate the collection.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SiteCollectionUrl
Specifies the URL of the personal site collection to retrieve.

```yaml
Type: Uri
Parameter Sets: ParamSet1
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

### Karamem0.SharePoint.PowerShell.Models.V1.TenantDeletedSiteCollection
## NOTES

## RELATED LINKS

