---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshSubscription

## SYNOPSIS
Retrieves one or more subscriptions from a list.

## SYNTAX

### ParamSet1
```
Get-KshSubscription [-Identity] <Subscription> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshSubscription [-List] <List> [-SubscriptionId] <Guid> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet3
```
Get-KshSubscription [-List] <List> [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshSubscription` cmdlet retrieves one or more subscriptions from a list based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshSubscription -Identity $subscription
```

This example retrieves a subscription by identity.

### Example 2
```powershell
PS C:\> Get-KshSubscription -List $list -SubscriptionId $subscriptionId
```

This example retrieves a subscription by subscription ID.

### Example 3
```powershell
PS C:\> Get-KshSubscription -List $list
```

This example retrieves all subscriptions.

## PARAMETERS

### -Identity
Specifies the subscription to retrieve.

```yaml
Type: Subscription
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -List
Specifies the list that contains the subscription.

```yaml
Type: List
Parameter Sets: ParamSet2, ParamSet3
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoEnumerate
Indicates that the cmdlet does not enumerate the subscription.

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

### -SubscriptionId
Specifies the ID of the subscription.

```yaml
Type: Guid
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 1
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

### Karamem0.SharePoint.PowerShell.Models.V1.Subscription
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.Subscription
## NOTES

## RELATED LINKS

