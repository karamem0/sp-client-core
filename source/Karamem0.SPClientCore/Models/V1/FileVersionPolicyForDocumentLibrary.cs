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

[ClientObject(Name = "Microsoft.Online.SharePoint.TenantAdministration.SPOFileVersionPolicySettings", Id = "{9937c8a3-f14f-4630-afbc-aa59c4305618}")]
[JsonObject()]
public class FileVersionPolicyForDocumentLibrary : ClientValueObject
{

    public FileVersionPolicyForDocumentLibrary()
    {
    }

    public FileVersionPolicyForDocumentLibrary(IReadOnlyDictionary<string, object> parameters) : base(parameters)
    {
    }

    [JsonProperty()]
    public virtual bool EnableAutoExpirationVersionTrim { get; protected set; }

    [JsonProperty()]
    public virtual int ExpireVersionsAfterDays { get; protected set; }

    [JsonProperty()]
    public virtual int MajorVersionLimit { get; protected set; }

    [JsonProperty()]
    public virtual int MajorWithMinorVersionsLimit { get; protected set; }

    [JsonProperty()]
    public virtual bool MinorVersionsEnabled { get; protected set; }

    [JsonProperty()]
    public virtual bool VersioningEnabled { get; protected set; }

}
