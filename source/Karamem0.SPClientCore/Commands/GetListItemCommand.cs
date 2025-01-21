//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Models.V2;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Get, "KshListItem")]
[OutputType(typeof(ListItem))]
public class GetListItemCommand : ClientObjectCmdlet<IListItemService>
{

    public GetListItemCommand()
    {
    }

    [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet1")]
    public ListItem Identity { get; private set; }

    [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet2")]
    public Models.V1.Folder Folder { get; private set; }

    [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet3")]
    public Models.V1.File File { get; private set; }

    [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet4")]
    public DriveItem DriveItem { get; private set; }

    [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet5")]
    public string ItemUrl { get; private set; }

    [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet6")]
    [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet7")]
    [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet8")]
    public List List { get; private set; }

    [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet6")]
    public int ItemId { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet7")]
    public SwitchParameter All { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet8")]
    public string FolderServerRelativeUrl { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet8")]
    public ListItemCollectionPosition ListItemCollectionPosition { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet8")]
    public string ViewXml { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet7")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet8")]
    public SwitchParameter NoEnumerate { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            this.Outputs.Add(this.Service.GetObject(this.Identity));
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            this.Outputs.Add(this.Service.GetObject(this.Folder));
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            this.Outputs.Add(this.Service.GetObject(this.File));
        }
        if (this.ParameterSetName == "ParamSet4")
        {
            this.Outputs.Add(this.Service.GetObject(this.DriveItem));
        }
        if (this.ParameterSetName == "ParamSet5")
        {
            this.Outputs.Add(this.Service.GetObject(this.ItemUrl));
        }
        if (this.ParameterSetName == "ParamSet6")
        {
            this.Outputs.Add(this.Service.GetObject(this.List, this.ItemId));
        }
        if (this.ParameterSetName == "ParamSet7")
        {
            this.ValidateSwitchParameter(nameof(this.All));
            if (this.NoEnumerate)
            {
                this.Outputs.Add(this.Service.GetObjectEnumerable(this.List));
            }
            else
            {
                this.Outputs.AddRange(this.Service.GetObjectEnumerable(this.List));
            }
        }
        if (this.ParameterSetName == "ParamSet8")
        {
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
