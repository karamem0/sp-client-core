---
Module Name: SPClientCore
external help file: SPClientCore.dll-Help.xml
schema: 2.0.0
---

# Add-KshExternalUser

## SYNOPSIS
Add an external user.

## SYNTAX

### ParamSet1
```
Add-KshExternalUser [-Site] [-UserId] <String[]> [-Role] <RoleType> [[-AdditivePermission] <Boolean>]
 [[-AllowExternalSharing] <Boolean>] [[-CustomMessage] <String>] [[-SendServerManagedNotification] <Boolean>]
 [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Add-KshExternalUser [-File] <File> [-UserId] <String[]> [-Role] <RoleType> [[-AdditivePermission] <Boolean>]
 [[-CustomMessage] <String>] [[-IncludeAnonymousLinksInNotification] <Boolean>] [[-PropagateAcl] <Boolean>]
 [[-SendServerManagedNotification] <Boolean>] [[-ValidateExistingPermissions] <Boolean>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Add-KshExternalUser [-Folder] <Folder> [-UserId] <String[]> [-Role] <RoleType>
 [[-AdditivePermission] <Boolean>] [[-CustomMessage] <String>]
 [[-IncludeAnonymousLinksInNotification] <Boolean>] [[-PropagateAcl] <Boolean>]
 [[-SendServerManagedNotification] <Boolean>] [[-ValidateExistingPermissions] <Boolean>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## PARAMETERS

### -AdditivePermission

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

