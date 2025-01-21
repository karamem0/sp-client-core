---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshTenantOrganizationNewsSite

## SYNOPSIS
Adds a organization news site to the tenant.

## SYNTAX

```
Add-KshTenantOrganizationNewsSite -Url <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshTenantOrganizationNewsSite` cmdlet adds a site as a organization news sites for the tenant.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshTenantOrganizationNewsSite -Url "https://contoso.sharepoint.com/sites/news"
```

This example adds the site as a organization news sites for the tenant.

## PARAMETERS

### -Url
Specifies the URL of the site to add to the organization news sites.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
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

### System.Void
## NOTES

## RELATED LINKS

