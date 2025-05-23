//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.V1;

[Flags()]
public enum ChangeObjects
{

    None = 0,

    Item = 1,

    List = 2,

    Site = 4,

    SiteCollection = 8,

    File = 16,

    Folder = 32,

    Alert = 64,

    User = 128,

    Group = 256,

    ContentType = 512,

    Column = 1024,

    SecurityPolicy = 2048,

    View = 4096,

    All = 8191,

}
