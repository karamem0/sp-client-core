---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-SPWebTemplate

## SYNOPSIS
Gets a site template.

## SYNTAX

```
Get-SPWebTemplate -Name <String> -LCID <UInt32> [-DoIncludeCrossLanguage] [-Includes <String[]>]
 [<CommonParameters>]
```

## DESCRIPTION
The Get-SPWeb cmdlet retrieves the site template which matches the parameter.

## EXAMPLES

### Example 1
```
PS C:\> Get-SPWebTemplate -Name 'STS#0' -LCID 1033
```

Gets a site template by name.

## PARAMETERS

### -DoIncludeCrossLanguage
If specified, includes cross language site templates.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Includes
Indicates the property name collection to include in the result object.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LCID
Indicates the LCID.

```yaml
Type: UInt32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Indicates the name.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.Core.WebTemplate
## NOTES

## RELATED LINKS
