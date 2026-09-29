//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security;
using System.Threading;

namespace Karamem0.SharePoint.PowerShell.Runtime.OAuth;

public interface IOAuthService
{

    Task ConnectWithDeviceCodeAsync(
        Uri authority,
        string clientId,
        Uri resource,
        bool userMode,
        Action<string> callback
    );

    Task ConnectWithCertificateAsync(
        Uri authority,
        string clientId,
        Uri resource,
        BinaryData certificate,
        SecureString certificatePassword
    );

    Task ConnectWithCertificateAsync(
        Uri authority,
        string clientId,
        Uri resource,
        BinaryData certificate,
        BinaryData privateKey
    );

    Task ConnectWithCacheAsync(Uri authority, Uri resource);

    Task ConnectWithClientSecretAsync(
        string clientId,
        SecureString clientSecret,
        Uri resource
    );

}

public class OAuthService : IOAuthService
{

    public async Task ConnectWithDeviceCodeAsync(
        Uri authority,
        string clientId,
        Uri resource,
        bool userMode,
        Action<string> callback
    )
    {
        try
        {
            Console.TreatControlCAsInput = true;
            var oAuthContext = new AadOAuthContext(
                authority.GetAuthority(),
                clientId,
                resource.GetAuthority(),
                userMode
            );
            var oAuthDeviceCodeMessage = await oAuthContext.AcquireDeviceCodeAsync();
            if (oAuthDeviceCodeMessage is OAuthDeviceCode oAuthDeviceCode)
            {
                _ = oAuthDeviceCode.Message ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
                _ = oAuthDeviceCode.DeviceCode ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
                callback?.Invoke(oAuthDeviceCode.Message);
                var expiresOn = DateTime.UtcNow.AddSeconds(oAuthDeviceCode.ExpiresIn);
                do
                {
                    for (var second = 0; second <= oAuthDeviceCode.Interval; second++)
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                        if (Console.KeyAvailable)
                        {
                            var key = Console.ReadKey(true);
                            if (key.Key == ConsoleKey.C && key.Modifiers == ConsoleModifiers.Control)
                            {
                                return;
                            }
                            if (key.Key == ConsoleKey.Escape)
                            {
                                return;
                            }
                        }
                    }
                    var oAuthTokenMessage = await oAuthContext.AcquireTokenByDeviceCodeAsync(oAuthDeviceCode.DeviceCode);
                    if (oAuthTokenMessage is AadOAuthToken oAuthToken)
                    {
                        AadOAuthTokenStore.Add(resource, oAuthToken);
                        ClientService.Register(
                            ClientContext.Create(
                                resource,
                                oAuthContext,
                                oAuthToken
                            )
                        );
                    }
                    if (oAuthTokenMessage is OAuthError oAuthTokenError)
                    {
                        if (oAuthTokenError.Error == "authorization_pending")
                        {
                            continue;
                        }
                        else
                        {
                            throw new InvalidOperationException(oAuthTokenError.ErrorDescription);
                        }
                    }
                    if (ClientService.ServiceProvider is not null)
                    {
                        break;
                    }
                } while (expiresOn > DateTime.UtcNow);
            }
            if (oAuthDeviceCodeMessage is OAuthError oAuthDeviceCodeError)
            {
                throw new InvalidOperationException(oAuthDeviceCodeError.ErrorDescription);
            }
        }
        finally
        {
            Console.TreatControlCAsInput = false;
        }
    }

    public async Task ConnectWithCertificateAsync(
        Uri authority,
        string clientId,
        Uri resource,
        BinaryData certificate,
        SecureString certificatePassword
    )
    {
        var oAuthContext = new AadOAuthContext(
            authority.GetAuthority(),
            clientId,
            resource.GetAuthority()
        );
        var oAuthMessage = await oAuthContext.AcquireTokenByCertificateAsync(certificate, certificatePassword);
        if (oAuthMessage is AadOAuthToken oAuthToken)
        {
            ClientService.Register(
                ClientContext.Create(
                    resource,
                    oAuthContext,
                    oAuthToken
                )
            );
        }
        if (oAuthMessage is OAuthError oAuthError)
        {
            throw new InvalidOperationException(oAuthError.ErrorDescription);
        }
    }

    public async Task ConnectWithCertificateAsync(
        Uri authority,
        string clientId,
        Uri resource,
        BinaryData certificate,
        BinaryData privateKey
    )
    {
        var oAuthContext = new AadOAuthContext(
            authority.GetAuthority(),
            clientId,
            resource.GetAuthority()
        );
        var oAuthMessage = await oAuthContext.AcquireTokenByCertificateAsync(certificate, privateKey);
        if (oAuthMessage is AadOAuthToken oAuthToken)
        {
            ClientService.Register(
                ClientContext.Create(
                    resource,
                    oAuthContext,
                    oAuthToken
                )
            );
        }
        if (oAuthMessage is OAuthError oAuthError)
        {
            throw new InvalidOperationException(oAuthError.ErrorDescription);
        }
    }

    public async Task ConnectWithCacheAsync(Uri authority, Uri resource)
    {
        var oAuthToken = AadOAuthTokenStore.Get(resource);
        var jwtToken = new JsonWebToken(oAuthToken.AccessToken);
        var clientId = jwtToken.GetPayloadValue<string>("appid");
        var oAuthContext = new AadOAuthContext(
            authority.GetAuthority(),
            clientId,
            resource.GetAuthority()
        );
        ClientService.Register(
            ClientContext.Create(
                resource,
                oAuthContext,
                oAuthToken
            )
        );
    }

    public async Task ConnectWithClientSecretAsync(
        string clientId,
        SecureString clientSecret,
        Uri resource
    )
    {
        var oAuthContext = new AcsOAuthContext(
            clientId,
            clientSecret,
            resource.GetAuthority()
        );
        var oAuthMessage = await oAuthContext.AcquireTokenAsync();
        if (oAuthMessage is AcsOAuthToken oAuthToken)
        {
            ClientService.Register(
                ClientContext.Create(
                    resource,
                    oAuthContext,
                    oAuthToken
                )
            );
        }
        if (oAuthMessage is OAuthError oAuthError)
        {
            throw new InvalidOperationException(oAuthError.ErrorDescription);
        }
    }

}
