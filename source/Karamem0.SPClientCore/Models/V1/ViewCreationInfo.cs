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

[ClientObject(Name = "SP.ViewCreationInformation", Id = "{a3547807-7266-42f3-b055-afa6e840e458}")]
[JsonObject()]
public class ViewCreationInfo : ClientValueObject
{

    [JsonProperty()]
    public virtual int BaseViewId { get; private set; }

    [JsonProperty()]
    public virtual bool Paged { get; private set; }

    [JsonProperty()]
    public virtual bool PersonalView { get; private set; }

    [JsonProperty()]
    public virtual int RowLimit { get; private set; }

    [JsonProperty()]
    public virtual bool SetAsDefaultView { get; private set; }

    [JsonProperty()]
    public virtual string? Title { get; private set; }

    [JsonProperty("ViewFields")]
    public virtual IReadOnlyCollection<string>? ViewColumns { get; private set; }

    [JsonProperty("Query")]
    public virtual string? ViewQuery { get; private set; }

    [JsonProperty("ViewTypeKind")]
    public virtual ViewType? ViewType { get; private set; }

}
