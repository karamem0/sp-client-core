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

[Cmdlet(VerbsCommon.Get, "ContentTypeColumn")]
[OutputType(typeof(ContentTypeColumn))]
public class GetContentTypeColumnCommand : ClientObjectCmdlet<IContentTypeColumnService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet1"
    )]
    public ContentTypeColumn? Identity { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet2"
    )]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
    public ContentType? ContentType { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public Column? Column { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
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
            _ = this.ContentType ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ContentType));
            _ = this.Column?.Id ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Column));
            this.Outputs.Add(this.Service.GetObject(this.ContentType, this.Column.Id));
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            _ = this.ContentType ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ContentType));
            if (this.NoEnumerate)
            {
                this.Outputs.Add(this.Service.GetObjectEnumerable(this.ContentType));
            }
            else
            {
                this.Outputs.AddRange(this.Service.GetObjectEnumerable(this.ContentType));
            }
        }
    }

}
