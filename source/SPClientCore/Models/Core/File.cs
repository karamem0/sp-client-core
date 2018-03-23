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

    [JsonObject(Id = "SP.File")]
    public class File : ClientObject
    {

        public File()
        {
        }

        [JsonProperty()]
        public User Author { get; private set; }

        [JsonProperty()]
        public User CheckedOutByUser { get; private set; }

        [JsonProperty()]
        public string CheckInComment { get; private set; }

        [JsonProperty()]
        public int? CheckOutType { get; private set; }

        [JsonProperty()]
        public string ContentTag { get; private set; }

        [JsonProperty()]
        public int? CustomizedPageStatus { get; private set; }

        [JsonProperty()]
        public string ETag { get; private set; }

        [JsonProperty()]
        public bool? Exists { get; private set; }

        [JsonProperty()]
        public long? Length { get; private set; }

        [JsonProperty()]
        public byte? Level { get; private set; }

        [JsonProperty()]
        public ListItem ListItemAllFields { get; private set; }

        [JsonProperty()]
        public User LockedByUser { get; private set; }

        [JsonProperty()]
        public int? MajorVersion { get; private set; }

        [JsonProperty()]
        public int? MinorVersion { get; private set; }

        [JsonProperty()]
        public User ModifiedBy { get; private set; }

        [JsonProperty()]
        public string Name { get; private set; }

        [JsonProperty()]
        public string ServerRelativeUrl { get; private set; }

        [JsonProperty()]
        public DateTime? TimeCreated { get; private set; }

        [JsonProperty()]
        public DateTime? TimeLastModified { get; private set; }

        [JsonProperty()]
        public string Title { get; private set; }

        [JsonProperty()]
        public int? UIVersion { get; private set; }

        [JsonProperty()]
        public string UIVersionLabel { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<FileVersion> Versions { get; private set; }

    }

}
