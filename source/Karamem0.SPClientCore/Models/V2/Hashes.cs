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

namespace Karamem0.SharePoint.PowerShell.Models.V2;

[JsonObject()]
public class Hashes : ODataV2Object
{

    [JsonProperty("crc32Hash")]
    public virtual string Crc32Hash { get; protected set; }

    [JsonProperty("sha1Hash")]
    public virtual string Sha1Hash { get; protected set; }

    [JsonProperty("sha256Hash")]
    public virtual string Sha256Hash { get; protected set; }

    [JsonProperty("quickXorHash")]
    public virtual string QuickXorHash { get; protected set; }

}
