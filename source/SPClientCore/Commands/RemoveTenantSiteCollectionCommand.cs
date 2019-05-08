//
// Copyright (c) 2019 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("Remove", "KshTenantSiteCollection")]
    [OutputType(typeof(void))]
    public class RemoveTenantSiteCollectionCommand : ClientObjectCmdlet<ITenantSiteCollectionService>
    {

        public RemoveTenantSiteCollectionCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet1")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet2")]
        public TenantSiteCollection Identity { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
        public SwitchParameter NoWait { get; private set; }

        protected override void ProcessRecordCore()
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                this.Service.RemoveObjectAwait(this.Identity);
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                if (this.NoWait)
                {
                    this.Service.RemoveObject(this.Identity);
                }
                else
                {
                    throw new ArgumentException(
                        string.Format(StringResources.ErrorValueCannotBeValue, false),
                        nameof(this.NoWait));
                }
            }
        }

    }

}