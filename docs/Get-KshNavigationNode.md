---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshNavigationNode

## SYNOPSIS
Retrieves one or more navigation nodes.

## SYNTAX

### ParamSet1
```
Get-KshNavigationNode [-Identity] <NavigationNode> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshNavigationNode [-NavigationNodeId] <Int32> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Get-KshNavigationNode [-NavigationNode] <NavigationNode> [-NoEnumerate] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshNavigationNode` cmdlet retrieves one or more navigation nodes based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshNavigationNode -Identity $node
```

This example retrieves a navigation node by identity.

### Example 2
```powershell
PS C:\> Get-KshNavigationNode -NavigationNodeId 2001
```

This example retrieves a navigation node by navigation node ID.

### Example 3
```powershell
PS C:\> Get-KshNavigationNode -NavigationNode $node
```

This example retrieves all navigation nodes.

## PARAMETERS

### -Identity
Specifies the navigation node to retrieve.

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

### -NavigationNode
Specifies the navigation node to retrieve.

```yaml
Type: NavigationNode
Parameter Sets: ParamSet3
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NavigationNodeId
Specifies the ID of the navigation node to retrieve.

```yaml
Type: Int32
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
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

### Karamem0.SharePoint.PowerShell.Models.V1.NavigationNode
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.NavigationNode
## NOTES

## RELATED LINKS

