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

[ClientObject(Name = "SP.ChangeGroup", Id = "{8c377687-4e62-4ddb-b244-20a832de16dd}")]
[JsonObject()]
public class ChangeGroup : Change
{

    [JsonProperty()]
    public override ChangeToken? ChangeToken { get; set; }

    [JsonProperty()]
    public override ChangeType? ChangeType { get; set; }

    [JsonProperty()]
    public virtual int GroupId { get; set; }

    [JsonProperty()]
    public override string? RelativeTime { get; set; }

    [JsonProperty("SiteId")]
    public override Guid SiteCollectionId { get; set; }

    [JsonProperty()]
    public override DateTime Time { get; set; }

}
