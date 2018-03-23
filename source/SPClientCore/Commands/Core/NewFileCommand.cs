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

    [Cmdlet("New", "SPFile")]
    [OutputType(typeof(File))]
    public class NewFileCommand : PSCmdlet
    {

        public NewFileCommand()
        {
        }

        [Parameter(Mandatory = true)]
        public FolderPipeBind Folder { get; private set; }

        [Parameter(Mandatory = true)]
        public string Name { get; private set; }

        [Parameter(Mandatory = true)]
        public System.IO.Stream Content { get; private set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter Overwrite { get; private set; }

        [Parameter(Mandatory = false)]
        public string[] Includes { get; private set; }

        protected override void ProcessRecord()
        {
            if (ClientObjectService.ServiceProvider == null)
            {
                throw new InvalidOperationException(StringResources.ErrorNotConnected);
            }
            var fileService = ClientObjectService.ServiceProvider.GetService<IFileService>();
            var fileQuery = ODataQuery.Create<File>(this.MyInvocation.BoundParameters);
            var folderService = ClientObjectService.ServiceProvider.GetService<IFolderService>();
            var folder = folderService.GetFolder(this.Folder);
            this.WriteObject(fileService.CreateFile(folder.ServerRelativeUrl, this.Name, this.Content, this.Overwrite, fileQuery));
        }

    }

}
