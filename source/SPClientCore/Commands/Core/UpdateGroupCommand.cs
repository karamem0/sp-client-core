//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.Core;
using Karamem0.SharePoint.PowerShell.Models.OData;
using Karamem0.SharePoint.PowerShell.PipeBinds.Core;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Services;
using Karamem0.SharePoint.PowerShell.Services.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands.Core
{

    [Cmdlet("Update", "SPGroup")]
    [OutputType(typeof(Group))]
    public class UpdateGroupCommand : PSCmdlet
    {

        public UpdateGroupCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public GroupPipeBind Group { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? AllowMembersEditMembership { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? AllowRequestToJoinLeave { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? AutoAcceptRequestToJoinLeave { get; private set; }

        [Parameter(Mandatory = false)]
        public string Description { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? OnlyAllowMembersViewMembership { get; private set; }

        [Parameter(Mandatory = false)]
        public string RequestToJoinLeaveEmailSetting { get; private set; }

        [Parameter(Mandatory = true)]
        public string Title { get; private set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; private set; }

        [Parameter(Mandatory = false)]
        public string[] Includes { get; private set; }

        protected override void ProcessRecord()
        {
            if (ClientObjectService.ServiceProvider == null)
            {
                throw new InvalidOperationException(StringResources.ErrorNotConnected);
            }
            var groupService = ClientObjectService.ServiceProvider.GetService<IGroupService>();
            var groupQuery = ODataQuery.Create<Group>(this.MyInvocation.BoundParameters);
            var group = groupService.GetGroup(this.Group);
            groupService.UpdateGroup(group.Id, this.MyInvocation.BoundParameters);
            if (this.PassThru)
            {
                this.WriteObject(groupService.GetGroup(new GroupPipeBind(group.Id), groupQuery));
            }
        }

    }

}
