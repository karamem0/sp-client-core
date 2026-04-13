//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;

namespace Karamem0.SharePoint.PowerShell.Models.V1;

[ClientObject(Name = "Microsoft.Online.SharePoint.TenantAdministration.SPOFileVersionFileTypePolicySettings", Id = "d9c57458-e19c-4cab-a08f-4563e52b8fb3")]
[JsonObject()]
public class FileVersionFileTypePolicySetting : ClientValueObject
{

    [JsonProperty()]
    public virtual bool EnableAutoExpirationVersionTrim { get; protected set; }

    [JsonProperty()]
    public virtual string? ExpireVersionsAfter { get; protected set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<string>? Extensions { get; protected set; }

    [JsonProperty()]
    public virtual int MajorVersionLimit { get; protected set; }

    [JsonProperty()]
    public virtual int MajorWithMinorVersionsLimit { get; protected set; }

    [JsonProperty()]
    public virtual string? Name { get; protected set; }

}
