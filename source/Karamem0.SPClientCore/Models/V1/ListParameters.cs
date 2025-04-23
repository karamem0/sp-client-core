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

[ClientObject(Name = "Microsoft.Online.SharePoint.TenantAdministration.SPOListParameters", Id = "{041476cd-5865-49c1-bb67-0682f69a2a51}")]
[JsonObject()]
public class ListParameters(Guid id = new Guid(), string title = null) : ClientValueObject
{

    [JsonProperty()]
    public virtual Guid Id { get; protected set; } = id;

    [JsonProperty()]
    public virtual string Title { get; protected set; } = title;

}
