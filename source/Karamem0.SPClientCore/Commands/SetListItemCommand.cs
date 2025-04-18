//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Set, "KshListItem")]
[OutputType(typeof(ListItem))]
public class SetListItemCommand : ClientObjectCmdlet<IListItemService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true
    )]
    public ListItem Identity { get; private set; }

    [Parameter(Mandatory = true)]
    public PSObject Value { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter SystemUpdate { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter PassThru { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.Value.BaseObject is Hashtable hashtable)
        {
            this.Service.SetObject(
                this.Identity,
                hashtable.ToDictionary<string, object>(),
                this.SystemUpdate
            );
        }
        else
        {
            this.Service.SetObject(
                this.Identity,
                this.Value.Properties.ToDictionary(property => property.Name, property => property.Value),
                this.SystemUpdate
            );
        }
        if (this.PassThru)
        {
            this.Outputs.Add(this.Service.GetObject(this.Identity));
        }
    }

}
