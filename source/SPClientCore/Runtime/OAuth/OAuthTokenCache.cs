//
// Copyright (c) 2020 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Resources;
using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.OAuth
{

    public class OAuthTokenCache
    {

        private OAuthContext oAuthContext;

        private OAuthToken oAuthToken;

        public OAuthTokenCache(OAuthContext oAuthContext)
        {
            if (oAuthContext == null)
            {
                throw new ArgumentNullException(nameof(oAuthContext));
            }
            this.oAuthContext = oAuthContext;
            this.oAuthToken = OAuthToken.Load();
        }

        public OAuthTokenCache(OAuthContext oAuthContext, OAuthToken oAuthToken)
        {
            if (oAuthContext == null)
            {
                throw new ArgumentNullException(nameof(oAuthContext));
            }
            if (oAuthToken == null)
            {
                throw new ArgumentNullException(nameof(oAuthToken));
            }
            this.oAuthContext = oAuthContext;
            this.oAuthToken = oAuthToken;
            this.oAuthToken.Save();
        }

        public string GetAccessToken() 
        {
            var jwtToken = new JsonWebToken(this.oAuthToken.AccessToken);
            var expireIn = jwtToken.GetPayloadValue<double>("exp");
            var expireOn = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(expireIn);
            if (expireOn <= DateTime.UtcNow)
            {
                if (this.oAuthToken.RefreshToken == null)
                {
                    throw new InvalidOperationException(StringResources.ErrorAccessTokenExpired);
                }
                var oAuthMessage = this.oAuthContext.AcquireTokenByRefreshToken(this.oAuthToken.RefreshToken);
                if (oAuthMessage is OAuthToken oAuthToken)
                {
                    this.oAuthToken = oAuthToken;
                    this.oAuthToken.Save();
                }
                if (oAuthMessage is OAuthError oAuthError)
                {
                    throw new InvalidOperationException(oAuthError.ErrorDescription);
                }
            }
            return this.oAuthToken.AccessToken;
        }

    }

}
