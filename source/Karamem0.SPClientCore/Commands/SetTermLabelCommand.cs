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

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            _ = this.Identity?.Name ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Identity));
            if (this.PassThru)
            {
                var termObject = this.Service1.GetObject(this.Identity);
                _ = termObject ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
                this.Service2.SetObject(this.Identity, this.MyInvocation.BoundParameters);
                this.Outputs.Add(
                    this.Service2.GetObject(
                        termObject,
                        this.Identity.Name,
                        this.Lcid
                    )
                );
            }
            else
            {
                this.Service2.SetObjectAwait(this.Identity, this.MyInvocation.BoundParameters);
            }
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            _ = this.Identity ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Identity));
            _ = this.Name ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Name));
            if (this.PassThru)
            {
                var termObject = this.Service1.GetObject(this.Identity);
                _ = termObject ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
                this.Service2.SetObject(this.Identity, this.MyInvocation.BoundParameters);
                this.Outputs.Add(
                    this.Service2.GetObject(
                        termObject,
                        this.Name,
                        this.Identity.Lcid
                    )
                );
            }
            else
            {
                this.Service2.SetObjectAwait(this.Identity, this.MyInvocation.BoundParameters);
            }
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            this.ValidateSwitchParameter(nameof(this.IsDefault));
            _ = this.Identity ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Identity));
            this.Service2.SetObjectAsDefault(this.Identity);
            if (this.PassThru)
            {
                this.Outputs.Add(this.Service2.GetObject(this.Identity));
            }
        }
    }

}
