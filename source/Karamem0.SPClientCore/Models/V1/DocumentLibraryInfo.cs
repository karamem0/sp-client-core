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

    [ClientObject(Name = "SP.DocumentLibraryInformation", Id = "{fb3ddd20-725d-4c42-8c72-34c5efc2a0b4}")]
    [JsonObject()]
    public class DocumentLibraryInfo : ClientValueObject
    {

        public DocumentLibraryInfo()
        {
        }

        [JsonProperty()]
        public virtual string AbsoluteUrl { get; protected set; }

        [JsonProperty()]
        public virtual bool FromCrossFarm { get; protected set; }

        [JsonProperty()]
        public virtual string DriveId { get; protected set; }

        [JsonProperty()]
        public virtual Guid Id { get; protected set; }

        [JsonProperty()]
        public virtual bool IsDefaultDocumentLibrary { get; protected set; }

        [JsonProperty()]
        public virtual DateTime Modified { get; protected set; }

        [JsonProperty()]
        public virtual string ModifiedFriendlyDisplay { get; protected set; }

        [JsonProperty()]
        public virtual string ServerRelativeUrl { get; protected set; }

        [JsonProperty()]
        public virtual string Title { get; protected set; }

    }

}
