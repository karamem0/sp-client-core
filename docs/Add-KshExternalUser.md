---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshExternalUser

## SYNOPSIS
Adds a new external user to a site, file, or folder with permissions.

## SYNTAX

### ParamSet1
```
Add-KshExternalUser [-Site] [-UserId] <String[]> [-Role] <RoleType> [-AdditivePermission <Boolean>]
 [-AllowExternalSharing <Boolean>] [-CustomMessage <String>] [-SendServerManagedNotification <Boolean>]
 [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Add-KshExternalUser [-File] <File> [-UserId] <String[]> [-Role] <RoleType> [-AdditivePermission <Boolean>]
 [-CustomMessage <String>] [-IncludeAnonymousLinksInNotification <Boolean>] [-PropagateAcl <Boolean>]
 [-SendServerManagedNotification <Boolean>] [-ValidateExistingPermissions <Boolean>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Add-KshExternalUser [-Folder] <Folder> [-UserId] <String[]> [-Role] <RoleType> [-AdditivePermission <Boolean>]
 [-CustomMessage <String>] [-IncludeAnonymousLinksInNotification <Boolean>] [-PropagateAcl <Boolean>]
 [-SendServerManagedNotification <Boolean>] [-ValidateExistingPermissions <Boolean>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshExternalUser` cmdlet adds an external user to a site, file, or folder with the given role and permissions.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshExternalUser -Site -UserId "user@example.com" -Role "View" -AllowExternalSharing $true
```

This example adds an external user with the email "user@example.com" to the site with "View" permissions and allows external sharing.

### Example 2
```powershell
PS C:\> Add-KshExternalUser -File $file -UserId "user@example.com" -Role "Edit" -IncludeAnonymousLinksInNotification $true
```

This example adds an external user with the email "user@example.com" to the specified file with "Edit" permissions and includes anonymous links in the notification.

### Example 3
```powershell
PS C:\> Add-KshExternalUser -Folder $folder -UserId "user@example.com" -Role Owner -PropagateAcl $true
```

This example adds an external user with the email "user@example.com" to the specified folder with owner permissions and propagates the access control list (ACL).

## PARAMETERS

### -AdditivePermission
Specifies whether to add the permissions to the existing permissions.

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

### -AllowExternalSharing
Specifies whether to allow external sharing.

```yaml
Type: Boolean
Parameter Sets: ParamSet1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomMessage
Specifies a custom message to include in the notification.

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

### -File
Specifies the file to which the external user is added.

```yaml
Type: File
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Folder
Specifies the folder to which the external user is added.

```yaml
Type: Folder
Parameter Sets: ParamSet3
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeAnonymousLinksInNotification
Specifies whether to include anonymous links in the notification.

```yaml
Type: Boolean
Parameter Sets: ParamSet2, ParamSet3
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoEnumerate
Specifies whether to prevent enumeration of the user.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PropagateAcl
Specifies whether to propagate the access control list (ACL).

```yaml
Type: Boolean
Parameter Sets: ParamSet2, ParamSet3
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Role
Specifies the role to assign to the external user.

```yaml
Type: RoleType
Parameter Sets: (All)
Aliases:
Accepted values: None, View, Edit, Owner, LimitedView, LimitedEdit, Review, RestrictedView, Submit, ManageList

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SendServerManagedNotification
Specifies whether to send a server-managed notification.

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

### -Site
Specifies the site to which the external user is added.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserId
Specifies the user ID of the external user.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValidateExistingPermissions
Specifies whether to validate existing permissions.

```yaml
Type: Boolean
Parameter Sets: ParamSet2, ParamSet3
Aliases:

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

### None
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.UserSharingResult
## NOTES

## RELATED LINKS

