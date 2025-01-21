---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshNavigationNode

## SYNOPSIS
Adds a new navigation node to the specified location.

## SYNTAX

### ParamSet1
```
Add-KshNavigationNode [-NavigationNode] <NavigationNode> [-AsLastNode <Boolean>] [-IsExternal <Boolean>]
 [-PreviousNode <NavigationNode>] [-Title <String>] [-Url <String>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet2
```
Add-KshNavigationNode [-QuickLaunch] [-AsLastNode <Boolean>] [-IsExternal <Boolean>]
 [-PreviousNode <NavigationNode>] [-Title <String>] [-Url <String>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet3
```
Add-KshNavigationNode [-TopNavigationBar] [-AsLastNode <Boolean>] [-IsExternal <Boolean>]
 [-PreviousNode <NavigationNode>] [-Title <String>] [-Url <String>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshNavigationNode` cmdlet adds a navigation node to the specified location in the navigation structure.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshNavigationNode -NavigationNode $node -Title "New Sub Node" -Url "http://example.com/sub"
```

This example adds a new sub-navigation node under an existing node with the title "New Sub Node" and URL "http://example.com/sub".

### Example 2
```powershell
PS C:\> Add-KshNavigationNode -QuickLaunch -Title "New Node" -Url "http://example.com"
```

This example adds a new navigation node to the Quick Launch with the title "New Node" and URL "http://example.com".

### Example 3
```powershell
PS C:\> Add-KshNavigationNode -TopNavigationBar -Title "Top Node" -Url "http://example.com/top"
```

This example adds a new navigation node to the top navigation bar with the title "Top Node" and URL "http://example.com/top".

## PARAMETERS

### -AsLastNode
Specifies whether to add the node as the last node.

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
Specifies whether the URL is external.

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
Specifies the navigation node to add.

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
Specifies the previous node in the navigation structure.

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
Specifies that the node should be added to the Quick Launch.

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

### -Title
Specifies the title of the navigation node.

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
Specifies that the node should be added to the top navigation bar.

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
Specifies the URL of the navigation node.

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

### Karamem0.SharePoint.PowerShell.Models.V1.NavigationNode
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.NavigationNode
## NOTES

## RELATED LINKS

