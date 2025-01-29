---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Move-KshFolder

## SYNOPSIS

Moves a folder.

## SYNTAX

### ParamSet1

```
Move-KshFolder [-Identity] <Folder> [-NewUrl] <Uri> [-KeepBoth] [-ResetAuthorAndCreatedOnCopy]
 [-RetainEditorAndModifiedOnMove] [-ShouldBypassSharedLocks] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet2

```
Move-KshFolder [-Identity] <Folder> [-NewUrl] <Uri> [-Legacy] [-PassThru] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION

The `Move-KshFolder` cmdlet moves a folder to a new location. You can specify whether to keep both the original and the new folder, reset author and created information on copy, retain editor and modified information on move, and bypass shared locks.

## EXAMPLES

### Example 1

```powershell
PS C:\> Move-KshFolder -Identity $folder -NewUrl "https://contoso.sharepoint.com/Shared%20Documents/NewFolder"
```

This example moves the specified folder to a new location.

### Example 2

```powershell
PS C:\> Move-KshFolder -Identity $folder -NewUrl "/sites/japan/hr/Shared%20Documents/README.txt" -Legacy
```

This example moves the specified folder to a new location using the legacy API.

## PARAMETERS

### -Identity

Specifies the folder to move.

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

### -KeepBoth

Indicates that both the original and the new folder should be kept.

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

Specifies the new URL for the folder.

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

### -PassThru

Returns the folder object that was processed.

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

Indicates that the author and created information should be reset on copy.

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

Indicates that the editor and modified information should be retained on move.

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

Indicates that shared locks should be bypassed during the move operation.

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

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about\_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.Folder

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.Folder

## NOTES

## RELATED LINKS
