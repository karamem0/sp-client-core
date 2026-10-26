---
Module Name: SPClientCore
external help file: SPClientCore.dll-Help.xml
schema: 2.0.0
---

# Add-KshNavigationNode

## SYNOPSIS
Add a navigation node.

## SYNTAX

### ParamSet1
```
Add-KshNavigationNode [-NavigationNode] <NavigationNode> [[-AsLastNode] <Boolean>] [[-IsExternal] <Boolean>]
 [[-PreviousNode] <NavigationNode>] [[-Title] <String>] [[-Url] <Uri>] [-SelectAllProperties]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Add-KshNavigationNode [-QuickLaunch] [[-AsLastNode] <Boolean>] [[-IsExternal] <Boolean>]
 [[-PreviousNode] <NavigationNode>] [[-Title] <String>] [[-Url] <Uri>] [-SelectAllProperties]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Add-KshNavigationNode [-TopNavigationBar] [[-AsLastNode] <Boolean>] [[-IsExternal] <Boolean>]
 [[-PreviousNode] <NavigationNode>] [[-Title] <String>] [[-Url] <Uri>] [-SelectAllProperties]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## PARAMETERS

### -AsLastNode

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

### -IsExternal

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

### -NavigationNode

```yaml
Type: NavigationNode
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PreviousNode

```yaml
Type: NavigationNode
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -QuickLaunch

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SelectAllProperties

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

### -Title

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TopNavigationBar

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Url

```yaml
Type: Uri
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction

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

### Karamem0.SharePoint.PowerShell.Models.V1.NavigationNode

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.NavigationNode

