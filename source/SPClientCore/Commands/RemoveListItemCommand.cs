//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.PipeBinds;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("Remove", "SPListItem")]
    [OutputType(typeof(GuidResult))]
    public class RemoveListItemCommand : PSCmdlet
    {

        public RemoveListItemCommand()
        {
        }

        [Parameter(Mandatory = true)]
        public ListPipeBind List { get; private set; }

        [Parameter(Mandatory = true)]
        public ListItemPipeBind ListItem { get; private set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter RecycleBin { get; private set; }

        protected override void ProcessRecord()
        {
            if (ClientObjectService.ServiceProvider == null)
            {
                throw new InvalidOperationException(StringResources.ErrorNotConnected);
            }
            var listItemService = ClientObjectService.ServiceProvider.GetService<IListItemService>();
            var listService = ClientObjectService.ServiceProvider.GetService<IListService>();
            var list = listService.GetList(this.List);
            var listItem = listItemService.GetListItem(list.Id, this.ListItem);
            if (this.RecycleBin)
            {
                this.WriteObject(listItemService.RecycleListItem(list.Id, listItem.Id));
            }
            else
            {
                listItemService.RemoveListItem(list.Id, listItem.Id);
            }
        }

    }

}
