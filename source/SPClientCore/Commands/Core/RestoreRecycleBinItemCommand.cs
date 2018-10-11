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

    [Cmdlet("Restore", "SPRecycleBinItem", DefaultParameterSetName = "One")]
    [OutputType(typeof(void))]
    public class RestoreRecycleBinItemCommand : ClientObjectCmdlet
    {

        public RestoreRecycleBinItemCommand()
        {
        }

        [Parameter(Mandatory = true, ParameterSetName = "One", Position = 0, ValueFromPipeline = true)]
        public RecycleBinItemPipeBind RecycleBinItem { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "All")]
        public SwitchParameter All { get; private set; }

        protected override void ProcessRecord()
        {
            if (ClientObjectService.ServiceProvider == null)
            {
                throw new InvalidOperationException(StringResources.ErrorNotConnected);
            }
            var recycleBinItemService = ClientObjectService.ServiceProvider.GetService<IRecycleBinItemService>();
            if (this.ParameterSetName == "One")
            {
                var recycleBinItem = recycleBinItemService.GetRecycleBinItem(this.RecycleBinItem);
                recycleBinItemService.RestoreRecycleBinItem(recycleBinItem.Id);
            }
            if (this.ParameterSetName == "All")
            {
                recycleBinItemService.RestoreAllRecycleBinItems();
            }
        }

    }

}
