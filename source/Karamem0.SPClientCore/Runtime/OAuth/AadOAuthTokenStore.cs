//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.OAuth;

public static class AadOAuthTokenStore
{

    public static void Add(Uri resource, AadOAuthToken oAuthToken)
    {
        _ = resource ?? throw new ArgumentNullException(nameof(resource));
        _ = oAuthToken ?? throw new ArgumentNullException(nameof(oAuthToken));
        var oAuthTokens = AadOAuthTokenDictionary.Load();
        oAuthTokens[resource.GetAuthority()] = oAuthToken;
        oAuthTokens.Save();
    }

    public static AadOAuthToken Get(Uri resource)
    {
        _ = resource ?? throw new ArgumentNullException(nameof(resource));
        if (AadOAuthTokenDictionary
            .Load()
            .TryGetValue(resource.GetAuthority(), out var oAuthToken))
        {
            return oAuthToken;
        }
        throw new InvalidOperationException(StringResources.ErrorAccessTokenIsNotCached);
    }

    public static void Remove(Uri resource)
    {
        _ = resource ?? throw new ArgumentNullException(nameof(resource));
        var oAuthTokens = AadOAuthTokenDictionary.Load();
        _ = oAuthTokens.Remove(resource.GetAuthority());
        oAuthTokens.Save();
    }

    public static void Remove(string tenantId)
    {
        _ = tenantId ?? throw new ArgumentNullException(nameof(tenantId));
        var oAuthTokens = AadOAuthTokenDictionary.Load();
        var resource = oAuthTokens
            .Where(
                oAuthToken =>
                {
                    var accessToken = oAuthToken.Value.AccessToken;
                    var jwtToken = new JsonWebToken(accessToken);
                    var jwtTenantId = jwtToken.GetPayloadValue<string>("tid");
                    return jwtTenantId == tenantId;
                }
            )
            .Select(oAuthToken => oAuthToken.Key)
            .FirstOrDefault();
        if (resource is null)
        {
            _ = oAuthTokens.Remove(resource);
            oAuthTokens.Save();
        }
    }

}
