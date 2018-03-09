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

namespace Karamem0.SharePoint.PowerShell.PipeBinds
{

    public class ContentTypePipeBind : ClientObjectPipeBind<ContentType>
    {

        public ContentTypePipeBind(ContentType inputObject) : base(inputObject)
        {
        }

        public ContentTypePipeBind(ContentTypeId inputObject)
        {
            if (inputObject == null)
            {
                throw new ArgumentNullException(nameof(inputObject));
            }
            this.Id = inputObject.StringValue;
        }

        public ContentTypePipeBind(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
            {
                throw new ArgumentNullException(nameof(inputString));
            }
            this.Id = inputString;
        }

        public string Id { get; private set; }

    }

}
