//
// Copyright (c) 2019 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.OAuth
{

    public class OAuthTokenCache
    {

        private OAuthContext oAuthContext;

        private OAuthToken oAuthToken;

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
        }

        public string GetAccessToken() 
        {
            var jwtToken = new JwtSecurityToken(this.oAuthToken.AccessToken);
            var expireIn = (double)jwtToken.Payload.Exp;
            var expireOn = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(expireIn);
            if (expireOn <= DateTime.UtcNow)
            {
                var oAuthMessage = this.oAuthContext.AcquireTokenByRefreshToken(this.oAuthToken.RefreshToken);
                if (oAuthMessage is OAuthToken oAuthToken)
                {
                    this.oAuthToken = oAuthToken;
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
