//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/spclientcore/blob/master/LICENSE
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

    [Cmdlet("Remove", "KshTenantCdnOrigin")]
    [OutputType(typeof(void))]
    public class RemoveTenantCdnOriginCommand : ClientObjectCmdlet<ITenantCdnService>
    {

        public RemoveTenantCdnOriginCommand()
        {
        }

        [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
        public SwitchParameter Public { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
        public SwitchParameter Private { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
        [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
        public string Origin { get; private set; }

        protected override void ProcessRecordCore()
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                this.ValidateSwitchParameter(nameof(this.Public));
                this.Service.RemoveOrigin(TenantCdnType.Public, this.Origin);
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                this.ValidateSwitchParameter(nameof(this.Private));
                this.Service.RemoveOrigin(TenantCdnType.Private, this.Origin);
            }
        }

    }

}
