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

[Cmdlet(VerbsCommon.Get, "SiteTemplate")]
[OutputType(typeof(SiteTemplate))]
public class GetSiteTemplateCommand : ClientObjectCmdlet<ISiteService, ISiteTemplateService>
{

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    public string? SiteTemplateName { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    public SwitchParameter IncludeCrossLanguage { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    public uint Lcid { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    public SwitchParameter NoEnumerate { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.Lcid == default)
        {
            var siteObject = this.Service1.GetObject();
            if (siteObject is not null)
            {
                this.Lcid = siteObject.Lcid;
            }
        }
        if (this.ParameterSetName == "ParamSet1")
        {
            _ = this.SiteTemplateName ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.SiteTemplateName));
            this.Outputs.Add(
                this.Service2.GetObject(
                    this.SiteTemplateName,
                    this.Lcid,
                    this.IncludeCrossLanguage
                )
            );
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            if (this.NoEnumerate)
            {
                this.Outputs.Add(this.Service2.GetObjectEnumerable(this.Lcid, this.IncludeCrossLanguage));
            }
            else
            {
                this.Outputs.AddRange(this.Service2.GetObjectEnumerable(this.Lcid, this.IncludeCrossLanguage));
            }
        }
    }

}
