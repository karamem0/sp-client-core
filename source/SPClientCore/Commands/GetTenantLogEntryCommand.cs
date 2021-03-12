//
// Copyright (c) 2021 karamem0
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

    [Cmdlet("Get", "KshTenantLogEntry")]
    [OutputType(typeof(TenantLogEntry))]
    public class GetTenantLogEntryCommand : ClientObjectCmdlet<ITenantLogEntryService>
    {

        public GetTenantLogEntryCommand()
        {
        }

        [Parameter(Mandatory = true)]
        public DateTime BeginDateTime { get; private set; }

        [Parameter(Mandatory = true)]
        public DateTime EndDateTime { get; private set; }

        [Parameter(Mandatory = true)]
        public uint Rows { get; private set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter NoEnumerate { get; private set; }

        protected override void ProcessRecordCore()
        {
            this.WriteObject(this.Service.GetObjectEnumerable(this.BeginDateTime, this.EndDateTime, this.Rows), this.NoEnumerate ? false : true);
        }

    }

}
