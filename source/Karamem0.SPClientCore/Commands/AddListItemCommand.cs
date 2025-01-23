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

[Cmdlet(VerbsCommon.Add, "KshListItem")]
[OutputType(typeof(ListItem))]
public class AddListItemCommand : ClientObjectCmdlet<IListItemService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true
    )]
    public List List { get; private set; }

    [Parameter(Mandatory = true, Position = 1)]
    public PSObject[] Value { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter NoEnumerate { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.NoEnumerate)
        {
            this.Outputs.Add(
                this.Service.AddObjectEnumerable(
                    this.List,
                    this.Value
                        .Select(
                            value =>
                            {
                                if (value.BaseObject is Hashtable hashtable)
                                {
                                    return hashtable.ToDictionary<string, object>();
                                }
                                else
                                {
                                    return value.Properties.ToDictionary(
                                        property => property.Name,
                                        property => property.Value
                                    );
                                }
                            }
                        )
                        .ToArray()
                )
            );
        }
        else
        {
            this.Outputs.AddRange(
                this.Service.AddObjectEnumerable(
                    this.List,
                    this.Value
                        .Select(
                            value =>
                            {
                                if (value.BaseObject is Hashtable hashtable)
                                {
                                    return hashtable.ToDictionary<string, object>();
                                }
                                else
                                {
                                    return value.Properties.ToDictionary(
                                        property => property.Name,
                                        property => property.Value
                                    );
                                }
                            }
                        )
                        .ToArray()
                )
            );
        }
    }

}
