# SPClientCore

[View in English](README.md)

PowerShell Core 向けの SharePoint サービス モジュール

[![Build Status](https://dev.azure.com/karamem0/SPClientCore/_apis/build/status/SPClientCore?branchName=master)](https://dev.azure.com/karamem0/SPClientCore/_build/latest?definitionId=51&branchName=master)
[![License](https://img.shields.io/github/license/karamem0/spclientcore.svg)](https://github.com/karamem0/spclientcore/blob/master/LICENSE)

## インストール

SPClientCore は [PowerShell Gallery](https://www.powershellgallery.com/packages/SPClientCore) に公開されています。

## 機能

### PowerShell Core での動作

はい、SPClientCore は PowerShell Core で動作し、また Windows PowerShell でも動作します。つまり、このモジュールを Windows はもちろん Mac や Linux でも使用できるということです (もちろんそのマシンに PowerShell Core がインストールされていればですが)。<del>Windows 以外の環境で SharePoint Online を管理するには REST API を実行する方法しかありませんでした。</del>しかし REST API は SharePoint クライアント ライブラリ (CSOM) に比べていくつかの問題を持っています。SPClientCore は SharePoint クライアント ライブラリと互換性のある API 呼び出しを行うことで完全な機能を提供します。

*(更新) CSOM および PnP PowerShell は PowerShell Core をサポートしました。*

### 1 つのモジュールですべての管理を

SPClientCore はサイト管理者機能とテナント管理機能の両方の要素を含んでいます。一般のサイト (https://tenant.sharepoint.com およびその配下の URL) に接続すればサイト管理のためのコマンドレットを実行することができ、SharePoint 管理センター (https://tenant-admin.sharepoint.com) に接続すればテナント管理のためのコマンドレットを実行することができます。現在 SharePoint 管理センターに接続しているかどうかを確認することもできます。

### フレンドリーな名前付け

CSOM の名前付けは非プログラマーにとって難解です。例えば、サイトは "Site" ではありません (正しくは "Web" です) し、列は "Column" ではありません (正しくは "Field" です)。SPClientCoreはユーザーが使用する名前と一致するように名前付けを調整しています。

### 先端認証の使用

SPClientCore は Azure AD 2.0 認証をサポートします (Device Code Grant および Password Grant)。もしあなたが MFA を有効にしていても異なるデバイスの Web ブラウザーでログインすることができます。MFA を有効にしていないアカウントであれば、ユーザー名とパスワードを使ってログインできます (組織の承認が必要です)。

## 依存関係

- [Microsoft.Extensions.DependencyInjection](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection/5.0.1) (5.0.1)
- [Microsoft.Extensions.DependencyInjection.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection.Abstractions/5.0.0) (5.0.0)
- [Microsoft.IdentityModel.JsonWebTokens](https://www.nuget.org/packages/Microsoft.IdentityModel.JsonWebTokens/6.8.0) (6.8.0)
- [Microsoft.IdentityModel.JsonWebTokens](https://www.nuget.org/packages/Newtonsoft.Json/12.0.3) (12.0.3)

## コマンド リファレンス (英語)

- ログイン
  - [Connect-KshSite](docs/Connect-KshSite.md)
  - [Get-KshCurrentSite](docs/Get-KshCurrentSite.md)
  - [Get-KshCurrentSiteCollection](docs/Get-KshCurrentSiteCollection.md)
  - [Get-KshCurrentUser](docs/Get-KshCurrentUser.md)
  - [Get-KshCurrentUserProfile](docs/Get-KshCurrentUserProfile.md)
  - [Get-KshCurrentUserProperty](docs/Get-KshCurrentUserProperty.md)
  - [Select-KshSite](docs/Select-KshSite.md)
  - [Test-KshTenantSiteCollection](docs/Test-KshTenantSiteCollection.md)
- サイト管理
  - 通知
    - [Get-KshAlert](docs/Get-KshAlert.md)
    - [New-KshAlert](docs/New-KshAlert.md)
    - [Remove-KshAlert](docs/Remove-KshAlert.md)
    - [Update-KshAlert](docs/Update-KshAlert.md)
  - アプリ インスタンス
    - [Get-KshAppInstance](docs/Get-KshAppInstance.md)
  - 添付ファイル
    - [Get-KshAttachmentFile](docs/Get-KshAttachmentFile.md)
    - [Open-KshAttachmentFile](docs/Open-KshAttachmentFile.md)
    - [Remove-KshAttachmentFile](docs/Remove-KshAttachmentFile.md)
    - [Save-KshAttachmentFile](docs/Save-KshAttachmentFile.md)
  - 変更
    - [Get-KshChange](docs/Get-KshChange.md)
  - クライアント コンポーネントのプロパティ
    - [Add-KshStorageEntity](docs/Add-KshStorageEntity.md)
    - [Get-KshStorageEntity](docs/Get-KshStorageEntity.md)
    - [Remove-KshStorageEntity](docs/Remove-KshStorageEntity.md)
  - 列
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
  - コメント
    - [Get-KshComment](docs/Get-KshComment.md)
    - [New-KshComment](docs/New-KshComment.md)
    - [Remove-KshComment](docs/Remove-KshComment.md)
  - コンテンツ タイプ
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
  - ドキュメント ライブラリ
    - [Get-KshDocumentLibrary](docs/Get-KshDocumentLibrary.md)
  - ドキュメント セット
    - [New-KshDocumentSet](docs/New-KshDocumentSet.md)
  - ドキュメント セット テンプレート
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
  - ドライブ
    - [Get-KshDrive](docs/Get-KshDrive.md)
  - ファイル
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
  - ファイル バージョン
    - [Get-KshFileVersion](docs/Get-KshFileVersion.md)
    - [Remove-KshFileVersion](docs/Remove-KshFileVersion.md)
    - [Restore-KshFileVersion](docs/Restore-KshFileVersion.md)
  - フォルダー
    - [Approve-KshFolder](docs/Approve-KshFolder.md)
    - [Copy-KshFolder](docs/Copy-KshFolder.md)
    - [Deny-KshFolder](docs/Deny-KshFolder.md)
    - [Get-KshFolder](docs/Get-KshFolder.md)
    - [New-KshFolder](docs/New-KshFolder.md)
    - [Move-KshFolder](docs/Move-KshFolder.md)
    - [Remove-KshFolder](docs/Remove-KshFolder.md)
    - [Suspend-KshFolder](docs/Suspend-KshFolder.md)
    - [Update-KshFolder](docs/Update-KshFolder.md)
  - グループ
    - [Get-KshGroup](docs/Get-KshGroup.md)
    - [New-KshGroup](docs/New-KshGroup.md)
    - [Remove-KshGroup](docs/Remove-KshGroup.md)
    - [Update-KshGroup](docs/Update-KshGroup.md)
    - [Add-KshGroupMember](docs/Add-KshGroupMember.md)
    - [Get-KshGroupMember](docs/Get-KshGroupMember.md)
    - [Remove-KshGroupMember](docs/Remove-KshGroupMember.md)
    - [Get-KshGroupOwner](docs/Get-KshGroupOwner.md)
    - [Set-KshGroupOwner](docs/Set-KshGroupOwner.md)
  - リスト
    - [Get-KshList](docs/Get-KshList.md)
    - [New-KshList](docs/New-KshList.md)
    - [Remove-KshList](docs/Remove-KshList.md)
    - [Update-KshList](docs/Update-KshList.md)
  - リスト アイテム
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
  - リスト テンプレート
    - [Get-KshListTemplate](docs/Get-KshListTemplate.md)
  - ナビゲーション
    - [Get-KshNavigation](docs/Get-KshNavigation.md)
    - [Get-KshNavigationNode](docs/Get-KshNavigationNode.md)
    - [New-KshNavigationNode](docs/New-KshNavigationNode.md)
    - [Remove-KshNavigationNode](docs/Remove-KshNavigationNode.md)
    - [Update-KshNavigationNode](docs/Update-KshNavigationNode.md)
  - ごみ箱
    - [Get-KshRecycleBinItem](docs/Get-KshRecycleBinItem.md)
    - [Move-KshRecycleBinItem](docs/Move-KshRecycleBinItem.md)
    - [Remove-KshRecycleBinItem](docs/Remove-KshRecycleBinItem.md)
    - [Restore-KshRecycleBinItem](docs/Restore-KshRecycleBinItem.md)
  - 地域と言語の設定
    - [Get-KshRegionalSettings](docs/Get-KshRegionalSettings.md)
    - [Update-KshRegionalSettings](docs/Update-KshRegionalSettings.md)
  - アクセス許可
    - [Get-KshRoleAssignment](docs/Get-KshRoleAssignment.md)
    - [New-KshRoleAssignment](docs/New-KshRoleAssignment.md)
    - [Remove-KshRoleAssignment](docs/Remove-KshRoleAssignment.md)
    - [Set-KshUniqueRoleAssignmentEnabled](docs/Set-KshUniqueRoleAssignmentEnabled.md)
  - アクセス許可レベル
    - [Get-KshRoleDefinition](docs/Get-KshRoleDefinition.md)
    - [New-KshRoleDefinition](docs/New-KshRoleDefinition.md)
    - [Remove-KshRoleDefinition](docs/Remove-KshRoleDefinition.md)
    - [Update-KshRoleDefinition](docs/Update-KshRoleDefinition.md)
    - [Initialize-KshBasePermission](docs/Initialize-KshBasePermission.md)
  - 共有リンク
    - [New-KshAnonymousLink](docs/New-KshAnonymousLink.md)
    - [Remove-KshAnonymousLink](docs/Remove-KshAnonymousLink.md)
    - [New-KshOrganizationSharingLink](docs/New-KshOrganizationSharingLink.md)
    - [Remove-KshOrganizationSharingLink](docs/Remove-KshOrganizationSharingLink.md)
    - [Test-KshSharingLink](docs/New-KshSharingLink.md)
  - サイト
    - [Get-KshSite](docs/Get-KshSite.md)
    - [New-KshSite](docs/New-KshSite.md)
    - [Remove-KshSite](docs/Remove-KshSite.md)
    - [Update-KshSite](docs/Update-KshSite.md)
  - サイト コレクションのアプリ
    - [Get-KshSiteCollectionApp](docs/Get-KshSiteCollectionApp.md)
    - [Install-KshSiteCollectionApp](docs/Install-KshSiteCollectionApp.md)
    - [New-KshSiteCollectionApp](docs/New-KshSiteCollectionApp.md)
    - [Publish-KshSiteCollectionApp](docs/Publish-KshSiteCollectionApp.md)
    - [Remove-KshSiteCollectionApp](docs/Remove-KshSiteCollectionApp.md)
    - [Uninstall-KshSiteCollectionApp](docs/Uninstall-KshSiteCollectionApp.md)
    - [Unpublish-KshSiteCollectionApp](docs/Unpublish-KshSiteCollectionApp.md)
  - サイト コレクションのアプリ カタログ
    - [Add-KshSiteCollectionAppCatalog](docs/Add-KshSiteCollectionAppCatalog.md)
    - [Get-KshSiteCollectionAppCatalog](docs/Get-KshSiteCollectionAppCatalog.md)
    - [Remove-KshSiteCollectionAppCatalog](docs/Remove-KshSiteCollectionAppCatalog.md)
  - サイト コレクションの機能
    - [Add-KshSiteCollectionFeature](docs/Add-KshSiteCollectionFeature.md)
    - [Get-KshSiteCollectionFeature](docs/Get-KshSiteCollectionFeature.md)
    - [Remove-KshSiteCollectionFeature](docs/Remove-KshSiteCollectionFeature.md)
  - サイトの機能
    - [Add-KshSiteFeature](docs/Add-KshSiteFeature.md)
    - [Get-KshSiteFeature](docs/Get-KshSiteFeature.md)
    - [Remove-KshSiteFeature](docs/Remove-KshSiteFeature.md)
  - サイト ページ
    - [Add-KshSitePage](docs/Add-KshSitePage.md)
    - [Remove-KshSitePage](docs/Remove-KshSitePage.md)
    - [Set-KshSitePage](docs/Set-KshSitePage.md)
  - サイト テンプレート
    - [Get-KshSiteTemplate](docs/Get-KshSiteTemplate.md)
  - テナントのアプリ
    - [Get-KshTenantApp](docs/Get-KshTenantApp.md)
    - [Install-KshTenantApp](docs/Install-KshTenantApp.md)
    - [New-KshTenantApp](docs/New-KshTenantApp.md)
    - [Publish-KshTenantApp](docs/Publish-KshTenantApp.md)
    - [Remove-KshTenantApp](docs/Remove-KshTenantApp.md)
    - [Uninstall-KshTenantApp](docs/Uninstall-KshTenantApp.md)
    - [Unpublish-KshTenantApp](docs/Unpublish-KshTenantApp.md)
  - テナントの設定
    - [Get-KshTenantSettings](docs/Get-KshTenantSettings.md)
  - ユーザー
    - [Get-KshUser](docs/Get-KshUser.md)
    - [New-KshUser](docs/New-KshUser.md)
    - [Remove-KshUser](docs/Remove-KshUser.md)
    - [Resolve-KshUser](docs/Resolve-KshUser.md)
    - [Update-KshUser](docs/Update-KshUser.md)
  - ユーザーの権限
    - [Get-KshUserPermission](docs/Get-KshUserPermission.md)
  - ユーザー プロパティ
    - [Get-KshUserProperty](docs/Get-KshUserProperty.md)
  - ビュー
    - [Get-KshView](docs/Get-KshView.md)
    - [New-KshView](docs/New-KshView.md)
    - [Remove-KshView](docs/Remove-KshView.md)
    - [Update-KshView](docs/Update-KshView.md)
    - [Add-KshViewColumn](docs/Add-KshViewColumn.md)
    - [Get-KshViewColumn](docs/Get-KshViewColumn.md)
    - [Move-KshViewColumn](docs/Move-KshViewColumn.md)
    - [Remove-KshViewColumn](docs/Remove-KshViewColumn.md)
  - Webhook
    - [Get-KshSubscription](docs/Get-KshSubscription.md)
    - [New-KshSubscription](docs/New-KshSubscription.md)
    - [Remove-KshSubscription](docs/Remove-KshSubscription.md)
    - [Update-KshSubscription](docs/Update-KshSubscription.md)
- テナント管理
  - 削除されたサイト コレクション
    - [Get-KshTenantDeletedSiteCollection](docs/Get-KshTenantDeletedSiteCollection.md)
    - [Remove-KshTenantDeletedSiteCollection](docs/Remove-KshTenantDeletedSiteCollection.md)
    - [Restore-KshTenantDeletedSiteCollection](docs/Restore-KshTenantDeletedSiteCollection.md)
  - ホーム サイト
    - [Get-KshTenantHomeSite](docs/Get-KshTenantHomeSite.md)
    - [Remove-KshTenantHomeSite](docs/Remove-KshTenantHomeSite.md)
    - [Set-KshTenantHomeSite](docs/Set-KshTenantHomeSite.md)
  - ハブ サイト
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
  - 組織のニュース サイト
    - [Get-KshTenantOrganizationNewsSite](docs/Get-KshTenantOrganizationNewsSite.md)
    - [Add-KshTenantOrganizationNewsSite](docs/Add-KshTenantOrganizationNewsSite.md)
    - [Remove-KshTenantOrganizationNewsSite](docs/Remove-KshTenantOrganizationNewsSite.md)
  - サイト コレクション
    - [Get-KshSiteCollection](docs/Get-KshSiteCollection.md)
    - [Get-KshTenantSiteCollection](docs/Get-KshTenantSiteCollection.md)
    - [Lock-KshTenantSiteCollection](docs/Lock-KshTenantSiteCollection.md)
    - [New-KshTenantSiteCollection](docs/New-KshTenantSiteCollection.md)
    - [Remove-KshTenantSiteCollection](docs/Remove-KshTenantSiteCollection.md)
    - [Unlock-KshTenantSiteCollection](docs/Unlock-KshTenantSiteCollection.md)
    - [Update-KshTenantSiteCollection](docs/Update-KshTenantSiteCollection.md)
  - サイト テンプレート
    - [Get-KshTenantSiteTemplate](docs/Get-KshTenantSiteTemplate.md)
  - テーマ
    - [Get-KshTenantTheme](docs/Get-KshTenantTheme.md)
    - [New-KshTenantTheme](docs/New-KshTenantTheme.md)
    - [Remove-KshTenantTheme](docs/Remove-KshTenantTheme.md)
    - [Update-KshTenantTheme](docs/Update-KshTenantTheme.md)
- 管理されたメタデータ
  - カスタム プロパティ
    - [Add-KshTermCustomProperty](docs/Add-KshTermCustomProperty.md)
    - [Remove-KshTermCustomProperty](docs/Remove-KshTermCustomProperty.md)
    - [Add-KshTermLocalCustomProperty](docs/Add-KshTermLocalCustomProperty.md)
    - [Remove-KshTermLocalCustomProperty](docs/Remove-KshTermLocalCustomProperty.md)
  - 用語
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
  - 用語グループ
    - [Get-KshTermGroup](docs/Get-KshTermGroup.md)
    - [New-KshTermGroup](docs/New-KshTermGroup.md)
    - [Remove-KshTermGroup](docs/Remove-KshTermGroup.md)
    - [Update-KshTermGroup](docs/Update-KshTermGroup.md)
  - 用語ラベル
    - [Get-KshTermLabel](docs/Get-KshTermLabel.md)
    - [New-KshTermLabel](docs/New-KshTermLabel.md)
    - [Remove-KshTermLabel](docs/Remove-KshTermLabel.md)
    - [Update-KshTermLabel](docs/Update-KshTermLabel.md)
  - 用語セット
    - [Get-KshTermSet](docs/Get-KshTermSet.md)
    - [New-KshTermSet](docs/New-KshTermSet.md)
    - [Remove-KshTermSet](docs/Remove-KshTermSet.md)
    - [Update-KshTermSet](docs/Update-KshTermSet.md)
  - 用語ストア
    - [Get-KshTermStore](docs/Get-KshTermStore.md)
    - [Update-KshTermStore](docs/Update-KshTermStore.md)
    - [Add-KshTermStoreLanguage](docs/Add-KshTermStoreLanguage.md)
    - [Remove-KshTermStoreLanguage](docs/Remove-KshTermStoreLanguage.md)
