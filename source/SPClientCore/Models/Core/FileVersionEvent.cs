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

    [JsonObject(Id = "SP.FileVersionEvent")]
    public class FileVersionEvent : ClientObject
    {

        public FileVersionEvent()
        {
        }

        [JsonProperty()]
        public string Editor { get; private set; }

        [JsonProperty()]
        public string EditorEmail { get; private set; }

        [JsonProperty()]
        public FileVersionEventType EventType { get; private set; }

        [JsonProperty()]
        public SharedWithUser SharedByUser { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<SharedWithUser> SharedWithUsers { get; private set; }

        [JsonProperty()]
        public DateTime? Time { get; private set; }

    }

}
