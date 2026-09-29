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

[Cmdlet(VerbsCommon.Add, "View")]
[OutputType(typeof(View))]
public class AddViewCommand : ClientObjectCmdlet<IViewService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true
    )]
    public List? List { get; private set; }

    [Parameter(Mandatory = false)]
    public int BaseViewId { get; private set; }

    [Parameter(Mandatory = false)]
    public bool Paged { get; private set; }

    [Parameter(Mandatory = false)]
    public bool PersonalView { get; private set; }

    [Parameter(Mandatory = false)]
    public int RowLimit { get; private set; }

    [Parameter(Mandatory = false)]
    public bool SetAsDefaultView { get; private set; }

    [Parameter(Mandatory = true)]
    public string? Title { get; private set; }

    [Parameter(Mandatory = false)]
    public string[]? ViewColumns { get; private set; }

    [Parameter(Mandatory = false)]
    public string? ViewQuery { get; private set; }

    [Parameter(Mandatory = false)]
    public ViewType ViewType { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter SelectAllProperties { get; private set; } = true;

    protected override async Task ProcessRecordAsync()
    {
        _ = this.List ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.List));
        var creationInfo = new Dictionary<string, object?>(this.MyInvocation.BoundParameters);
        this.Outputs.Add(
            await this.Service.AddObjectAsync(
                this.List,
                creationInfo,
                this.SelectAllProperties
            )
        );
    }

}
