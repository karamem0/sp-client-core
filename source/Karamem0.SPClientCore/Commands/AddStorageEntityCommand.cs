//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Add, "KshStorageEntity")]
[OutputType(typeof(void))]
public class AddStorageEntityCommand : ClientObjectCmdlet<IStorageEntityService>
{

    [Parameter(Mandatory = true)]
    public string? Key { get; private set; }

    [Parameter(Mandatory = true)]
    public string? Value { get; private set; }

    [Parameter(Mandatory = false)]
    public string? Description { get; private set; }

    [Parameter(Mandatory = false)]
    public string? Comment { get; private set; }

    protected override void ProcessRecordCore()
    {
        _ = this.Key ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Key));
        _ = this.Value ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Value));
        this.Service.AddObject(
            this.Key,
            this.Value,
            this.Description,
            this.Comment
        );
    }

}
