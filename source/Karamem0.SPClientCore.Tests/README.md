# Karamem0.SPClientCore.Tests

## How to set up the test environment

1. Create a self-signed certificate and save it to `Certificate/localhost.pfx`.

1. Register an Entra ID Application and upload the certificate (see Wiki page).

1. Create test users.

    |User Principal Name|Display Name|
    |-|-|
    |`testuser0@yourtenantname.onmicrosoft.com`|Test User 0|
    |`testuser1@yourtenantname.onmicrosoft.com`|Test User 1|
    |`testuser2@yourtenantname.onmicrosoft.com`|Test User 2|
    |`testuser3@yourtenantname.onmicrosoft.com`|Test User 3|

1. Invite a guest user (`outlook.com`, `gmail.com`, etc.).

1. Publish `SPClientCore`.

    ```pwsh
    dotnet publish ../Karamem0.SPClientCore/Karamem0.SPClientCore.csproj
    ```

1. Import `SPClientCore`.

    ```pwsh
    Import-Module ../Karamem0.SPClientCore/bin/Debug/netstandard2.1/publish/SPClientCore.psd1
    ```

1. Import `SPClientCore.Tests`.

    ```pwsh
    Import-Module ./Scripts/SPClientCore.Tests.psd1
    ```

1. Run `Install-TestSite`.

    ```pwsh
    $certificatePath = Resolve-Path "./Certificate/localhost.pfx"
    $certificatePassword = ConvertTo-SecureString "p@$$w0rd" -AsPlainText -Force
    $params = @{
        TenantName = "yourtenantname"
        ClientId = "53bf1d7f-f4dd-..."
        CertificatePath = $certificatePath
        CertificatePassword = $certificatePassword
        OwnerUserName = "someone@yourtenantname.onmicrosoft.com"
        ExternalUserName = "someone@example.com"
    }
    $settings = Install-TestSite @params
    $settings | ConvertTo-Json -Depth 16 | Out-File "./bin/Debug/net8.0/SPClientCore.Tests.config.json"
    ```

1. These components are created.

- `/sites/sp-client-core`
  - `/TestSite1` (Site)
    - `/TestSite2` (Site)
      - `/TestSite3` (Site)
      - `/TestSite4` (Site)
    - `/Lists/TestList1` (List)
      - `Column1` (Text)
      - `Column2` (MultiLineText)
      - `Column3` (Choice)
      - `Column4` (MultiChoice)
      - `Column5` (Number)
      - `Column6` (Currency)
      - `Column7` (DateTime)
      - `Column8` (Lookup)
      - `Column9` (LookupMulti)
      - `Column10` (Boolean)
      - `Column11` (User)
      - `Column12` (UserMulti)
      - `Column13` (Url)
      - `Column14` (Calculated)
      - `Column15` (Guid)
      - `Column16` (Geolocation)
      - `Column17` (Taxonomy)
      - `Column18` (Image)
    - `/TestList2` (DocLib)
    - `/TestList3` (DocLib)

## How to clean up the test environment

1. Publish `SPClientCore`.

    ```pwsh
    dotnet publish ../Karamem0.SPClientCore/Karamem0.SPClientCore.csproj
    ```

1. Import `SPClientCore`.

    ```pwsh
    Import-Module ../Karamem0.SPClientCore/bin/Debug/netstandard2.1/publish/SPClientCore.psd1
    ```

1. Import `SPClientCore.Tests`.

    ```pwsh
    Import-Module ./Scripts/SPClientCore.Tests.psd1
    ```

1. Run `Uninstall-TestSite`.

    ```pwsh
    $certificatePath = Resolve-Path "./Certificate/localhost.pfx"
    $certificatePassword = ConvertTo-SecureString "p@$$w0rd" -AsPlainText -Force
    $params = @{
        TenantName = "yourtenantname"
        ClientId = "53bf1d7f-f4dd-..."
        CertificatePath = $certificatePath
        CertificatePassword = $certificatePassword
    }
    Uninstall-TestSite @params
    ```
