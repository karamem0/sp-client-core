---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshSiteCollectionApp

## SYNOPSIS
Retrieves one or more apps from a site collection app catalog.

## SYNTAX

### ParamSet1
```
Get-KshSiteCollectionApp [-Identity] <App> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshSiteCollectionApp [-AppId] <Guid> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Get-KshSiteCollectionApp [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshSiteCollectionApp` cmdlet retrieves one or more apps from a site collection app catalog based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshSiteCollectionApp -Identity $app
```

This example retrieves a app by identity.

### Example 2
```powershell
PS C:\> Get-KshSiteCollectionApp -AppId $appId
```

This example retrieves a app by app ID.

### Example 3
```powershell
PS C:\> Get-KshSiteCollectionApp
```

This example retrieves all apps.

## PARAMETERS

### -AppId
Specifies the ID of the app to retrieve.

```yaml
Type: Guid
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Identity
Specifies the app to retrieve.

```yaml
Type: App
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NoEnumerate
Indicates that the cmdlet does not enumerate the collection.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet3
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

### Karamem0.SharePoint.PowerShell.Models.V1.App
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.App
## NOTES

## RELATED LINKS

