//
// Copyright (c) 2018-2024 karamem0
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

    public ChangeGroup()
    {
    }

    [JsonProperty()]
    public override ChangeToken ChangeToken { get; protected set; }

    [JsonProperty()]
    public override ChangeType ChangeType { get; protected set; }

    [JsonProperty()]
    public virtual int GroupId { get; protected set; }

    [JsonProperty()]
    public override string RelativeTime { get; protected set; }

    [JsonProperty("SiteId")]
    public override Guid SiteCollectionId { get; protected set; }

    [JsonProperty()]
    public override DateTime Time { get; protected set; }

}
