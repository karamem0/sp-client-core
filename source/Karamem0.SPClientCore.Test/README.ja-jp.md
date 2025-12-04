# Karamem0.SPClientCore.Test

## テスト環境のセットアップ

1. 自己署名証明書を作成し、`Certificate/localhost.pfx` に保存します。

1. Entra ID アプリケーションを登録し、証明書をアップロードします (Wiki ページを参照)。

1. テスト ユーザーを作成します。

    |ユーザー プリンシパル名|表示名|
    |-|-|
    |`testuser0@yourtenantname.onmicrosoft.com`|Test User 0|
    |`testuser1@yourtenantname.onmicrosoft.com`|Test User 1|
    |`testuser2@yourtenantname.onmicrosoft.com`|Test User 2|
    |`testuser3@yourtenantname.onmicrosoft.com`|Test User 3|

1. ゲスト ユーザーを招待します (`outlook.com`、`gmail.com` など)。

1. `SPClientCore` を発行します。

    ```pwsh
    dotnet publish ../Karamem0.SPClientCore/Karamem0.SPClientCore.csproj
    ```

1. `SPClientCore` をインポートします。

    ```pwsh
    Import-Module ../Karamem0.SPClientCore/bin/Debug/netstandard2.1/publish/SPClientCore.psd1
    ```

1. `SPClientCore.Test` をインポートします。

    ```pwsh
    Import-Module ./Scripts/SPClientCore.Test.psd1
    ```

1. `Install-TestSite` を実行します。

    ```pwsh
    $certificatePath = Resolve-Path "./Certificate/localhost.crt"
    $privateKeyPath = Resolve-Path "./Certificate/localhost.key"
    $params = @{
        TenantName = "yourtenantname"
        ClientId = "53bf1d7f-f4dd-..."
        CertificatePath = $certificatePath
        PrivateKeyPath = $privateKeyPath
        OwnerUserName = "someone@yourtenantname.onmicrosoft.com"
        ExternalUserName = "someone@example.com"
    }
    $settings = Install-TestSite @params
    $settings | ConvertTo-Json -Depth 16 | Out-File "./bin/Debug/net9.0/SPClientCore.Test.config.json"
    ```

1. 次のコンポーネントが作成されます。

- `/sites/sp-client-core`
  - `/TestSite1` (Site)
    - `/TestSite2` (Site)
      - `/TestSite3` (Site)
      - `/TestSite4` (Site)
    - `/Lists/TestList1` (List)
      - `Column1` (テキスト)
      - `Column2` (複数行テキスト)
      - `Column3` (選択肢)
      - `Column4` (複数選択可能な選択肢)
      - `Column5` (数値)
      - `Column6` (通貨)
      - `Column7` (日付と時刻)
      - `Column8` (参照)
      - `Column9` (複数選択可能な参照)
      - `Column10` (はい/いいえ)
      - `Column11` (ユーザーまたはグループ)
      - `Column12` (複数選択可能なユーザーまたはグループ)
      - `Column13` (ハイパーリンクまたは画像)
      - `Column14` (集計値)
      - `Column15` (GUID)
      - `Column16` (地理位置情報)
      - `Column17` (管理されたメタデータ)
      - `Column18` (画像)
      - `Column19` (Location)
    - `/TestList2` (ドキュメント ライブラリ)
    - `/TestList3` (ドキュメント ライブラリ)

## テスト環境のクリーンアップ

1. `SPClientCore` を発行します。

    ```pwsh
    dotnet publish ../Karamem0.SPClientCore/Karamem0.SPClientCore.csproj
    ```

1. `SPClientCore` をインポートします。

    ```pwsh
    Import-Module ../Karamem0.SPClientCore/bin/Debug/netstandard2.1/publish/SPClientCore.psd1
    ```

1. `SPClientCore.Test` をインポートします。

    ```pwsh
    Import-Module ./Scripts/SPClientCore.Test.psd1
    ```

1. `Uninstall-TestSite` を実行します。

    ```pwsh
    $certificatePath = Resolve-Path "./Certificate/localhost.crt"
    $privateKeyPath = Resolve-Path "./Certificate/localhost.key"
    $params = @{
        TenantName = "yourtenantname"
        ClientId = "53bf1d7f-f4dd-..."
        CertificatePath = $certificatePath
        PrivateKeyPath = $privateKeyPath
    }
    Uninstall-TestSite @params
    ```
