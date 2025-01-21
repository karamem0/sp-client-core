---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshOrganizationSharingLink

## SYNOPSIS
Creates a new sharing link for an organization.

## SYNTAX

```
Add-KshOrganizationSharingLink -Url <Uri> -IsEditLink <Boolean> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshOrganizationSharingLink` cmdlet creates a sharing link for an organization, allowing users to share resources with specified permissions.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshOrganizationSharingLink -Url "https://example.com/resource" -IsEditLink $true
```

This example creates an edit sharing link for the specified URL.

## PARAMETERS

### -IsEditLink
Specifies whether the sharing link allows editing.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Url
Specifies the URL of the resource to share.

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

### System.String
## NOTES

## RELATED LINKS

