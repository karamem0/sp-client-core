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
using System.Management.Automation;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.New, "ColumnTaxonomyValue")]
[OutputType(typeof(ColumnTaxonomyValue))]
public class NewColumnTaxonomyValueCommand : ClientObjectCmdlet
{

    [Parameter(Mandatory = true)]
    public Term? Term { get; private set; }

    protected override void ProcessRecordCore()
    {
        _ = this.Term ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Term));
        this.Outputs.Add(
            new ColumnTaxonomyValue(
                this.Term.Name,
                this.Term.Id.ToString(),
                -1
            )
        );
    }

}
