//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.V1;

[JsonObject()]
public class LikedUser : ODataV1Object<LikedUser>
{

    [JsonProperty("creationDate")]
    public virtual DateTime Created { get; protected set; }

    [JsonProperty("email")]
    public virtual string? Email { get; protected set; }

    [JsonProperty("id")]
    public virtual int Id { get; protected set; }

    [JsonProperty("loginName")]
    public virtual string? LoginName { get; protected set; }

    [JsonProperty("name")]
    public virtual string? Name { get; protected set; }

}
