---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Remove-KshSiteCollectionApp

## SYNOPSIS
Removes a site collection app.

## SYNTAX

```
Remove-KshSiteCollectionApp [-Identity] <App> [<CommonParameters>]
```

## DESCRIPTION
The Remove-KshSiteCollectionApp removes an app from the current site collection app catalog.

## EXAMPLES

### Example 1
```powershell
PS C:\> The Remove-KshSiteCollectionApp -Identity (Get-KshSiteCollectionApp -AppId 'fdee2390-48bf-409e-956a-20f11a0add59')
```

Removes an app.

## PARAMETERS

### -Identity
Specifies the app.

```yaml
Type: App
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.App

## OUTPUTS

### None

## NOTES

## RELATED LINKS
