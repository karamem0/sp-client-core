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

    [JsonObject(Id = "SP.CreatablesInfo")]
    public class CreatablesInfo : ClientObject
    {

        public CreatablesInfo()
        {
        }

        [JsonProperty()]
        public bool? CanCreateFolders { get; private set; }

        [JsonProperty()]
        public bool? CanCreateItems { get; private set; }

        [JsonProperty()]
        public bool? CanUploadFiles { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<CreatableItemInfo> CreatablesCollection { get; private set; }

    }

}
