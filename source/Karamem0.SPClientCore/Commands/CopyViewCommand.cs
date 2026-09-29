//
// Copyright (c) 2018-2026 karamem0
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

[Cmdlet(VerbsCommon.Copy, "View")]
[OutputType(typeof(View))]
public class CopyViewCommand : ClientObjectCmdlet<IViewService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true
    )]
    public List? List { get; private set; }

    [Parameter(Mandatory = true)]
    public View? View { get; private set; }

    [Parameter(Mandatory = true)]
    public string? NewName { get; private set; }

    [Parameter(Mandatory = true)]
    public bool PersonalView { get; private set; }

    [Parameter(Mandatory = false)]
    public string? Url { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter PassThru { get; private set; }

    protected override async Task ProcessRecordAsync()
    {
        _ = this.List ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.List));
        _ = this.View ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.View));
        _ = this.NewName ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.NewName));
        _ = await this.Service.CopyObjectAsync(
            this.List,
            this.View,
            this.NewName,
            this.PersonalView,
            this.Url
        );
        if (this.PassThru)
        {
            this.Outputs.Add(await this.Service.GetObjectAsync(this.List, this.NewName));
        }
    }

}
