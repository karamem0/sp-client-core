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

    [Cmdlet("Get", "KshGroup")]
    [OutputType(typeof(Group))]
    public class GetGroupCommand : ClientObjectCmdlet<IGroupService>
    {

        public GetGroupCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet1")]
        public Group Identity { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet2")]
        public int GroupId { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet3")]
        public string GroupTitle { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet4")]
        public SwitchParameter NoEnumerate { get; private set; }

        protected override void ProcessRecordCore()
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                this.Outputs.Add(this.Service.GetObject(this.Identity));
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                this.Outputs.Add(this.Service.GetObject(this.GroupId));
            }
            if (this.ParameterSetName == "ParamSet3")
            {
                this.Outputs.Add(this.Service.GetObject(this.GroupTitle));
            }
            if (this.ParameterSetName == "ParamSet4")
            {
                if (this.NoEnumerate)
                {
                    this.Outputs.Add(this.Service.GetObjectEnumerable());
                }
                else
                {
                    this.Outputs.AddRange(this.Service.GetObjectEnumerable());
                }
            }
        }

    }

}
