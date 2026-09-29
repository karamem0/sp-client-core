//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System.Management.Automation;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Get, "DocumentLibrary")]
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

    protected override async Task ProcessRecordAsync()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            this.ValidateSwitchParameter(nameof(this.Default));
            this.Outputs.Add(await this.Service.GetObjectAsync());
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            if (this.IncludeMediaLibraries)
            {
                if (this.NoEnumerate)
                {
                    this.Outputs.Add(await this.Service.GetObjectEnumerableAsync(this.IncludeMediaLibraries));
                }
                else
                {
                    this.Outputs.AddRange(await this.Service.GetObjectEnumerableAsync(this.IncludeMediaLibraries));
                }
            }
            else
            {
                if (this.NoEnumerate)
                {
                    this.Outputs.Add(await this.Service.GetObjectEnumerableAsync());
                }
                else
                {
                    this.Outputs.AddRange(await this.Service.GetObjectEnumerableAsync());
                }
            }
        }
    }

}
