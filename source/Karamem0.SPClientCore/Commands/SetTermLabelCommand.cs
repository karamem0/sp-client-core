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

[Cmdlet(VerbsCommon.Set, "TermLabel")]
[OutputType(typeof(TermLabel))]
public class SetTermLabelCommand : ClientObjectCmdlet<ITermService, ITermLabelService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet1"
    )]
    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet2"
    )]
    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet3"
    )]
    public TermLabel? Identity { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    public uint Lcid { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public string? Name { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
    public SwitchParameter IsDefault { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    public SwitchParameter PassThru { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    public SwitchParameter SelectAllProperties { get; private set; } = true;

    protected override async Task ProcessRecordAsync()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            _ = this.Identity?.Name ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Identity));
            if (this.PassThru)
            {
                var termObject = await this.Service1.GetObjectAsync(this.Identity);
                _ = termObject ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
                await this.Service2.SetObjectAsync(this.Identity, this.MyInvocation.BoundParameters);
                this.Outputs.Add(
                    await this.Service2.GetObjectAsync(
                        termObject,
                        this.Identity.Name,
                        this.Lcid
                    )
                );
            }
            else
            {
                await this.Service2.SetObjectAwaitAsync(this.Identity, this.MyInvocation.BoundParameters);
            }
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            _ = this.Identity ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Identity));
            _ = this.Name ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Name));
            if (this.PassThru)
            {
                var termObject = await this.Service1.GetObjectAsync(this.Identity);
                _ = termObject ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
                await this.Service2.SetObjectAsync(this.Identity, this.MyInvocation.BoundParameters);
                this.Outputs.Add(
                    await this.Service2.GetObjectAsync(
                        termObject,
                        this.Name,
                        this.Identity.Lcid
                    )
                );
            }
            else
            {
                await this.Service2.SetObjectAwaitAsync(this.Identity, this.MyInvocation.BoundParameters);
            }
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            this.ValidateSwitchParameter(nameof(this.IsDefault));
            _ = this.Identity ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Identity));
            await this.Service2.SetObjectAsDefaultAsync(this.Identity);
            if (this.PassThru)
            {
                this.Outputs.Add(await this.Service2.GetObjectAsync(this.Identity, this.SelectAllProperties));
            }
        }
    }

}
