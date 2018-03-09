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

    [JsonObject(Id = "SP.RecycleBinItem")]
    public class RecycleBinItem : ClientObject
    {

        public RecycleBinItem()
        {
        }

        [JsonProperty()]
        public User Author { get; private set; }

        [JsonProperty()]
        public User DeletedBy { get; private set; }

        [JsonProperty()]
        public DateTime? DeletedDate { get; private set; }

        [JsonProperty()]
        public string DirName { get; private set; }

        [JsonProperty()]
        public Guid? Id { get; private set; }

        [JsonProperty()]
        public RecycleBinItemState? ItemState { get; private set; }

        [JsonProperty()]
        public RecycleBinItemType? ItemType { get; private set; }

        [JsonProperty()]
        public string LeafName { get; private set; }

        [JsonProperty()]
        public int? Size { get; private set; }

        [JsonProperty()]
        public string Title { get; private set; }

    }

}
