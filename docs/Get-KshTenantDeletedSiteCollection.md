---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshTenantDeletedSiteCollection

## SYNOPSIS
Retrieves one or more deleted site collections from the tenant.

## SYNTAX

### ParamSet1
```
Get-KshTenantDeletedSiteCollection [-Identity] <TenantDeletedSiteCollection>
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshTenantDeletedSiteCollection [-SiteCollectionUrl] <Uri> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet3
```
Get-KshTenantDeletedSiteCollection [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshTenantDeletedSiteCollection` cmdlet retrieves one or more deleted site collections from the tenant based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshTenantDeletedSiteCollection -Identity $deletedSiteCollection
```

This example retrieves a deleted site collection by identity.

### Example 2
```powershell
PS C:\> Get-KshTenantDeletedSiteCollection -SiteCollectionUrl "https://contoso.sharepoint.com/sites/deletedSite"
```

This example retrieves a deleted site collection by URL.

### Example 3
```powershell
PS C:\> Get-KshTenantDeletedSiteCollection
```

This example retrieves all deleted site collections.

## PARAMETERS

### -Identity
Specifies the deleted site collection to retrieve.

```yaml
Type: TenantDeletedSiteCollection
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NoEnumerate
Indicates that the cmdlet should not enumerate the collection.

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

### -SiteCollectionUrl
Specifies the URL of the deleted site collection to retrieve.

```yaml
Type: Uri
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

### Karamem0.SharePoint.PowerShell.Models.V1.TenantDeletedSiteCollection
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.TenantDeletedSiteCollection
## NOTES

## RELATED LINKS

