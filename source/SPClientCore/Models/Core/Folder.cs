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

    [JsonObject(Id = "SP.Folder")]
    public class Folder : ClientObject
    {

        public Folder()
        {
        }

        [JsonProperty()]
        public ClientObjectCollection<ContentTypeId> ContentTypeOrder { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<File> Files { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<Folder> Folders { get; private set; }

        [JsonProperty()]
        public int? ItemCount { get; private set; }

        [JsonProperty()]
        public ListItem ListItemAllFields { get; private set; }

        [JsonProperty()]
        public string Name { get; private set; }

        [JsonProperty()]
        public Folder ParentFolder { get; private set; }

        [JsonProperty()]
        public PropertyValues Properties { get; private set; }

        [JsonProperty()]
        public string ServerRelativeUrl { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<ContentTypeId> UniqueContentTypeOrder { get; private set; }

        [JsonProperty()]
        public string WelcomePage { get; private set; }

    }

}
