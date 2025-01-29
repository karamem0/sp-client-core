---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Lock-KshTenantSiteCollection

## SYNOPSIS

Locks a site collection.

## SYNTAX

### ParamSet1

```
Lock-KshTenantSiteCollection [-Identity] <TenantSiteCollection> [-PassThru]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2

```
Lock-KshTenantSiteCollection [-Identity] <TenantSiteCollection> [-NoWait] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION

The `Lock-KshTenantSiteCollection` cmdlet locks a site collection to prevent users from accessing it.

## EXAMPLES

### Example 1

```powershell
PS C:\> Lock-KshTenantSiteCollection -Identity "https://tenant.sharepoint.com/sites/site1"
```

This example locks the specified site collection.

## PARAMETERS

### -Identity

Specifies the tenant site collection to lock.

```yaml
Type: TenantSiteCollection
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NoWait

Indicates that the cmdlet returns immediately without waiting for the operation to complete.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru

Returns the tenant site collection object that was processed.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1
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

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about\_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.TenantSiteCollection

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.TenantSiteCollection

## NOTES

## RELATED LINKS
