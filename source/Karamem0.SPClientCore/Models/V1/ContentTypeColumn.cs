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

    [ClientObject(Name = "SP.FieldLink", Id = "{e2d99203-868f-4211-ac76-f6bca0ff94ee}")]
    [JsonObject()]
    public class ContentTypeColumn : ClientObject
    {

        public ContentTypeColumn()
        {
        }

        [JsonProperty("FieldInternalName")]
        public virtual string ColumnName { get; protected set; }

        [JsonProperty()]
        public virtual string DisplayName { get; protected set; }

        [JsonProperty()]
        public virtual bool Hidden { get; protected set; }

        [JsonProperty()]
        public virtual Guid Id { get; protected set; }

        [JsonProperty()]
        public virtual string Name { get; protected set; }

        [JsonProperty()]
        public virtual bool ReadOnly { get; protected set; }

        [JsonProperty()]
        public virtual bool Required { get; protected set; }

        [JsonProperty()]
        public virtual bool ShowInDisplayForm { get; protected set; }

    }

}
