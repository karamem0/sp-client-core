//
// Copyright (c) 2019 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("Add", "KshViewColumn")]
    [OutputType(typeof(void))]
    public class AddViewColumnCommand : ClientObjectCmdlet<IViewColumnService>
    {

        public AddViewColumnCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public View View { get; private set; }

        [Parameter(Mandatory = true, Position = 1)]
        public Column Column { get; private set; }

        protected override void ProcessRecordCore()
        {
            this.Service.AddObject(this.View, this.Column);
        }

    }

}
