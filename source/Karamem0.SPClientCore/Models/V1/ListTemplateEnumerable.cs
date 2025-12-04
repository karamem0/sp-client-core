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

[ClientObject(Name = "SP.ListTemplateCollection", Id = "{23748d10-16a1-4946-a38b-98fdec0e0ec8}")]
[JsonObject()]
public class ListTemplateEnumerable : ClientObjectEnumerable<ListTemplate>;
