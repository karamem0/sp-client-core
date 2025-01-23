//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

[JsonObject()]
public class ODataV1Metadata : ValueObject
{

    public static ODataV1Metadata Create(Type type)
    {
        var attribute = type.GetCustomAttribute<ODataV1ObjectAttribute>(false);
        if (attribute is not null)
        {
            if (attribute.Name is not null)
            {
                return new ODataV1Metadata()
                {
                    Id = null,
                    Uri = null,
                    Type = attribute.Name
                };
            }
        }
        return null;
    }

    [JsonProperty("id")]
    public string Id { get; private set; }

    [JsonProperty("uri")]
    public Uri Uri { get; private set; }

    [JsonProperty("type")]
    public string Type { get; private set; }

}
