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

[ClientObject(Name = "SP.DocumentSet.WelcomePageFieldCollection", Id = "{d9662ecf-16a1-4530-84ea-029e69ff60aa}")]
[JsonObject()]
public class WelcomePageColumnEnumerable : ClientObjectEnumerable<Column>;
