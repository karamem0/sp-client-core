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
public class FileVersionPolicy(Tenant? tenant = null) : ODataObject
{

    [JsonProperty()]
    public virtual bool EnableAutoExpirationVersionTrim { get; set; } = tenant?.EnableAutoExpirationVersionTrim ?? default;

    [JsonProperty()]
    public virtual int ExpireVersionsAfterDays { get; set; } = tenant?.ExpireVersionsAfterDays ?? default;

    [JsonProperty()]
    public virtual int MajorVersionLimit { get; set; } = tenant?.MajorVersionLimit ?? default;

}
