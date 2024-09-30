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

[ClientObject(Name = "SP.Navigation", Id = "{d6aa87a7-71b3-4bbe-bca7-00ab1bd7d37f}")]
[JsonObject()]
public class Navigation : ClientObject
{

    public Navigation()
    {
    }

    [JsonProperty()]
    public virtual NavigationNodeEnumerable QuickLaunch { get; protected set; }

    [JsonProperty()]
    public virtual NavigationNodeEnumerable TopNavigationBar { get; protected set; }

    [JsonProperty()]
    public virtual bool UseShared { get; protected set; }

}
