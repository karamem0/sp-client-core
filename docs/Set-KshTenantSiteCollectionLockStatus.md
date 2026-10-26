---
Module Name: SPClientCore
external help file: SPClientCore.dll-Help.xml
schema: 2.0.0
---

# Set-KshTenantSiteCollectionLockStatus

## SYNOPSIS
Set tenant site collection lock status.

## SYNTAX

### ParamSet1
```
Set-KshTenantSiteCollectionLockStatus [-Identity] <TenantSiteCollection> [-Lock] [-PassThru]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Set-KshTenantSiteCollectionLockStatus [-Identity] <TenantSiteCollection> [-Lock] [-NoWait]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Set-KshTenantSiteCollectionLockStatus [-Identity] <TenantSiteCollection> [-Unlock] [-PassThru]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet4
```
Set-KshTenantSiteCollectionLockStatus [-Identity] <TenantSiteCollection> [-Unlock] [-NoWait]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## PARAMETERS

### -Identity

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

### -Lock

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1, ParamSet2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet2, ParamSet4
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1, ParamSet3
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Unlock

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet3, ParamSet4
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction

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

