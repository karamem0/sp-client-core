# SPClientCore

[View in English](README.md)

PowerShell Core 向けの SharePoint サービス モジュール

[![Build status](https://ci.appveyor.com/api/projects/status/etlu54thystfp79a?svg=true)](https://ci.appveyor.com/project/karamem0/spclientcore)
[![License](https://img.shields.io/github/license/karamem0/spclientcore.svg)](https://github.com/karamem0/spclientcore/blob/master/LICENSE)

## インストール

SPClientCore は [PowerShell Gallery](https://www.powershellgallery.com/packages/SPClientCore) に公開されています。

## 機能

### PowerShell Core での動作

はい、SPClientCore は PowerShell Core で動作します。そして Windows PowerShell では動作しません。つまり、このモジュールを Windows はもちろん Mac や Linux でも使用できるということです (もちろんそのマシンに PowerShell Core がインストールされていればですが)。Windows 以外の環境で SharePoint Online を管理するには REST API を実行する方法しかありませんでした。しかし REST API は SharePoint クライアント ライブラリ (CSOM) に比べていくつかの問題を持っています。SPClientCore は SharePoint クライアント ライブラリと互換性のある API 呼び出しを行うことで完全な機能を提供します。

### 1 つのモジュールですべての管理を

PnP-PowerShell にはサイト管理機能のみしかなく、SharePoint Online 管理シェルにはテナント管理機能のみしかありません。SPClientCore は両方の機能を含んでいます。一般のサイト (https://tenant.sharepoint.com およびその配下の URL) に接続すればサイト管理のためのコマンドレットを実行することができ、SharePoint 管理センター (https://tenant-admin.sharepoint.com) に接続すればテナント管理のためのコマンドレットを実行することができます。現在 SharePoint 管理センターに接続しているかどうかを確認することもできます。

### フレンドリーな名前付け

CSOM の名前付けは非プログラマーにとって難解です。例えば、サイトは "Site" ではありません (正しくは "Web" です) し、列は "Column" ではありません (正しくは "Field" です)。SPClientCoreはユーザーが使用する名前と一致するように名前付けを調整しています。

### 先端認証の使用

SPClientCore は Azure AD 2.0 をサポートします (Device Code Grant および Password Grant)。もしあなたが MFA を有効にしていても異なるデバイスの Web ブラウザーでログインすることができます。MFA を有効にしていないアカウントであれば、ユーザー名とパスワードを使ってログインできます (組織の承認が必要です)。

## 依存関係

- [Microsoft.Extensions.DependencyInjection](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection/2.2.0) (2.2.0)
- [System.IdentityModel.Tokens.Jwt](https://www.nuget.org/packages/System.IdentityModel.Tokens.Jwt/5.4.0) (5.4.0)
- [System.Management.Automation](https://www.nuget.org/packages/System.Management.Automation/6.1.0) (6.1.0)

## コマンド リファレンス (英語)

- ログイン
  - [Connect-KshSite](docs/Connect-KshSite.md)
  - [Get-KshCurrentSite](docs/Connect-KshCurrentSite.md)
  - [Get-KshCurrentSiteCollection](docs/Connect-KshCurrentSiteCollection.md)
  - [Get-KshCurrentUser](docs/Connect-KshCurrentUser.md)
  - [Select-KshSite](docs/Select-KshSite.md)
  - [Test-KshTenantSiteCollection](docs/Test-KshTenantSiteCollection.md)
- サイト管理
  - 添付ファイル
    - [Get-KshAttachmentFile](docs/Get-KshAttachmentFile.md)
    - [Open-KshAttachmentFile](docs/Open-KshAttachmentFile.md)
    - [Remove-KshAttachmentFile](docs/Remove-KshAttachmentFile.md)
    - [Save-KshAttachmentFile](docs/Save-KshAttachmentFile.md)
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
  - コンテンツ タイプ
    - [Get-KshContentType](docs/Get-KshContentType.md)
    - [New-KshContentType](docs/New-KshContentType.md)
    - [Remove-KshContentType](docs/Remove-KshContentType.md)
    - [Update-KshContentType](docs/Update-KshContentType.md)
    - [New-KshContentTypeId](docs/New-KshContentTypeId.md)
    - [Get-KshContentTypeColumn](docs/Get-KshContentTypeColumn.md)
    - [New-KshContentTypeColumn](docs/New-KshContentTypeColumn.md)
    - [Remove-KshContentTypeColumn](docs/Remove-KshContentTypeColumn.md)
    - [Update-KshContentTypeColumn](docs/Update-KshContentTypeColumn.md)
  - ファイル
    - [Approve-KshFile](docs/Approve-KshFile.md)
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
    - [Deny-KshFolder](docs/Deny-KshFolder.md)
    - [Get-KshFolder](docs/Get-KshFolder.md)
    - [New-KshFolder](docs/New-KshFolder.md)
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
    - [New-KshColumnGeolocationValue](docs/New-KshColumnGeolocationValue.md)
    - [New-KshColumnLookupValue](docs/New-KshColumnLookupValue.md)
    - [New-KshColumnUrlValue](docs/New-KshColumnUrlValue.md)
    - [New-KshColumnUserValue](docs/New-KshColumnUserValue.md)
  - リスト テンプレート
    - [Get-KshListTemplate](docs/Get-KshListTemplate.md)
  - ごみ箱
    - [Get-KshRecycleBinItem](docs/Get-KshRecycleBinItem.md)
    - [Move-KshRecycleBinItem](docs/Move-KshRecycleBinItem.md)
    - [Remove-KshRecycleBinItem](docs/Remove-KshRecycleBinItem.md)
    - [Restore-KshRecycleBinItem](docs/Remove-KshRecycleBinItem.md)
  - サイト
    - [Get-KshSite](docs/Get-KshSite.md)
    - [New-KshSite](docs/New-KshSite.md)
    - [Remove-KshSite](docs/Remove-KshSite.md)
    - [Update-KshSite](docs/Update-KshSite.md)
  - サイト コレクションのアプリ カタログ
    - [Add-KshSiteCollectionAppCatalog](docs/Add-KshSiteCollectionAppCatalog.md)
    - [Get-KshSiteCollectionAppCatalog](docs/Get-KshSiteCollectionAppCatalog.md)
    - [Remove-KshSiteCollectionAppCatalog](docs/Remove-KshSiteCollectionAppCatalog.md)
  - サイト コレクションの機能
    - [Add-KshSiteCollectionFeature](docs/Add-KshSiteCollectionFeature.md)
    - [Get-KshSiteCollectionFeature](docs/Get-KshSiteCollectionFeature.md)
    - [Remove-KshCollectionSiteFeature](docs/Remove-KshSiteCollectionFeature.md)
  - サイトの機能
    - [Add-KshSiteFeature](docs/Add-KshSiteFeature.md)
    - [Get-KshSiteFeature](docs/Get-KshSiteFeature.md)
    - [Remove-KshSiteFeature](docs/Remove-KshSiteFeature.md)
  - サイト テンプレート
    - [Get-KshSiteTemplate](docs/Get-KshSiteTemplate.md)
  - ユーザー
    - [Get-KshUser](docs/Get-KshUser.md)
    - [New-KshUser](docs/New-KshUser.md)
    - [Remove-KshUser](docs/Remove-KshUser.md)
    - [Update-KshUser](docs/Update-KshUser.md)
  - ビュー
    - [Get-KshView](docs/Get-KshView.md)
    - [New-KshView](docs/New-KshView.md)
    - [Remove-KshView](docs/Remove-KshView.md)
    - [Update-KshView](docs/Update-KshView.md)
    - [Add-KshViewColumn](docs/Add-KshViewColumn.md)
    - [Get-KshViewColumn](docs/Get-KshViewColumn.md)
    - [Move-KshViewColumn](docs/Move-KshViewColumn.md)
    - [Remove-KshViewColumn](docs/Remove-KshViewColumn.md)
- テナント管理
  - Office 365 CDN
    - [Get-KshTenantCdnEnabled](docs/Get-KshTenantCdnEnabled.md)
    - [Set-KshTenantCdnEnabled](docs/Set-KshTenantCdnEnabled.md)
    - [Add-KshTenantCdnOrigin](docs/Get-KshTenantCdnOrigin.md)
    - [Get-KshTenantCdnOrigin](docs/Get-KshTenantCdnOrigin.md)
    - [Remove-KshTenantCdnOrigin](docs/Remove-KshTenantCdnOrigin.md)
    - [Get-KshTenantCdnPolicy](docs/Get-KshTenantCdnPolicy.md)
    - [Set-KshTenantCdnPolicy](docs/Get-KshTenantCdnPolicy.md)
  - 削除されたサイト コレクション
    - [Get-KshTenantDeletedSiteCollection](docs/Get-KshTenantDeletedSiteCollection.md)
    - [Remove-KshTenantDeletedSiteCollection](docs/Remove-KshTenantDeletedSiteCollection.md)
    - [Restore-KshTenantDeletedSiteCollection](docs/Restore-KshTenantDeletedSiteCollection.md)
  - サイト コレクション
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
