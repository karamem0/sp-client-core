---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshFileVersion

## SYNOPSIS
Retrieves a file version from a file.

## SYNTAX

### ParamSet1
```
Get-KshFileVersion [-Identity] <FileVersion> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshFileVersion [-File] <File> [-FileVersionId] <Int32> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet3
```
Get-KshFileVersion [-File] <File> [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshFileVersion` cmdlet retrieves a file version from a file based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshFileVersion -Identity $fileVersion
```

This example retrieves a file version by identity.

### Example 2
```powershell
PS C:\> Get-KshFileVersion -File $file -FileVersionId 1
```

This example retrieves a file version by file version ID.

### Example 3
```powershell
PS C:\> Get-KshFileVersion -File $file
```

This example retrieves all file versions.

## PARAMETERS

### -File
Specifies the file for which to retrieve the version.

```yaml
Type: File
Parameter Sets: ParamSet2, ParamSet3
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FileVersionId
Specifies the ID of the file version to retrieve.

```yaml
Type: Int32
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Identity
Specifies the file version to retrieve.

```yaml
Type: FileVersion
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NoEnumerate
Indicates that the cmdlet does not enumerate the collection.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet3
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

### Karamem0.SharePoint.PowerShell.Models.V1.FileVersion
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.FileVersion
## NOTES

## RELATED LINKS

