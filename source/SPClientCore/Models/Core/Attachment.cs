﻿//
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

    [JsonObject(Id = "SP.Attachment")]
    public class Attachment : ClientObject
    {

        public Attachment()
        {
        }

        [JsonProperty()]
        public string FileName { get; private set; }

        [JsonProperty()]
        public ResourcePath FileNameAsPath { get; private set; }

        [JsonProperty()]
        public ResourcePath ServerRelativePath { get; private set; }

        [JsonProperty()]
        public string ServerRelativeUrl { get; private set; }

    }

}