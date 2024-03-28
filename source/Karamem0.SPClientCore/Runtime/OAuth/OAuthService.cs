//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

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

    void ConnectWithDeviceCode(Uri authority, string clientId, Uri resource, bool userMode, Action<string> callback);

    void ConnectWithPassword(Uri authority, string clientId, Uri resource, NetworkCredential credential, bool userMode);

    void ConnectWithCertificate(Uri authority, string clientId, Uri resource, byte[] certificate, SecureString password, bool userMode);

    void ConnectWithCache(Uri authority, string clientId, Uri resource, bool userMode);

    void ConnectWithClientSecret(string clientId, string clientSecret, Uri resource);

}

public class OAuthService : IOAuthService
{

    public void ConnectWithDeviceCode(Uri authority, string clientId, Uri resource, bool userMode, Action<string> callback)
    {
        try
        {
            Console.TreatControlCAsInput = true;
            authority ??= new Uri(OAuthConstants.AadAuthority);
            clientId ??= OAuthConstants.ClientId;
            var oAuthContext = new AadOAuthContext(authority.GetAuthority(), clientId, resource.GetAuthority(), userMode);
            var oAuthDeviceCodeMessage = oAuthContext.AcquireDeviceCode();
            if (oAuthDeviceCodeMessage is OAuthDeviceCode oAuthDeviceCode)
            {
                callback?.Invoke(oAuthDeviceCode.Message);
                var expiresOn = DateTime.UtcNow.AddSeconds(oAuthDeviceCode.ExpiresIn);
                do
                {
                    for (var second = 0; second < oAuthDeviceCode.Interval; second++)
                    {
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
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                    }
                    var oAuthTokenMessage = oAuthContext.AcquireTokenByDeviceCode(oAuthDeviceCode.DeviceCode);
                    if (oAuthTokenMessage is AadOAuthToken oAuthToken)
                    {
                        AadOAuthTokenStore.Add(resource, oAuthToken);
                        ClientService.Register(ClientContext.Create(resource, oAuthContext, oAuthToken));
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
                }
                while (expiresOn > DateTime.UtcNow);

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

    public void ConnectWithPassword(Uri authority, string clientId, Uri resource, NetworkCredential credential, bool userMode)
    {
        authority ??= new Uri(OAuthConstants.AadAuthority);
        clientId ??= OAuthConstants.ClientId;
        var oAuthContext = new AadOAuthContext(authority.GetAuthority(), clientId, resource.GetAuthority(), userMode);
        var oAuthMessage = oAuthContext.AcquireTokenByPassword(credential.UserName, credential.Password);
        if (oAuthMessage is AadOAuthToken oAuthToken)
        {
            AadOAuthTokenStore.Add(resource, oAuthToken);
            ClientService.Register(ClientContext.Create(resource, oAuthContext, oAuthToken));
        }
        if (oAuthMessage is OAuthError oAuthError)
        {
            throw new InvalidOperationException(oAuthError.ErrorDescription);
        }
    }

    public void ConnectWithCertificate(Uri authority, string clientId, Uri resource, byte[] certificate, SecureString password, bool userMode)
    {
        authority ??= new Uri(OAuthConstants.AadAuthority);
        clientId ??= OAuthConstants.ClientId;
        var oAuthContext = new AadOAuthContext(authority.GetAuthority(), clientId, resource.GetAuthority(), userMode);
        var oAuthMessage = oAuthContext.AcquireTokenByCertificate(certificate, password);
        if (oAuthMessage is AadOAuthToken oAuthToken)
        {
            AadOAuthTokenStore.Add(resource, oAuthToken);
            ClientService.Register(ClientContext.Create(resource, oAuthContext, oAuthToken));
        }
        if (oAuthMessage is OAuthError oAuthError)
        {
            throw new InvalidOperationException(oAuthError.ErrorDescription);
        }
    }

    public void ConnectWithCache(Uri authority, string clientId, Uri resource, bool userMode)
    {
        authority ??= new Uri(OAuthConstants.AadAuthority);
        clientId ??= OAuthConstants.ClientId;
        var oAuthContext = new AadOAuthContext(authority.GetAuthority(), clientId, resource.GetAuthority(), userMode);
        var oAuthToken = AadOAuthTokenStore.Get(resource);
        ClientService.Register(ClientContext.Create(resource, oAuthContext, oAuthToken));
    }

    public void ConnectWithClientSecret(string clientId, string clientSecret, Uri resource)
    {
        var oAuthContext = new AcsOAuthContext(
            clientId,
            clientSecret,
            resource.GetAuthority());
        var oAuthMessage = oAuthContext.AcquireToken();
        if (oAuthMessage is AcsOAuthToken oAuthToken)
        {
            ClientService.Register(ClientContext.Create(resource, oAuthContext, oAuthToken));
        }
        if (oAuthMessage is OAuthError oAuthError)
        {
            throw new InvalidOperationException(oAuthError.ErrorDescription);
        }
    }

}
