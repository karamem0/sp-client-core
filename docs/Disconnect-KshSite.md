---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Disconnect-KshSite

## SYNOPSIS
Disconnects from a site.

## SYNTAX

```
Disconnect-KshSite [[-Url] <Uri>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Disconnect-KshSite` cmdlet disconnects from a site and clear a credential cache.

## EXAMPLES

### Example 1
```powershell
PS C:\> Disconnect-KshSite -Url "https://consoto.sharepoint.com"
```

This example disconnects from the site at "https://consoto.sharepoint.com".

## PARAMETERS

### -Url
Specifies the URL of the site to disconnect from.

```yaml
Type: Uri
Parameter Sets: (All)
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
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

### System.Uri
## OUTPUTS

### System.Void
## NOTES

## RELATED LINKS

