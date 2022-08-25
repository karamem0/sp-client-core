---
external help file: SPClientCore.dll-help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshSharingInfo

## SYNOPSIS
Retrieves a sharing information.

## SYNTAX

```
Get-KshSharingInfo -Url <Uri> [-CheckForAccessRequests <Boolean>] [-ExcludeCurrentUser <Boolean>]
 [-ExcludeSecurityGroups <Boolean>] [-ExcludeSiteAdmin <Boolean>] [-RetrieveAnonymousLinks <Boolean>]
 [-RetrievePermissionLevels <Boolean>] [-RetrieveUserInfoDetails <Boolean>] [<CommonParameters>]
```

## DESCRIPTION
The Get-KshSharingInfo cmdlet retrieves a sharing information of the specified URL.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshSharingInfo -Url 'https://example.sharepoint.com/Shared%20Documents/README.txt'
```

Retrieves a sharing information.

## PARAMETERS

### -CheckForAccessRequests
Specifies whether to check for access requests.

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
Specifies whether to exclude the current user.

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
Specifies whether to exclude security groups.

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
Specifies whether to exclude the site administrators.

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
Specifies whether to retrieve anonymous links.

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
Specifies whether to retrieve permission levels.

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
Specifies whether to retrieve user information details.

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
Specifies the URL.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.SharingInfo
## NOTES

## RELATED LINKS
