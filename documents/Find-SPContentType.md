---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Find-SPContentType

## SYNOPSIS
Lists content types.

## SYNTAX

### Web (Default)
```
Find-SPContentType [-Includes <String[]>] [-OrderBy <String[]>] [-Top <Int32>] [-Skip <Int32>]
 [<CommonParameters>]
```

### List
```
Find-SPContentType [-List] <ListPipeBind> [-Includes <String[]>] [-OrderBy <String[]>] [-Top <Int32>]
 [-Skip <Int32>] [<CommonParameters>]
```

## DESCRIPTION
The Find-SPContentType cmdlet retrieves all content types.

## EXAMPLES

### Example 1
```
PS C:\> Find-SPContentType
```

Lists site content types.

### Example 2
```
PS C:\> Find-SPContentType -List 'Shared Documents'
```

Lists list content types.

## PARAMETERS

### -Includes
Indicates the property name collection to include in the result object.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -List
Indicates the list ID or title.

```yaml
Type: ListPipeBind
Parameter Sets: List
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OrderBy
Indicates the property name collection used for sorting.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skip
Indicates number which ignores the first N objects and then gets the remaining objects.

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

### -Top
Indicates number which selecting only the first N objects of the collection.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.Core.ContentType[]
## NOTES

## RELATED LINKS
