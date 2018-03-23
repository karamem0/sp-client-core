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

    [Cmdlet("New", "SPUser")]
    [OutputType(typeof(User))]
    public class NewUserCommand : PSCmdlet
    {

        public NewUserCommand()
        {
        }

        [Parameter(Mandatory = false)]
        public GroupPipeBind Group { get; private set; }

        [Parameter(Mandatory = false)]
        public string Email { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? IsSiteAdmin { get; private set; }

        [Parameter(Mandatory = true)]
        public string LoginName { get; private set; }

        [Parameter(Mandatory = false)]
        public string Title { get; private set; }

        [Parameter(Mandatory = false)]
        public string[] Includes { get; private set; }

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
                this.WriteObject(userService.CreateUser(this.MyInvocation.BoundParameters, userQuery));
            }
            else
            {
                var groupService = ClientObjectService.ServiceProvider.GetService<IGroupService>();
                var group = groupService.GetGroup(this.Group);
                this.WriteObject(userService.CreateUser(group.Id, this.MyInvocation.BoundParameters, userQuery));
            }
        }

    }

}
