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
public class OAuthDeviceCode : OAuthMessage
{

    [JsonProperty("user_code")]
    public string? UserCode { get; protected set; }

    [JsonProperty("device_code")]
    public string? DeviceCode { get; protected set; }

    [JsonProperty("verification_url")]
    public string? VerificationUrl { get; protected set; }

    [JsonProperty("expires_in")]
    public int ExpiresIn { get; protected set; }

    [JsonProperty("interval")]
    public int Interval { get; protected set; }

    [JsonProperty("message")]
    public string? Message { get; protected set; }

}
