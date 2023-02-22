//
// Copyright (c) 2023 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.V1
{

    public enum RecycleBinItemType
    {

        None = 0,

        File = 1,

        FileVersion = 2,

        ListItem = 3,

        List = 4,

        Folder = 5,

        FolderWithLists = 6,

        Attachment = 7,

        ListItemVersion = 8,

        CascadeParent = 9,

    }

}
