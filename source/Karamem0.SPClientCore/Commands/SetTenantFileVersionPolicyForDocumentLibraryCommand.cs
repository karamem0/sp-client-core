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

[Cmdlet(VerbsCommon.Set, "TenantFileVersionPolicyForDocumentLibrary")]
[OutputType(typeof(FileVersionPolicyForDocumentLibrary))]
public class SetTenantFileVersionPolicyForDocumentLibraryCommand : ClientObjectCmdlet<ITenantFileVersionPolicyForDocumentLibraryService>
{

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet4")]
    public Uri? SiteUrl { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public Guid ListId { get; set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet4")]
    public string? ListTitle { get; set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet4")]
    public bool IsAutoTrimEnabled { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet4")]
    public int MajorVersionLimit { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet4")]
    public int ExpireVersionsAfterDays { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    public SwitchParameter PassThru { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet4")]
    public SwitchParameter NoWait { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            _ = this.SiteUrl ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.SiteUrl));
            this.Service.SetObjectAwait(
                this.SiteUrl,
                this.ListId,
                this.MyInvocation.BoundParameters
            );
            if (this.PassThru)
            {
                this.Outputs.Add(this.Service.GetObject(this.SiteUrl, this.ListId));
            }
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            this.ValidateSwitchParameter(nameof(this.NoWait));
            _ = this.SiteUrl ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.SiteUrl));
            _ = this.Service.SetObject(
                this.SiteUrl,
                this.ListId,
                this.MyInvocation.BoundParameters
            );
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            _ = this.SiteUrl ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.SiteUrl));
            _ = this.ListTitle ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ListTitle));
            this.Service.SetObjectAwait(
                this.SiteUrl,
                this.ListTitle,
                this.MyInvocation.BoundParameters
            );
            if (this.PassThru)
            {
                this.Outputs.Add(this.Service.GetObject(this.SiteUrl, this.ListTitle));
            }
        }
        if (this.ParameterSetName == "ParamSet4")
        {
            this.ValidateSwitchParameter(nameof(this.NoWait));
            _ = this.SiteUrl ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.SiteUrl));
            _ = this.ListTitle ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ListTitle));
            _ = this.Service.SetObject(
                this.SiteUrl,
                this.ListTitle,
                this.MyInvocation.BoundParameters
            );
        }
    }

}
