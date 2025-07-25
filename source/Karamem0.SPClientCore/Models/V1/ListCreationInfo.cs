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
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.V1;

[ClientObject(Name = "SP.ListCreationInformation", Id = "{e247b7fc-095e-4ea4-a4c9-c5d373723d8c}")]
[JsonObject()]
public class ListCreationInfo : ClientValueObject
{

    [JsonProperty()]
    public virtual string? Description { get; protected set; }

    [JsonProperty()]
    [DefaultValue(QuickLaunchOptions.DefaultValue)]
    public virtual QuickLaunchOptions QuickLaunchOption { get; protected set; }

    [JsonProperty("Url")]
    public virtual Uri? ServerRelativeUrl { get; protected set; }

    [JsonProperty("TemplateType")]
    public virtual int Template { get; protected set; }

    [JsonProperty()]
    public virtual string? Title { get; protected set; }

}
