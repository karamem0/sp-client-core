---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshDocumentLibrary

## SYNOPSIS
Retrieves one or more document libraries from the current site.

## SYNTAX

### ParamSet1
```
Get-KshDocumentLibrary [-Default] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshDocumentLibrary [-IncludeMediaLibraries] [-IncludePageLibraries] [-NoEnumerate]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshDocumentLibrary` cmdlet retrieves one or more document libraries from the current site. This cmdlet can include media libraries and page libraries if needed.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshDocumentLibrary -Default
```

This example retrieves the default document library.

### Example 2
```powershell
PS C:\> Get-KshDocumentLibrary -IncludeMediaLibraries -IncludePageLibraries
```

This example retrieves all document libraries, including media and page libraries.

## PARAMETERS

### -Default
Specifies that only the default document library should be retrieved.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeMediaLibraries
Includes media libraries in the retrieval.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludePageLibraries
Includes page libraries in the retrieval.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoEnumerate
Prevents enumeration of the document libraries.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet2
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

### Karamem0.SharePoint.PowerShell.Models.V1.DocumentLibraryInfo
## NOTES

## RELATED LINKS

