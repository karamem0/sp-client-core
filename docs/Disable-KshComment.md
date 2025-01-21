---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Disable-KshComment

## SYNOPSIS
Disables a comment on a list item.

## SYNTAX

```
Disable-KshComment [-Identity] <ListItem> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Disable-KshComment` cmdlet disables a comment on a list item.

## EXAMPLES

### Example 1
```powershell
PS C:\> Disable-KshComment -Identity $listItem
```

This example disables a comment on the specified list item.

## PARAMETERS

### -Identity
Specifies the list item that contains the comment to disable.

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

### System.Void
## NOTES

## RELATED LINKS

