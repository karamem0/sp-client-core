---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Select-SPWeb

## SYNOPSIS
Select a site.

## SYNTAX

```
Select-SPWeb [-Web] <WebPipeBind> [-PassThru] [-Includes <String[]>] [<CommonParameters>]
```

## DESCRIPTION
The Select-SPWeb cmdlet set the site which matches the parameter to current.

## EXAMPLES

### Example 1
```
PS C:\> Select-SPWeb -Web 'eaaad9d1-3a34-413c-9c73-f0ecd6bfe91a'
```

Changes the current web by ID.

### Example 2
```
PS C:\> Select-SPWeb -Web '/path/to/site'
```

Changes the current web by URL.

## PARAMETERS

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

### -PassThru
If specified, returns the selected object.

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

### -Web
Indicates the web ID or URL.

```yaml
Type: WebPipeBind
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.PipeBinds.Core.WebPipeBind
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.Core.Web
## NOTES

## RELATED LINKS
