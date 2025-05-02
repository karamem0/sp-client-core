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

[ClientObject(Name = "SP.ChangeItem", Id = "{3e4716ac-a622-4d48-bc14-3fecabd52e21}")]
[JsonObject()]
public class ChangeItem : Change
{

    [JsonProperty()]
    public override ChangeToken? ChangeToken { get; set; }

    [JsonProperty()]
    public override ChangeType? ChangeType { get; set; }

    [JsonProperty()]
    public virtual string? Editor { get; set; }

    [JsonProperty()]
    public virtual string? EditorEmailHint { get; set; }

    [JsonProperty()]
    public virtual string? EditorLoginName { get; set; }

    [JsonProperty()]
    public virtual FileSystemObjectType? FileSystemObjectType { get; set; }

    [JsonProperty()]
    public virtual string? FileType { get; set; }

    [JsonProperty()]
    public virtual string? HashTag { get; set; }

    [JsonProperty()]
    public virtual bool Hidden { get; set; }

    [JsonProperty()]
    public virtual int ItemId { get; set; }

    [JsonProperty()]
    public virtual Guid ListId { get; set; }

    [JsonProperty()]
    public virtual ListTemplateType? ListTemplate { get; set; }

    [JsonProperty()]
    public virtual string? ListTitle { get; set; }

    [JsonProperty()]
    public override string? RelativeTime { get; set; }

    [JsonProperty()]
    public virtual string? ServerRelativeUrl { get; set; }

    [JsonProperty("SharedByUser")]
    public virtual SharedWithUser? SharedWithUser { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<SharedWithUser>? SharedWithUsers { get; set; }

    [JsonProperty("SiteId")]
    public override Guid SiteCollectionId { get; set; }

    [JsonProperty("WebId")]
    public virtual Guid SiteId { get; set; }

    [JsonProperty()]
    public override DateTime Time { get; set; }

    [JsonProperty()]
    public virtual string? Title { get; set; }

    [JsonProperty()]
    public virtual Guid UniqueId { get; set; }

}
