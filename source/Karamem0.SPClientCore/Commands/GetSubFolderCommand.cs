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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Get, "KshSubFolder")]
[OutputType(typeof(Folder))]
public class GetSubFolderCommand : ClientObjectCmdlet<IFolderService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet1"
    )]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public Folder? Folder { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 1,
        ParameterSetName = "ParamSet1"
    )]
    public string? FolderName { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    public SwitchParameter NoEnumerate { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            _ = this.Folder ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Folder));
            _ = this.FolderName ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.FolderName));
            this.Outputs.Add(this.Service.GetObject(this.Folder, this.FolderName));
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            _ = this.Folder ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Folder));
            if (this.NoEnumerate)
            {
                this.Outputs.Add(this.Service.GetObjectEnumerable(this.Folder));
            }
            else
            {
                this.Outputs.AddRange(this.Service.GetObjectEnumerable(this.Folder));
            }
        }
    }

}
