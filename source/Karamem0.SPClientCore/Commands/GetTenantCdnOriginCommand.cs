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

    [Cmdlet("Get", "KshTenantCdnOrigin")]
    [OutputType(typeof(string))]
    public class GetTenantCdnOriginCommand : ClientObjectCmdlet<ITenantCdnService>
    {

        public GetTenantCdnOriginCommand()
        {
        }

        [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
        public SwitchParameter Public { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
        public SwitchParameter Private { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
        [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
        public SwitchParameter NoEnumerate { get; private set; }

        protected override void ProcessRecordCore()
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                this.ValidateSwitchParameter(nameof(this.Public));
                if (this.NoEnumerate)
                {
                    this.Outputs.Add(this.Service.GetOriginEnumerable(TenantCdnType.Public));
                }
                else
                {
                    this.Outputs.AddRange(this.Service.GetOriginEnumerable(TenantCdnType.Public));
                }
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                this.ValidateSwitchParameter(nameof(this.Private));
                if (this.NoEnumerate)
                {
                    this.Outputs.Add(this.Service.GetOriginEnumerable(TenantCdnType.Private));
                }
                else
                {
                    this.Outputs.AddRange(this.Service.GetOriginEnumerable(TenantCdnType.Private));
                }
            }
        }

    }

}
