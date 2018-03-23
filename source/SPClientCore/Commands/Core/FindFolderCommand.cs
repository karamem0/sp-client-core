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

    [Cmdlet("Find", "SPFolder")]
    [OutputType(typeof(Folder[]))]
    public class FindFolderCommand : PSCmdlet
    {

        public FindFolderCommand()
        {
        }

        [Parameter(Mandatory = true)]
        public FolderPipeBind Folder { get; private set; }

        [Parameter(Mandatory = false)]
        public string[] Includes { get; private set; }

        [Parameter(Mandatory = false)]
        public string[] OrderBy { get; private set; }

        [Parameter(Mandatory = false)]
        public int? Top { get; private set; }

        [Parameter(Mandatory = false)]
        public int? Skip { get; private set; }

        protected override void ProcessRecord()
        {
            if (ClientObjectService.ServiceProvider == null)
            {
                throw new InvalidOperationException(StringResources.ErrorNotConnected);
            }
            var folderService = ClientObjectService.ServiceProvider.GetService<IFolderService>();
            var folderQuery = ODataQuery.Create<Folder>(this.MyInvocation.BoundParameters);
            var folder = folderService.GetFolder(this.Folder);
            this.WriteObject(folderService.FindFolders(folder.ServerRelativeUrl, folderQuery), true);
        }

    }

}
