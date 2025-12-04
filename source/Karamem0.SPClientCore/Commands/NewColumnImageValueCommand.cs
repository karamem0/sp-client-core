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

[Cmdlet(VerbsCommon.New, "ColumnImageValue")]
[OutputType(typeof(ColumnImageValue))]
public class NewColumnImageValueCommand : ClientObjectCmdlet<ISiteService>
{

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    public ImageItem? ImageItem { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    public string? ColumnName { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    public string? FileName { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    public Uri? ServerUrl { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    public Uri? ServerRelativeUrl { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    public Guid Id { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            _ = this.ImageItem ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ImageItem));
            var siteObject = this.Service.GetObject();
            _ = siteObject ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
            var siteUrl = siteObject.Url;
            _ = siteUrl ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
            this.Outputs.Add(
                new ColumnImageValue(
                    this.ColumnName,
                    this.ImageItem.Name,
                    new Uri(siteUrl.GetLeftPart(UriPartial.Authority), UriKind.Absolute),
                    this.ImageItem.ServerRelativeUrl,
                    this.ImageItem.UniqueId.ToString()
                )
            );
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            this.Outputs.Add(
                new ColumnImageValue(
                    this.ColumnName,
                    this.FileName,
                    this.ServerUrl,
                    this.ServerRelativeUrl,
                    this.Id.ToString()
                )
            );
        }
    }

}
