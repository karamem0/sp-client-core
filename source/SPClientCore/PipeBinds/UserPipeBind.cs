//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Karamem0.SharePoint.PowerShell.PipeBinds
{

    public class UserPipeBind : ClientObjectPipeBind<User>
    {

        public UserPipeBind(User inputObject) : base(inputObject)
        {
        }

        public UserPipeBind(int? inputId)
        {
            if (inputId == null)
            {
                throw new ArgumentNullException(nameof(inputId));
            }
            this.Id = inputId;
        }

        public UserPipeBind(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
            {
                throw new ArgumentNullException(nameof(inputString));
            }
            else if (int.TryParse(inputString, out var inputId))
            {
                this.Id = inputId;
            }
            else if (Regex.IsMatch(inputString, "^[ci]:0"))
            {
                this.LoginName = inputString;
            }
            else
            {
                this.Email = inputString;
            }
        }

        public int? Id { get; private set; }

        public string LoginName { get; private set; }

        public string Email { get; private set; }

    }

}
