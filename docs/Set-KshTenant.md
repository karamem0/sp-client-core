---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Set-KshTenant

## SYNOPSIS
Changes the tenant.

## SYNTAX

```
Set-KshTenant [-DisplayStartASiteOption <Boolean>] [-ExternalServicesEnabled <Boolean>]
 [-NoAccessRedirectUrl <String>] [-OfficeClientAdalDisabled <Boolean>]
 [-ProvisionSharedWithEveryoneFolder <Boolean>] [-RequireAcceptingAccountMatchInvitedAccount <Boolean>]
 [-SearchResolveExactEmailOrUpn <Boolean>] [-SharingCapability <SharingCapabilities>]
 [-ShowAllUsersClaim <Boolean>] [-ShowEveryoneClaim <Boolean>]
 [-ShowEveryoneExceptExternalUsersClaim <Boolean>] [-SignInAccelerationDomain <String>]
 [-StartASiteFormUrl <String>] [-UsePersistentCookiesForExplorerView <Boolean>] [<CommonParameters>]
```

## DESCRIPTION
The Set-KshTermDescription cmdlet changes properties of the tenant.

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-KshTenant -SharingCapability Disabled
```

Changes properties of the tenant.

## PARAMETERS

### -DisplayStartASiteOption
Specifies whether to display \[Start a site\] option.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExternalServicesEnabled
Specifies whether to enable external services.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoAccessRedirectUrl
Specifies the redirect URL when users cannot access.

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

### -OfficeClientAdalDisabled
Specifies whether to disable to using ADAL when sign in with Office client.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProvisionSharedWithEveryoneFolder
Specifies whether to provision \[Shared with Everyone\] folder.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequireAcceptingAccountMatchInvitedAccount
Specifies whether to require the accepting account to match the invited account.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SearchResolveExactEmailOrUpn
Specifies whether to resolve the exact e-mail or UPN when searching.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SharingCapability
Specifies the sharing capability.

```yaml
Type: SharingCapabilities
Parameter Sets: (All)
Aliases:
Accepted values: Disabled, ExternalUserSharingOnly, ExternalUserAndGuestSharing, ExistingExternalUserSharingOnly

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShowAllUsersClaim
Specifies whether to show \[All users\] claim.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShowEveryoneClaim
Specifies whether to show \[Everyone\] claim.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShowEveryoneExceptExternalUsersClaim
Specifies whether to show \[Everyone except external users\] claim.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SignInAccelerationDomain
Specifies the sign-in acceleration domain.

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

### -StartASiteFormUrl
Specifies the \[Start a site\] form URL.

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

### -UsePersistentCookiesForExplorerView
Specifies whether to use persistent cookies for the explorer view.

```yaml
Type: Boolean
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

### System.Void

## NOTES

## RELATED LINKS
