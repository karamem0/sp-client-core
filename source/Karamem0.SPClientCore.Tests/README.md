# Karamem0.SPClientCore.Tests

## How to install the test environment

1. Register an Entra ID Application and upload the certificate (see Wiki page).

1. Create test users.

    |User Principal Name|Display Name|
    |-|-|
    |`testuser0@yourtenantname.onicrosoft.com`|Test User 0|
    |`testuser1@yourtenantname.onicrosoft.com`|Test User 1|
    |`testuser2@yourtenantname.onicrosoft.com`|Test User 2|
    |`testuser3@yourtenantname.onicrosoft.com`|Test User 3|

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
    $password = New-Object System.Security.SecureString
    $certificatePath = Resolve-Path "./Certificate/localhost.pfx"
    $params = @{
        TenantName = "yourtenantname"
        ClientId = "53bf1d7f-f4dd-..."
        CertificatePath = $certificatePath
        CertificatePassword = $password
        OwnerUserName = "someone@yourtenantname.onmicrosoft.com"
        ExternalUserName = "someone@example.com"
    }
    $settings = Install-TestSite @params
    $settings | ConvertTo-Json -Depth 16 | Out-File "./bin/Debug/net8.0/SPClientCore.Tests.config.json"
    ```

## How to uninstall the test environment

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
    $password = New-Object System.Security.SecureString
    $params = @{
        TenantName = "yourtenantname"
        ClientId = "53bf1d7f-f4dd-..."
        CertificatePath = "./Certificate/localhost.pfx"
        CertificatePassword = $password
    }
    Uninstall-TestSite @params
    ```
