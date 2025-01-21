---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshTenantListDesign

## SYNOPSIS
Retrieves one or more list designs from the tenant.

## SYNTAX

### ParamSet1
```
Get-KshTenantListDesign [-Identity] <TenantListDesign> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet2
```
Get-KshTenantListDesign [-ListDesignId] <Guid> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Get-KshTenantListDesign [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshTenantListDesign` cmdlet retrieves one or more list designs from the tenant based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshTenantListDesign -Identity $listDesign
```

This example retrieves a tenant list design by identity.

### Example 2
```powershell
PS C:\> Get-KshTenantListDesign -ListDesignId "00000000-0000-0000-0000-000000000000"
```

This example retrieves a list design by its GUID.

### Example 3
```powershell
PS C:\> Get-KshTenantListDesign
```

This example retrieves all list designs.

## PARAMETERS

### -Identity
Specifies the list design to retrieve.

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
Specifies the GUID of the list design.

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
Indicates that the cmdlet does not enumerate the list design.

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

### -ProgressAction
Specifies the action preference for progress.

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

### Karamem0.SharePoint.PowerShell.Models.V1.TenantListDesign
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.TenantListDesign
## NOTES

## RELATED LINKS

