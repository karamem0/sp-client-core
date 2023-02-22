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

    [Cmdlet("Get", "KshTenantHomeSite")]
    [OutputType(typeof(string))]
    public class GetTenantHomeSiteCommand : ClientObjectCmdlet<ITenantHomeSiteService>
    {

        public GetTenantHomeSiteCommand()
        {
        }

        protected override void ProcessRecordCore()
        {
            this.Outputs.Add(this.Service.GetObject());
        }

    }

}
