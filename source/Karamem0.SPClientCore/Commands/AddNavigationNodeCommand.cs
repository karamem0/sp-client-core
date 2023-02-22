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

    [Cmdlet("Add", "KshNavigationNode")]
    [Alias("New-KshNavigationNode")]
    [OutputType(typeof(NavigationNode))]
    public class AddNavigationNodeCommand : ClientObjectCmdlet<INavigationNodeService>
    {

        public AddNavigationNodeCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet1")]
        public NavigationNode NavigationNode { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
        public SwitchParameter QuickLaunch { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
        public SwitchParameter TopNavigationBar { get; private set; }

        [Parameter(Mandatory = false)]
        public bool AsLastNode { get; private set; }

        [Parameter(Mandatory = false)]
        public bool IsExternal { get; private set; }

        [Parameter(Mandatory = false)]
        public NavigationNode PreviousNode { get; private set; }

        [Parameter(Mandatory = false)]
        public string Title { get; private set; }

        [Parameter(Mandatory = false)]
        public string Url { get; private set; }

        protected override void ProcessRecordCore()
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                this.Outputs.Add(this.Service.AddObject(this.NavigationNode, this.MyInvocation.BoundParameters));
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                this.Outputs.Add(this.Service.AddObjectToQuickLaunch(this.MyInvocation.BoundParameters));
            }
            if (this.ParameterSetName == "ParamSet3")
            {
                this.Outputs.Add(this.Service.AddObjectToTopNavigationBar(this.MyInvocation.BoundParameters));
            }
        }

    }

}
