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

[Cmdlet(VerbsCommon.Get, "TenantTheme")]
[OutputType(typeof(TenantTheme))]
public class GetTenantThemeCommand : ClientObjectCmdlet<ITenantThemeService>
{

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    public TenantTheme? Identity { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public string? ThemeName { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    public SwitchParameter NoEnumerate { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            this.Outputs.Add(
                this.Service.GetObject(this.Identity ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Identity)))
            );
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            this.Outputs.Add(
                this.Service.GetObject(this.ThemeName ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ThemeName)))
            );
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            if (this.NoEnumerate)
            {
                this.Outputs.Add(this.Service.GetObjectEnumerable());
            }
            else
            {
                this.Outputs.AddRange(this.Service.GetObjectEnumerable());
            }
        }
    }

}
