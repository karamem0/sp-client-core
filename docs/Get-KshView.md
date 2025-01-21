---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshView

## SYNOPSIS
Retrieves a view from a list.

## SYNTAX

### ParamSet1
```
Get-KshView [-Identity] <View> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshView [-List] <List> [-ViewId] <Guid> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Get-KshView [-List] <List> [-ViewTitle] <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet4
```
Get-KshView [-List] <List> [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshView` cmdlet retrieves a view from a list based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshView -Identity $view
```

This example retrieves a view by identity.

### Example 2
```powershell
PS C:\> Get-KshView -List $list -ViewId $viewId
```

This example retrieves a view by view ID.

### Example 3
```powershell
PS C:\> Get-KshView -List $list -ViewTitle "All Items"
```

This example retrieves a view by view title.

### Example 4
```powershell
PS C:\> Get-KshView -List $list
```

This example retrieves all views.

## PARAMETERS

### -Identity
Specifies the view to retrieve.

```yaml
Type: View
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -List
Specifies the list that contains the view.

```yaml
Type: List
Parameter Sets: ParamSet2, ParamSet3, ParamSet4
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoEnumerate
Indicates that the cmdlet does not enumerate the view.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet4
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ViewId
Specifies the ID of the view to retrieve.

```yaml
Type: Guid
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ViewTitle
Specifies the title of the view to retrieve.

```yaml
Type: String
Parameter Sets: ParamSet3
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
Specifies the action preference for progress.

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

### Karamem0.SharePoint.PowerShell.Models.V1.View
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.View
## NOTES

## RELATED LINKS

