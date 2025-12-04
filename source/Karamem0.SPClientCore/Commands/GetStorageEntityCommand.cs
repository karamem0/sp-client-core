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

[Cmdlet(VerbsCommon.Get, "StorageEntity")]
[OutputType(typeof(StorageEntity))]
public class GetStorageEntityCommand : ClientObjectCmdlet<IStorageEntityService>
{

    [Parameter(Mandatory = true)]
    public string? Key { get; private set; }

    protected override void ProcessRecordCore()
    {
        _ = this.Key ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Key));
        this.Outputs.Add(this.Service.GetObject(this.Key));
    }

}
