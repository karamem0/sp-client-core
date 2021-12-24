---
external help file: SPClientCore.dll-help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# New-KshBasePermission

## SYNOPSIS
Creates a base permission.

## SYNTAX

```
New-KshBasePermission [-Permission] <PermissionKind[]> [<CommonParameters>]
```

## DESCRIPTION
The New-KshBasePermission cmdlet creates a new base permission from permissions.
This is provided for the [Add-KshRoleDefinition](Add-KshRoleDefinition.md) cmdlet and [Set-KshRoleDefinition](Set-KshRoleDefinition.md) cmdlet.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-KshBasePermission -Permission @('ViewListItems', 'AddListItems', 'EditListItems', 'DeleteListItems')
```

Creates a base permission.

## PARAMETERS

### -Permission
Specifies the permissions.

```yaml
Type: PermissionKind[]
Parameter Sets: (All)
Aliases:
Accepted values: EmptyMask, ViewListItems, AddListItems, EditListItems, DeleteListItems, ApproveItems, OpenItems, ViewVersions, DeleteVersions, CancelCheckOut, ManagePersonalViews, ManageLists, ViewFormPages, AnonymousSearchAccessList, Open, ViewPages, AddAndCustomizePages, ApplyThemeAndBorder, ApplyStyleSheets, ViewUsageData, CreateSSCSite, ManageSubwebs, CreateGroups, ManagePermissions, BrowseDirectories, BrowseUserInfo, AddDelPrivateWebParts, UpdatePersonalWebParts, ManageWeb, AnonymousSearchAccessWebLists, UseClientIntegration, UseRemoteAPIs, ManageAlerts, CreateAlerts, EditMyUserInfo, EnumeratePermissions, FullMask

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.BasePermission

## NOTES

## RELATED LINKS
