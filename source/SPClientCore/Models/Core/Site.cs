//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.Core
{

    [JsonObject(Id = "SP.Site")]
    public class Site : ClientObject
    {

        public Site()
        {
        }

        [JsonProperty()]
        public bool? AllowDesigner { get; private set; }

        [JsonProperty()]
        public bool? AllowMasterPageEditing { get; private set; }

        [JsonProperty()]
        public bool? AllowRevertFromTemplate { get; private set; }

        [JsonProperty()]
        public bool? AllowSelfServiceUpgrade { get; private set; }

        [JsonProperty()]
        public bool? AllowSelfServiceUpgradeEvaluation { get; private set; }

        [JsonProperty()]
        public bool? CanUpgrade { get; private set; }

        [JsonProperty()]
        public int? CompatibilityLevel { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<EventReceiverDefinition> EventReceivers { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<Feature> Features { get; private set; }

        [JsonProperty()]
        public Guid? Id { get; private set; }

        [JsonProperty()]
        public string LockIssue { get; private set; }

        [JsonProperty()]
        public string MaxItemsPerThrottledOperation { get; private set; }

        [JsonProperty()]
        public User Owner { get; private set; }

        [JsonProperty()]
        public string PrimaryUri { get; private set; }

        [JsonProperty()]
        public bool? ReadOnly { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<RecycleBinItem> RecycleBin { get; private set; }

        [JsonProperty()]
        public Web RootWeb { get; private set; }

        [JsonProperty()]
        public string ServerRelativeUrl { get; private set; }

        [JsonProperty()]
        public bool? ShareByLinkEnabled { get; private set; }

        [JsonProperty()]
        public bool? ShowUrlStructure { get; private set; }

        [JsonProperty()]
        public bool? UIVersionConfigurationEnabled { get; private set; }

        [JsonProperty()]
        public UpgradeInfo UpgradeInfo { get; private set; }

        [JsonProperty()]
        public string UpgradeReminderDate { get; private set; }

        [JsonProperty()]
        public bool? Upgrading { get; private set; }

        [JsonProperty()]
        public string Url { get; private set; }

        [JsonProperty()]
        public UsageInfo Usage { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<UserCustomAction> UserCustomActions { get; private set; }

    }

}
