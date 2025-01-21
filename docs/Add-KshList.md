---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshList

## SYNOPSIS
Creates a new list.

## SYNTAX

```
Add-KshList [-Description <String>] [-QuickLaunchOption <QuickLaunchOptions>] [-ServerRelativeUrl <String>]
 [-Template <ListTemplateType>] -Title <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshList` cmdlet creates a new list in the current site with the given parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshList -Title "Project Tasks" -Template "GenericList" -Description "This is a list for project tasks."
```

This example creates a new generic list with the title "Project Tasks" and the description "This is a list for project tasks."

## PARAMETERS

### -Description
Specifies the description of the list.

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

### -QuickLaunchOption
Specifies whether the list appears on the Quick Launch.

```yaml
Type: QuickLaunchOptions
Parameter Sets: (All)
Aliases:
Accepted values: Off, On, DefaultValue

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerRelativeUrl
Specifies the server-relative URL where the list is created.

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

### -Template
Specifies the list template to use for the new list.

```yaml
Type: ListTemplateType
Parameter Sets: (All)
Aliases:
Accepted values: NoListTemplate, GenericList, DocumentLibrary, Survey, Links, Announcements, Contacts, Events, Tasks, DiscussionBoard, PictureLibrary, DataSources, XmlForm, NoCodeWorkflows, WorkflowProcess, WebPageLibrary, CustomGrid, WorkflowHistory, GanttTasks, IssuesTracking, InvalidType

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Title
Specifies the title of the list.

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

### Karamem0.SharePoint.PowerShell.Models.V1.List
## NOTES

## RELATED LINKS

