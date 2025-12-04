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

[Cmdlet(VerbsCommon.Get, "Folder")]
[OutputType(typeof(Folder))]
public class GetFolderCommand : ClientObjectCmdlet<IFolderService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet1"
    )]
    public Folder? Identity { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet2"
    )]
    public List? List { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet3"
    )]
    public ListItem? ListItem { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet4")]
    public Guid FolderId { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet5")]
    public Uri? FolderUrl { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet6")]
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
            _ = this.List ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.List));
            this.Outputs.Add(this.Service.GetObject(this.List));
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            _ = this.ListItem ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ListItem));
            this.Outputs.Add(this.Service.GetObject(this.ListItem));
        }
        if (this.ParameterSetName == "ParamSet4")
        {
            this.Outputs.Add(this.Service.GetObject(this.FolderId));
        }
        if (this.ParameterSetName == "ParamSet5")
        {
            _ = this.FolderUrl ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.FolderUrl));
            if (this.FolderUrl.IsAbsoluteUri)
            {
                this.Outputs.Add(this.Service.GetObject(new Uri(this.FolderUrl.AbsolutePath, UriKind.Relative)));
            }
            else
            {
                this.Outputs.Add(this.Service.GetObject(this.FolderUrl));
            }
        }
        if (this.ParameterSetName == "ParamSet6")
        {
            if (this.NoEnumerate)
            {
                this.Outputs.Add(this.Service.GetObjectEnumerable());
            }
            else
            {
                this.Outputs.AddRange(this.Service.GetObjectEnumerable());
            }
        }
    }

}
