//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Get, "KshFolder")]
[OutputType(typeof(Folder))]
public class GetFolderCommand : ClientObjectCmdlet<IFolderService>
{

    public GetFolderCommand()
    {
    }

    [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet1")]
    public Folder Identity { get; private set; }

    [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet2")]
    public List List { get; private set; }

    [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet3")]
    public ListItem ListItem { get; private set; }

    [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet4")]
    public Guid FolderId { get; private set; }

    [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet5")]
    public Uri FolderUrl { get; private set; }

    [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet6")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet7")]
    public Folder Folder { get; private set; }

    [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet6")]
    public string FolderName { get; private set; }

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
            this.Outputs.Add(this.Service.GetObject(this.List));
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            this.Outputs.Add(this.Service.GetObject(this.ListItem));
        }
        if (this.ParameterSetName == "ParamSet4")
        {
            this.Outputs.Add(this.Service.GetObject(this.FolderId));
        }
        if (this.ParameterSetName == "ParamSet5")
        {
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
            this.Outputs.Add(this.Service.GetObject(this.Folder, this.FolderName));
        }
        if (this.ParameterSetName == "ParamSet7")
        {
            if (this.NoEnumerate)
            {
                this.Outputs.Add(this.Service.GetObjectEnumerable(this.Folder));
            }
            else
            {
                this.Outputs.AddRange(this.Service.GetObjectEnumerable(this.Folder));
            }
        }
        if (this.ParameterSetName == "ParamSet8")
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
