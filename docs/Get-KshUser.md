---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshUser

## SYNOPSIS
Retrieves one or more users from the current site.

## SYNTAX

### ParamSet1
```
Get-KshUser [-Identity] <User> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshUser [-UserId] <Int32> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Get-KshUser [-UserName] <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet4
```
Get-KshUser [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshUser` cmdlet retrieves one or more users from the current site based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshUser -Identity $user
```

This example retrieves a user by identity.

### Example 2
```powershell
PS C:\> Get-KshUser -UserId 13
```

This example retrieves a user by user ID.

### Example 3
```powershell
PS C:\> Get-KshUser -UserName "meganb@contoso.com"
```

This example retrieves a user by user name.

### Example 4
```powershell
PS C:\> Get-KshUser
```

This example retrieves all users.

## PARAMETERS

### -Identity
Specifies the user identity to retrieve.

```yaml
Type: User
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NoEnumerate
Indicates that the cmdlet does not enumerate the collection.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet4
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserId
Specifies the user ID to retrieve.

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

### -UserName
Specifies the user name to retrieve.

```yaml
Type: String
Parameter Sets: ParamSet3
Aliases:

Required: True
Position: 0
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

### Karamem0.SharePoint.PowerShell.Models.V1.User
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.User
## NOTES

## RELATED LINKS

