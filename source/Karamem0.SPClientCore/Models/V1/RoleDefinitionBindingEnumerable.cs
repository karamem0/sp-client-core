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

[ClientObject(Name = "SP.RoleDefinitionBindingCollection", Id = "{07bf1941-6953-4761-b114-58374b4aaf57}")]
[JsonObject()]
public class RoleDefinitionBindingEnumerable : ClientObjectEnumerable<RoleDefinition>;
