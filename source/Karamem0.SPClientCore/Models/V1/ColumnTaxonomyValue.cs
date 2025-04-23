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

[ClientObject(Name = "SP.Taxonomy.TaxonomyFieldValue", Id = "{19e70ed0-4177-456b-8156-015e4d163ff8}")]
[JsonObject()]
public class ColumnTaxonomyValue(
    string label = null,
    string termGuid = null,
    int wssId = 0
) : ClientValueObject
{

    [JsonProperty()]
    public virtual string Label { get; protected set; } = label;

    [JsonProperty()]
    public virtual string TermGuid { get; protected set; } = termGuid;

    [JsonProperty()]
    public virtual int WssId { get; protected set; } = wssId;

}
