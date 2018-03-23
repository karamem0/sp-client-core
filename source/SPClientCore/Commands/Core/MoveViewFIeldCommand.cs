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

    [Cmdlet("Move", "SPViewField")]
    [OutputType(typeof(void))]
    public class MoveViewFieldCommand : PSCmdlet
    {

        public MoveViewFieldCommand()
        {
        }

        [Parameter(Mandatory = true)]
        public ListPipeBind List { get; private set; }

        [Parameter(Mandatory = true)]
        public ViewPipeBind View { get; private set; }

        [Parameter(Mandatory = true)]
        public string Name { get; private set; }

        [Parameter(Mandatory = true)]
        public int Index { get; private set; }

        protected override void ProcessRecord()
        {
            if (ClientObjectService.ServiceProvider == null)
            {
                throw new InvalidOperationException(StringResources.ErrorNotConnected);
            }
            var listService = ClientObjectService.ServiceProvider.GetService<IListService>();
            var viewService = ClientObjectService.ServiceProvider.GetService<IViewService>();
            var list = listService.GetList(this.List);
            var view = viewService.GetView(list.Id, this.View);
            viewService.MoveViewField(list.Id, view.Id, this.Name, this.Index);
        }

    }

}
