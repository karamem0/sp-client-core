//
// Copyright (c) 2022 karamem0
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

namespace Karamem0.SharePoint.PowerShell.Models.V1
{

    [JsonObject()]
    public class ColumnImageValue : ODataObject
    {

        public ColumnImageValue()
        {
        }

        public ColumnImageValue(string columnName, string fileName, string serverUrl, string serverRelativeUrl, string id)
        {
            this.Type = "thumbnail";
            this.ColumnName = columnName;
            this.FileName = fileName;
            this.ServerUrl = serverUrl;
            this.ServerRelativeUrl = serverRelativeUrl;
            this.Id = id;
        }

        [JsonProperty("fieldName")]
        public virtual string ColumnName { get; protected set; }

        [JsonProperty("fileName")]
        public virtual string FileName { get; protected set; }

        [JsonProperty("id")]
        public virtual string Id { get; protected set; }

        [JsonProperty("serverRelativeUrl")]
        public virtual string ServerRelativeUrl { get; protected set; }

        [JsonProperty("serverUrl")]
        public virtual string ServerUrl { get; protected set; }

        [JsonProperty("type")]
        public virtual string Type { get; protected set; }

    }

}
