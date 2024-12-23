//
// Copyright (c) 2018-2024 karamem0
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

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Get, "KshTenantFileVersionPolicyForDocumentLibrary")]
[OutputType(typeof(FileVersionPolicyForDocumentLibrary))]
public class GetTenantFileVersionPolicyForDocumentLibraryCommand : ClientObjectCmdlet<ITenantFileVersionPolicyForDocumentLibraryService>
{

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public Uri SiteUrl { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    public Guid ListId { get; set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public string ListTitle { get; set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            this.Outputs.Add(this.Service.GetObject(this.SiteUrl, this.ListId));
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            this.Outputs.Add(this.Service.GetObject(this.SiteUrl, this.ListTitle));
        }
    }

}
