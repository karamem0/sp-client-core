---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshDocumentSetSharedColumn

## SYNOPSIS
Adds a shared column to a document set content type.

## SYNTAX

```
Add-KshDocumentSetSharedColumn [-ContentType] <ContentType> -Column <Column> [-PushChanges]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshDocumentSetSharedColumn` cmdlet adds a shared column to a document set content type.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshDocumentSetSharedColumn -ContentType $contentType -Column $column -PushChanges
```

This example adds a shared column to the specified document set content type and pushes the changes.

## PARAMETERS

### -Column
Specifies the column to add to the document set content type.

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
Specifies the document set content type to which the column will be added.

```yaml
Type: ContentType
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PushChanges
Indicates that the changes should be pushed to all items that use the content type.

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

### System.Void
## NOTES

## RELATED LINKS

