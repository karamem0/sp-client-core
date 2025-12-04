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
using System.Management.Automation;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Set, "SitePage")]
[OutputType(typeof(void))]
public class SetSitePageCommand : ClientObjectCmdlet<ISitePageService, IListService, IFolderService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ParameterSetName = "ParamSet1"
    )]
    public List? List { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 1,
        ParameterSetName = "ParamSet1"
    )]
    [Parameter(
        Mandatory = true,
        Position = 1,
        ParameterSetName = "ParamSet2"
    )]
    public string? PageName { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    public SitePageLayoutType PageLayoutType { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    public string? Title { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            _ = this.List ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.List));
            _ = this.PageName ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.PageName));
            var folderObject = this.Service3.GetObject(this.List);
            _ = folderObject ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
            this.Service1.SetObject(
                folderObject,
                this.PageName,
                this.MyInvocation.BoundParameters
            );
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            _ = this.PageName ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.PageName));
            var listObject = this.Service2.GetObject(LibraryType.ClientRenderedSitePages);
            _ = listObject ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
            var folderObject = this.Service3.GetObject(listObject);
            _ = folderObject ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
            this.Service1.SetObject(
                folderObject,
                this.PageName,
                this.MyInvocation.BoundParameters
            );
        }
    }

}
