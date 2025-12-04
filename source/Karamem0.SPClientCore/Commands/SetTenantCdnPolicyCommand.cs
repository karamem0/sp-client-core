//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System.Management.Automation;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Set, "TenantCdnPolicy")]
[OutputType(typeof(void))]
public class SetTenantCdnPolicyCommand : ClientObjectCmdlet<ITenantCdnService>
{

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    public SwitchParameter Public { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public SwitchParameter Private { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public TenantCdnPolicyType Type { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public string? Value { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            this.ValidateSwitchParameter(nameof(this.Public));
            _ = this.Value ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Value));
            this.Service.SetPolicy(
                TenantCdnType.Public,
                this.Type,
                this.Value
            );
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            this.ValidateSwitchParameter(nameof(this.Private));
            _ = this.Value ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Value));
            this.Service.SetPolicy(
                TenantCdnType.Private,
                this.Type,
                this.Value
            );
        }
    }

}
