---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Connect-SPServer

## SYNOPSIS
Connects to SharePoint Server.

## SYNTAX

```
Connect-SPServer -Url <Uri> [-Credential <PSCredential>] [<CommonParameters>]
```

## DESCRIPTION
The Connect-SPServer cmdlet creates new connection to SharePoint Server. (On-premiss)

## EXAMPLES

### Example 1
```powershell
PS C:\> Connect-SPServer -Url 'https://example.com/sharepoint' -Credentials (Get-Credential)
```

Connects to SharePoint Server with user name and password.

## PARAMETERS

### -Credential
Indicates the credential (user name and password).

```yaml
Type: PSCredential
Parameter Sets: (All)
Aliases:

Required: False
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.Core.User

## NOTES

## RELATED LINKS
