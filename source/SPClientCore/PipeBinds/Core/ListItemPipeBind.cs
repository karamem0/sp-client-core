//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.PipeBinds.Core
{

    public class ListItemPipeBind : ClientObjectPipeBind<ListItem>
    {

        public ListItemPipeBind(ListItem inputObject) : base(inputObject)
        {
        }

        public ListItemPipeBind(int? inputId)
        {
            if (inputId == null)
            {
                throw new ArgumentNullException(nameof(inputId));
            }
            this.Id = inputId;
        }

        public ListItemPipeBind(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
            {
                throw new ArgumentNullException(nameof(inputString));
            }
            else if (int.TryParse(inputString, out var itemId))
            {
                this.Id = itemId;
            }
            else
            {
                throw new FormatException();
            }
        }

        public int? Id { get; private set; }

    }

}
