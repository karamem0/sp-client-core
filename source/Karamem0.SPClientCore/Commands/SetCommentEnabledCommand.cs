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

[Cmdlet(VerbsCommon.Set, "CommentEnabled")]
[OutputType(typeof(ListItem))]
public class SetCommentEnabledCommand : ClientObjectCmdlet<ICommentService, IListItemService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true
    )]
    public ListItem? Identity { get; private set; }

    [Parameter(Mandatory = true)]
    public bool Enabled { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter PassThru { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter SelectAllProperties { get; private set; } = true;

    protected override async Task ProcessRecordAsync()
    {
        _ = this.Identity ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Identity));
        if (this.Enabled)
        {
            await this.Service1.SetDisabledAsync(this.Identity, false);
        }
        else
        {
            await this.Service1.SetDisabledAsync(this.Identity, true);
        }
        if (this.PassThru)
        {
            this.Outputs.Add(await this.Service2.GetObjectAsync(this.Identity, this.SelectAllProperties));
        }
    }

}
