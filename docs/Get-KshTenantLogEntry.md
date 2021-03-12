---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshTenantLogEntry

## SYNOPSIS
Retrieves one or more tenant logs.

## SYNTAX

```
Get-KshTenantLogEntry -BeginDateTime <DateTime> -EndDateTime <DateTime> -Rows <UInt32> [-NoEnumerate]
 [<CommonParameters>]
```

## DESCRIPTION
The Get-KshTenantLogEntry cmdlet retrieves tenant logs.
This cmdlet can be used only when connected to the SharePoint admin center.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshTenantLogEntry -BeginDateTime '2021/01/01 00:00:00' -EndDateTime '2021/01/31 23:59:59' -Rows 100
```

Retrieves hub sites by period.

## PARAMETERS

### -BeginDateTime
Specifies the begin time to search for the logs.

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndDateTime
Specifies the end time to search for the logs.

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoEnumerate
If specified, suppresses to enumerate objects.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Rows
Specifies the number of rows.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.TenantLogEntry

## NOTES

## RELATED LINKS
