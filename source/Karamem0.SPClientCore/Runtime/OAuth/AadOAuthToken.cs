//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Newtonsoft.Json;

namespace Karamem0.SharePoint.PowerShell.Runtime.OAuth;

[JsonObject()]
public class AadOAuthToken : OAuthMessage
{

    [JsonProperty("token_type")]
    public virtual string? TokenType { get; protected set; }

    [JsonProperty("scope")]
    public virtual string? Scope { get; protected set; }

    [JsonProperty("expires_in")]
    public virtual int ExpiresIn { get; protected set; }

    [JsonProperty("ext_expires_in")]
    public virtual int ExtExpiresIn { get; protected set; }

    [JsonProperty("access_token")]
    public virtual string? AccessToken { get; protected set; }

    [JsonProperty("refresh_token")]
    public virtual string? RefreshToken { get; protected set; }

}
