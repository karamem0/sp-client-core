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

[Cmdlet(VerbsCommon.Set, "KshCommentEnabled")]
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

    protected override void ProcessRecordCore()
    {
        _ = this.Identity ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Identity));
        if (this.Enabled)
        {
            this.Service1.SetDisabled(this.Identity, false);
        }
        else
        {
            this.Service1.SetDisabled(this.Identity, true);
        }
        if (this.PassThru)
        {
            this.Outputs.Add(this.Service2.GetObject(this.Identity));
        }
    }

}
