---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Connect-SPOnline

## SYNOPSIS
Connects to SharePoint Online.

## SYNTAX

### DeviceCode (Default)
```
Connect-SPOnline -Url <Uri> [-Authority <Uri>] [<CommonParameters>]
```

### Password
```
Connect-SPOnline -Url <Uri> -Credential <PSCredential> [-Authority <Uri>] [<CommonParameters>]
```

### AdminConsent
```
Connect-SPOnline -Url <Uri> [-AdminConsent] [-Authority <Uri>] [<CommonParameters>]
```

## DESCRIPTION
The Connect-SPOnline cmdlet creates new connection to SharePoint Online.

## EXAMPLES

### Example 1
```
PS C:\> Connect-SPOnline -Url 'https://example.sharepoint.com'
```

Connects to SharePoint Online with device code.

### Example 2
```
PS C:\> Connect-SPOnline -Url 'https://example.sharepoint.com' -Credentials (Get-Credential)
```

Connects to SharePoint Online with user name and password.

### Example 3
```
PS C:\> Connect-SPOnline -Url 'https://example.sharepoint.com' -AdminConsent
```

Retrieves the admin consent URL.

## PARAMETERS

### -Authority
Indicates the authorization endpoint URL.
This parameter is provided for some environment.
(Germany, China, and US Government)

```yaml
Type: Uri
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Credential
Indicates the credential (user name and password).

```yaml
Type: PSCredential
Parameter Sets: Password
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Url
Indicates the site URL.

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

### -AdminConsent
If speficied, retrieves the admin consent URL.

```yaml
Type: SwitchParameter
Parameter Sets: AdminConsent
Aliases:

Required: True
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.Core.User
## NOTES

## RELATED LINKS
