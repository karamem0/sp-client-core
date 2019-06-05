---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# New-KshFile

## SYNOPSIS
Creates a new file.

## SYNTAX

```
New-KshFile -Folder <Folder> -Content <Byte[]> [-Overwrite <Boolean>] -FileName <String> [<CommonParameters>]
```

## DESCRIPTION
The New-KshFolder cmdlet adds a new file to the specified folder. Maximum file size is 2MB.

## EXAMPLES

### Example 1
```powershell
PS C:\> $content = [System.Text.Encoding]::UTF8.GetBytes('Contact: admin@example.onmicrosoft.com')
PS C:\> $file = New-KshFile -Folder '/sites/japan/hr/Shared%20Documents' -Content $content -FileName 'README.txt'
```

Creates a new file.

## PARAMETERS

### -Content
Specifies the contents.

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
Specifies the file name.

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
Specifies the folder.

```yaml
Type: Folder
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Overwrite
If specified, overwrites the existing file.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.File

## NOTES

## RELATED LINKS
