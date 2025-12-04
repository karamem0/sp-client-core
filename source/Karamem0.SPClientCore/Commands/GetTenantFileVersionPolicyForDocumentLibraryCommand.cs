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

[Cmdlet(VerbsCommon.Get, "TenantFileVersionPolicyForDocumentLibrary")]
[OutputType(typeof(FileVersionPolicyForDocumentLibrary))]
public class GetTenantFileVersionPolicyForDocumentLibraryCommand : ClientObjectCmdlet<ITenantFileVersionPolicyForDocumentLibraryService>
{

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public Uri? SiteUrl { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    public Guid ListId { get; set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public string? ListTitle { get; set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            _ = this.SiteUrl ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.SiteUrl));
            this.Outputs.Add(this.Service.GetObject(this.SiteUrl, this.ListId));
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            _ = this.SiteUrl ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.SiteUrl));
            _ = this.ListTitle ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ListTitle));
            this.Outputs.Add(this.Service.GetObject(this.SiteUrl, this.ListTitle));
        }
    }

}
