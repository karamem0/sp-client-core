---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshTenantExternalUser

## SYNOPSIS
Retrieves one or more external users.

## SYNTAX

### ParamSet1
```
Get-KshTenantExternalUser [-SiteCollectionUrl] <String> [-Filter <String>] [-SortOrder <SortOrder>]
 [-NoEnumerate] [<CommonParameters>]
```

### ParamSet2
```
Get-KshTenantExternalUser [-Filter <String>] [-SortOrder <SortOrder>] [-NoEnumerate] [<CommonParameters>]
```

## DESCRIPTION
The Get-KshTenantExternalUser cmdlet retrieves external users of the tenant or the specified site collection. This cmdlet can be used only when connected to the SharePoint admin center.

## EXAMPLES

### Example 1
```powershell
PS C:\> KshTenantExternalUser -SiteCollectionUrl 'https://example.sharepoint.com/sites/japan'
```

Retrieves all users of the specified site collection.

### Example 2
```powershell
PS C:\> KshTenantExternalUser
```

Retrieves all users of the tenant.

## PARAMETERS

### -Filter
Specifies the filter that forward matches first name, last name, or email address.

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
If specified, suppresses to enumerate objects.

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
Specifies the site collection URL.

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
Specifies the sort order.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.ExternalUser

## NOTES

## RELATED LINKS
