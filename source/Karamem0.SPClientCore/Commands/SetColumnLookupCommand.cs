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

[Cmdlet(VerbsCommon.Set, "ColumnLookup")]
[OutputType(typeof(ColumnLookup))]
public class SetColumnLookupCommand : ClientObjectCmdlet<IColumnService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true
    )]
    public Column? Identity { get; private set; }

    [Parameter(Mandatory = false)]
    public bool AllowMultipleValues { get; private set; }

    [Parameter(Mandatory = false)]
    public string? ClientSideComponentId { get; private set; }

    [Parameter(Mandatory = false)]
    public string? ClientSideComponentProperties { get; private set; }

    [Parameter(Mandatory = false)]
    public string? CustomFormatter { get; private set; }

    [Parameter(Mandatory = false)]
    public string? Description { get; private set; }

    [Parameter(Mandatory = false)]
    public string? Direction { get; private set; }

    [Parameter(Mandatory = false)]
    public bool EnforceUniqueValues { get; private set; }

    [Parameter(Mandatory = false)]
    public string? Group { get; private set; }

    [Parameter(Mandatory = false)]
    public bool Hidden { get; private set; }

    [Parameter(Mandatory = false)]
    public bool Indexed { get; private set; }

    [Parameter(Mandatory = false)]
    public string? JSLink { get; private set; }

    [Parameter(Mandatory = false)]
    public string? LookupColumnName { get; private set; }

    [Parameter(Mandatory = false)]
    public Guid LookupListId { get; private set; }

    [Parameter(Mandatory = false)]
    public Guid LookupSiteId { get; private set; }

    [Parameter(Mandatory = false)]
    public bool NoCrawl { get; private set; }

    [Parameter(Mandatory = false)]
    public bool ReadOnly { get; private set; }

    [Parameter(Mandatory = false)]
    public RelationshipDeleteBehaviorType RelationshipDeleteBehavior { get; private set; }

    [Parameter(Mandatory = false)]
    public bool Required { get; private set; }

    [Parameter(Mandatory = false)]
    public string? StaticName { get; private set; }

    [Parameter(Mandatory = false)]
    public string? Title { get; private set; }

    [Parameter(Mandatory = false)]
    public bool UnlimitedLengthInDocumentLibrary { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter PushChanges { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter PassThru { get; private set; }

    protected override void ProcessRecordCore()
    {
        _ = this.Identity ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Identity));
        this.Service.SetObject(
            this.Identity,
            this.MyInvocation.BoundParameters,
            this.PushChanges
        );
        if (this.PassThru)
        {
            this.Outputs.Add(this.Service.GetObject(this.Identity));
        }
    }

}
