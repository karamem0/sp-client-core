//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.Social;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.PipeBinds.Social
{

    public class SocialActorPipeBind : ClientObjectPipeBind<SocialActor>
    {

        public SocialActorPipeBind(SocialActor inputObject) : base(inputObject)
        {
        }

        public SocialActorPipeBind(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
            {
                throw new ArgumentNullException(nameof(inputString));
            }
            else
            {
                this.Item = inputString;
            }
        }

        public string Item { get; private set; }

    }

}
