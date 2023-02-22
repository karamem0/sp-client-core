---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Remove-KshTenantListDesign

## SYNOPSIS
Removes a list design.

## SYNTAX

```
Remove-KshTenantListDesign [-Identity] <TenantListDesign> [<CommonParameters>]
```

## DESCRIPTION
The Remove-KshTenantListDesign cmdlet removes a list design. This cmdlet can be used only when connected to the SharePoint admin center.

## EXAMPLES

### Example 1
```powershell
PS C:\> Remove-KshTenantListDesign -Identity (Get-KshTenantListDesign -SiteScriptId "df3a2598-5f30-4bdc-8625-cf6d7c5db6b9")
```

Removes a list design.

## PARAMETERS

### -Identity
Specifies the list design.

```yaml
Type: TenantListDesign
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

### Karamem0.SharePoint.PowerShell.Models.V1.TenantListDesign

## OUTPUTS

### None
## NOTES

## RELATED LINKS
