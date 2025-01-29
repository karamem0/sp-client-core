---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Publish-KshSiteCollectionApp

## SYNOPSIS

Publishes an app to a site collection.

## SYNTAX

```
Publish-KshSiteCollectionApp [-Identity] <App> [-PassThru] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION

The `Publish-KshSiteCollectionApp` cmdlet publishes an app to a site collection.

## EXAMPLES

### Example 1

```powershell
PS C:\> Publish-KshSiteCollectionApp -Identity $app
```

This example publishes the specified app to the site collection.

## PARAMETERS

### -Identity

Specifies the app to publish.

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

### -PassThru

Returns the app object that was processed.

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

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about\_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.App

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.App

## NOTES

## RELATED LINKS
