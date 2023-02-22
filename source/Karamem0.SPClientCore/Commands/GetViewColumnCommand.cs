//
// Copyright (c) 2023 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("Get", "KshViewColumn")]
    [OutputType(typeof(string))]
    public class GetViewColumnCommand : ClientObjectCmdlet<IViewColumnService>
    {

        public GetViewColumnCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0)]
        public View View { get; private set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter NoEnumerate { get; private set; }

        protected override void ProcessRecordCore()
        {
            if (this.NoEnumerate)
            {
                this.Outputs.Add(this.Service.GetObjectEnumerable(this.View));
            }
            else
            {
                this.Outputs.AddRange(this.Service.GetObjectEnumerable(this.View));
            }
        }

    }

}
