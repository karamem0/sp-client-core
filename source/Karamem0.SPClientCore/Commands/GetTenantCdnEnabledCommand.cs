//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System.Management.Automation;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Get, "TenantCdnEnabled")]
[OutputType(typeof(bool))]
public class GetTenantCdnEnabledCommand : ClientObjectCmdlet<ITenantCdnService>
{

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    public SwitchParameter Public { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public SwitchParameter Private { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            this.ValidateSwitchParameter(nameof(this.Public));
            this.Outputs.Add(this.Service.GetEnabled(TenantCdnType.Public));
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            this.ValidateSwitchParameter(nameof(this.Private));
            this.Outputs.Add(this.Service.GetEnabled(TenantCdnType.Private));
        }
    }

}
