---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshSharingSettings

## SYNOPSIS
Retrieves the sharing settings for a URL.

## SYNTAX

```
Get-KshSharingSettings -Url <Uri> [-GroupId <Int32>] [-UseSimplifiedRoles <Boolean>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshSharingSettings` cmdlet retrieves the sharing settings for a URL.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshSharingSettings -Url "https://contoso.sharepoint.com/Shared Documents/file.txt"
```

This example retrieves the sharing settings.

## PARAMETERS

### -GroupId
Specifies the ID of the group to filter the sharing settings.

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

### -Url
Specifies the URL for which to retrieve the sharing settings.

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

### -UseSimplifiedRoles
Indicates whether to use simplified roles in the sharing settings.

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

### Karamem0.SharePoint.PowerShell.Models.V1.SharingSettings
## NOTES

## RELATED LINKS

