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

    public enum ChangeType
    {

        NoChange = 0,

        Add = 1,

        Update = 2,

        DeleteObject = 3,

        Rename = 4,

        MoveAway = 5,

        MoveInto = 6,

        Restore = 7,

        RoleAdd = 8,

        RoleDelete = 9,

        RoleUpdate = 10,

        AssignmentAdd = 11,

        AssignmentDelete = 12,

        MemberAdd = 13,

        MemberDelete = 14,

        SystemUpdate = 15,

        Navigation = 16,

        ScopeAdd = 17,

        ScopeDelete = 18,

        ListContentTypeAdd = 19,

        ListContentTypeDelete = 20,

        Dirty = 21,

        Activity = 22,

    }

}
