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

    [Cmdlet("Uninstall", "KshTenantApp")]
    [OutputType(typeof(App))]
    public class UninstallTenantAppCommand : ClientObjectCmdlet<ITenantAppService>
    {

        public UninstallTenantAppCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public App Identity { get; private set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; private set; }

        protected override void ProcessRecordCore()
        {
            this.Service.UninstallObject(this.Identity);
            if (this.PassThru)
            {
                this.WriteObject(this.Service.GetObject(this.Identity));
            }
        }

    }

}
