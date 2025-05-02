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
public class Comment : ODataV1Object
{

    [JsonProperty("author")]
    public virtual SharingPrincipal? Author { get; set; }

    [JsonProperty("createdDate")]
    public virtual DateTime Created { get; set; }

    [JsonProperty("id")]
    public virtual int Id { get; set; }

    [JsonProperty("isLikedByUser")]
    public virtual bool IsLikedByUser { get; set; }

    [JsonProperty("isReply")]
    public virtual bool IsReply { get; set; }

    [JsonProperty("itemId")]
    public virtual int ItemId { get; set; }

    [JsonProperty("likeCount")]
    public virtual int LikeCount { get; set; }

    [JsonProperty("likedBy")]
    public virtual ODataV1ObjectEnumerable<LikedUser>? LikedBy { get; set; }

    [JsonProperty("listId")]
    public virtual Guid ListId { get; set; }

    [JsonProperty("parentId")]
    public virtual int ParentId { get; set; }

    [JsonProperty("replyCount")]
    public virtual int ReplyCount { get; set; }

    [JsonProperty("text")]
    public virtual string? Text { get; set; }

}
