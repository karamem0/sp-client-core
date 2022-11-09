---
external help file: SPClientCore.dll-help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshExternalUser

## SYNOPSIS
Creates a new external user.

## SYNTAX

### ParamSet1
```
Add-KshExternalUser [-Site] [-UserId] <String[]> [-Role] <RoleType> [-AdditivePermission <Boolean>]
 [-AllowExternalSharing <Boolean>] [-CustomMessage <String>] [-SendServerManagedNotification <Boolean>]
 [-NoEnumerate] [<CommonParameters>]
```

### ParamSet2
```
Add-KshExternalUser [-File] <File> [-UserId] <String[]> [-Role] <RoleType> [-AdditivePermission <Boolean>]
 [-CustomMessage <String>] [-IncludeAnonymousLinksInNotification <Boolean>] [-PropagateAcl <Boolean>]
 [-SendServerManagedNotification <Boolean>] [-ValidateExistingPermissions <Boolean>] [<CommonParameters>]
```

### ParamSet3
```
Add-KshExternalUser [-Folder] <Folder> [-UserId] <String[]> [-Role] <RoleType> [-AdditivePermission <Boolean>]
 [-CustomMessage <String>] [-IncludeAnonymousLinksInNotification <Boolean>] [-PropagateAcl <Boolean>]
 [-SendServerManagedNotification <Boolean>] [-ValidateExistingPermissions <Boolean>] [<CommonParameters>]
```

## DESCRIPTION
The Add-KshExternalUser cmdlet adds a new external user to the current site or the specified file or folder.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshExternalUser -Site -UserId 'someone@contoso.com'
```

Creates a new user to the current site.

## PARAMETERS

### -AdditivePermission
Specifies whether to add permissions to the external user.

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
Specifies the custom message.

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
Specifies the file.

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
Specifies the folder.

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
Specifies whether to include the anonymous links in notification.

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
If specified, suppresses to enumerate objects.

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
Specifies whether to propagate ACL.

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
Specifies the role.

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
Specifies whether to send server managed notification.

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
If specified, uses the current site.

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
Specifies the user ID.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.UserSharingResult
## NOTES

## RELATED LINKS
