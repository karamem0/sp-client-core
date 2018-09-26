//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.Core
{

    public enum AlertEventType
    {

        AddObject = 1,

        ModifyObject = 2,

        DeleteObject = 4,

        Discussion = 4080,

        All = -1,

    }

}
