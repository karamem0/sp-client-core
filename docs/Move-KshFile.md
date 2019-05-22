---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Move-KshFile

## SYNOPSIS
Moves a file.

## SYNTAX

```
Move-KshFile [-Identity] <File> [-Url] <Uri> [-MoveOperation <MoveOperations>] [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
The Move-KshFile cmdlet moves a file to the specified URL.

## EXAMPLES

### Example 1
```powershell
PS C:\> $file = Get-KshFile -FileUrl '/sites/japan/hr/Shared%20Documents/Readme.txt'
PS C:\> Move-KshFile -Identity $file -Url '/sites/japan/hr/Shared%20Documents/License.txt'
```

Move the view file.

## PARAMETERS

### -Identity
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

### -MoveOperation
Specifies the move operations.

```yaml
Type: MoveOperations
Parameter Sets: (All)
Aliases:
Accepted values: None, Overwrite, AllowBrokenThickets, BypassApprovePermission

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
If specified, returns the updated object.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Url
Specifies the URL.

```yaml
Type: Uri
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.Models.File

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.File

## NOTES

## RELATED LINKS
