---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshDocumentSetWelcomePageColumn

## SYNOPSIS
Adds a column to the welcome page of a document set.

## SYNTAX

```
Add-KshDocumentSetWelcomePageColumn [-ContentType] <ContentType> -Column <Column> [-PushChanges]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshDocumentSetWelcomePageColumn` cmdlet adds a specified column to the welcome page of a document set.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshDocumentSetWelcomePageColumn -ContentType $contentType -Column $column -PushChanges
```

This example adds the specified column to the welcome page of the document set and pushes the changes.

## PARAMETERS

### -Column
Specifies the column to add to the welcome page.

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
Specifies the content type of the document set.

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
Indicates that the changes should be pushed immediately.

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

