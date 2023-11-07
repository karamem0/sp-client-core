---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Remove-KshTenantSiteDesign

## SYNOPSIS
Removes a site design.

## SYNTAX

```
Remove-KshTenantSiteDesign [-Identity] <TenantSiteDesign> [<CommonParameters>]
```

## DESCRIPTION
The Remove-KshTenantSiteDesign cmdlet removes a list design. This cmdlet can be used only when connected to the SharePoint admin center.

## EXAMPLES

### Example 1
```powershell
PS C:\> Remove-KshTenantSiteDesign -Identity (Get-KshTenantSiteDesign -SiteScriptId "fabdb184-cdc3-495d-a961-523a824045f9")
```

Removes a site design.

## PARAMETERS

### -Identity
Specifies the site design.

```yaml
Type: TenantSiteDesign
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

### Karamem0.SharePoint.PowerShell.Models.V1.TenantSiteDesign

## OUTPUTS

### None

## NOTES

## RELATED LINKS
