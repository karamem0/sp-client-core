// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.Core;
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

    [Cmdlet("Remove", "SPList")]
    [OutputType(typeof(GuidResult))]
    public class RemoveListCommand : PSCmdlet
    {

        public RemoveListCommand()
        {
        }

        [Parameter(Mandatory = false)]
        public ListPipeBind List { get; private set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter RecycleBin { get; private set; }

        protected override void ProcessRecord()
        {
            if (ClientObjectService.ServiceProvider == null)
            {
                throw new InvalidOperationException(StringResources.ErrorNotConnected);
            }
            var listService = ClientObjectService.ServiceProvider.GetService<IListService>();
            var list = listService.GetList(this.List);
            if (this.RecycleBin)
            {
                this.WriteObject(listService.RecycleList(list.Id));
            }
            else
            {
                listService.RemoveList(list.Id);
            }
        }

    }

}
