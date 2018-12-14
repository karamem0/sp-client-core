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

    [Cmdlet("New", "KshColumnUrlValue")]
    [OutputType(typeof(ColumnUserValue))]
    public class NewColumnUrlValueCommand : ClientObjectCmdlet
    {

        public NewColumnUrlValueCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public string Url { get; private set; }

        [Parameter(Mandatory = false, Position = 1)]
        public string Description { get; private set; }

        protected override void ProcessRecordCore()
        {
            this.WriteObject(new ColumnUrlValue(this.Url, this.Description));
        }

    }

}
