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

namespace Karamem0.SharePoint.PowerShell.Runtime.OAuth;

public static class AadOAuthTokenStore
{

    public static void Add(Uri resource, AadOAuthToken oAuthToken)
    {
        var oAuthTokens = AadOAuthTokenDictionary.Load();
        oAuthTokens[resource.GetAuthority()] = oAuthToken;
        oAuthTokens.Save();
    }

    public static AadOAuthToken Get(Uri resource)
    {
        var oAuthTokens = AadOAuthTokenDictionary.Load();
        if (oAuthTokens.TryGetValue(resource.GetAuthority(), out var oAuthToken))
        {
            return oAuthToken;
        }
        throw new InvalidOperationException(StringResources.ErrorAccessTokenIsNotCached);
    }

    public static void Remove(Uri resource)
    {
        var oAuthTokens = AadOAuthTokenDictionary.Load();
        _ = oAuthTokens.Remove(resource.GetAuthority());
        oAuthTokens.Save();
    }

    public static void Remove(string tenantId)
    {
        var oAuthTokens = AadOAuthTokenDictionary.Load();
        var resource = oAuthTokens
            .Where(oAuthToken =>
                {
                    var accessToken = oAuthToken.Value.AccessToken;
                    var jwtToken = new JsonWebToken(accessToken);
                    var jwtTenantId = jwtToken.GetPayloadValue<string>("tid");
                    return jwtTenantId == tenantId;
                }
            )
            .Select(oAuthToken => oAuthToken.Key)
            .FirstOrDefault();
        if (resource is not null)
        {
            _ = oAuthTokens.Remove(resource);
            oAuthTokens.Save();
        }
    }

}
