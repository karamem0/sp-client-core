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

    [Cmdlet("Update", "SPFile")]
    [OutputType(typeof(File))]
    public class UpdateFileCommand : PSCmdlet
    {

        public UpdateFileCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public FilePipeBind File { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "CheckOut")]
        public SwitchParameter CheckOut { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "CheckIn")]
        public SwitchParameter CheckIn { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "CheckIn")]
        public string Comment { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "CheckIn")]
        public CheckInType CheckInType { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "UndoCheckOut")]
        public SwitchParameter UndoCheckOut { get; private set; }

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
            var fileService = ClientObjectService.ServiceProvider.GetService<IFileService>();
            var fileQuery = ODataQuery.Create<Folder>(this.MyInvocation.BoundParameters);
            var file = fileService.GetFile(this.File);
            if (this.ParameterSetName == "CheckOut")
            {
                fileService.CheckOutFile(file.ServerRelativeUrl);
            }
            if (this.ParameterSetName == "CheckIn")
            {
                fileService.CheckInFile(file.ServerRelativeUrl, this.Comment, (int)this.CheckInType);
            }
            if (this.ParameterSetName == "UndoCheckOut")
            {
                fileService.UndoCheckOutFile(file.ServerRelativeUrl);
            }
            if (this.PassThru)
            {
                this.WriteObject(fileService.GetFile(new FilePipeBind(file.ServerRelativeUrl), fileQuery));
            }
        }

    }

}
