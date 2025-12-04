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

[Cmdlet(VerbsData.Merge, "Term")]
[OutputType(typeof(void))]
public class MergeTermCommand : ClientObjectCmdlet<ITermService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true
    )]
    public Term? Identity { get; private set; }

    [Parameter(Mandatory = true, Position = 1)]
    public Term? ToMerge { get; private set; }

    protected override void ProcessRecordCore()
    {
        _ = this.Identity ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Identity));
        _ = this.ToMerge ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ToMerge));
        this.Service.MergeObject(this.Identity, this.ToMerge);
    }

}
