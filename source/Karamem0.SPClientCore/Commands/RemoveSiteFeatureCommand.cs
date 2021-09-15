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

    [Cmdlet("Remove", "KshSiteFeature")]
    [OutputType(typeof(void))]
    public class RemoveSiteFeatureCommand : ClientObjectCmdlet<ISiteFeatureService>
    {

        public RemoveSiteFeatureCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public Feature Identity { get; private set; }

        [Parameter(Mandatory = false)]
        public bool Force { get; private set; }

        protected override void ProcessRecordCore(ref List<object> outputs)
        {
            this.Service.RemoveObject(this.Identity.DefinitionId, this.Force);
        }

    }

}
