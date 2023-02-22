---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshTenantListDesign

## SYNOPSIS
Retrieves one or more list designs.

## SYNTAX

### ParamSet1
```
Get-KshTenantListDesign [-Identity] <TenantListDesign> [<CommonParameters>]
```

### ParamSet2
```
Get-KshTenantListDesign [-ListDesignId] <Guid> [<CommonParameters>]
```

### ParamSet3
```
Get-KshTenantListDesign [-NoEnumerate] [<CommonParameters>]
```

## DESCRIPTION
The Get-KshTenantListDesign cmdlet retrieves list designs. This cmdlet can be used only when connected to the SharePoint admin center.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshTenantListDesign -ListDesignId "df3a2598-5f30-4bdc-8625-cf6d7c5db6b9"
```

Retrieves a list design by list design ID.

### Example 2
```powershell
PS C:\> Get-KshTenantListDesign
```

Retrieves all list designs.

## PARAMETERS

### -Identity
Specifies the list design.

```yaml
Type: TenantListDesign
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ListDesignId
Specifies the list design ID.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.TenantListDesign
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.TenantListDesign
## NOTES

## RELATED LINKS
