---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshSubscription

## SYNOPSIS
Creates a new subscription for a list.

## SYNTAX

```
Add-KshSubscription [-List] <List> [-ClientState <String>] -ExpirationDateTime <DateTime>
 -NotificationUrl <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshSubscription` cmdlet creates a new subscription for a list with the given parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshSubscription -List $list -ExpirationDateTime (Get-Date).AddMonths(3) -NotificationUrl "https://example.com/notifications"
```

This example creates a new subscription for the specified list that expires in 3 months and sends notifications to the specified URL.

## PARAMETERS

### -ClientState
Specifies the client state that will be sent with the notification.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExpirationDateTime
Specifies the expiration date and time for the subscription.

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -List
Specifies the list to which the subscription is added.

```yaml
Type: List
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NotificationUrl
Specifies the URL to which notifications will be sent.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
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

### Karamem0.SharePoint.PowerShell.Models.V1.List
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.Subscription
## NOTES

## RELATED LINKS

