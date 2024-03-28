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

namespace Karamem0.SharePoint.PowerShell.Models.V2;

[JsonObject()]
public class File : ODataV2Object
{

    public File()
    {
    }

    [JsonProperty("hashes")]
    public virtual Hashes Hashes { get; protected set; }

    [JsonProperty("irmEnabled")]
    public virtual bool IrmEnabled { get; protected set; }

    [JsonProperty("mimeType")]
    public virtual string MimeType { get; protected set; }

}
