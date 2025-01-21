---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshDrive

## SYNOPSIS
Retrieves one or mode drives from the current site.

## SYNTAX

### ParamSet1
```
Get-KshDrive [-Identity] <Drive> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshDrive [-List] <List> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Get-KshDrive [-DriveId] <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet4
```
Get-KshDrive [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshDrive` cmdlet retrieves one or mode drives from the current site based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshDrive -Identity $drive
```

This example retrieves a drive by identity.

### Example 2
```powershell
PS C:\> Get-KshDrive -List $list
```

This example retrieves a drive by list.

### Example 3
```powershell
PS C:\> Get-KshDrive -DriveId "b!vpvKq3kXeEaww1z6NPnGbKhvcv2QlkNIoGE112ESrYtKvAhAPsWLSLhCqJy8wVDu"
```

This example retrieves a drive by drive ID.

### Example 4
```powershell
PS C:\> Get-KshDrive
```

This example retrieves all drives.

## PARAMETERS

### -DriveId
Specifies the ID of the drive to retrieve.

```yaml
Type: String
Parameter Sets: ParamSet3
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Identity
Specifies the drive to retrieve.

```yaml
Type: Drive
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -List
Specifies the list object to retrieve the drive from.

```yaml
Type: List
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoEnumerate
Indicates that the cmdlet does not enumerate the drive objects.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet4
Aliases:

Required: False
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

### Karamem0.SharePoint.PowerShell.Models.V2.Drive
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V2.Drive
## NOTES

## RELATED LINKS

