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

[Cmdlet(VerbsCommon.Add, "ContentType")]
[OutputType(typeof(ContentType))]
public class AddContentTypeCommand : ClientObjectCmdlet<IContentTypeService>
{

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public List? List { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    public ContentType? ContentType { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    public string? Description { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    public string? Group { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
    public string? Name { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    public SwitchParameter SelectAllProperties { get; private set; } = true;

    protected override async Task ProcessRecordAsync()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            _ = this.List ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.List));
            _ = this.ContentType ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ContentType));
            this.Outputs.Add(
                await this.Service.AddObjectAsync(
                    this.List,
                    this.ContentType,
                    this.SelectAllProperties
                )
            );
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            _ = this.List ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.List));
            var creationInfo = new Dictionary<string, object?>(this.MyInvocation.BoundParameters);
            this.Outputs.Add(
                await this.Service.AddObjectAsync(
                    this.List,
                    creationInfo,
                    this.SelectAllProperties
                )
            );
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            var creationInfo = new Dictionary<string, object?>(this.MyInvocation.BoundParameters);
            this.Outputs.Add(await this.Service.AddObjectAsync(creationInfo, this.SelectAllProperties));
        }
    }

}
