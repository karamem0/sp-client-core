---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshColumnUser

## SYNOPSIS
Adds a new User column to a list or library.

## SYNTAX

### ParamSet1
```
Add-KshColumnUser [-List] <List> [-AllowMultipleValues <Boolean>] [-ClientSideComponentId <String>]
 [-ClientSideComponentProperties <String>] [-CustomFormatter <String>] [-Description <String>]
 [-Direction <String>] [-EnforceUniqueValues <Boolean>] [-Group <String>] [-Hidden <Boolean>] [-Id <Guid>]
 [-Indexed <Boolean>] [-JSLink <String>] [-LookupColumnName <String>] -Name <String> [-NoCrawl <Boolean>]
 [-ReadOnly <Boolean>] [-RelationshipDeleteBehavior <RelationshipDeleteBehaviorType>] [-Required <Boolean>]
 [-SelectionGroupId <Int32>] [-SelectionMode <ColumnUserSelectionMode>] [-StaticName <String>]
 [-Title <String>] [-UnlimitedLengthInDocumentLibrary <Boolean>] [-AddToDefaultContentType]
 [-AddToNoContentType] [-AddToAllContentTypes] [-AddColumnInternalNameHint] [-AddColumnToDefaultView]
 [-AddColumnCheckDisplayName] [-AddToDefaultView] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Add-KshColumnUser [-AllowMultipleValues <Boolean>] [-ClientSideComponentId <String>]
 [-ClientSideComponentProperties <String>] [-CustomFormatter <String>] [-Description <String>]
 [-Direction <String>] [-EnforceUniqueValues <Boolean>] [-Group <String>] [-Hidden <Boolean>] [-Id <Guid>]
 [-Indexed <Boolean>] [-JSLink <String>] [-LookupColumnName <String>] -Name <String> [-NoCrawl <Boolean>]
 [-ReadOnly <Boolean>] [-RelationshipDeleteBehavior <RelationshipDeleteBehaviorType>] [-Required <Boolean>]
 [-SelectionGroupId <Int32>] [-SelectionMode <ColumnUserSelectionMode>] [-StaticName <String>]
 [-Title <String>] [-UnlimitedLengthInDocumentLibrary <Boolean>] [-AddToDefaultContentType]
 [-AddToNoContentType] [-AddToAllContentTypes] [-AddColumnInternalNameHint] [-AddColumnToDefaultView]
 [-AddColumnCheckDisplayName] [-AddToDefaultView] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Add-KshColumnUser [-AllowMultipleValues <Boolean>] [-ClientSideComponentId <String>]
 [-ClientSideComponentProperties <String>] [-CustomFormatter <String>] [-Description <String>]
 [-Direction <String>] [-EnforceUniqueValues <Boolean>] [-Group <String>] [-Hidden <Boolean>] [-Id <Guid>]
 [-Indexed <Boolean>] [-JSLink <String>] [-LookupColumnName <String>] -Name <String> [-NoCrawl <Boolean>]
 [-ReadOnly <Boolean>] [-RelationshipDeleteBehavior <RelationshipDeleteBehaviorType>] [-Required <Boolean>]
 [-SelectionGroupId <Int32>] [-SelectionMode <ColumnUserSelectionMode>] [-StaticName <String>]
 [-Title <String>] [-UnlimitedLengthInDocumentLibrary <Boolean>] [-WhatIf] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshColumnUser` cmdlet adds a new User column to a list or library. The column can be configured to allow multiple values, enforce unique values, and other settings.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshColumnUser -List $list -Name "AssignedTo" -Title "Assigned To" -SelectionMode PeopleOnly
```

This example adds a new user column named "AssignedTo" to the specified list with the title "Assigned To" and selection mode set to "PeopleOnly".

### Example 2
```powershell
PS C:\> Add-KshColumnUser -Name "Reviewer" -Title "Reviewer" -SelectionMode PeopleAndGroups -AllowMultipleValues $true
```

This example adds a new user column named "Reviewer" as a site column with the title "Reviewer", allowing multiple values and setting the selection mode to "PeopleAndGroups".

### Example 3
```powershell
PS C:\> Add-KshColumnUser -Name "Approver" -Title "Approver" -SelectionMode GroupsOnly -EnforceUniqueValues $true -WhatIf
```

This example shows what would happen if the cmdlet runs without actually creating the column. The column would be named "Approver" with the title "Approver" is added, with the selection mode set to "GroupsOnly" and enforcing unique values.

## PARAMETERS

### -AddColumnCheckDisplayName
Specifies whether to check the display name when adding the column.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1, ParamSet2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AddColumnInternalNameHint
Specifies whether to add an internal name hint for the column.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1, ParamSet2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AddColumnToDefaultView
Specifies whether to add the column to the default view.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1, ParamSet2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AddToAllContentTypes
Specifies whether to add the column to all content types.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1, ParamSet2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AddToDefaultContentType
Specifies whether to add the column to the default content type.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1, ParamSet2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AddToDefaultView
Specifies whether to add the column to the default view.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1, ParamSet2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AddToNoContentType
Specifies whether to add the column to no content type.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1, ParamSet2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AllowMultipleValues
Specifies whether to allow multiple values for the column.

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

### -ClientSideComponentId
Specifies the client-side component ID for the column.

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

### -ClientSideComponentProperties
Specifies the client-side component properties for the column.

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

### -CustomFormatter
Specifies the custom formatter for the column.

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

### -Description
Specifies the description of the column.

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

### -Direction
Specifies the direction of the column.

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

### -EnforceUniqueValues
Specifies whether to enforce unique values for the column.

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

### -Group
Specifies the group of the column.

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

### -Hidden
Specifies whether the column is hidden.

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

### -Id
Specifies the ID of the column.

```yaml
Type: Guid
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Indexed
Specifies whether the column is indexed.

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

### -JSLink
Specifies the JSLink for the column.

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

### -List
Specifies the list to which the column is added.

```yaml
Type: List
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LookupColumnName
Specifies the lookup column name.

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

### -Name
Specifies the name of the column.

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

### -NoCrawl
Specifies whether to exclude the column from search crawling.

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

### -ReadOnly
Specifies whether the column is read-only.

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

### -RelationshipDeleteBehavior
Specifies the relationship delete behavior for the column.

```yaml
Type: RelationshipDeleteBehaviorType
Parameter Sets: (All)
Aliases:
Accepted values: None, Cascade, Restrict

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Required
Specifies whether the column is required.

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

### -SelectionGroupId
Specifies the selection group ID for the column.

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

### -SelectionMode
Specifies the selection mode for the column.

```yaml
Type: ColumnUserSelectionMode
Parameter Sets: (All)
Aliases:
Accepted values: PeopleOnly, PeopleAndGroups, GroupsOnly

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StaticName
Specifies the static name of the column.

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

### -Title
Specifies the title of the column.

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

### -UnlimitedLengthInDocumentLibrary
Specifies whether the column has unlimited length in the document library.

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

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

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

### Karamem0.SharePoint.PowerShell.Models.V1.ColumnUser
## NOTES

## RELATED LINKS

