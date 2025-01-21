---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshTermStoreLanguage

## SYNOPSIS
Adds a language to the term store.

## SYNTAX

```
Add-KshTermStoreLanguage -Lcid <UInt32> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshTermStoreLanguage` cmdlet adds a language to the term store using the specified LCID (Locale Identifier).

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshTermStoreLanguage -Lcid 1033
```

This example adds the English language (LCID 1033) to the term store.

## PARAMETERS

### -Lcid
Specifies the LCID (Locale Identifier) of the language to add.

```yaml
Type: UInt32
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

