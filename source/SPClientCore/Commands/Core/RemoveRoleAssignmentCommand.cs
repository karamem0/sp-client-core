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

    [Cmdlet("Remove", "SPRoleAssignment", DefaultParameterSetName = "Web")]
    [OutputType(typeof(void))]
    public class RemoveRoleAssignmentCommand : PSCmdlet
    {

        public RemoveRoleAssignmentCommand()
        {
        }

        [Parameter(Mandatory = true, ParameterSetName = "List", Position = 0)]
        [Parameter(Mandatory = true, ParameterSetName = "ListItem", Position = 0)]
        public ListPipeBind List { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "ListItem", Position = 1)]
        public ListItemPipeBind ListItem { get; private set; }

        [Parameter(Mandatory = true)]
        public int? PrincipalId { get; private set; }

        [Parameter(Mandatory = true)]
        public int? RoleDefinitionId { get; private set; }

        protected override void ProcessRecord()
        {
            if (ClientObjectService.ServiceProvider == null)
            {
                throw new InvalidOperationException(StringResources.ErrorNotConnected);
            }
            if (this.ParameterSetName == "Web")
            {
                var webService = ClientObjectService.ServiceProvider.GetService<IWebService>();
                webService.RemoveWebRoleAssignment(this.PrincipalId, this.RoleDefinitionId);
            }
            if (this.ParameterSetName == "List")
            {
                var listService = ClientObjectService.ServiceProvider.GetService<IListService>();
                var list = listService.GetList(this.List);
                listService.RemoveListRoleAssignment(list.Id, this.PrincipalId, this.RoleDefinitionId);
            }
            if (this.ParameterSetName == "ListItem")
            {
                var listItemService = ClientObjectService.ServiceProvider.GetService<IListItemService>();
                var listService = ClientObjectService.ServiceProvider.GetService<IListService>();
                var list = listService.GetList(this.List);
                var listItem = listItemService.GetListItem(list.Id, this.ListItem);
                listItemService.RemoveListItemRoleAssignment(list.Id, listItem.Id, this.PrincipalId, this.RoleDefinitionId);
            }
        }

    }

}
