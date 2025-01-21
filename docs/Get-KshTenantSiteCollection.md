---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshTenantSiteCollection

## SYNOPSIS
Retrieves one or more site collections from the tenant.

## SYNTAX

### ParamSet1
```
Get-KshTenantSiteCollection [-Identity] <TenantSiteCollection> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet2
```
Get-KshTenantSiteCollection [-SiteCollectionUrl] <Uri> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet3
```
Get-KshTenantSiteCollection [-GroupIdDefined] [-IncludePersonalSite] [-Template <String>] [-NoEnumerate]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshTenantSiteCollection` cmdlet retrieves one or more site collections from the tenant based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshTenantSiteCollection -Identity $siteCollection
```

This example retrieves a site collection by identity.

### Example 2
```powershell
PS C:\> Get-KshTenantSiteCollection -SiteCollectionUrl "https://contoso.sharepoint.com/sites/site1"
```

This example retrieves a site collection by site collection URL.

### Example 3
```powershell
PS C:\> Get-KshTenantSiteCollection -GroupIdDefined
```

This example retrieves site collections that have a group ID defined.

### Example 4
```powershell
PS C:\> Get-KshTenantSiteCollection -IncludePersonalSite
```

This example retrieves site collections that include personal sites.

### Example 5
```powershell
PS C:\> Get-KshTenantSiteCollection -Template "STS#0"
```

This example retrieves site collections by template.

## PARAMETERS

### -GroupIdDefined
Indicates whether the site collection has a group ID defined.

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

### -Identity
Specifies the site collection to retrieve.

```yaml
Type: TenantSiteCollection
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IncludePersonalSite
Indicates whether to include personal sites in the results.

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

### -NoEnumerate
Indicates whether to enumerate the results.

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
Specifies the URL of the site collection to retrieve.

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

### -Template
Specifies the template of the site collection to retrieve.

```yaml
Type: String
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

### Karamem0.SharePoint.PowerShell.Models.V1.TenantSiteCollection
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.TenantSiteCollection
## NOTES

## RELATED LINKS

