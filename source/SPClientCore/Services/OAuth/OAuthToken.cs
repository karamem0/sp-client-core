//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.OAuth
{

    [JsonObject()]
    public class OAuthToken : OAuthMessage
    {

        public OAuthToken()
        {
        }

        [JsonProperty("token_type")]
        public string TokenType { get; private set; }

        [JsonProperty("scope")]
        public string Scope { get; private set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; private set; }

        [JsonProperty("ext_expires_in")]
        public int ExtExpiresIn { get; private set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; private set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; private set; }

    }

}
