//
// Copyright (c) 2023 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("Set", "KshNavigationNode")]
    [Alias("Update-KshNavigationNode")]
    [OutputType(typeof(NavigationNode))]
    public class SetNavigationNodeCommand : ClientObjectCmdlet<INavigationNodeService>
    {

        public SetNavigationNodeCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public NavigationNode Identity { get; private set; }

        [Parameter(Mandatory = false)]
        public Guid[] AudienceIds { get; private set; }

        [Parameter(Mandatory = false)]
        public bool IsVisible { get; private set; }

        [Parameter(Mandatory = false)]
        public string Title { get; private set; }

        [Parameter(Mandatory = false)]
        public string Url { get; private set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; private set; }

        protected override void ProcessRecordCore()
        {
            this.Service.SetObject(this.Identity, this.MyInvocation.BoundParameters);
            if (this.PassThru)
            {
                this.Outputs.Add(this.Service.GetObject(this.Identity));
            }
        }

    }

}
