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
using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System.Management.Automation;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Add, "ListItem")]
[OutputType(typeof(ListItem))]
public class AddListItemCommand : ClientObjectCmdlet<IListItemService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true
    )]
    public List? List { get; private set; }

    [Parameter(Mandatory = true, Position = 1)]
    public PSObject[]? Value { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter NoEnumerate { get; private set; }

    protected override void ProcessRecordCore()
    {
        _ = this.List ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.List));
        if (this.NoEnumerate)
        {
            this.Outputs.Add(
                this.Service.AddObjectEnumerable(
                    this.List,
                    this.Value.Select(value => value
                        .ToDictionary()
                        .AsReadOnly()
                    )
                )
            );
        }
        else
        {
            this.Outputs.AddRange(
                this.Service.AddObjectEnumerable(
                    this.List,
                    this.Value.Select(value => value
                        .ToDictionary()
                        .AsReadOnly()
                    )
                )
            );
        }
    }

}
