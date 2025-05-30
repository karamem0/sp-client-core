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

[ClientObject(Name = "SP.WebCreationInformation", Id = "{8f9e9fbe-189e-492f-884f-98f9ef9cc4d6}")]
[JsonObject()]
public class SiteCreationInfo : ClientValueObject
{

    [JsonProperty()]
    public virtual string? Description { get; protected set; }

    [JsonProperty("Language")]
    public virtual uint Lcid { get; protected set; }

    [JsonProperty("Url")]
    public virtual Uri? ServerRelativeUrl { get; protected set; }

    [JsonProperty("WebTemplate")]
    public virtual string? Template { get; protected set; }

    [JsonProperty()]
    public virtual string? Title { get; protected set; }

    [JsonProperty()]
    public virtual bool UseSamePermissionsAsParentSite { get; protected set; }

}
