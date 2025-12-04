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

[Cmdlet(VerbsCommon.Get, "Term")]
[OutputType(typeof(Term))]
public class GetTermCommand : ClientObjectCmdlet<ITermService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet1"
    )]
    public Term? Identity { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet2"
    )]
    public TermLabel? TermLabel { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet3"
    )]
    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet4"
    )]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet5")]
    public TermSet? TermSet { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet6"
    )]
    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet7"
    )]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet8")]
    public Term? Term { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet6")]
    public Guid TermId { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet4")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet7")]
    public string? TermName { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet5")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet8")]
    public SwitchParameter NoEnumerate { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            _ = this.Identity ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Identity));
            this.Outputs.Add(this.Service.GetObject(this.Identity));
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            _ = this.TermLabel ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.TermLabel));
            this.Outputs.Add(this.Service.GetObject(this.TermLabel));
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            _ = this.TermSet ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.TermSet));
            this.Outputs.Add(this.Service.GetObject(this.TermSet, this.TermId));
        }
        if (this.ParameterSetName == "ParamSet4")
        {
            _ = this.TermSet ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.TermSet));
            _ = this.TermName ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.TermName));
            this.Outputs.Add(this.Service.GetObject(this.TermSet, this.TermName));
        }
        if (this.ParameterSetName == "ParamSet5")
        {
            _ = this.TermSet ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.TermSet));
            if (this.NoEnumerate)
            {
                this.Outputs.Add(this.Service.GetObjectEnumerable(this.TermSet));
            }
            else
            {
                this.Outputs.AddRange(this.Service.GetObjectEnumerable(this.TermSet));
            }
        }
        if (this.ParameterSetName == "ParamSet6")
        {
            _ = this.Term ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Term));
            this.Outputs.Add(this.Service.GetObject(this.Term, this.TermId));
        }
        if (this.ParameterSetName == "ParamSet7")
        {
            _ = this.Term ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Term));
            _ = this.TermName ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.TermName));
            this.Outputs.Add(this.Service.GetObject(this.Term, this.TermName));
        }
        if (this.ParameterSetName == "ParamSet8")
        {
            _ = this.Term ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Term));
            if (this.NoEnumerate)
            {
                this.Outputs.Add(this.Service.GetObjectEnumerable(this.Term));
            }
            else
            {
                this.Outputs.AddRange(this.Service.GetObjectEnumerable(this.Term));
            }
        }
    }

}
