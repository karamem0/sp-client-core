---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Set-KshGroupOwner

## SYNOPSIS
Changes a group owner.

## SYNTAX

```
Set-KshGroupOwner [-Group] <Group> -Owner <Principal> [<CommonParameters>]
```

## DESCRIPTION
Get-KshGroupOwner cmdlet changes the user or group that is the owner of the group.

## EXAMPLES

### Example 1
```powershell
PS C:\> $group = Get-KshGroup -GroupName 'Blog Owners'
PS C:\> $owner = Get-KshUser -UserName 'i:0#.f|membership|admin@example.onmicrosoft.com'
PS C:\> Set-KshGroupOwner -Identity $group -Owner $owner
```

Changes a group owner.

## PARAMETERS

### -Group
Specifies the group.

```yaml
Type: Group
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Owner
Specifies the user or group.

```yaml
Type: Principal
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

### Karamem0.SharePoint.PowerShell.Models.Group

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.User

## NOTES

## RELATED LINKS
