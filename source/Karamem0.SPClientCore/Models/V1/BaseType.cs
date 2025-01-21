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

public enum BaseType
{

    None = -1,

    GenericList = 0,

    DocumentLibrary = 1,

    Unused = 2,

    DiscussionBoard = 3,

    Survey = 4,

    Issue = 5,

}
