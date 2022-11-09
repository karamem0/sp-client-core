//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("Test", "KshTenantSiteCollection")]
    [OutputType(typeof(bool))]
    public class TestTenantSiteCollectionCommand : ClientObjectCmdlet<ITenantService>
    {

        public TestTenantSiteCollectionCommand()
        {
        }

        protected override void ProcessRecordCore()
        {
            try
            {
                var tenant = this.Service.GetObject();
                if (tenant != null)
                {
                    this.Outputs.Add(true);
                }
                else
                {
                    this.Outputs.Add(false);
                }
            }
            catch
            {
                this.Outputs.Add(false);
            }
        }

    }

}
