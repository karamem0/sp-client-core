---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshSiteCollectionApp

## SYNOPSIS
Adds a new app to a site collection app catalog.

## SYNTAX

```
Add-KshSiteCollectionApp -Content <Stream> -FileName <String> [-Overwrite <Boolean>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshSiteCollectionApp` cmdlet adds a new app to the current site collection app catalog.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshSiteCollectionApp -Content $content -FileName "app.zip" -Overwrite $true
```

This example adds a new app to the current site collection app catalog from the specified stream and file name, and overwrites the existing app if it exists.

## PARAMETERS

### -Content
Specifies the content of the app as a stream.

```yaml
Type: Stream
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FileName
Specifies the name of the app file.

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

### -Overwrite
Indicates whether to overwrite the existing app if it exists.

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

### None
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.App
## NOTES

## RELATED LINKS

