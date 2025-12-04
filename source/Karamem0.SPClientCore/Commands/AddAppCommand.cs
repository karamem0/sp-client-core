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

[Cmdlet(VerbsCommon.Add, "App")]
[OutputType(typeof(App))]
public class AddAppCommand : ClientObjectCmdlet<IAppService>
{

    [Parameter(Mandatory = true)]
    public System.IO.Stream? Content { get; private set; }

    [Parameter(Mandatory = true)]
    public string? FileName { get; private set; }

    [Parameter(Mandatory = false)]
    public bool Overwrite { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter Tenant { get; private set; }

    protected override void ProcessRecordCore()
    {
        _ = this.Content ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Content));
        _ = this.FileName ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.FileName));
        this.Outputs.Add(
            this.Service.AddObject(
                this.Content,
                this.FileName,
                this.Overwrite,
                this.Tenant
            )
        );
    }

}
