---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshFile

## SYNOPSIS
Adds a new file to a folder.

## SYNTAX

```
Add-KshFile [-Folder] <Folder> -Content <Byte[]> -FileName <String> [-Overwrite <Boolean>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshFile` cmdlet adds a file to a folder with the given content and file name. Optionally, it can overwrite an existing file and show progress.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshFile -Folder $folder -Content $content -FileName "example.txt" -Overwrite $true
```

This example adds a file named "example.txt" to the specified folder with the given content and overwrites any existing file with the same name.

## PARAMETERS

### -Content
Specifies the content of the file as a byte array.

```yaml
Type: Byte[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FileName
Specifies the name of the file to be added.

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

### -Folder
Specifies the folder where the file will be added.

```yaml
Type: Folder
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Overwrite
Indicates whether to overwrite an existing file with the same name.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
Specifies the action to take when displaying progress.

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

### Karamem0.SharePoint.PowerShell.Models.V1.Folder
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.File
## NOTES

## RELATED LINKS

