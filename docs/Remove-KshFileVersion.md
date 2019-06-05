---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Remove-KshFileVersion

## SYNOPSIS
Removes a file version.

## SYNTAX

### ParamSet1
```
Remove-KshFileVersion [-File] <File> [-FileVersion] <FileVersion> [<CommonParameters>]
```

### ParamSet2
```
Remove-KshFileVersion [-File] <File> [-FileVersion] <FileVersion> [-RecycleBin] [<CommonParameters>]
```

### ParamSet3
```
Remove-KshFileVersion [-File] <File> [-All] [<CommonParameters>]
```

## DESCRIPTION
The Remove-KshFileVersion cmdlet removes a file version from the file.

## EXAMPLES

### Example 1
```powershell
PS C:\> $file = Get-KshFile -FileUrl '/sites/japan/hr/Shared%20Documents/README.txt'
PS C:\> $fileVersion = Get-KshFileVersion -File $file -FileVersionId 1
PS C:\> Remove-KshFileVersion -File $file -FileVersion $fileVersion
```

Removes a file version.

### Example 2
```powershell
PS C:\> $file = Get-KshFile -FileUrl '/sites/japan/hr/Shared%20Documents/README.txt'
PS C:\> Remove-KshFileVersion -File $file -All
```

Removes all file versions.

### Example 3
```powershell
PS C:\> $file = Get-KshFile -FileUrl '/sites/japan/hr/Shared%20Documents/README.txt'
PS C:\> $fileVersion = Get-KshFileVersion -File $file -FileVersionId 1
PS C:\> Remove-KshFileVersion -File $file -FileVersion $fileVersion -RecycleBin
```

Moves a file version to the recycle bin.

## PARAMETERS

### -All
If specified, removes all file versions.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -File
Specifies the file.

```yaml
Type: File
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -FileVersion
Specifies the file version.

```yaml
Type: FileVersion
Parameter Sets: ParamSet1, ParamSet2
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecycleBin
If specified, moves the item to the recycle bin.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.Models.File

## OUTPUTS

### System.Void

## NOTES

## RELATED LINKS
