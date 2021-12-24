//
// Copyright (c) 2022 karamem0
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

    [Cmdlet("Set", "KshTermStore")]
    [Alias("Update-KshTermStore")]
    [OutputType(typeof(TermStore))]
    public class SetTermStoreCommand : ClientObjectCmdlet<ITermStoreService>
    {

        public SetTermStoreCommand()
        {
        }

        [Parameter(Mandatory = false)]
        public uint DefaultLcid { get; private set; }

        [Parameter(Mandatory = false)]
        public uint WorkingLcid { get; private set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; private set; }

        protected override void ProcessRecordCore()
        {
            this.Service.SetObject(this.MyInvocation.BoundParameters);
            if (this.PassThru)
            {
                this.Outputs.Add(this.Service.GetObject());
            }
        }

    }

}
