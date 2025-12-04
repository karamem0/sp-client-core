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

[Cmdlet(VerbsCommon.Add, "TermLocalCustomProperty")]
[OutputType(typeof(void))]
public class AddTermLocalCustomPropertyCommand : ClientObjectCmdlet<ITermLocalCustomPropertyService>
{

    [Parameter(Mandatory = true, Position = 0)]
    public Term? Term { get; private set; }

    [Parameter(Mandatory = true)]
    public string? Name { get; private set; }

    [Parameter(Mandatory = true)]
    public string? Value { get; private set; }

    protected override void ProcessRecordCore()
    {
        _ = this.Term ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Term));
        _ = this.Name ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Name));
        _ = this.Value ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Value));
        this.Service.AddObject(
            this.Term,
            this.Name,
            this.Value
        );
    }

}
