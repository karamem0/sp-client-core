//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Models.V2;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System.Management.Automation;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Get, "ListItem")]
[OutputType(typeof(ListItem))]
public class GetListItemCommand : ClientObjectCmdlet<IListItemService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet1"
    )]
    public ListItem? Identity { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet2"
    )]
    public Models.V1.Folder? Folder { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet3"
    )]
    public Models.V1.File? File { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet4"
    )]
    public DriveItem? DriveItem { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet5")]
    public Uri? ItemUrl { get; private set; }

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
        ParameterSetName = "ParamSet8"
    )]
    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet9"
    )]
    public List? List { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet6")]
    public int ItemId { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet7")]
    public Guid ItemUniqueId { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet8")]
    public SwitchParameter All { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet9")]
    public Uri? FolderServerRelativeUrl { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet9")]
    public ListItemCollectionPosition? ListItemCollectionPosition { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet9")]
    public string? ViewXml { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet8")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet9")]
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
            _ = this.Folder ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Folder));
            this.Outputs.Add(this.Service.GetObject(this.Folder));
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            _ = this.File ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.File));
            this.Outputs.Add(this.Service.GetObject(this.File));
        }
        if (this.ParameterSetName == "ParamSet4")
        {
            _ = this.DriveItem ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.DriveItem));
            this.Outputs.Add(this.Service.GetObject(this.DriveItem));
        }
        if (this.ParameterSetName == "ParamSet5")
        {
            _ = this.ItemUrl ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ItemUrl));
            this.Outputs.Add(this.Service.GetObject(this.ItemUrl));
        }
        if (this.ParameterSetName == "ParamSet6")
        {
            _ = this.List ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.List));
            this.Outputs.Add(this.Service.GetObject(this.List, this.ItemId));
        }
        if (this.ParameterSetName == "ParamSet7")
        {
            _ = this.List ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.List));
            this.Outputs.Add(this.Service.GetObject(this.List, this.ItemUniqueId));
        }
        if (this.ParameterSetName == "ParamSet8")
        {
            this.ValidateSwitchParameter(nameof(this.All));
            _ = this.List ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.List));
            if (this.NoEnumerate)
            {
                this.Outputs.Add(this.Service.GetObjectEnumerable(this.List));
            }
            else
            {
                this.Outputs.AddRange(this.Service.GetObjectEnumerable(this.List));
            }
        }
        if (this.ParameterSetName == "ParamSet9")
        {
            _ = this.List ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.List));
            if (this.NoEnumerate)
            {
                this.Outputs.Add(this.Service.GetObjectEnumerable(this.List, this.MyInvocation.BoundParameters));
            }
            else
            {
                this.Outputs.AddRange(this.Service.GetObjectEnumerable(this.List, this.MyInvocation.BoundParameters));
            }
        }
    }

}
