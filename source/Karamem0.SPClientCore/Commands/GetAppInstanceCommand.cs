//
// Copyright (c) 2018-2026 karamem0
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

[Cmdlet(VerbsCommon.Get, "AppInstance")]
[OutputType(typeof(AppInstance))]
public class GetAppInstanceCommand : ClientObjectCmdlet<IAppInstanceService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet1"
    )]
    public AppInstance? Identity { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public Guid AppInstanceId { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
    public Guid AppProductId { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter SelectAllProperties { get; private set; } = true;

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet4")]
    public SwitchParameter NoEnumerate { get; private set; }

    protected override async Task ProcessRecordAsync()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            _ = this.Identity?.Id ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Identity));
            this.Outputs.Add(await this.Service.GetObjectAsync(this.Identity.Id, this.SelectAllProperties));
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            this.Outputs.Add(await this.Service.GetObjectAsync(this.AppInstanceId, this.SelectAllProperties));
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            if (this.NoEnumerate)
            {
                this.Outputs.Add(await this.Service.GetObjectEnumerableAsync(this.AppProductId, this.SelectAllProperties));
            }
            else
            {
                this.Outputs.AddRange(await this.Service.GetObjectEnumerableAsync(this.AppProductId, this.SelectAllProperties));
            }
        }
        if (this.ParameterSetName == "ParamSet4")
        {
            if (this.NoEnumerate)
            {
                this.Outputs.Add(await this.Service.GetObjectEnumerableAsync(this.SelectAllProperties));
            }
            else
            {
                this.Outputs.AddRange(await this.Service.GetObjectEnumerableAsync(this.SelectAllProperties));
            }
        }
    }

}
