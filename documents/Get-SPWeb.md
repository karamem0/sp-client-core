---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-SPWeb

## SYNOPSIS
Gets a sub site.

## SYNTAX

```
Get-SPWeb [[-Web] <WebPipeBind>] [-Includes <String[]>] [<CommonParameters>]
```

## DESCRIPTION
The Get-SPWeb cmdlet retrieves the sub site which matches the parameter.

## EXAMPLES

### Example 1
```
PS C:\> Get-SPWeb -Web 'eaaad9d1-3a34-413c-9c73-f0ecd6bfe91a'
```

Gets the web by ID.

### Example 2
```
PS C:\> Get-SPWeb -Web '/path/to/site'
```

Gets the web by URL.

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

### -Web
Indicates the web ID or URL.

```yaml
Type: WebPipeBind
Parameter Sets: (All)
Aliases:

Required: False
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
