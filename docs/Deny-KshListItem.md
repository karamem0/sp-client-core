---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Deny-KshListItem

## SYNOPSIS
Rejects a list item.

## SYNTAX

```
Deny-KshListItem [-Identity] <ListItem> [-Comment <String>] [-PassThru] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
The `Deny-KshListItem` cmdlet rejects a draft of a list item with an optional comment.

## EXAMPLES

### Example 1
```powershell
PS C:\> Deny-KshListItem -Identity $listItem -Comment "Rejected"
```

This example rejects the specified list item with the comment "Rejected".

## PARAMETERS

### -Comment
Specifies a comment to associate with the approval.

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

### -Identity
Specifies the list item to reject.

```yaml
Type: ListItem
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
Returns the folder object that was processed.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
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

### Karamem0.SharePoint.PowerShell.Models.V1.ListItem
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.ListItem
## NOTES

## RELATED LINKS

