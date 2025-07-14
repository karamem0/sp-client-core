//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Add, "KshSitePage")]
[OutputType(typeof(void))]
public class AddSitePageCommand : ClientObjectCmdlet<IListService, IFolderService, ISitePageService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ParameterSetName = "ParamSet1"
    )]
    public List? List { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public string? PageName { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    public SitePageLayoutType PageLayoutType { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            _ = this.List ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.List));
            _ = this.PageName ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.PageName));
            var folderObject = this.Service2.GetObject(this.List);
            _ = folderObject ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
            this.Service3.AddObject(
                folderObject,
                this.PageName,
                this.PageLayoutType
            );
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            var listObject = this.Service1.GetObject(LibraryType.ClientRenderedSitePages);
            _ = listObject ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
            var folderObject = this.Service2.GetObject(listObject);
            _ = this.PageName ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.PageName));
            this.Service3.AddObject(
                folderObject ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull),
                this.PageName,
                this.PageLayoutType
            );
        }
    }

}
