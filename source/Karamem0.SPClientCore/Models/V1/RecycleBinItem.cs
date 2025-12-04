//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;

namespace Karamem0.SharePoint.PowerShell.Models.V1;

[ClientObject(Name = "SP.RecycleBinItem", Id = "{5ebf462e-9e9a-440c-992b-abbb3916563d}")]
[JsonObject()]
public class RecycleBinItem : ClientObject
{

    [JsonProperty()]
    public virtual string? AuthorEmail { get; protected set; }

    [JsonProperty()]
    public virtual string? AuthorName { get; protected set; }

    [JsonProperty()]
    public virtual string? DeletedByEmail { get; protected set; }

    [JsonProperty()]
    public virtual string? DeletedByName { get; protected set; }

    [JsonProperty()]
    public virtual DateTime DeletedDate { get; protected set; }

    [JsonProperty()]
    public virtual string? DeletedDateLocalFormatted { get; protected set; }

    [JsonProperty()]
    public virtual string? DirName { get; protected set; }

    [JsonProperty()]
    public virtual ResourcePath? DirNamePath { get; protected set; }

    [JsonProperty()]
    public virtual Guid Id { get; protected set; }

    [JsonProperty()]
    public virtual RecycleBinItemState ItemState { get; protected set; }

    [JsonProperty()]
    public virtual RecycleBinItemType ItemType { get; protected set; }

    [JsonProperty()]
    public virtual string? LeafName { get; protected set; }

    [JsonProperty()]
    public virtual ResourcePath? LeafNamePath { get; protected set; }

    [JsonProperty()]
    public virtual int Size { get; protected set; }

    [JsonProperty()]
    public virtual string? Title { get; protected set; }

}
