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

    public class AttachmentPipeBind : ClientObjectPipeBind<Attachment>
    {

        public AttachmentPipeBind(Attachment inputObject) : base(inputObject)
        {
        }

        public AttachmentPipeBind(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
            {
                throw new ArgumentNullException(nameof(inputString));
            }
            else
            {
                this.FileName = inputString;
            }
        }

        public string FileName { get; private set; }

    }

}
