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

[ClientObject(Name = "SP.ChangeWeb", Id = "{e7fa8647-bde1-474c-93b1-1ef9ce5cf02c}")]
[JsonObject()]
public class ChangeSite : Change
{

    [JsonProperty()]
    public override ChangeToken? ChangeToken { get; protected set; }

    [JsonProperty()]
    public override ChangeType ChangeType { get; protected set; }

    [JsonProperty()]
    public override string? RelativeTime { get; protected set; }

    [JsonProperty("SiteId")]
    public override Guid SiteCollectionId { get; protected set; }

    [JsonProperty("WebId")]
    public virtual Guid SiteId { get; protected set; }

    [JsonProperty()]
    public override DateTime Time { get; protected set; }

}
