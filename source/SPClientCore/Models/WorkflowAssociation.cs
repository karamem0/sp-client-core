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

namespace Karamem0.SharePoint.PowerShell.Models
{

    [JsonObject(Id = "SP.WorkflowAssociation")]
    public class WorkflowAssociation : ClientObject
    {

        public WorkflowAssociation()
        {
        }

        [JsonProperty()]
        public bool? AllowManual { get; private set; }

        [JsonProperty()]
        public string AssociationData { get; private set; }

        [JsonProperty()]
        public bool? AutoStartChange { get; private set; }

        [JsonProperty()]
        public bool? AutoStartCreate { get; private set; }

        [JsonProperty()]
        public Guid? BaseId { get; private set; }

        [JsonProperty()]
        public DateTime? Created { get; private set; }

        [JsonProperty()]
        public string Description { get; private set; }

        [JsonProperty()]
        public bool? Enabled { get; private set; }

        [JsonProperty()]
        public string HistoryListTitle { get; private set; }

        [JsonProperty()]
        public Guid? Id { get; private set; }

        [JsonProperty()]
        public string InstantiationUrl { get; private set; }

        [JsonProperty()]
        public string PublicName { get; private set; }

        [JsonProperty()]
        public bool? IsDeclarative { get; private set; }

        [JsonProperty()]
        public Guid? ListId { get; private set; }

        [JsonProperty()]
        public DateTime? Modified { get; private set; }

        [JsonProperty()]
        public string Name { get; private set; }

        [JsonProperty()]
        public string TaskListTitle { get; private set; }

        [JsonProperty()]
        public Guid? WebId { get; private set; }

    }

}
