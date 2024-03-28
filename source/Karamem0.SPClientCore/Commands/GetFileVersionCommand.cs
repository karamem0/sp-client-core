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

[Cmdlet(VerbsCommon.Get, "KshFileVersion")]
[OutputType(typeof(FileVersion))]
public class GetFileVersionCommand : ClientObjectCmdlet<IFileVersionService>
{

    public GetFileVersionCommand()
    {
    }

    [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet1")]
    public FileVersion Identity { get; private set; }

    [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
    public File File { get; private set; }

    [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet2")]
    public int FileVersionId { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    public SwitchParameter NoEnumerate { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            this.Outputs.Add(this.Service.GetObject(this.Identity));
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            this.Outputs.Add(this.Service.GetObject(this.File, this.FileVersionId));
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            if (this.NoEnumerate)
            {
                this.Outputs.Add(this.Service.GetObjectEnumerable(this.File));
            }
            else
            {
                this.Outputs.AddRange(this.Service.GetObjectEnumerable(this.File));
            }
        }
    }

}
