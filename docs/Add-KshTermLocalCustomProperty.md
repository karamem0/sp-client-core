---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshTermLocalCustomProperty

## SYNOPSIS
Adds a custom property to a term.

## SYNTAX

```
Add-KshTermLocalCustomProperty [-Term] <Term> -Name <String> -Value <String>
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshTermLocalCustomProperty` cmdlet adds a custom property to a term.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshTermLocalCustomProperty -Term $term -Name "SortOrder" -Value "1"
```

This example adds a custom property named "SortOrder" with the value "1" to the specified term.

## PARAMETERS

### -Name
Specifies the name of the custom property to add.

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

### -Term
Specifies the term to which the custom property is added.

```yaml
Type: Term
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Value
Specifies the value of the custom property.

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

### None
## OUTPUTS

### System.Void
## NOTES

## RELATED LINKS

