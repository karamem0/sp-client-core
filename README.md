# SPClientCore

[日本語で見る](README.ja-jp.md)

SharePoint Service Module for PowerShell

[![.github/workflows/workflow.yml](https://github.com/karamem0/sp-client-core/actions/workflows/workflow.yml/badge.svg)](https://github.com/karamem0/sp-client-core/actions/workflows/workflow.yml)
[![License](https://img.shields.io/github/license/karamem0/sp-client-core.svg)](https://github.com/karamem0/sp-client-core/blob/main/LICENSE)

## Installation

SPClientCore is published to [PowerShell Gallery](https://www.powershellgallery.com/packages/SPClientCore).

## Features

### Works with PowerShell 7

Yes, SPClientCore works with PowerShell 7, also it works with Windows PowerShell. It means that you can use this module on Mac and Linux as well as Windows (of course if PowerShell 7 is installed on the machine). <del>There was only a way to run the SharePoint REST API to manage SharePoint Online in non-Windows environments. </del>But SharePoint REST API has a few problems compared to the SharePoint Client Library (CSOM). SPClientCore provides full functionality by making compatible API calls with CSOM.

*(UPDATE) CSOM and PnP PowerShell now supports PowerShell 7.*

### One module, manage all

SPClientCore includes both elements that site admin features and tenant admin features. You can run cmdlets for site admin by connecting to a site (https://tenant.sharepoint.com and its sub URLs), and you can run tenant admin cmdlets for connecting to the SharePoint admin center (https://tenant-admin.sharepoint.com). You can also determine whether you are currently connected to the SharePoint admin center.

### Friendly Naming

CSOM naming is difficult for non-programmers. For example, A site is not "Site" (that is "Web"), A column is not "Column" (that is "Field"). SPClientCore adjusts the naming so that it matches the name used by the user.

### Uses Modern Authentication

SPClientCore supports Azure AD 2.0 authentication (Device Code Grant and Password Grant). If you enable MFA, you can log in with a web browser of another device. If you do not enable MFA, you can log in using your user name and password (admin consent is required).

## Dependencies

- [Microsoft.ApplicationInsights](https://www.nuget.org/packages/Microsoft.ApplicationInsights/2.21.0) (2.21.0)
- [Microsoft.Extensions.Configuration.Json](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Json/8.0.0) (8.0.0)
- [Microsoft.Extensions.Configuration.EnvironmentVariables](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.EnvironmentVariables/8.0.0) (8.0.0)
- [Microsoft.Extensions.DependencyInjection](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection/8.0.0) (8.0.0)
- [Microsoft.Extensions.DependencyInjection.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection.Abstractions/8.0.1) (8.0.1)
- [Microsoft.Extensions.Options.ConfigurationExtensions](https://www.nuget.org/packages/Microsoft.Extensions.Options.ConfigurationExtensions/8.0.0) (8.0.0)
- [Microsoft.IdentityModel.JsonWebTokens](https://www.nuget.org/packages/Microsoft.IdentityModel.JsonWebTokens/7.5.0) (8.1.0)
- [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/13.0.3) (13.0.3)
- [PowerShellStandard.Library](https://www.nuget.org/packages/PowerShellStandard.Library/5.1.1) (5.1.1)

## Command References

- Login
  - [Connect-KshSite](docs/Connect-KshSite.md)
  - [Disconnect-KshSite](docs/Disconnect-KshSite.md)
  - [Get-KshCurrentConnection](docs/Get-KshCurrentConnection.md)
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
    - [Add-KshAlert](docs/Add-KshAlert.md)
    - [Remove-KshAlert](docs/Remove-KshAlert.md)
    - [Set-KshAlert](docs/Set-KshAlert.md)
  - App Instances
    - [Get-KshAppInstance](docs/Get-KshAppInstance.md)
  - Attachment Files
    - [Get-KshAttachmentFile](docs/Get-KshAttachmentFile.md)
    - [Remove-KshAttachmentFile](docs/Remove-KshAttachmentFile.md)
    - [Open-KshAttachmentFile](docs/Open-KshAttachmentFile.md)
    - [Save-KshAttachmentFile](docs/Save-KshAttachmentFile.md)
  - Changes
    - [Get-KshChange](docs/Get-KshChange.md)
  - Client Components Properties
    - [Get-KshStorageEntity](docs/Get-KshStorageEntity.md)
    - [Add-KshStorageEntity](docs/Add-KshStorageEntity.md)
    - [Remove-KshStorageEntity](docs/Remove-KshStorageEntity.md)
  - Columns
    - [Get-KshColumn](docs/Get-KshColumn.md)
    - [Add-KshColumnBoolean](docs/Add-KshColumnBoolean.md)
    - [Add-KshColumnCalculated](docs/Add-KshColumnCalculated.md)
    - [Add-KshColumnChoice](docs/Add-KshColumnChoice.md)
    - [Add-KshColumnCurrency](docs/Add-KshColumnCurrency.md)
    - [Add-KshColumnDateTime](docs/Add-KshColumnDateTime.md)
    - [Add-KshColumnGeolocation](docs/Add-KshColumnGeolocation.md)
    - [Add-KshColumnImage](docs/Add-KshColumnImage.md)
    - [Add-KshColumnLookup](docs/Add-KshColumnLookup.md)
    - [Add-KshColumnMultiChoice](docs/Add-KshColumnMultiChoice.md)
    - [Add-KshColumnMultiLineText](docs/Add-KshColumnMultiLineText.md)
    - [Add-KshColumnNumber](docs/Add-KshColumnNumber.md)
    - [Add-KshColumnTaxonomy](docs/Add-KshColumnTaxonomy.md)
    - [Add-KshColumnText](docs/Add-KshColumnText.md)
    - [Add-KshColumnUrl](docs/Add-KshColumnUrl.md)
    - [Add-KshColumnUser](docs/Add-KshColumnUser.md)
    - [Remove-KshColumn](docs/Remove-KshColumn.md)
    - [Set-KshColumnBoolean](docs/Set-KshColumnBoolean.md)
    - [Set-KshColumnCalculated](docs/Set-KshColumnCalculated.md)
    - [Set-KshColumnChoice](docs/Set-KshColumnChoice.md)
    - [Set-KshColumnCurrency](docs/Set-KshColumnCurrency.md)
    - [Set-KshColumnDateTime](docs/Set-KshColumnDateTime.md)
    - [Set-KshColumnGeolocation](docs/Set-KshColumnGeolocation.md)
    - [Set-KshColumnImage](docs/Set-KshColumnImage.md)
    - [Set-KshColumnLookup](docs/Set-KshColumnLookup.md)
    - [Set-KshColumnMultiChoice](docs/Set-KshColumnMultiChoice.md)
    - [Set-KshColumnMultiLineText](docs/Set-KshColumnMultiLineText.md)
    - [Set-KshColumnNumber](docs/Set-KshColumnNumber.md)
    - [Set-KshColumnTaxonomy](docs/Set-KshColumnTaxonomy.md)
    - [Set-KshColumnText](docs/Set-KshColumnText.md)
    - [Set-KshColumnUrl](docs/Set-KshColumnUrl.md)
    - [Set-KshColumnUser](docs/Set-KshColumnUser.md)
  - Comments
    - [Get-KshComment](docs/Get-KshComment.md)
    - [Add-KshComment](docs/Add-KshComment.md)
    - [Remove-KshComment](docs/Remove-KshComment.md)
    - [Enable-KshComment](docs/Enable-KshComment.md)
    - [Disable-KshComment](docs/Disable-KshComment.md)
  - Content Types
    - [Get-KshContentType](docs/Get-KshContentType.md)
    - [Add-KshContentType](docs/Add-KshContentType.md)
    - [Remove-KshContentType](docs/Remove-KshContentType.md)
    - [Set-KshContentType](docs/Set-KshContentType.md)
    - [New-KshContentTypeId](docs/New-KshContentTypeId.md)
    - [Get-KshContentTypeColumn](docs/Get-KshContentTypeColumn.md)
    - [Add-KshContentTypeColumn](docs/Add-KshContentTypeColumn.md)
    - [Remove-KshContentTypeColumn](docs/Remove-KshContentTypeColumn.md)
    - [Set-KshContentTypeColumn](docs/Set-KshContentTypeColumn.md)
    - [Set-KshContentTypeColumnOrder](docs/Set-KshContentTypeColumnOrder.md)
  - Document Libraries
    - [Get-KshDocumentLibrary](docs/Get-KshDocumentLibrary.md)
  - Document Sets
    - [Add-KshDocumentSet](docs/Add-KshDocumentSet.md)
  - Document Set Templates
    - [Get-KshDocumentSetAllowedContentType](docs/Get-KshDocumentSetAllowedContentType.md)
    - [Add-KshDocumentSetAllowedContentType](docs/Add-KshDocumentSetAllowedContentType.md)
    - [Remove-KshDocumentSetAllowedContentType](docs/Remove-KshDocumentSetAllowedContentType.md)
    - [Add-KshDocumentSetDefaultDocument](docs/Add-KshDocumentSetDefaultDocument.md)
    - [Get-KshDocumentSetDefaultDocument](docs/Get-KshDocumentSetDefaultDocument.md)
    - [Remove-KshDocumentSetDefaultDocument](docs/Remove-KshDocumentSetDefaultDocument.md)
    - [Get-KshDocumentSetSharedColumn](docs/Get-KshDocumentSetSharedColumn.md)
    - [Add-KshDocumentSetSharedColumn](docs/Add-KshDocumentSetSharedColumn.md)
    - [Remove-KshDocumentSetSharedColumn](docs/Remove-KshDocumentSetSharedColumn.md)
    - [Add-KshDocumentSetWelcomePageColumn](docs/Add-KshDocumentSetWelcomePageColumn.md)
    - [Get-KshDocumentSetWelcomePageColumn](docs/Get-KshDocumentSetWelcomePageColumn.md)
    - [Remove-KshDocumentSetWelcomePageColumn](docs/Remove-KshDocumentSetWelcomePageColumn.md)
  - Drives
    - [Get-KshDrive](docs/Get-KshDrive.md)
  - Drive Items
    - [Get-KshDriveItem](docs/Get-KshDriveItem.md)
  - External Sharing
    - [Get-KshSharingInfo](docs/Get-KshSharingInfo.md)
    - [Get-KshSharingSettings](docs/Get-KshSharingSettings.md)
    - [Test-KshExternalUserSharing](docs/Test-KshExternalUserSharing.md)
  - Files
    - [Get-KshFile](docs/Get-KshFile.md)
    - [Add-KshFile](docs/Add-KshFile.md)
    - [Remove-KshFile](docs/Remove-KshFile.md)
    - [Open-KshFile](docs/Open-KshFile.md)
    - [Save-KshFile](docs/Save-KshFile.md)
    - [Copy-KshFile](docs/Copy-KshFile.md)
    - [Move-KshFile](docs/Move-KshFile.md)
    - [Approve-KshFile](docs/Approve-KshFile.md)
    - [Deny-KshFile](docs/Deny-KshFile.md)
    - [Lock-KshFile](docs/Lock-KshFile.md)
    - [Unlock-KshFile](docs/Unlock-KshFile.md)
    - [Publish-KshFile](docs/Publish-KshFile.md)
    - [Unpublish-KshFile](docs/Unpublish-KshFile.md)
  - File Versions
    - [Get-KshFileVersion](docs/Get-KshFileVersion.md)
    - [Remove-KshFileVersion](docs/Remove-KshFileVersion.md)
    - [Restore-KshFileVersion](docs/Restore-KshFileVersion.md)
  - Folders
    - [Get-KshFolder](docs/Get-KshFolder.md)
    - [Add-KshFolder](docs/Add-KshFolder.md)
    - [Remove-KshFolder](docs/Remove-KshFolder.md)
    - [Set-KshFolder](docs/Set-KshFolder.md)
    - [Copy-KshFolder](docs/Copy-KshFolder.md)
    - [Move-KshFolder](docs/Move-KshFolder.md)
    - [Approve-KshFolder](docs/Approve-KshFolder.md)
    - [Deny-KshFolder](docs/Deny-KshFolder.md)
    - [Suspend-KshFolder](docs/Suspend-KshFolder.md)
  - Groups
    - [Get-KshGroup](docs/Get-KshGroup.md)
    - [Add-KshGroup](docs/Add-KshGroup.md)
    - [Remove-KshGroup](docs/Remove-KshGroup.md)
    - [Set-KshGroup](docs/Set-KshGroup.md)
    - [Add-KshGroupMember](docs/Add-KshGroupMember.md)
    - [Get-KshGroupMember](docs/Get-KshGroupMember.md)
    - [Remove-KshGroupMember](docs/Remove-KshGroupMember.md)
    - [Get-KshGroupOwner](docs/Get-KshGroupOwner.md)
    - [Set-KshGroupOwner](docs/Set-KshGroupOwner.md)
  - Images
    - [Save-KshImage](docs/Save-KshImage.md)
  - Likes
    - [Get-KshLike](docs/Get-KshLike.md)
    - [Enable-KshLike](docs/Enable-KshLike.md)
    - [Disable-KshLike](docs/Disable-KshLike.md)
  - Lists
    - [Get-KshList](docs/Get-KshList.md)
    - [Add-KshList](docs/Add-KshList.md)
    - [Remove-KshList](docs/Remove-KshList.md)
    - [Set-KshList](docs/Set-KshList.md)
  - List Items
    - [Get-KshListItem](docs/Get-KshListItem.md)
    - [Add-KshListItem](docs/Add-KshListItem.md)
    - [Remove-KshListItem](docs/Remove-KshListItem.md)
    - [Set-KshListItem](docs/Set-KshListItem.md)
    - [Approve-KshListItem](docs/Approve-KshListItem.md)
    - [Deny-KshListItem](docs/Deny-KshListItem.md)
    - [Suspend-KshListItem](docs/Suspend-KshListItem.md)
    - [New-KshColumnGeolocationValue](docs/New-KshColumnGeolocationValue.md)
    - [New-KshColumnImageValue](docs/New-KshColumnImageValue.md)
    - [New-KshColumnLookupValue](docs/New-KshColumnLookupValue.md)
    - [New-KshColumnTaxonomyValue](docs/New-KshColumnTaxonomyValue.md)
    - [New-KshColumnUrlValue](docs/New-KshColumnUrlValue.md)
    - [New-KshColumnUserValue](docs/New-KshColumnUserValue.md)
    - [Set-KshColumnTaxonomyValue](docs/Set-KshColumnTaxonomyValue.md)
  - List Templates
    - [Get-KshListTemplate](docs/Get-KshListTemplate.md)
  - Navigation
    - [Get-KshNavigation](docs/Get-KshNavigation.md)
    - [Set-KshNavigation](docs/Set-KshNavigation.md)
    - [Get-KshNavigationNode](docs/Get-KshNavigationNode.md)
    - [Add-KshNavigationNode](docs/Add-KshNavigationNode.md)
    - [Remove-KshNavigationNode](docs/Remove-KshNavigationNode.md)
    - [Set-KshNavigationNode](docs/Set-KshNavigationNode.md)
  - Properties
    - [Get-KshProperty](docs/Get-KshProperty.md)
  - Recycle Bin Items
    - [Get-KshRecycleBinItem](docs/Get-KshRecycleBinItem.md)
    - [Move-KshRecycleBinItem](docs/Move-KshRecycleBinItem.md)
    - [Remove-KshRecycleBinItem](docs/Remove-KshRecycleBinItem.md)
    - [Restore-KshRecycleBinItem](docs/Restore-KshRecycleBinItem.md)
  - Regional Settings
    - [Get-KshRegionalSettings](docs/Get-KshRegionalSettings.md)
    - [Set-KshRegionalSettings](docs/Set-KshRegionalSettings.md)
    - [ConvertTo-KshLocalTime](docs/ConvertTo-KshLocalTime.md)
    - [ConvertTo-KshUniversalTime](docs/ConvertTo-KshUniversalTime.md)
  - Role Assignments
    - [Get-KshRoleAssignment](docs/Get-KshRoleAssignment.md)
    - [Add-KshRoleAssignment](docs/Add-KshRoleAssignment.md)
    - [Remove-KshRoleAssignment](docs/Remove-KshRoleAssignment.md)
    - [Set-KshUniqueRoleAssignmentEnabled](docs/Set-KshUniqueRoleAssignmentEnabled.md)
  - Role Definitions
    - [Get-KshRoleDefinition](docs/Get-KshRoleDefinition.md)
    - [Add-KshRoleDefinition](docs/Add-KshRoleDefinition.md)
    - [Remove-KshRoleDefinition](docs/Remove-KshRoleDefinition.md)
    - [Set-KshRoleDefinition](docs/Set-KshRoleDefinition.md)
    - [New-KshBasePermission](docs/New-KshBasePermission.md)
  - Sharing Links
    - [Add-KshAnonymousLink](docs/Add-KshAnonymousLink.md)
    - [Remove-KshAnonymousLink](docs/Remove-KshAnonymousLink.md)
    - [Add-KshOrganizationSharingLink](docs/Add-KshOrganizationSharingLink.md)
    - [Remove-KshOrganizationSharingLink](docs/Remove-KshOrganizationSharingLink.md)
    - [Test-KshSharingLink](docs/Add-KshSharingLink.md)
  - Sites
    - [Get-KshSite](docs/Get-KshSite.md)
    - [Add-KshSite](docs/Add-KshSite.md)
    - [Remove-KshSite](docs/Remove-KshSite.md)
    - [Set-KshSite](docs/Set-KshSite.md)
  - Site Collection Apps
    - [Get-KshSiteCollectionApp](docs/Get-KshSiteCollectionApp.md)
    - [Add-KshSiteCollectionApp](docs/Add-KshSiteCollectionApp.md)
    - [Remove-KshSiteCollectionApp](docs/Remove-KshSiteCollectionApp.md)
    - [Install-KshSiteCollectionApp](docs/Install-KshSiteCollectionApp.md)
    - [Uninstall-KshSiteCollectionApp](docs/Uninstall-KshSiteCollectionApp.md)
    - [Publish-KshSiteCollectionApp](docs/Publish-KshSiteCollectionApp.md)
    - [Unpublish-KshSiteCollectionApp](docs/Unpublish-KshSiteCollectionApp.md)
  - Site Collection App Catalogs
    - [Get-KshSiteCollectionAppCatalog](docs/Get-KshSiteCollectionAppCatalog.md)
    - [Add-KshSiteCollectionAppCatalog](docs/Add-KshSiteCollectionAppCatalog.md)
    - [Remove-KshSiteCollectionAppCatalog](docs/Remove-KshSiteCollectionAppCatalog.md)
  - Site Collection Features
    - [Get-KshSiteCollectionFeature](docs/Get-KshSiteCollectionFeature.md)
    - [Add-KshSiteCollectionFeature](docs/Add-KshSiteCollectionFeature.md)
    - [Remove-KshSiteCollectionFeature](docs/Remove-KshSiteCollectionFeature.md)
  - Site Features
    - [Get-KshSiteFeature](docs/Get-KshSiteFeature.md)
    - [Add-KshSiteFeature](docs/Add-KshSiteFeature.md)
    - [Remove-KshSiteFeature](docs/Remove-KshSiteFeature.md)
  - Site Pages
    - [Add-KshSitePage](docs/Add-KshSitePage.md)
    - [Remove-KshSitePage](docs/Remove-KshSitePage.md)
    - [Set-KshSitePage](docs/Set-KshSitePage.md)
  - Site Templates
    - [Get-KshSiteTemplate](docs/Get-KshSiteTemplate.md)
  - Tenant Apps
    - [Get-KshTenantApp](docs/Get-KshTenantApp.md)
    - [Add-KshTenantApp](docs/Add-KshTenantApp.md)
    - [Remove-KshTenantApp](docs/Remove-KshTenantApp.md)
    - [Install-KshTenantApp](docs/Install-KshTenantApp.md)
    - [Uninstall-KshTenantApp](docs/Uninstall-KshTenantApp.md)
    - [Publish-KshTenantApp](docs/Publish-KshTenantApp.md)
    - [Unpublish-KshTenantApp](docs/Unpublish-KshTenantApp.md)
  - Tenant App Catalog
    - [Get-KshTenantAppCatalog](docs/Get-KshTenantAppCatalog.md)
  - Users
    - [Get-KshUser](docs/Get-KshUser.md)
    - [Add-KshUser](docs/Add-KshUser.md)
    - [Remove-KshUser](docs/Remove-KshUser.md)
    - [Set-KshUser](docs/Set-KshUser.md)
    - [Resolve-KshUser](docs/Resolve-KshUser.md)
    - [Add-KshExternalUser](docs/Get-KshExternalUser.md)
  - User Permissions
    - [Get-KshUserPermission](docs/Get-KshUserPermission.md)
  - User Properties
    - [Get-KshUserProperty](docs/Get-KshUserProperty.md)
  - Views
    - [Get-KshView](docs/Get-KshView.md)
    - [Add-KshView](docs/Add-KshView.md)
    - [Remove-KshView](docs/Remove-KshView.md)
    - [Set-KshView](docs/Set-KshView.md)
    - [Add-KshViewColumn](docs/Add-KshViewColumn.md)
    - [Get-KshViewColumn](docs/Get-KshViewColumn.md)
    - [Move-KshViewColumn](docs/Move-KshViewColumn.md)
    - [Remove-KshViewColumn](docs/Remove-KshViewColumn.md)
  - Webhooks
    - [Get-KshSubscription](docs/Get-KshSubscription.md)
    - [Add-KshSubscription](docs/Add-KshSubscription.md)
    - [Remove-KshSubscription](docs/Remove-KshSubscription.md)
    - [Set-KshSubscription](docs/Set-KshSubscription.md)
- Tenant Administration
  - Deleted Site Collections
    - [Get-KshTenantDeletedPersonalSiteCollection](docs/Get-KshTenantDeletedPersonalSiteCollection.md)
    - [Get-KshTenantDeletedSiteCollection](docs/Get-KshTenantDeletedSiteCollection.md)
    - [Remove-KshTenantDeletedSiteCollection](docs/Remove-KshTenantDeletedSiteCollection.md)
    - [Restore-KshTenantDeletedSiteCollection](docs/Restore-KshTenantDeletedSiteCollection.md)
  - Home Site
    - [Get-KshTenantHomeSite](docs/Get-KshTenantHomeSite.md)
    - [Remove-KshTenantHomeSite](docs/Remove-KshTenantHomeSite.md)
    - [Set-KshTenantHomeSite](docs/Set-KshTenantHomeSite.md)
  - Hub Sites
    - [Get-KshTenantHubSite](docs/Get-KshTenantHubSite.md)
    - [Add-KshTenantHubSite](docs/Add-KshTenantHubSite.md)
    - [Remove-KshTenantHubSite](docs/Remove-KshTenantHubSite.md)
    - [Set-KshTenantHubSite](docs/Set-KshTenantHubSite.md)
  - List Designs
    - [Get-KshTenantListDesign](docs/Get-KshTenantListDesign.md)
    - [Add-KshTenantListDesign](docs/Add-KshTenantListDesign.md)
    - [Remove-KshTenantListDesign](docs/Remove-KshTenantListDesign.md)
  - Office 365 CDN
    - [Get-KshTenantCdnEnabled](docs/Get-KshTenantCdnEnabled.md)
    - [Set-KshTenantCdnEnabled](docs/Set-KshTenantCdnEnabled.md)
    - [Get-KshTenantCdnOrigin](docs/Set-KshTenantCdnOrigin.md)
    - [Add-KshTenantCdnOrigin](docs/Get-KshTenantCdnOrigin.md)
    - [Remove-KshTenantCdnOrigin](docs/Remove-KshTenantCdnOrigin.md)
    - [Get-KshTenantCdnPolicy](docs/Get-KshTenantCdnPolicy.md)
    - [Set-KshTenantCdnPolicy](docs/Set-KshTenantCdnPolicy.md)
  - Organization News Sites
    - [Get-KshTenantOrganizationNewsSite](docs/Get-KshTenantOrganizationNewsSite.md)
    - [Add-KshTenantOrganizationNewsSite](docs/Add-KshTenantOrganizationNewsSite.md)
    - [Remove-KshTenantOrganizationNewsSite](docs/Remove-KshTenantOrganizationNewsSite.md)
  - Personal Sites
    - [Get-KshTenantPersonalSite](docs/Get-KshTenantPersonalSite.md)
  - Site Collections
    - [Get-KshSiteCollection](docs/Get-KshSiteCollection.md)
    - [Get-KshTenantSiteCollection](docs/Get-KshTenantSiteCollection.md)
    - [Add-KshTenantSiteCollection](docs/Add-KshTenantSiteCollection.md)
    - [Remove-KshTenantSiteCollection](docs/Remove-KshTenantSiteCollection.md)
    - [Set-KshTenantSiteCollection](docs/Set-KshTenantSiteCollection.md)
    - [Lock-KshTenantSiteCollection](docs/Lock-KshTenantSiteCollection.md)
    - [Unlock-KshTenantSiteCollection](docs/Unlock-KshTenantSiteCollection.md)
  - Site Scripts
    - [Get-KshTenantSiteScript](docs/Get-KshTenantSiteScript.md)
    - [Add-KshTenantSiteScript](docs/Add-KshTenantSiteScript.md)
    - [Remove-KshTenantSiteScript](docs/Remove-KshTenantSiteScript.md)
    - [Get-KshTenantSiteScriptFromList](docs/Get-KshTenantSiteScriptFromList.md)
    - [Get-KshTenantSiteScriptFromSite](docs/Get-KshTenantSiteScriptFromSite.md)
  - Site Templates
    - [Get-KshTenantSiteTemplate](docs/Get-KshTenantSiteTemplate.md)
  - Tenant
    - [Get-KshTenant](docs/Get-KshTenant.md)
    - [Set-KshTenant](docs/Set-KshTenant.md)
  - Themes
    - [Get-KshTenantTheme](docs/Get-KshTenantTheme.md)
    - [Add-KshTenantTheme](docs/Add-KshTenantTheme.md)
    - [Remove-KshTenantTheme](docs/Remove-KshTenantTheme.md)
    - [Set-KshTenantTheme](docs/Set-KshTenantTheme.md)
  - Users
    - [Get-KshTenantUser](docs/Get-KshTenantUser.md)
    - [Add-KshTenantUser](docs/Add-KshTenantUser.md)
    - [Remove-KshTenantUser](docs/Remove-KshTenantUser.md)
    - [Set-KshTenantUser](docs/Set-KshTenantUser.md)
    - [Get-KshTenantExternalUser](docs/Get-KshTenantExternalUser.md)
    - [Remove-KshTenantExternalUser](docs/Remove-KshTenantExternalUser.md)
- Managed Metadata
  - Custom Properties
    - [Add-KshTermCustomProperty](docs/Add-KshTermCustomProperty.md)
    - [Remove-KshTermCustomProperty](docs/Remove-KshTermCustomProperty.md)
    - [Add-KshTermLocalCustomProperty](docs/Add-KshTermLocalCustomProperty.md)
    - [Remove-KshTermLocalCustomProperty](docs/Remove-KshTermLocalCustomProperty.md)
  - Terms
    - [Get-KshTerm](docs/Get-KshTerm.md)
    - [Add-KshTerm](docs/Add-KshTerm.md)
    - [Remove-KshTerm](docs/Remove-KshTerm.md)
    - [Set-KshTerm](docs/Set-KshTerm.md)
    - [Copy-KshTerm](docs/Copy-KshTerm.md)
    - [Move-KshTerm](docs/Move-KshTerm.md)
    - [Merge-KshTerm](docs/Merge-KshTerm.md)
    - [Disable-KshTerm](docs/Disable-KshTerm.md)
    - [Enable-KshTerm](docs/Enable-KshTerm.md)
    - [Get-KshTermDescription](docs/Get-KshTermDescription.md)
    - [Set-KshTermDescription](docs/Set-KshTermDescription.md)
  - Term Groups
    - [Get-KshTermGroup](docs/Get-KshTermGroup.md)
    - [Add-KshTermGroup](docs/Add-KshTermGroup.md)
    - [Remove-KshTermGroup](docs/Remove-KshTermGroup.md)
    - [Set-KshTermGroup](docs/Set-KshTermGroup.md)
  - Term Labels
    - [Get-KshTermLabel](docs/Get-KshTermLabel.md)
    - [Add-KshTermLabel](docs/Add-KshTermLabel.md)
    - [Remove-KshTermLabel](docs/Remove-KshTermLabel.md)
    - [Set-KshTermLabel](docs/Set-KshTermLabel.md)
  - Term Sets
    - [Get-KshTermSet](docs/Get-KshTermSet.md)
    - [Add-KshTermSet](docs/Add-KshTermSet.md)
    - [Remove-KshTermSet](docs/Remove-KshTermSet.md)
    - [Set-KshTermSet](docs/Set-KshTermSet.md)
  - Term Store
    - [Get-KshTermStore](docs/Get-KshTermStore.md)
    - [Set-KshTermStore](docs/Set-KshTermStore.md)
    - [Add-KshTermStoreLanguage](docs/Add-KshTermStoreLanguage.md)
    - [Remove-KshTermStoreLanguage](docs/Remove-KshTermStoreLanguage.md)
