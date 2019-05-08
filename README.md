# SPClientCore

SharePoint Service Module for PowerShell Core

[![Build status](https://ci.appveyor.com/api/projects/status/etlu54thystfp79a?svg=true)](https://ci.appveyor.com/project/karamem0/spclientcore)
[![License](https://img.shields.io/github/license/karamem0/spclientcore.svg)](https://github.com/karamem0/spclientcore/blob/master/LICENSE)

## Installation

SPClientCore is published to [PowerShell Gallery](https://www.powershellgallery.com/packages/SPClientCore).

## Features

### Works with PowerShell Core

Yes, SPClientCore works with PowerShell Core. And it does not work with Windows PowerShell. It means that you can use this module on Mac and Linux as well as Windows (of course if PowerShell Core is installed on the machine). There was only a way to run the SharePoint REST API to manage SharePoint Online in non-Windows environments. But SharePoint REST API has a few problems compared to the SharePoint Client Library (CSOM). SPClientCore provides full functionality by making compatible API calls with CSOM.

### One module, manage all

PnP PowerShell has only site admin features, and SharePoint Online Management Shell has only tenant admin features. SPClientCore includes both elements. You can run cmdlets for site admin by connecting to a site (https://tenant.sharepoint.com and its sub URLs), and you can run tenant admin cmdlets for connecting to the SharePoint admin center (https://tenant-admin.sharepoint.com). You can also determine whether you are currently connected to the SharePoint admin center.

### Friendly Naming

CSOM naming is difficult for non-programmers. For example, A site is not "Site" (that is "Web"), A column is not "Column" (that is "Field"). SPClientCore adjusts the naming so that it matches the name used by the user.

### Uses Modern Authentication

SPClientCore supports Azure AD 2.0 authentication (Device Code Grant and Password Grant). If you enable MFA, you can log in with a web browser of another device. If you do not enable MFA, you can log in using your user name and password (admin consent is required).

## Dependencies

- [Microsoft.Extensions.DependencyInjection](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection/2.2.0) (2.2.0)
- [System.IdentityModel.Tokens.Jwt](https://www.nuget.org/packages/System.IdentityModel.Tokens.Jwt/5.4.0) (5.4.0)
- [System.Management.Automation](https://www.nuget.org/packages/System.Management.Automation/6.1.0) (6.1.0)

## Command References

- Login
  - [Connect-KshSite](docs/Connect-KshSite.md)
  - [Get-KshCurrentSite](docs/Connect-KshCurrentSite.md)
  - [Get-KshCurrentSiteCollection](docs/Connect-KshCurrentSiteCollection.md)
  - [Get-KshCurrentUser](docs/Connect-KshCurrentUser.md)
  - [Select-KshSite](docs/Select-KshSite.md)
  - [Test-KshTenantSiteCollection](docs/Test-KshTenantSiteCollection.md)
- Site Administration
  - Attachment Files
    - [Get-KshAttachmentFile](docs/Get-KshAttachmentFile.md)
    - [Open-KshAttachmentFile](docs/Open-KshAttachmentFile.md)
    - [Remove-KshAttachmentFile](docs/Remove-KshAttachmentFile.md)
    - [Save-KshAttachmentFile](docs/Save-KshAttachmentFile.md)
  - Columns
    - [Get-KshColumn](docs/Get-KshColumn.md)
    - [New-KshColumnBoolean](docs/New-KshColumnBoolean.md)
    - [New-KshColumnCalculated](docs/New-KshColumnCalculated.md)
    - [New-KshColumnChoice](docs/New-KshColumnChoice.md)
    - [New-KshColumnCurrency](docs/New-KshColumnCurrency.md)
    - [New-KshColumnDateTime](docs/New-KshColumnDateTime.md)
    - [New-KshColumnGeolocation](docs/New-KshColumnGeolocation.md)
    - [New-KshColumnLookup](docs/New-KshColumnLookup.md)
    - [New-KshColumnMultiChoice](docs/New-KshColumnMultiChoice.md)
    - [New-KshColumnMultiLineText](docs/New-KshColumnMultiLineText.md)
    - [New-KshColumnNumber](docs/New-KshColumnNumber.md)
    - [New-KshColumnText](docs/New-KshColumnText.md)
    - [New-KshColumnUrl](docs/New-KshColumnUrl.md)
    - [New-KshColumnUser](docs/New-KshColumnUser.md)
    - [Remove-KshColumn](docs/Remove-KshColumn.md)
    - [Update-KshColumnBoolean](docs/Update-KshColumnBoolean.md)
    - [Update-KshColumnCalculated](docs/Update-KshColumnCalculated.md)
    - [Update-KshColumnChoice](docs/Update-KshColumnChoice.md)
    - [Update-KshColumnCurrency](docs/Update-KshColumnCurrency.md)
    - [Update-KshColumnDateTime](docs/Update-KshColumnDateTime.md)
    - [Update-KshColumnGeolocation](docs/Update-KshColumnGeolocation.md)
    - [Update-KshColumnLookup](docs/Update-KshColumnLookup.md)
    - [Update-KshColumnMultiChoice](docs/Update-KshColumnMultiChoice.md)
    - [Update-KshColumnMultiLineText](docs/Update-KshColumnMultiLineText.md)
    - [Update-KshColumnNumber](docs/Update-KshColumnNumber.md)
    - [Update-KshColumnText](docs/Update-KshColumnText.md)
    - [Update-KshColumnUrl](docs/Update-KshColumnUrl.md)
    - [Update-KshColumnUser](docs/Update-KshColumnUser.md)
  - Content Types
    - [Get-KshContentType](docs/Get-KshContentType.md)
    - [New-KshContentType](docs/New-KshContentType.md)
    - [Remove-KshContentType](docs/Remove-KshContentType.md)
    - [Update-KshContentType](docs/Update-KshContentType.md)
    - [New-KshContentTypeId](docs/New-KshContentTypeId.md)
    - [Get-KshContentTypeColumn](docs/Get-KshContentTypeColumn.md)
    - [New-KshContentTypeColumn](docs/New-KshContentTypeColumn.md)
    - [Remove-KshContentTypeColumn](docs/Remove-KshContentTypeColumn.md)
    - [Update-KshContentTypeColumn](docs/Update-KshContentTypeColumn.md)
  - Files
    - [Approve-KshFile](docs/Approve-KshFile.md)
    - [Deny-KshFile](docs/Deny-KshFile.md)
    - [Get-KshFile](docs/Get-KshFile.md)
    - [Lock-KshFile](docs/Lock-KshFile.md)
    - [New-KshFile](docs/New-KshFile.md)
    - [Open-KshFile](docs/Open-KshFile.md)
    - [Publish-KshFile](docs/Publish-KshFile.md)
    - [Remove-KshFile](docs/Remove-KshFile.md)
    - [Save-KshFile](docs/Save-KshFile.md)
    - [Unlock-KshFile](docs/Unlock-KshFile.md)
    - [Unpublish-KshFile](docs/Unpublish-KshFile.md)
  - File Versions
    - [Get-KshFileVersion](docs/Get-KshFileVersion.md)
    - [Remove-KshFileVersion](docs/Remove-KshFileVersion.md)
    - [Restore-KshFileVersion](docs/Restore-KshFileVersion.md)
  - Folders
    - [Approve-KshFolder](docs/Approve-KshFolder.md)
    - [Deny-KshFolder](docs/Deny-KshFolder.md)
    - [Get-KshFolder](docs/Get-KshFolder.md)
    - [New-KshFolder](docs/New-KshFolder.md)
    - [Remove-KshFolder](docs/Remove-KshFolder.md)
    - [Suspend-KshFolder](docs/Suspend-KshFolder.md)
    - [Update-KshFolder](docs/Update-KshFolder.md)
  - Groups
    - [Get-KshGroup](docs/Get-KshGroup.md)
    - [New-KshGroup](docs/New-KshGroup.md)
    - [Remove-KshGroup](docs/Remove-KshGroup.md)
    - [Update-KshGroup](docs/Update-KshGroup.md)
    - [Add-KshGroupMember](docs/Add-KshGroupMember.md)
    - [Get-KshGroupMember](docs/Get-KshGroupMember.md)
    - [Remove-KshGroupMember](docs/Remove-KshGroupMember.md)
    - [Get-KshGroupOwner](docs/Get-KshGroupOwner.md)
    - [Set-KshGroupOwner](docs/Set-KshGroupOwner.md)
  - Lists
    - [Get-KshList](docs/Get-KshList.md)
    - [New-KshList](docs/New-KshList.md)
    - [Remove-KshList](docs/Remove-KshList.md)
    - [Update-KshList](docs/Update-KshList.md)
  - List Items
    - [Approve-KshListItem](docs/Approve-KshListItem.md)
    - [Deny-KshListItem](docs/Deny-KshListItem.md)
    - [Get-KshListItem](docs/Get-KshListItem.md)
    - [New-KshListItem](docs/New-KshListItem.md)
    - [Remove-KshListItem](docs/Remove-KshListItem.md)
    - [Suspend-KshListItem](docs/Suspend-KshListItem.md)
    - [Update-KshListItem](docs/Update-KshListItem.md)
    - [New-KshColumnGeolocationValue](docs/New-KshColumnGeolocationValue.md)
    - [New-KshColumnLookupValue](docs/New-KshColumnLookupValue.md)
    - [New-KshColumnUrlValue](docs/New-KshColumnUrlValue.md)
    - [New-KshColumnUserValue](docs/New-KshColumnUserValue.md)
  - List Templates
    - [Get-KshListTemplate](docs/Get-KshListTemplate.md)
  - Recycle Bin Items
    - [Get-KshRecycleBinItem](docs/Get-KshRecycleBinItem.md)
    - [Remove-KshRecycleBinItem](docs/Remove-KshRecycleBinItem.md)
    - [Restore-KshRecycleBinItem](docs/Remove-KshRecycleBinItem.md)
  - Site
    - [Get-KshSite](docs/Get-KshSite.md)
    - [New-KshSite](docs/New-KshSite.md)
    - [Remove-KshSite](docs/Remove-KshSite.md)
    - [Update-KshSite](docs/Update-KshSite.md)
  - Site Templates
    - [Get-KshSiteTemplate](docs/Get-KshSiteTemplate.md)
  - Users
    - [Get-KshUser](docs/Get-KshUser.md)
    - [New-KshUser](docs/New-KshUser.md)
    - [Remove-KshUser](docs/Remove-KshUser.md)
    - [Update-KshUser](docs/Update-KshUser.md)
  - Views
    - [Get-KshView](docs/Get-KshView.md)
    - [New-KshView](docs/New-KshView.md)
    - [Remove-KshView](docs/Remove-KshView.md)
    - [Update-KshView](docs/Update-KshView.md)
    - [Add-KshViewColumn](docs/Add-KshViewColumn.md)
    - [Get-KshViewColumn](docs/Get-KshViewColumn.md)
    - [Move-KshViewColumn](docs/Move-KshViewColumn.md)
    - [Remove-KshViewColumn](docs/Remove-KshViewColumn.md)
- Tenant Administration
  - Deleted Site Collections
    - [Get-KshTenantDeletedSiteCollection](docs/Get-KshTenantDeletedSiteCollection.md)
    - [Remove-KshTenantDeletedSiteCollection](docs/Remove-KshTenantDeletedSiteCollection.md)
    - [Restore-KshTenantDeletedSiteCollection](docs/Restore-KshTenantDeletedSiteCollection.md)
  - Site Collections
    - [Get-KshTenantSiteCollection](docs/Get-KshTenantSiteCollection.md)
    - [Lock-KshTenantSiteCollection](docs/Lock-KshTenantSiteCollection.md)
    - [New-KshTenantSiteCollection](docs/New-KshTenantSiteCollection.md)
    - [Remove-KshTenantSiteCollection](docs/Remove-KshTenantSiteCollection.md)
    - [Unlock-KshTenantSiteCollection](docs/Unlock-KshTenantSiteCollection.md)
    - [Update-KshTenantSiteCollection](docs/Update-KshTenantSiteCollection.md)
  - Site Templates
    - [Get-KshTenantSiteTemplate](docs/Get-KshTenantSiteTemplate.md)
  - Themes
    - [Get-KshTenantTheme](docs/Get-KshTenantTheme.md)
    - [New-KshTenantTheme](docs/New-KshTenantTheme.md)
    - [Remove-KshTenantTheme](docs/Remove-KshTenantTheme.md)
    - [Update-KshTenantTheme](docs/Update-KshTenantTheme.md)
