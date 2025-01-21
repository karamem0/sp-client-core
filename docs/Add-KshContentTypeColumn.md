---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshContentTypeColumn

## SYNOPSIS
Adds a new column to a content type.

## SYNTAX

```
Add-KshContentTypeColumn -ContentType <ContentType> -Column <Column> [-PushChanges]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshContentTypeColumn` cmdlet adds a column to a content type. This operation can optionally push changes to child content types.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshContentTypeColumn -ContentType $contentType -Column $column -PushChanges
```

This example adds a column to the specified content type and pushes the changes to child content types.

## PARAMETERS

### -Column
Specifies the column to add to the content type.

```yaml
Type: Column
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContentType
Specifies the content type to which the column will be added.

```yaml
Type: ContentType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PushChanges
Indicates whether to push changes to child content types.

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

### None
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.ContentTypeColumn
## NOTES

## RELATED LINKS

