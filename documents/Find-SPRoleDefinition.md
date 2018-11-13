---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Find-SPRoleDefinition

## SYNOPSIS
Lists role definitions.

## SYNTAX

```
Find-SPRoleDefinition [-Includes <String[]>] [-OrderBy <String[]>] [-Top <Int32>] [-Skip <Int32>]
 [-Filter <String>] [<CommonParameters>]
```

## DESCRIPTION
The Find-SPRoleAssignment cmdlet retrieves all role definitions.

## EXAMPLES

### Example 1
```
PS C:\> Find-SPRoleDefinition
```

Lists role definitions.

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

### -Filter
Indicates a query string to select which objects to return.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.Core.RoleDefinition[]
## NOTES

## RELATED LINKS
