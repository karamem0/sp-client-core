---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# New-KshContentTypeId

## SYNOPSIS

Creates a new content type ID.

## SYNTAX

```
New-KshContentTypeId [-StringValue] <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION

The `New-KshContentTypeId` cmdlet creates a new content type ID.

## EXAMPLES

### Example 1

```powershell
PS C:\> New-KshContentTypeId -StringValue "0x0101009189AB5D3D2647B580F011DA2F356FB2"
```

This example creates a new content type ID with the specified string value.

## PARAMETERS

### -StringValue

Specifies the string value for the new content type ID.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
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

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about\_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.ContentTypeId

## NOTES

## RELATED LINKS
