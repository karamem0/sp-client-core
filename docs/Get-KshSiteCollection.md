---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshSiteCollection

## SYNOPSIS
Retrieves a site collection from the tenant.

## SYNTAX

### ParamSet1
```
Get-KshSiteCollection [-Identity] <SiteCollection> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshSiteCollection [-SiteCollectionUrl] <Uri> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshSiteCollection` cmdlet retrieves a site collection from the tenant based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshSiteCollection -Identity $siteCollection
```

This example retrieves a site collection by identity.

### Example 2
```powershell
PS C:\> Get-KshSiteCollection -SiteCollectionUrl "https://contoso.sharepoint.com/sites/site1"
```

This example retrieves a site collection by site collection URL.

## PARAMETERS

### -Identity
Specifies the site collection to retrieve.

```yaml
Type: SiteCollection
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
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

### Karamem0.SharePoint.PowerShell.Models.V1.SiteCollection
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.SiteCollection
## NOTES

## RELATED LINKS

