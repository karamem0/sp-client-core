//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
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

    [Cmdlet("Update", "KshTermSet")]
    [OutputType(typeof(TermSet))]
    public class UpdateTermSetCommand : ClientObjectCmdlet<ITermSetService>
    {

        public UpdateTermSetCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public TermSet Identity { get; private set; }

        [Parameter(Mandatory = false)]
        public string Contact { get; private set; }

        [Parameter(Mandatory = false)]
        public string CustomSortOrder { get; private set; }

        [Parameter(Mandatory = false)]
        public string Description { get; private set; }

        [Parameter(Mandatory = false)]
        public bool IsAvailableForTagging { get; private set; }

        [Parameter(Mandatory = false)]
        public bool IsOpenForTermCreation { get; private set; }

        [Parameter(Mandatory = false)]
        public string Name { get; private set; }

        [Parameter(Mandatory = false)]
        public string Owner { get; private set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; private set; }

        protected override void ProcessRecordCore(ref List<object> outputs)
        {
            this.Service.UpdateObject(this.Identity, this.MyInvocation.BoundParameters);
            if (this.PassThru)
            {
                outputs.Add(this.Service.GetObject(this.Identity));
            }
        }

    }

}
