//
// Copyright (c) 2019 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models
{

    [ClientObject(Name = "SP.RecycleBinItem", Id = "{5ebf462e-9e9a-440c-992b-abbb3916563d}")]
    [JsonObject()]
    public class RecycleBinItem : ClientObject
    {

        public RecycleBinItem()
        {
        }

        [JsonProperty()]
        public string AuthorEmail { get; private set; }

        [JsonProperty()]
        public string AuthorName { get; private set; }

        [JsonProperty()]
        public string DeletedByEmail { get; private set; }

        [JsonProperty()]
        public string DeletedByName { get; private set; }

        [JsonProperty()]
        public DateTime DeletedDate { get; private set; }

        [JsonProperty()]
        public string DeletedDateLocalFormatted { get; private set; }

        [JsonProperty()]
        public string DirName { get; private set; }

        [JsonProperty()]
        public ResourcePath DirNamePath { get; private set; }

        [JsonProperty()]
        public Guid Id { get; private set; }

        [JsonProperty()]
        public RecycleBinItemState ItemState { get; private set; }

        [JsonProperty()]
        public RecycleBinItemType ItemType { get; private set; }

        [JsonProperty()]
        public string LeafName { get; private set; }

        [JsonProperty()]
        public ResourcePath LeafNamePath { get; private set; }

        [JsonProperty()]
        public int Size { get; private set; }

        [JsonProperty()]
        public string Title { get; private set; }

    }

}
