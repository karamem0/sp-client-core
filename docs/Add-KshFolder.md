---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshFolder

## SYNOPSIS
Adds a new folder to a folder.

## SYNTAX

```
Add-KshFolder [-Folder] <Folder> -FolderName <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshFolder` cmdlet adds a new folder to a folder.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshFolder -Folder $parentFolder -FolderName "NewFolder"
```

This example creates a new folder named "NewFolder" inside the specified parent folder.

## PARAMETERS

### -Folder
Specifies the parent folder where the new folder will be created.

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

### -FolderName
Specifies the name of the new folder to be created.

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

