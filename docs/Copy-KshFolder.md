---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Copy-KshFolder

## SYNOPSIS
Copies a folder to a new location.

## SYNTAX

```
Copy-KshFolder [-Identity] <Folder> [-NewUrl] <Uri> [-KeepBoth] [-ResetAuthorAndCreatedOnCopy]
 [-RetainEditorAndModifiedOnMove] [-ShouldBypassSharedLocks] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
The `Copy-KshFolder` cmdlet copies a folder to a new location.

## EXAMPLES

### Example 1
```powershell
PS C:\> Copy-KshFolder -Identity $folder -NewUrl "http://contoso.sharepoint.com/Shared Documents/newfolder" -KeepBoth
```

This example copies the folder to a new URL and keeps both versions if a folder with the same name already exists.

## PARAMETERS

### -Identity
Specifies the folder to copy.

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
Keeps both the original and the copied folder if a folder with the same name already exists at the destination.

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

### -NewUrl
Specifies the URL of the new location for the folder.

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

### -ResetAuthorAndCreatedOnCopy
Resets the author and created date on the copied folder.

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

### -RetainEditorAndModifiedOnMove
Retains the editor and modified date on the moved folder.

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

### -ShouldBypassSharedLocks
Bypasses any shared locks on the folder during the copy operation.

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

### Karamem0.SharePoint.PowerShell.Models.V1.Folder
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.Folder
## NOTES

## RELATED LINKS

