---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshAppInstance

## SYNOPSIS
Retrieves one or more app instance from the current site.

## SYNTAX

### ParamSet1
```
Get-KshAppInstance [-Identity] <AppInstance> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshAppInstance [-AppInstanceId] <Guid> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Get-KshAppInstance [-AppProductId] <Guid> [-NoEnumerate] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet4
```
Get-KshAppInstance [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshAppInstance` cmdlet retrieves one or more app instances from the current site based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshAppInstance -Identity $appInstance
```

This example retrieves an app instance by identity.

### Example 2
```powershell
PS C:\> Get-KshAppInstance -AppInstanceId "12345678-1234-1234-1234-1234567890ab"
```

This example retrieves an app instance by app instance ID.

### Example 3
```powershell
PS C:\> Get-KshAppInstance -AppProductId "12345678-1234-1234-1234-1234567890ab"
```

This example retrieves an app instance by app product ID.

### Example 4
```powershell
PS C:\> Get-KshAppInstance
```

This example retrieves all app instances.

## PARAMETERS

### -AppInstanceId
Specifies the ID of the app instance.

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

### -AppProductId
Specifies the product ID of the app instance.

```yaml
Type: Guid
Parameter Sets: ParamSet3
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Identity
Specifies the app instance to retrieve.

```yaml
Type: AppInstance
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NoEnumerate
Indicates that the cmdlet does not enumerate the collection.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet3, ParamSet4
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.AppInstance
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.AppInstance
## NOTES

## RELATED LINKS

