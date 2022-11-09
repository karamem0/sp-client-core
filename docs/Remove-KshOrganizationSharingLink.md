---
external help file: SPClientCore.dll-help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Remove-KshOrganizationSharingLink

## SYNOPSIS
Removes an organization sharing link.

## SYNTAX

```
Remove-KshOrganizationSharingLink [-Url] <Uri> [-IsEditLink] <Boolean>
 [-RemoveAssociatedSharingLinkGroup] <Boolean> [<CommonParameters>]
```

## DESCRIPTION
The Remove-KshOrganizationSharingLink cmdlet removes an organization sharing link for the URL.

## EXAMPLES

### Example 1
```powershell
PS C:\> Remove-KshOrganizationSharingLink -Url '/sites/japan/hr/Shared%20Documents/README.txt' -IsEditLink $true -RemoveAssociatedSharingLinkGroup $true
```

Removes an organization sharing link.

## PARAMETERS

### -IsEditLink
Specifies whether it is an edit link.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RemoveAssociatedSharingLinkGroup
Specifies whether to remove the associated sharing link group.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
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

### None

## NOTES

## RELATED LINKS
