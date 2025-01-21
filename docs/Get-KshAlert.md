---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshAlert

## SYNOPSIS
Retrieves one or more alerts from the current site.

## SYNTAX

### ParamSet1
```
Get-KshAlert [-Identity] <Alert> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshAlert [-AlertId] <Guid> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Get-KshAlert [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshAlert` cmdlet retrieves one or more alerts from the current site based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshAlert -Identity $alert
```

This example retrieves an alert by identity.

### Example 2
```powershell
PS C:\> Get-KshAlert -AlertId "12345678-1234-1234-1234-1234567890ab"
```

This example retrieves an alert by alert ID.

### Example 3
```powershell
PS C:\> Get-KshAlert
```

This example retrieves all alerts.

## PARAMETERS

### -AlertId
Specifies the ID of the alert to retrieve.

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

### -Identity
Specifies the alert to retrieve.

```yaml
Type: Alert
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
Parameter Sets: ParamSet3
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

### Karamem0.SharePoint.PowerShell.Models.V1.Alert
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.Alert
## NOTES

## RELATED LINKS

