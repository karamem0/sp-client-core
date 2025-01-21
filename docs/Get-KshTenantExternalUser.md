---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshTenantExternalUser

## SYNOPSIS
Retrieves external users from the tenant.

## SYNTAX

### ParamSet1
```
Get-KshTenantExternalUser [-SiteCollectionUrl] <String> [-Filter <String>] [-SortOrder <SortOrder>]
 [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshTenantExternalUser [-Filter <String>] [-SortOrder <SortOrder>] [-NoEnumerate]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshTenantExternalUser` cmdlet retrieves external users from the tenant based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshTenantExternalUser -SiteCollectionUrl "https://contoso.sharepoint.com/sites/site1"
```

This example retrieves external users by site collection URL.

### Example 2
```powershell
PS C:\> Get-KshTenantExternalUser -Filter "meganb@contoso.com"
```

This example retrieves external users filtered by email address.

### Example 3
```powershell
PS C:\> Get-KshTenantExternalUser -SortOrder "Ascending"
```

This example retrieves all external users sorted in ascending order.

## PARAMETERS

### -Filter
Specifies a filter to limit the results.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoEnumerate
Indicates that the cmdlet does not enumerate the results.

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
Specifies the URL of the site collection from which to retrieve external users.

```yaml
Type: String
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SortOrder
Specifies the sort order of the results.

```yaml
Type: SortOrder
Parameter Sets: (All)
Aliases:
Accepted values: Ascending, Descending

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

### Karamem0.SharePoint.PowerShell.Models.V1.ExternalUser
## NOTES

## RELATED LINKS

