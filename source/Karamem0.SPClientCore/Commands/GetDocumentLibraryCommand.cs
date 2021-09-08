//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/spclientcore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("Get", "KshDocumentLibrary")]
    [OutputType(typeof(DocumentLibraryInformation))]
    public class GetDocumentLibraryCommand : ClientObjectCmdlet<IDocumentLibraryService>
    {

        public GetDocumentLibraryCommand()
        {
        }

        [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
        public SwitchParameter Default { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
        public SwitchParameter IncludeMediaLibraries { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
        public SwitchParameter IncludePageLibraries { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
        public SwitchParameter NoEnumerate { get; private set; }

        protected override void ProcessRecordCore(ref List<object> outputs)
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                this.ValidateSwitchParameter(nameof(this.Default));
                outputs.Add(this.Service.GetObject());
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                if (this.IncludeMediaLibraries)
                {
                    if (this.NoEnumerate)
                    {
                        outputs.Add(this.Service.GetObjectEnumerable(this.IncludeMediaLibraries));
                    }
                    else
                    {
                        outputs.AddRange(this.Service.GetObjectEnumerable(this.IncludeMediaLibraries));
                    }
                }
                else
                {
                    if (this.NoEnumerate)
                    {
                        outputs.Add(this.Service.GetObjectEnumerable());
                    }
                    else
                    {
                        outputs.AddRange(this.Service.GetObjectEnumerable());
                    }
                }
            }
        }

    }

}
