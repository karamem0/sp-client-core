---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshTenantSiteScript

## SYNOPSIS
Retrieves one or more site scripts.

## SYNTAX

### ParamSet1
```
Get-KshTenantSiteScript [-Identity] <TenantSiteScript> [<CommonParameters>]
```

### ParamSet2
```
Get-KshTenantSiteScript [-SiteScriptId] <Guid> [<CommonParameters>]
```

### ParamSet3
```
Get-KshTenantSiteScript [-NoEnumerate] [<CommonParameters>]
```

## DESCRIPTION
The Get-KshTenantSiteScript cmdlet retrieves site scripts. This cmdlet can be used only when connected to the SharePoint admin center.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshTenantSiteScript -SiteScriptId "c14cea4e-2b08-4c9f-bd51-8da187decdb5"
```

Retrieves a site script by site script ID.

## PARAMETERS

### -Identity
Specifies the site script.

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

### -SiteScriptId
Specifies the site script ID.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.TenantSiteScript
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.TenantSiteScript
## NOTES

## RELATED LINKS
