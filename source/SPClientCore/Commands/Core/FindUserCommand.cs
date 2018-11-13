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

    [Cmdlet("Find", "SPUser")]
    [OutputType(typeof(User[]))]
    public class FindUserCommand : ClientObjectCmdlet
    {

        public FindUserCommand()
        {
        }

        [Parameter(Mandatory = false, Position = 0)]
        public GroupPipeBind Group { get; private set; }

        [Parameter(Mandatory = false)]
        public string[] Includes { get; private set; }

        [Parameter(Mandatory = false)]
        public string[] OrderBy { get; private set; }

        [Parameter(Mandatory = false)]
        public int? Top { get; private set; }

        [Parameter(Mandatory = false)]
        public int? Skip { get; private set; }

        [Parameter(Mandatory = false)]
        public string Filter { get; private set; }

        protected override void ProcessRecord()
        {
            if (ClientObjectService.ServiceProvider == null)
            {
                throw new InvalidOperationException(StringResources.ErrorNotConnected);
            }
            var userService = ClientObjectService.ServiceProvider.GetService<IUserService>();
            var userQuery = ODataQuery.Create<User>(this.MyInvocation.BoundParameters);
            if (this.Group == null)
            {
                this.WriteObject(userService.FindUsers(userQuery), true);
            }
            else
            {
                var groupService = ClientObjectService.ServiceProvider.GetService<IGroupService>();
                var group = groupService.GetGroup(this.Group);
                this.WriteObject(userService.FindUsers(group.Id, userQuery), true);
            }
        }

    }

}
