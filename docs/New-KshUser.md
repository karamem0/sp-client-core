---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# New-KshUser

## SYNOPSIS
Creates a new user.

## SYNTAX

```
New-KshUser [-Email <String>] -LoginName <String> [-Title <String>] [<CommonParameters>]
```

## DESCRIPTION
The New-KshUser cmdlet adds a new user to the current site.

## EXAMPLES

### Example 1
```powershell
PS C:\> $user = New-KshUser -LoginName 'i:0#.f|membership|admin@example.onmicrosoft.com'
```

Creates a new user to the current site.

## PARAMETERS

### -Email
Specifies the e-mail address.

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

### -LoginName
Specifies the login name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Title
Specifies the title.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.User

## NOTES

## RELATED LINKS