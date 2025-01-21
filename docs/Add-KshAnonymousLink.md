---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshAnonymousLink

## SYNOPSIS
Creates an anonymous access link for a specified URL.

## SYNTAX

### ParamSet1
```
Add-KshAnonymousLink -Url <Uri> -IsEditLink <Boolean> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Add-KshAnonymousLink -Url <Uri> -IsEditLink <Boolean> -Expiration <DateTime>
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshAnonymousLink` cmdlet creates an anonymous access link for the specified URL. The link can be configured to allow either view or edit permissions. Optionally, an expiration date can be set for the link.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshAnonymousLink -Url "http://example.com/document" -IsEditLink $true
```

This example creates an anonymous edit link for the specified document URL.

### Example 2
```powershell
PS C:\> Add-KshAnonymousLink -Url "http://example.com/document" -IsEditLink $false -Expiration (Get-Date).AddDays(7)
```

This example creates an anonymous view link for the specified document URL that expires in 7 days.

## PARAMETERS

### -Expiration
Specifies the expiration date and time for the anonymous link.

```yaml
Type: DateTime
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsEditLink
Indicates whether the link allows edit permissions. If set to $true, the link allows editing; otherwise, it allows only viewing.

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
Specifies the URL for which the anonymous link is created.

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

