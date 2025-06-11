//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading;

namespace Karamem0.SharePoint.PowerShell.Runtime.OAuth;

public interface IOAuthService
{

    void ConnectWithDeviceCode(
        Uri authority,
        string clientId,
        Uri resource,
        bool userMode,
        Action<string> callback
    );

    void ConnectWithCertificate(
        Uri authority,
        string clientId,
        Uri resource,
        BinaryData certificate,
        SecureString certificatePassword
    );

    void ConnectWithCertificate(
        Uri authority,
        string clientId,
        Uri resource,
        BinaryData certificate,
        BinaryData privateKey
    );

    void ConnectWithCache(
        Uri authority,
        string clientId,
        Uri resource
    );

    void ConnectWithClientSecret(
        string clientId,
        SecureString clientSecret,
        Uri resource
    );

}

public class OAuthService : IOAuthService
{

    public void ConnectWithDeviceCode(
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
            var oAuthDeviceCodeMessage = oAuthContext.AcquireDeviceCode();
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
                    var oAuthTokenMessage = oAuthContext.AcquireTokenByDeviceCode(oAuthDeviceCode.DeviceCode);
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

    public void ConnectWithCertificate(
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
        var oAuthMessage = oAuthContext.AcquireTokenByCertificate(certificate, certificatePassword);
        if (oAuthMessage is AadOAuthToken oAuthToken)
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
        if (oAuthMessage is OAuthError oAuthError)
        {
            throw new InvalidOperationException(oAuthError.ErrorDescription);
        }
    }

    public void ConnectWithCertificate(
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
        var oAuthMessage = oAuthContext.AcquireTokenByCertificate(certificate, privateKey);
        if (oAuthMessage is AadOAuthToken oAuthToken)
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
        if (oAuthMessage is OAuthError oAuthError)
        {
            throw new InvalidOperationException(oAuthError.ErrorDescription);
        }
    }

    public void ConnectWithCache(
        Uri authority,
        string clientId,
        Uri resource
    )
    {
        var oAuthContext = new AadOAuthContext(
            authority.GetAuthority(),
            clientId,
            resource.GetAuthority()
        );
        var oAuthToken = AadOAuthTokenStore.Get(resource);
        ClientService.Register(
            ClientContext.Create(
                resource,
                oAuthContext,
                oAuthToken
            )
        );
    }

    public void ConnectWithClientSecret(
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
        var oAuthMessage = oAuthContext.AcquireToken();
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
