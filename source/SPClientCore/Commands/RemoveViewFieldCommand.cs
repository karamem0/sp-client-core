//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

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

    [Cmdlet("Remove", "SPViewField", DefaultParameterSetName = "One")]
    [OutputType(typeof(void))]
    public class RemoveViewFieldCommand : PSCmdlet
    {

        public RemoveViewFieldCommand()
        {
        }

        [Parameter(Mandatory = true)]
        public ViewPipeBind View { get; private set; }

        [Parameter(Mandatory = true)]
        public ListPipeBind List { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "One")]
        public string Name { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "All")]
        public SwitchParameter All { get; private set; }

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
            if (this.ParameterSetName == "One")
            {
                viewService.RemoveViewField(list.Id, view.Id, this.Name);
            }
            if (this.ParameterSetName == "All")
            {
                viewService.RemoveAllViewFields(list.Id, view.Id);
            }
        }

    }

}
