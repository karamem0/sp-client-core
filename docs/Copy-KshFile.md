---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Copy-KshFile

## SYNOPSIS
Copies a file to a new location.

## SYNTAX

### ParamSet1
```
Copy-KshFile [-Identity] <File> [-NewUrl] <Uri> [-Overwrite] [-KeepBoth] [-ResetAuthorAndCreatedOnCopy]
 [-RetainEditorAndModifiedOnMove] [-ShouldBypassSharedLocks] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet2
```
Copy-KshFile [-Identity] <File> [-NewUrl] <Uri> [-Overwrite] [-Legacy] [-PassThru]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Copy-KshFile` cmdlet copies a file to a new location. It provides options to overwrite existing files, keep both versions, and reset author and creation information on copy.

## EXAMPLES

### Example 1
```powershell
PS C:\> Copy-KshFile -Identity $file -NewUrl "https://contoso.sharepoint.com/Shared Documents/file.txt" -Overwrite
```

This example copies the file `file.txt` from the source directory to the destination directory, overwriting the existing file if it exists.

### Example 2
```powershell
PS C:\> Copy-KshFile -Identity $file -NewUrl "https://contoso.sharepoint.com/Shared Documents/file.txt" -KeepBoth
```

This example copies the file `file.txt` from the source directory to the destination directory, keeping both the original and the copied file if a file with the same name already exists at the destination.

### Example 3
```powershell
PS C:\> Copy-KshFile -Identity $file -NewUrl "/sites/site1/Shared Documents/old/file.txt" -Legacy
```

This example copies the file `file.txt` from the source directory to the destination directory using legacy copy methods and returns the copied file object.

## PARAMETERS

### -Identity
Specifies the file to be copied.

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

### -KeepBoth
Keeps both the original and the copied file if a file with the same name already exists at the destination.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Legacy
Uses legacy copy methods.

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

### -NewUrl
Specifies the new location for the copied file.

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

### -Overwrite
Overwrites the file at the destination if it already exists.

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

### -PassThru
Returns the file object that was processed.

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

### -ResetAuthorAndCreatedOnCopy
Resets the author and creation date information on the copied file.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RetainEditorAndModifiedOnMove
Retains the editor and modified date information when moving the file.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShouldBypassSharedLocks
Bypasses any shared locks on the file during the copy operation.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
Specifies the action to take when progress is reported.

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

### Karamem0.SharePoint.PowerShell.Models.V1.File
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.File
## NOTES

## RELATED LINKS

