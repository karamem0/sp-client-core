---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshSharingInfo

## SYNOPSIS
Retrieves sharing information for a URL.

## SYNTAX

```
Get-KshSharingInfo -Url <Uri> [-CheckForAccessRequests <Boolean>] [-ExcludeCurrentUser <Boolean>]
 [-ExcludeSecurityGroups <Boolean>] [-ExcludeSiteAdmin <Boolean>] [-RetrieveAnonymousLinks <Boolean>]
 [-RetrievePermissionLevels <Boolean>] [-RetrieveUserInfoDetails <Boolean>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshSharingInfo` cmdlet retrieves sharing information for a URL.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshSharingInfo -Url "https://contoso.sharepoint.com/Shared Documents/file.txt"
```

This example retrieves sharing information.

## PARAMETERS

### -CheckForAccessRequests
Indicates whether to check for access requests.

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

### -ExcludeCurrentUser
Indicates whether to exclude the current user from the results.

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

### -ExcludeSecurityGroups
Indicates whether to exclude security groups from the results.

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

### -ExcludeSiteAdmin
Indicates whether to exclude site administrators from the results.

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

### -RetrieveAnonymousLinks
Indicates whether to retrieve anonymous links.

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

### -RetrievePermissionLevels
Indicates whether to retrieve permission levels.

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

### -RetrieveUserInfoDetails
Indicates whether to retrieve detailed user information.

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

### -Url
Specifies the URL for which to retrieve sharing information.

```yaml
Type: Uri
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

### Karamem0.SharePoint.PowerShell.Models.V1.SharingInfo
## NOTES

## RELATED LINKS

