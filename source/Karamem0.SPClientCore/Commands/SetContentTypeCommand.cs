//
// Copyright (c) 2023 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("Set", "KshContentType")]
    [Alias("Update-KshContentType")]
    [OutputType(typeof(ContentType))]
    public class SetContentTypeCommand : ClientObjectCmdlet<IContentTypeService>
    {

        public SetContentTypeCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public ContentType Identity { get; private set; }

        [Parameter(Mandatory = false)]
        public string Description { get; private set; }

        [Parameter(Mandatory = false)]
        public string DisplayFormUrl { get; private set; }

        [Parameter(Mandatory = false)]
        public string EditFormUrl { get; private set; }

        [Parameter(Mandatory = false)]
        public string Group { get; private set; }

        [Parameter(Mandatory = false)]
        public string JSLink { get; private set; }

        [Parameter(Mandatory = false)]
        public bool Hidden { get; private set; }

        [Parameter(Mandatory = false)]
        public string Name { get; private set; }

        [Parameter(Mandatory = false)]
        public string NewFormUrl { get; private set; }

        [Parameter(Mandatory = false)]
        public bool ReadOnly { get; private set; }

        [Parameter(Mandatory = false)]
        public bool Sealed { get; private set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; private set; }

        protected override void ProcessRecordCore()
        {
            this.Service.SetObject(this.Identity, this.MyInvocation.BoundParameters);
            if (this.PassThru)
            {
                this.Outputs.Add(this.Service.GetObject(this.Identity));
            }
        }

    }

}
