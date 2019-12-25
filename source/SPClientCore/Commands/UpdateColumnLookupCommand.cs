//
// Copyright (c) 2020 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("Update", "KshColumnLookup")]
    [OutputType(typeof(ColumnLookup))]
    public class UpdateColumnLookupCommand : ClientObjectCmdlet<IColumnService>
    {

        public UpdateColumnLookupCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public Column Identity { get; private set; }

        [Parameter(Mandatory = false)]
        public bool AllowMultipleValues { get; private set; }

        [Parameter(Mandatory = false)]
        public string ClientSideComponentId { get; private set; }

        [Parameter(Mandatory = false)]
        public string ClientSideComponentProperties { get; private set; }

        [Parameter(Mandatory = false)]
        public string CustomFormatter { get; private set; }

        [Parameter(Mandatory = false)]
        public string Description { get; private set; }

        [Parameter(Mandatory = false)]
        public string Direction { get; private set; }

        [Parameter(Mandatory = false)]
        public bool EnforceUniqueValues { get; private set; }

        [Parameter(Mandatory = false)]
        public string Group { get; private set; }

        [Parameter(Mandatory = false)]
        public bool Hidden { get; private set; }

        [Parameter(Mandatory = false)]
        public bool Indexed { get; private set; }

        [Parameter(Mandatory = false)]
        public string JSLink { get; private set; }

        [Parameter(Mandatory = false)]
        public string LookupColumnName { get; private set; }

        [Parameter(Mandatory = false)]
        public Guid LookupListId { get; private set; }

        [Parameter(Mandatory = false)]
        public bool NoCrawl { get; private set; }

        [Parameter(Mandatory = false)]
        public bool ReadOnly { get; private set; }

        [Parameter(Mandatory = false)]
        public RelationshipDeleteBehaviorType RelationshipDeleteBehavior { get; private set; }

        [Parameter(Mandatory = false)]
        public bool Required { get; private set; }

        [Parameter(Mandatory = false)]
        public string StaticName { get; private set; }

        [Parameter(Mandatory = false)]
        public string Title { get; private set; }

        [Parameter(Mandatory = false)]
        public bool UnlimitedLengthInDocumentLibrary { get; private set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PushChanges { get; private set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; private set; }

        protected override void ProcessRecordCore()
        {
            this.Service.UpdateObject(this.Identity, this.MyInvocation.BoundParameters, this.PushChanges);
            if (this.PassThru)
            {
                this.WriteObject(this.Service.GetObject(this.Identity));
            }
        }

    }

}
