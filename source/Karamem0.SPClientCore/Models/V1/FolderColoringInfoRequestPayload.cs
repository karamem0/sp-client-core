//
// Copyright (c) 2018-2025 karamem0
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

namespace Karamem0.SharePoint.PowerShell.Models.V1;

[JsonObject()]
public class FolderColoringInfoRequestPayload
{

    public static FolderColoringInfoRequestPayload Create(IReadOnlyDictionary<string, object?> parameters)
    {
        var value = new FolderColoringInfoRequestPayload()
        {
            Entity = ClientValueObject.Create<FolderColoringInfo>(parameters)
        };
        return value;
    }

    [JsonProperty("coloringInformation")]
    public FolderColoringInfo? Entity { get; protected set; }

}
