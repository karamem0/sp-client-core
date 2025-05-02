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

[ClientObject(Name = "SP.RecycleBinItem", Id = "{5ebf462e-9e9a-440c-992b-abbb3916563d}")]
[JsonObject()]
public class RecycleBinItem : ClientObject
{

    [JsonProperty()]
    public virtual string? AuthorEmail { get; set; }

    [JsonProperty()]
    public virtual string? AuthorName { get; set; }

    [JsonProperty()]
    public virtual string? DeletedByEmail { get; set; }

    [JsonProperty()]
    public virtual string? DeletedByName { get; set; }

    [JsonProperty()]
    public virtual DateTime DeletedDate { get; set; }

    [JsonProperty()]
    public virtual string? DeletedDateLocalFormatted { get; set; }

    [JsonProperty()]
    public virtual string? DirName { get; set; }

    [JsonProperty()]
    public virtual ResourcePath? DirNamePath { get; set; }

    [JsonProperty()]
    public virtual Guid Id { get; set; }

    [JsonProperty()]
    public virtual RecycleBinItemState? ItemState { get; set; }

    [JsonProperty()]
    public virtual RecycleBinItemType? ItemType { get; set; }

    [JsonProperty()]
    public virtual string? LeafName { get; set; }

    [JsonProperty()]
    public virtual ResourcePath? LeafNamePath { get; set; }

    [JsonProperty()]
    public virtual int Size { get; set; }

    [JsonProperty()]
    public virtual string? Title { get; set; }

}
