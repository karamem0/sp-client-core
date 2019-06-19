//
// Copyright (c) 2019 karamem0
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

    [Cmdlet("Get", "KshRoleAssignment")]
    [OutputType(typeof(RoleAssignment))]
    public class GetRoleAssignmentCommand : ClientObjectCmdlet<ISiteService, IRoleAssignmentService>
    {

        public GetRoleAssignmentCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet1")]
        public RoleAssignment Identity { get; private set; }

        [Parameter(Mandatory = false, Position = 0, ParameterSetName = "ParamSet2")]
        [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
        public Site Site { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet4")]
        [Parameter(Mandatory = true, ParameterSetName = "ParamSet5")]
        public List List { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet6")]
        [Parameter(Mandatory = true, ParameterSetName = "ParamSet7")]
        public ListItem ListItem { get; private set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet2")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet4")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet6")]
        public int PrincipalId { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
        [Parameter(Mandatory = false, ParameterSetName = "ParamSet5")]
        [Parameter(Mandatory = false, ParameterSetName = "ParamSet7")]
        public SwitchParameter NoEnumerate { get; private set; }

        protected override void ProcessRecordCore()
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                this.WriteObject(this.Service2.GetObject(this.Identity));
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                if (this.Site == null)
                {
                    this.WriteObject(this.Service2.GetObject(this.Service1.GetObject(), this.PrincipalId));
                }
                else
                {
                    this.WriteObject(this.Service2.GetObject(this.Site, this.PrincipalId));
                }
            }
            if (this.ParameterSetName == "ParamSet3")
            {
                if (this.Site == null)
                {
                    this.WriteObject(this.Service2.GetObjectEnumerable(this.Service1.GetObject()), this.NoEnumerate ? false : true);
                }
                else
                {
                    this.WriteObject(this.Service2.GetObjectEnumerable(this.Site), this.NoEnumerate ? false : true);
                }
            }
            if (this.ParameterSetName == "ParamSet4")
            {
                this.WriteObject(this.Service2.GetObject(this.List, this.PrincipalId));
            }
            if (this.ParameterSetName == "ParamSet5")
            {
                this.WriteObject(this.Service2.GetObjectEnumerable(this.List), this.NoEnumerate ? false : true);
            }
            if (this.ParameterSetName == "ParamSet6")
            {
                this.WriteObject(this.Service2.GetObject(this.ListItem, this.PrincipalId));
            }
            if (this.ParameterSetName == "ParamSet7")
            {
                this.WriteObject(this.Service2.GetObjectEnumerable(this.ListItem), this.NoEnumerate ? false : true);
            }
        }

    }

}
