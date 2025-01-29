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

### ParamSet1

```
Move-KshFile [-Identity] <File> [-NewUrl] <Uri> [-Overwrite] [-KeepBoth] [-ResetAuthorAndCreatedOnCopy]
 [-RetainEditorAndModifiedOnMove] [-ShouldBypassSharedLocks] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet2

```
Move-KshFile [-Identity] <File> [-NewUrl] <Uri> [-Overwrite] [-Legacy] [-AllowBrokenThickets]
 [-BypassApprovePermission] [-PassThru] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION

The `Move-KshFile` cmdlet moves a file to a new location. You can specify various options such as overwriting the file, keeping both versions, and retaining editor and modified information.

## EXAMPLES

### Example 1

```powershell
PS C:\> Move-KshFile -Identity $file -NewUrl "https://contoso.sharepoint.com/Shared%20Documents/README.txt" -Overwrite
```

This example moves the specified file to the new location and overwrites the existing file if it exists.

### Example 2

```powershell
PS C:\> Move-KshFile -Identity $file -NewUrl "/Shared%20Documents/README.txt" -Overwrite -Legacy -AllowBrokenThickets
```

This example moves the file to the new location using the legacy API and allows the move to proceed even if the file has broken thickets.

## PARAMETERS

### -AllowBrokenThickets

Allows the move operation to proceed even if the file has broken thickets.

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

### -BypassApprovePermission

Bypasses the approval permission requirement for the move operation.

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

### -Identity

Specifies the file to be moved.

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

Keeps both the original and the moved file.

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

Indicates that the legacy API should be used for the move operation.

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

Specifies the new URL for the file.

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

Overwrites the file at the new URL if it already exists.

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

Resets the author and created date on the copied file.

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

Retains the editor and modified date on the moved file.

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

Bypasses shared locks during the move operation.

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

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about\_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.File

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.File

## NOTES

## RELATED LINKS
