//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("Get", "KshTenantOrganizationNewsSite")]
    [OutputType(typeof(string))]
    public class GetTenantOrganizationNewsSiteCommand : ClientObjectCmdlet<ITenantOrganizationNewsSiteService>
    {

        public GetTenantOrganizationNewsSiteCommand()
        {
        }

        [Parameter(Mandatory = false)]
        public SwitchParameter NoEnumerate { get; private set; }

        protected override void ProcessRecordCore(ref List<object> outputs)
        {
            if (this.NoEnumerate)
            {
                outputs.Add(this.Service.GetObjectEnumerable());
            }
            else
            {
                outputs.AddRange(this.Service.GetObjectEnumerable());
            }
        }

    }

}
