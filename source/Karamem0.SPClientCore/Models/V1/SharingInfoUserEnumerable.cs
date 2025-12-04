//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;

namespace Karamem0.SharePoint.PowerShell.Models.V1;

[ClientObject(Name = "SP.ObjectSharingInformationUserCollection", Id = "{1eca4555-5715-4122-9c3d-0ab651518bc1}")]
[JsonObject()]
public class SharingInfoUserEnumerable : ClientObjectEnumerable<SharingInforUser>;
