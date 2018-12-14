//
// Copyright (c) 2019 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("New", "KshContentTypeId")]
    [OutputType(typeof(ContentTypeId))]
    public class NewContentTypeIdCommand : ClientObjectCmdlet
    {

        public NewContentTypeIdCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public string StringValue { get; private set; }

        protected override void ProcessRecordCore()
        {
            this.WriteObject(new ContentTypeId(this.StringValue));
        }

    }

}
