//
// Copyright (c) 2018-2025 karamem0
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

[Cmdlet(VerbsCommon.Get, "KshDocumentLibrary")]
[OutputType(typeof(DocumentLibraryInfo))]
public class GetDocumentLibraryCommand : ClientObjectCmdlet<IDocumentLibraryService>
{

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    public SwitchParameter Default { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    public SwitchParameter IncludeMediaLibraries { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    public SwitchParameter IncludePageLibraries { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    public SwitchParameter NoEnumerate { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            this.ValidateSwitchParameter(nameof(this.Default));
            this.Outputs.Add(this.Service.GetObject());
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            if (this.IncludeMediaLibraries)
            {
                if (this.NoEnumerate)
                {
                    this.Outputs.Add(this.Service.GetObjectEnumerable(this.IncludeMediaLibraries));
                }
                else
                {
                    this.Outputs.AddRange(this.Service.GetObjectEnumerable(this.IncludeMediaLibraries));
                }
            }
            else
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

}
