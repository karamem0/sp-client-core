//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

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

    [Cmdlet("Remove", "SPUser")]
    [OutputType(typeof(void))]
    public class RemoveUserCommand : PSCmdlet
    {

        public RemoveUserCommand()
        {
        }

        [Parameter(Mandatory = true)]
        [Alias("Identity")]
        public UserPipeBind User { get; private set; }

        [Parameter(Mandatory = false)]
        public GroupPipeBind Group { get; private set; }

        protected override void ProcessRecord()
        {
            if (ClientObjectService.ServiceProvider == null)
            {
                throw new InvalidOperationException(StringResources.ErrorNotConnected);
            }
            var userService = ClientObjectService.ServiceProvider.GetService<IUserService>();
            if (this.Group == null)
            {
                var user = userService.GetUser(this.User);
                userService.RemoveUser(user.LoginName);
            }
            else
            {
                var groupService = ClientObjectService.ServiceProvider.GetService<IGroupService>();
                var group = groupService.GetGroup(this.Group);
                var user = userService.GetUser(group.Id, this.User);
                userService.RemoveUser(group.Id, user.LoginName);
            }
        }

    }

}
