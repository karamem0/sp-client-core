//
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

    [Cmdlet("Remove", "SPFolder")]
    [OutputType(typeof(GuidResult))]
    public class RemoveFolderCommand : ClientObjectCmdlet
    {

        public RemoveFolderCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public FolderPipeBind Folder { get; private set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter RecycleBin { get; private set; }

        protected override void ProcessRecord()
        {
            if (ClientObjectService.ServiceProvider == null)
            {
                throw new InvalidOperationException(StringResources.ErrorNotConnected);
            }
            var folderService = ClientObjectService.ServiceProvider.GetService<IFolderService>();
            var folder = folderService.GetFolder(this.Folder);
            if (this.RecycleBin)
            {
                this.WriteObject(folderService.RecycleFolder(folder.ServerRelativeUrl));
            }
            else
            {
                folderService.RemoveFolder(folder.ServerRelativeUrl);
            }
        }

    }

}
