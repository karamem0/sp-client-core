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

    [Cmdlet("Remove", "SPView")]
    [OutputType(typeof(void))]
    public class RemoveViewCommand : ClientObjectCmdlet
    {

        public RemoveViewCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0)]
        public ListPipeBind List { get; private set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        public ViewPipeBind View { get; private set; }

        protected override void ProcessRecord()
        {
            if (ClientObjectService.ServiceProvider == null)
            {
                throw new InvalidOperationException(StringResources.ErrorNotConnected);
            }
            var viewService = ClientObjectService.ServiceProvider.GetService<IViewService>();
            var listService = ClientObjectService.ServiceProvider.GetService<IListService>();
            var list = listService.GetList(this.List);
            var view = viewService.GetView(list.Id, this.View);
            viewService.RemoveView(list.Id, view.Id);
        }

    }

}
