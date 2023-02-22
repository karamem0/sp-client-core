---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Remove-KshTenantSiteScript

## SYNOPSIS
Removes a site script.

## SYNTAX

```
Remove-KshTenantSiteScript [-Identity] <TenantSiteScript> [<CommonParameters>]
```

## DESCRIPTION
The Remove-KshTenantSiteScript cmdlet removes a site script. This cmdlet can be used only when connected to the SharePoint admin center.

## EXAMPLES

### Example 1
```powershell
PS C:\> Remove-KshTenantSiteScript -Identity (Get-KshTenantSiteScript -SiteScriptId "9595dd35-ca86-499b-aa22-06b73a4b17aa")
```

Removes a site script.

## PARAMETERS

### -Identity
Specifies the site script.

```yaml
Type: TenantSiteScript
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.TenantSiteScript

## OUTPUTS

### None

## NOTES

## RELATED LINKS
