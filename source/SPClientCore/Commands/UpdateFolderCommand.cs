//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Models.OData;
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

    [Cmdlet("Update", "SPFolder")]
    [OutputType(typeof(Folder))]
    public class UpdateFolderCommand : PSCmdlet
    {

        public UpdateFolderCommand()
        {
        }

        [Parameter(Mandatory = true)]
        public FolderPipeBind Folder { get; private set; }

        [Parameter(Mandatory = false)]
        public string WelcomePage { get; private set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; private set; }

        [Parameter(Mandatory = false)]
        public string[] Includes { get; private set; }

        protected override void ProcessRecord()
        {
            if (ClientObjectService.ServiceProvider == null)
            {
                throw new InvalidOperationException(StringResources.ErrorNotConnected);
            }
            var folderService = ClientObjectService.ServiceProvider.GetService<IFolderService>();
            var folderQuery = ODataQuery.Create<Folder>(this.MyInvocation.BoundParameters);
            var folder = folderService.GetFolder(this.Folder);
            folderService.UpdateFolder(folder.ServerRelativeUrl, this.MyInvocation.BoundParameters);
            if (this.PassThru)
            {
                this.WriteObject(folderService.GetFolder(new FolderPipeBind(folder.ServerRelativeUrl), folderQuery));
            }
        }

    }

}
