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

[ClientObject()]
[JsonObject()]
public class FileVersionPolicy : ClientValueObject
{

    public FileVersionPolicy()
    {
    }

    public FileVersionPolicy(Tenant tenant)
    {
        this.EnableAutoExpirationVersionTrim = tenant.EnableAutoExpirationVersionTrim;
        this.ExpireVersionsAfterDays = tenant.ExpireVersionsAfterDays;
        this.MajorVersionLimit = tenant.MajorVersionLimit;
    }

    [JsonProperty()]
    public virtual bool EnableAutoExpirationVersionTrim { get; protected set; }

    [JsonProperty()]
    public virtual int ExpireVersionsAfterDays { get; protected set; }

    [JsonProperty()]
    public virtual int MajorVersionLimit { get; protected set; }

}
