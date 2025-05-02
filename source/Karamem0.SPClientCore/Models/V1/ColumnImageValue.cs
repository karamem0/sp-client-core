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
public class ColumnImageValue(
    string? columnName = null,
    string? fileName = null,
    string? serverUrl = null,
    string? serverRelativeUrl = null,
    string? id = null,
    string? type = "thumbnail"
) : ODataObject
{

    [JsonProperty("fieldName")]
    public virtual string? ColumnName { get; protected set; } = columnName;

    [JsonProperty("fileName")]
    public virtual string? FileName { get; protected set; } = fileName;

    [JsonProperty("id")]
    public virtual string? Id { get; protected set; } = id;

    [JsonProperty("serverRelativeUrl")]
    public virtual string? ServerRelativeUrl { get; protected set; } = serverRelativeUrl;

    [JsonProperty("serverUrl")]
    public virtual string? ServerUrl { get; protected set; } = serverUrl;

    [JsonProperty("type")]
    public virtual string? Type { get; protected set; } = type;

}
