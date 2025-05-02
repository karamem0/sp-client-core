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

[ClientObject(Name = "SP.AlertCreationInformation", Id = "{f0c12e8e-54f5-4e31-b015-f4f824eea024}")]
[JsonObject()]
public class AlertCreationInfo : ClientValueObject
{

    [JsonProperty()]
    public virtual AlertFrequency? AlertFrequency { get; set; }

    [JsonProperty()]
    public virtual string? AlertTemplateName { get; set; }

    [JsonProperty()]
    public virtual DateTime AlertTime { get; set; }

    [JsonProperty()]
    public virtual AlertType? AlertType { get; set; }

    [JsonProperty()]
    public virtual bool AlwaysNotify { get; set; }

    [JsonProperty()]
    public virtual AlertDeliveryChannel? DeliveryChannels { get; set; }

    [JsonProperty()]
    public virtual AlertEventType? EventType { get; set; }

    [JsonProperty()]
    public virtual int EventTypeBitmask { get; set; }

    [JsonProperty()]
    public virtual string? Filter { get; set; }

    [JsonProperty()]
    public virtual List? List { get; set; }

    [JsonProperty("Item")]
    public virtual ListItem? ListItem { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyDictionary<string, string>? Properties { get; set; }

    [JsonProperty()]
    public virtual AlertStatus? Status { get; set; }

    [JsonProperty()]
    public virtual string? Title { get; set; }

    [JsonProperty()]
    public virtual User? User { get; set; }

}
