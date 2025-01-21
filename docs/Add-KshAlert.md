---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshAlert

## SYNOPSIS
Creates a new alert for a user on a list or list item.

## SYNTAX

```
Add-KshAlert [-AlertFrequency <AlertFrequency>] [-AlertTemplateName <String>] [-AlertTime <DateTime>]
 [-AlertType <AlertType>] [-AlwaysNotify <Boolean>] [-DeliveryChannels <AlertDeliveryChannel>]
 [-EventType <AlertEventType>] [-EventTypeBitmask <Int32>] [-Filter <String>] -List <List>
 [-ListItem <ListItem>]
 [-Properties <System.Collections.Generic.IReadOnlyDictionary`2[System.String,System.String]>]
 [-Status <AlertStatus>] [-Title <String>] -User <User> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshAlert` cmdlet creates a new alert for a user on a specified list or list item. Alerts notify users of changes to list items or documents.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshAlert -List $list -User $user -Title "New Alert" -AlertFrequency "Daily" -DeliveryChannels "Email"
```

This example creates a daily email alert for the specified user on the specified list with the title "New Alert".

## PARAMETERS

### -AlertFrequency
Specifies how frequently the alert is sent.

```yaml
Type: AlertFrequency
Parameter Sets: (All)
Aliases:
Accepted values: Immediate, Daily, Weekly

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AlertTemplateName
Specifies the name of the alert template to use.

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

### -AlertTime
Specifies the time of day the alert is sent.

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AlertType
Specifies the type of alert.

```yaml
Type: AlertType
Parameter Sets: (All)
Aliases:
Accepted values: List, ListItem, Custom

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AlwaysNotify
Indicates whether the user should always be notified.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeliveryChannels
Specifies the delivery channels for the alert.

```yaml
Type: AlertDeliveryChannel
Parameter Sets: (All)
Aliases:
Accepted values: Email, Sms

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventType
Specifies the type of event that triggers the alert.

```yaml
Type: AlertEventType
Parameter Sets: (All)
Aliases:
Accepted values: AddObject, ModifyObject, DeleteObject, Discussion, All

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventTypeBitmask
Specifies a bitmask value for the event type.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
Specifies a filter for the alert.

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

### -List
Specifies the list for the alert.

```yaml
Type: List
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ListItem
Specifies the list item for the alert.

```yaml
Type: ListItem
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Properties
Specifies additional properties for the alert.

```yaml
Type: System.Collections.Generic.IReadOnlyDictionary`2[System.String,System.String]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Status
Specifies the status of the alert.

```yaml
Type: AlertStatus
Parameter Sets: (All)
Aliases:
Accepted values: On, Off, Error

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Title
Specifies the title of the alert.

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

### -User
Specifies the user for the alert.

```yaml
Type: User
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

### None
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.Alert
## NOTES

## RELATED LINKS

