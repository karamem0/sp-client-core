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

[Cmdlet(VerbsData.Save, "Image")]
[OutputType(typeof(ImageItem))]
public class SaveImageCommand : ClientObjectCmdlet<IImageService>
{

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    public List? List { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public ListItem? ListItem { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public System.IO.Stream? Content { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public string? FileName { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            _ = this.List ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.List));
            _ = this.FileName ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.FileName));
            _ = this.Content ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Content));
            this.Outputs.Add(
                this.Service.UploadObject(
                    this.List,
                    this.FileName,
                    this.Content
                )
            );
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            _ = this.ListItem ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ListItem));
            _ = this.FileName ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.FileName));
            _ = this.Content ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Content));
            this.Outputs.Add(
                this.Service.UploadObject(
                    this.ListItem,
                    this.FileName,
                    this.Content
                )
            );
        }
    }

}
