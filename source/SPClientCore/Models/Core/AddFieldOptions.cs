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

    [Flags()]
    public enum AddFieldOptions
    {

        DefaultValue = 0,

        AddToDefaultContentType = 1,

        AddToNoContentType = 2,

        AddToAllContentTypes = 4,

        AddFieldInternalNameHint = 8,

        AddFieldToDefaultView = 16,

        AddFieldCheckDisplayName = 32,

    }

}
