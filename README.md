# SPClientCore

[日本語で見る](README.ja-jp.md)

SharePoint Service Module for PowerShell Core

[![Build Status](https://dev.azure.com/karamem0/SPClientCore/_apis/build/status/SPClientCore?branchName=master)](https://dev.azure.com/karamem0/SPClientCore/_build/latest?definitionId=51&branchName=master)
[![License](https://img.shields.io/github/license/karamem0/spclientcore.svg)](https://github.com/karamem0/spclientcore/blob/master/LICENSE)

## Installation

SPClientCore is published to [PowerShell Gallery](https://www.powershellgallery.com/packages/SPClientCore).

## Features

### Works with PowerShell Core

Yes, SPClientCore works with PowerShell Core, also it works with Windows PowerShell. It means that you can use this module on Mac and Linux as well as Windows (of course if PowerShell Core is installed on the machine). <del>There was only a way to run the SharePoint REST API to manage SharePoint Online in non-Windows environments. </del>But SharePoint REST API has a few problems compared to the SharePoint Client Library (CSOM). SPClientCore provides full functionality by making compatible API calls with CSOM.

*(UPDATE) CSOM and PnP PowerShell now supports PowerShell Core.*

### One module, manage all

SPClientCore includes both elements that site admin features and tenant admin features. You can run cmdlets for site admin by connecting to a site (https://tenant.sharepoint.com and its sub URLs), and you can run tenant admin cmdlets for connecting to the SharePoint admin center (https://tenant-admin.sharepoint.com). You can also determine whether you are currently connected to the SharePoint admin center.

### Friendly Naming

CSOM naming is difficult for non-programmers. For example, A site is not "Site" (that is "Web"), A column is not "Column" (that is "Field"). SPClientCore adjusts the naming so that it matches the name used by the user.

### Uses Modern Authentication

SPClientCore supports Azure AD 2.0 authentication (Device Code Grant and Password Grant). If you enable MFA, you can log in with a web browser of another device. If you do not enable MFA, you can log in using your user name and password (admin consent is required).

## Dependencies

- [Microsoft.Extensions.DependencyInjection](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection/5.0.1) (5.0.1)
- [Microsoft.Extensions.DependencyInjection.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection.Abstractions/5.0.0) (5.0.0)
- [Microsoft.IdentityModel.JsonWebTokens](https://www.nuget.org/packages/Microsoft.IdentityModel.JsonWebTokens/6.8.0) (6.8.0)
- [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/12.0.3) (12.0.3)

## Command References

- Login
  - [Connect-KshSite](docs/Connect-KshSite.md)
  - [Get-KshCurrentSite](docs/Get-KshCurrentSite.md)
  - [Get-KshCurrentSiteCollection](docs/Get-KshCurrentSiteCollection.md)
  - [Get-KshCurrentUser](docs/Get-KshCurrentUser.md)
  - [Get-KshCurrentUserProfile](docs/Get-KshCurrentUserProfile.md)
  - [Get-KshCurrentUserProperty](docs/Get-KshCurrentUserProperty.md)
  - [Select-KshSite](docs/Select-KshSite.md)
  - [Test-KshTenantSiteCollection](docs/Test-KshTenantSiteCollection.md)
- Site Administration
  - Alerts
    - [Get-KshAlert](docs/Get-KshAlert.md)
    - [New-KshAlert](docs/New-KshAlert.md)
    - [Remove-KshAlert](docs/Remove-KshAlert.md)
    - [Update-KshAlert](docs/Update-KshAlert.md)
  - App Instances
    - [Get-KshAppInstance](docs/Get-KshAppInstance.md)
  - Attachment Files
    - [Get-KshAttachmentFile](docs/Get-KshAttachmentFile.md)
    - [Open-KshAttachmentFile](docs/Open-KshAttachmentFile.md)
    - [Remove-KshAttachmentFile](docs/Remove-KshAttachmentFile.md)
    - [Save-KshAttachmentFile](docs/Save-KshAttachmentFile.md)
  - Changes
    - [Get-KshChange](docs/Get-KshChange.md)
  - Client Components Properties
    - [Add-KshStorageEntity](docs/Add-KshStorageEntity.md)
    - [Get-KshStorageEntity](docs/Get-KshStorageEntity.md)
    - [Remove-KshStorageEntity](docs/Remove-KshStorageEntity.md)
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
    - [New-KshColumnTaxonomy](docs/New-KshColumnTaxonomy.md)
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
    - [Update-KshColumnTaxonomy](docs/Update-KshColumnTaxonomy.md)
    - [Update-KshColumnText](docs/Update-KshColumnText.md)
    - [Update-KshColumnUrl](docs/Update-KshColumnUrl.md)
    - [Update-KshColumnUser](docs/Update-KshColumnUser.md)
  - Comments
    - [Get-KshComment](docs/Get-KshComment.md)
    - [New-KshComment](docs/New-KshComment.md)
    - [Remove-KshComment](docs/Remove-KshComment.md)
  - Content Types
    - [Get-KshContentType](docs/Get-KshContentType.md)
    - [New-KshContentType](docs/New-KshContentType.md)
    - [Remove-KshContentType](docs/Remove-KshContentType.md)
    - [Update-KshContentType](docs/Update-KshContentType.md)
    - [Initialize-KshContentTypeId](docs/Initialize-KshContentTypeId.md)
    - [Get-KshContentTypeColumn](docs/Get-KshContentTypeColumn.md)
    - [New-KshContentTypeColumn](docs/New-KshContentTypeColumn.md)
    - [Remove-KshContentTypeColumn](docs/Remove-KshContentTypeColumn.md)
    - [Update-KshContentTypeColumn](docs/Update-KshContentTypeColumn.md)
    - [Set-KshContentTypeColumnOrder](docs/Set-KshContentTypeColumnOrder.md)
  - Document Libraries
    - [Get-KshDocumentLibrary](docs/Get-KshDocumentLibrary.md)
  - Document Sets
    - [New-KshDocumentSet](docs/New-KshDocumentSet.md)
  - Document Set Templates
    - [Add-KshDocumentSetAllowedContentType](docs/Add-KshDocumentSetAllowedContentType.md)
    - [Add-KshDocumentSetSharedColumn](docs/Add-KshDocumentSetSharedColumn.md)
    - [Add-KshDocumentSetWelcomePageColumn](docs/Add-KshDocumentSetWelcomePageColumn.md)
    - [Get-KshDocumentSetAllowedContentType](docs/Get-KshDocumentSetAllowedContentType.md)
    - [Get-KshDocumentSetDefaultDocument](docs/Get-KshDocumentSetDefaultDocument.md)
    - [Get-KshDocumentSetSharedColumn](docs/Get-KshDocumentSetSharedColumn.md)
    - [Get-KshDocumentSetWelcomePageColumn](docs/Get-KshDocumentSetWelcomePageColumn.md)
    - [New-KshDocumentSetDefaultDocument](docs/New-KshDocumentSetDefaultDocument.md)
    - [Remove-KshDocumentSetAllowedContentType](docs/Remove-KshDocumentSetAllowedContentType.md)
    - [Remove-KshDocumentSetDefaultDocument](docs/Remove-KshDocumentSetDefaultDocument.md)
    - [Remove-KshDocumentSetSharedColumn](docs/Remove-KshDocumentSetSharedColumn.md)
    - [Remove-KshDocumentSetWelcomePageColumn](docs/Remove-KshDocumentSetWelcomePageColumn.md)
  - Drives
    - [Get-KshDrive](docs/Get-KshDrive.md)
  - Files
    - [Approve-KshFile](docs/Approve-KshFile.md)
    - [Copy-KshFile](docs/Copy-KshFile.md)
    - [Deny-KshFile](docs/Deny-KshFile.md)
    - [Get-KshFile](docs/Get-KshFile.md)
    - [Lock-KshFile](docs/Lock-KshFile.md)
    - [Move-KshFile](docs/Move-KshFile.md)
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
    - [Copy-KshFolder](docs/Copy-KshFolder.md)
    - [Deny-KshFolder](docs/Deny-KshFolder.md)
    - [Get-KshFolder](docs/Get-KshFolder.md)
    - [Move-KshFolder](docs/Move-KshFolder.md)
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
    - [Initialize-KshColumnGeolocationValue](docs/Initialize-KshColumnGeolocationValue.md)
    - [Initialize-KshColumnLookupValue](docs/Initialize-KshColumnLookupValue.md)
    - [Initialize-KshColumnTaxonomyValue](docs/Initialize-KshColumnTaxonomyValue.md)
    - [Initialize-KshColumnUrlValue](docs/Initialize-KshColumnUrlValue.md)
    - [Initialize-KshColumnUserValue](docs/Initialize-KshColumnUserValue.md)
    - [Set-KshColumnTaxonomyValue](docs/Set-KshColumnTaxonomyValue.md)
  - List Templates
    - [Get-KshListTemplate](docs/Get-KshListTemplate.md)
  - Navigation
    - [Get-KshNavigation](docs/Get-KshNavigation.md)
    - [Get-KshNavigationNode](docs/Get-KshNavigationNode.md)
    - [New-KshNavigationNode](docs/New-KshNavigationNode.md)
    - [Remove-KshNavigationNode](docs/Remove-KshNavigationNode.md)
    - [Update-KshNavigationNode](docs/Update-KshNavigationNode.md)
  - Recycle Bin Items
    - [Get-KshRecycleBinItem](docs/Get-KshRecycleBinItem.md)
    - [Move-KshRecycleBinItem](docs/Move-KshRecycleBinItem.md)
    - [Remove-KshRecycleBinItem](docs/Remove-KshRecycleBinItem.md)
    - [Restore-KshRecycleBinItem](docs/Restore-KshRecycleBinItem.md)
  - Regional Settings
    - [Get-KshRegionalSettings](docs/Get-KshRegionalSettings.md)
    - [Update-KshRegionalSettings](docs/Update-KshRegionalSettings.md)
  - Role Assignments
    - [Get-KshRoleAssignment](docs/Get-KshRoleAssignment.md)
    - [New-KshRoleAssignment](docs/New-KshRoleAssignment.md)
    - [Remove-KshRoleAssignment](docs/Remove-KshRoleAssignment.md)
    - [Set-KshUniqueRoleAssignmentEnabled](docs/Set-KshUniqueRoleAssignmentEnabled.md)
  - Role Definitions
    - [Get-KshRoleDefinition](docs/Get-KshRoleDefinition.md)
    - [New-KshRoleDefinition](docs/New-KshRoleDefinition.md)
    - [Remove-KshRoleDefinition](docs/Remove-KshRoleDefinition.md)
    - [Update-KshRoleDefinition](docs/Update-KshRoleDefinition.md)
    - [Initialize-KshBasePermission](docs/Initialize-KshBasePermission.md)
  - Sharing Links
    - [New-KshAnonymousLink](docs/New-KshAnonymousLink.md)
    - [Remove-KshAnonymousLink](docs/Remove-KshAnonymousLink.md)
    - [New-KshOrganizationSharingLink](docs/New-KshOrganizationSharingLink.md)
    - [Remove-KshOrganizationSharingLink](docs/Remove-KshOrganizationSharingLink.md)
    - [Test-KshSharingLink](docs/New-KshSharingLink.md)
  - Sites
    - [Get-KshSite](docs/Get-KshSite.md)
    - [New-KshSite](docs/New-KshSite.md)
    - [Remove-KshSite](docs/Remove-KshSite.md)
    - [Update-KshSite](docs/Update-KshSite.md)
  - Site Collection Apps
    - [Get-KshSiteCollectionApp](docs/Get-KshSiteCollectionApp.md)
    - [Install-KshSiteCollectionApp](docs/Install-KshSiteCollectionApp.md)
    - [New-KshSiteCollectionApp](docs/New-KshSiteCollectionApp.md)
    - [Publish-KshSiteCollectionApp](docs/Publish-KshSiteCollectionApp.md)
    - [Remove-KshSiteCollectionApp](docs/Remove-KshSiteCollectionApp.md)
    - [Uninstall-KshSiteCollectionApp](docs/Uninstall-KshSiteCollectionApp.md)
    - [Unpublish-KshSiteCollectionApp](docs/Unpublish-KshSiteCollectionApp.md)
  - Site Collection App Catalogs
    - [Add-KshSiteCollectionAppCatalog](docs/Add-KshSiteCollectionAppCatalog.md)
    - [Get-KshSiteCollectionAppCatalog](docs/Get-KshSiteCollectionAppCatalog.md)
    - [Remove-KshSiteCollectionAppCatalog](docs/Remove-KshSiteCollectionAppCatalog.md)
  - Site Collection Features
    - [Add-KshSiteCollectionFeature](docs/Add-KshSiteCollectionFeature.md)
    - [Get-KshSiteCollectionFeature](docs/Get-KshSiteCollectionFeature.md)
    - [Remove-KshSiteCollectionFeature](docs/Remove-KshSiteCollectionFeature.md)
  - Site Features
    - [Add-KshSiteFeature](docs/Add-KshSiteFeature.md)
    - [Get-KshSiteFeature](docs/Get-KshSiteFeature.md)
    - [Remove-KshSiteFeature](docs/Remove-KshSiteFeature.md)
  - Site Pages
    - [Add-KshSitePage](docs/Add-KshSitePage.md)
    - [Remove-KshSitePage](docs/Remove-KshSitePage.md)
    - [Set-KshSitePage](docs/Set-KshSitePage.md)
  - Site Templates
    - [Get-KshSiteTemplate](docs/Get-KshSiteTemplate.md)
  - Tenant Apps
    - [Get-KshTenantApp](docs/Get-KshTenantApp.md)
    - [Install-KshTenantApp](docs/Install-KshTenantApp.md)
    - [New-KshTenantApp](docs/New-KshTenantApp.md)
    - [Publish-KshTenantApp](docs/Publish-KshTenantApp.md)
    - [Remove-KshTenantApp](docs/Remove-KshTenantApp.md)
    - [Uninstall-KshTenantApp](docs/Uninstall-KshTenantApp.md)
    - [Unpublish-KshTenantApp](docs/Unpublish-KshTenantApp.md)
  - Tenant Settings
    - [Get-KshTenantSettings](docs/Get-KshTenantSettings.md)
  - Users
    - [Get-KshUser](docs/Get-KshUser.md)
    - [New-KshUser](docs/New-KshUser.md)
    - [Remove-KshUser](docs/Remove-KshUser.md)
    - [Resolve-KshUser](docs/Resolve-KshUser.md)
    - [Update-KshUser](docs/Update-KshUser.md)
  - User Permissions
    - [Get-KshUserPermission](docs/Get-KshUserPermission.md)
  - User Properties
    - [Get-KshUserProperty](docs/Get-KshUserProperty.md)
  - Views
    - [Get-KshView](docs/Get-KshView.md)
    - [New-KshView](docs/New-KshView.md)
    - [Remove-KshView](docs/Remove-KshView.md)
    - [Update-KshView](docs/Update-KshView.md)
    - [Add-KshViewColumn](docs/Add-KshViewColumn.md)
    - [Get-KshViewColumn](docs/Get-KshViewColumn.md)
    - [Move-KshViewColumn](docs/Move-KshViewColumn.md)
    - [Remove-KshViewColumn](docs/Remove-KshViewColumn.md)
  - Webhooks
    - [Get-KshSubscription](docs/Get-KshSubscription.md)
    - [New-KshSubscription](docs/New-KshSubscription.md)
    - [Remove-KshSubscription](docs/Remove-KshSubscription.md)
    - [Update-KshSubscription](docs/Update-KshSubscription.md)
- Tenant Administration
  - Deleted Site Collections
    - [Get-KshTenantDeletedPersonalSiteCollection](docs/Get-KshTenantDeletedPersonalSiteCollection.md)
    - [Get-KshTenantDeletedSiteCollection](docs/Get-KshTenantDeletedSiteCollection.md)
    - [Remove-KshTenantDeletedSiteCollection](docs/Remove-KshTenantDeletedSiteCollection.md)
    - [Restore-KshTenantDeletedSiteCollection](docs/Restore-KshTenantDeletedSiteCollection.md)
  - Home site
    - [Get-KshTenantHomeSite](docs/Get-KshTenantHomeSite.md)
    - [Remove-KshTenantHomeSite](docs/Remove-KshTenantHomeSite.md)
    - [Set-KshTenantHomeSite](docs/Set-KshTenantHomeSite.md)
  - Hub sites
    - [Get-KshTenantHubSite](docs/Get-KshTenantHubSite.md)
    - [New-KshTenantHubSite](docs/New-KshTenantHubSite.md)
    - [Remove-KshTenantHubSite](docs/Remove-KshTenantHubSite.md)
    - [Update-KshTenantHubSite](docs/Update-KshTenantHubSite.md)
  - Office 365 CDN
    - [Get-KshTenantCdnEnabled](docs/Get-KshTenantCdnEnabled.md)
    - [Set-KshTenantCdnEnabled](docs/Set-KshTenantCdnEnabled.md)
    - [Add-KshTenantCdnOrigin](docs/Get-KshTenantCdnOrigin.md)
    - [Get-KshTenantCdnOrigin](docs/Set-KshTenantCdnOrigin.md)
    - [Remove-KshTenantCdnOrigin](docs/Remove-KshTenantCdnOrigin.md)
    - [Get-KshTenantCdnPolicy](docs/Get-KshTenantCdnPolicy.md)
    - [Set-KshTenantCdnPolicy](docs/Set-KshTenantCdnPolicy.md)
  - Organization News Sites
    - [Get-KshTenantOrganizationNewsSite](docs/Get-KshTenantOrganizationNewsSite.md)
    - [Add-KshTenantOrganizationNewsSite](docs/Add-KshTenantOrganizationNewsSite.md)
    - [Remove-KshTenantOrganizationNewsSite](docs/Remove-KshTenantOrganizationNewsSite.md)
  - Site Collections
    - [Get-KshSiteCollection](docs/Get-KshSiteCollection.md)
    - [Get-KshTenantSiteCollection](docs/Get-KshTenantSiteCollection.md)
    - [Lock-KshTenantSiteCollection](docs/Lock-KshTenantSiteCollection.md)
    - [New-KshTenantSiteCollection](docs/New-KshTenantSiteCollection.md)
    - [Remove-KshTenantSiteCollection](docs/Remove-KshTenantSiteCollection.md)
    - [Unlock-KshTenantSiteCollection](docs/Unlock-KshTenantSiteCollection.md)
    - [Update-KshTenantSiteCollection](docs/Update-KshTenantSiteCollection.md)
  - Site Templates
    - [Get-KshTenantSiteTemplate](docs/Get-KshTenantSiteTemplate.md)
  - Tenant
    - [Get-KshTenant](docs/Get-KshTenant.md)
    - [Set-KshTenant](docs/Set-KshTenant.md)
  - Themes
    - [Get-KshTenantTheme](docs/Get-KshTenantTheme.md)
    - [New-KshTenantTheme](docs/New-KshTenantTheme.md)
    - [Remove-KshTenantTheme](docs/Remove-KshTenantTheme.md)
    - [Update-KshTenantTheme](docs/Update-KshTenantTheme.md)
- Managed Metadata
  - Custom Properties
    - [Add-KshTermCustomProperty](docs/Add-KshTermCustomProperty.md)
    - [Remove-KshTermCustomProperty](docs/Remove-KshTermCustomProperty.md)
    - [Add-KshTermLocalCustomProperty](docs/Add-KshTermLocalCustomProperty.md)
    - [Remove-KshTermLocalCustomProperty](docs/Remove-KshTermLocalCustomProperty.md)
  - Terms
    - [Copy-KshTerm](docs/Copy-KshTerm.md)
    - [Disable-KshTerm](docs/Disable-KshTerm.md)
    - [Enable-KshTerm](docs/Enable-KshTerm.md)
    - [Get-KshTerm](docs/Get-KshTerm.md)
    - [Merge-KshTerm](docs/Merge-KshTerm.md)
    - [Move-KshTerm](docs/Move-KshTerm.md)
    - [New-KshTerm](docs/New-KshTerm.md)
    - [Remove-KshTerm](docs/Remove-KshTerm.md)
    - [Update-KshTerm](docs/Update-KshTerm.md)
    - [Get-KshTermDescription](docs/Get-KshTermDescription.md)
    - [Set-KshTermDescription](docs/Set-KshTermDescription.md)
  - Term Groups
    - [Get-KshTermGroup](docs/Get-KshTermGroup.md)
    - [New-KshTermGroup](docs/New-KshTermGroup.md)
    - [Remove-KshTermGroup](docs/Remove-KshTermGroup.md)
    - [Update-KshTermGroup](docs/Update-KshTermGroup.md)
  - Term Labels
    - [Get-KshTermLabel](docs/Get-KshTermLabel.md)
    - [New-KshTermLabel](docs/New-KshTermLabel.md)
    - [Remove-KshTermLabel](docs/Remove-KshTermLabel.md)
    - [Update-KshTermLabel](docs/Update-KshTermLabel.md)
  - Term Sets
    - [Get-KshTermSet](docs/Get-KshTermSet.md)
    - [New-KshTermSet](docs/New-KshTermSet.md)
    - [Remove-KshTermSet](docs/Remove-KshTermSet.md)
    - [Update-KshTermSet](docs/Update-KshTermSet.md)
  - Term Store
    - [Get-KshTermStore](docs/Get-KshTermStore.md)
    - [Update-KshTermStore](docs/Update-KshTermStore.md)
    - [Add-KshTermStoreLanguage](docs/Add-KshTermStoreLanguage.md)
    - [Remove-KshTermStoreLanguage](docs/Remove-KshTermStoreLanguage.md)
