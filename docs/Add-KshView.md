---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshView

## SYNOPSIS
Adds a new view to a list.

## SYNTAX

```
Add-KshView [-List] <List> [-BaseViewId <Int32>] [-Paged <Boolean>] [-PersonalView <Boolean>]
 [-RowLimit <Int32>] [-SetAsDefaultView <Boolean>] -Title <String> [-ViewColumns <String[]>]
 [-ViewQuery <String>] [-ViewType <ViewType>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshView` cmdlet adds a new view to a list with the given parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshView -List $list -Title "New View" -ViewColumns @("Title", "Created") -RowLimit 100
```

This example adds a new view titled "New View" to the specified list with the columns "Title" and "Created", and sets the row limit to 100.

## PARAMETERS

### -BaseViewId
Specifies the base view ID.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -List
Specifies the list to which the view is added.

```yaml
Type: List
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Paged
Indicates whether the view is paged.

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

### -PersonalView
Indicates whether the view is personal.

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

### -RowLimit
Specifies the row limit for the view.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SetAsDefaultView
Indicates whether the view is set as the default view.

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

### -Title
Specifies the title of the view.

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

### -ViewColumns
Specifies the columns to include in the view.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ViewQuery
Specifies the query for the view.

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

### -ViewType
Specifies the type of the view.

```yaml
Type: ViewType
Parameter Sets: (All)
Aliases:
Accepted values: None, Html, Grid, Recurrence, Chart, Calendar, Gantt

Required: False
Position: Named
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

### Karamem0.SharePoint.PowerShell.Models.V1.List
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.View
## NOTES

## RELATED LINKS

