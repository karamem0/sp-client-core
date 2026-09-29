//
// Copyright (c) 2018-2026 karamem0
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

[Cmdlet(VerbsCommon.Get, "TenantCdnOrigin")]
[OutputType(typeof(string))]
public class GetTenantCdnOriginCommand : ClientObjectCmdlet<ITenantCdnService>
{

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    public SwitchParameter Public { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public SwitchParameter Private { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    public SwitchParameter NoEnumerate { get; private set; }

    protected override async Task ProcessRecordAsync()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            this.ValidateSwitchParameter(nameof(this.Public));
            if (this.NoEnumerate)
            {
                this.Outputs.Add(await this.Service.GetOriginEnumerableAsync(TenantCdnType.Public));
            }
            else
            {
                this.Outputs.AddRange(await this.Service.GetOriginEnumerableAsync(TenantCdnType.Public));
            }
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            this.ValidateSwitchParameter(nameof(this.Private));
            if (this.NoEnumerate)
            {
                this.Outputs.Add(await this.Service.GetOriginEnumerableAsync(TenantCdnType.Private));
            }
            else
            {
                this.Outputs.AddRange(await this.Service.GetOriginEnumerableAsync(TenantCdnType.Private));
            }
        }
    }

}
