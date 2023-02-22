//
// Copyright (c) 2023 karamem0
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

    [ClientObject(Name = "SP.Sharing.DocumentSharingManager", Id = "{10c23c0e-cead-4f15-9deb-a0f1d7507495}")]
    [JsonObject()]
    public class DocumentSharingManager : ClientObject
    {

        public DocumentSharingManager()
        {
        }

    }

}
