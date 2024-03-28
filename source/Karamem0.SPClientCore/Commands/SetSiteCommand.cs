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

[Cmdlet(VerbsCommon.Set, "KshSite")]
[OutputType(typeof(Site))]
public class SetSiteCommand : ClientObjectCmdlet<ISiteService>
{

    public SetSiteCommand()
    {
    }

    [Parameter(Mandatory = false, Position = 0, ValueFromPipeline = true)]
    public Site Identity { get; private set; }

    [Parameter(Mandatory = false)]
    public bool AllowAutomaticASPXPageIndexing { get; private set; }

    [Parameter(Mandatory = false)]
    public string AlternateCssUrl { get; private set; }

    // [Parameter(Mandatory = false)]
    // public Group AssociatedMemberGroup { get; private set; }

    // [Parameter(Mandatory = false)]
    // public Group AssociatedOwnerGroup { get; private set; }

    // [Parameter(Mandatory = false)]
    // public Group AssociatedVisitorGroup { get; private set; }

    [Parameter(Mandatory = false)]
    public bool CommentsOnSitePagesDisabled { get; private set; }

    [Parameter(Mandatory = false)]
    public bool ContainsConfidentialInfo { get; private set; }

    [Parameter(Mandatory = false)]
    public string CustomMasterUrl { get; private set; }

    [Parameter(Mandatory = false)]
    public bool DisableAppViews { get; private set; }

    [Parameter(Mandatory = false)]
    public bool DisableFlows { get; private set; }

    [Parameter(Mandatory = false)]
    public string Description { get; private set; }

    [Parameter(Mandatory = false)]
    public bool EnableMinimalDownload { get; private set; }

    [Parameter(Mandatory = false)]
    public bool ExcludeFromOfflineClient { get; private set; }

    [Parameter(Mandatory = false)]
    public bool FooterEnabled { get; private set; }

    [Parameter(Mandatory = false)]
    public FooterLayoutType FooterLayout { get; private set; }

    [Parameter(Mandatory = false)]
    public VariantThemeType HeaderEmphasis { get; private set; }

    [Parameter(Mandatory = false)]
    public HeaderLayoutType HeaderLayout { get; private set; }

    [Parameter(Mandatory = false)]
    public bool HorizontalQuickLaunch { get; private set; }

    [Parameter(Mandatory = false)]
    public LogoAlignment LogoAlignment { get; private set; }

    [Parameter(Mandatory = false)]
    public string MasterUrl { get; private set; }

    [Parameter(Mandatory = false)]
    public bool MembersCanShare { get; private set; }

    [Parameter(Mandatory = false)]
    public bool MegaMenuEnabled { get; private set; }

    [Parameter(Mandatory = false)]
    public bool NavAudienceTargetingEnabled { get; private set; }

    [Parameter(Mandatory = false)]
    public bool NoCrawl { get; private set; }

    [Parameter(Mandatory = false)]
    public bool ObjectCacheEnabled { get; private set; }

    [Parameter(Mandatory = false)]
    public bool OverwriteTranslationsOnChange { get; private set; }

    [Parameter(Mandatory = false)]
    public bool QuickLaunchEnabled { get; private set; }

    [Parameter(Mandatory = false)]
    public string RequestAccessEmail { get; private set; }

    [Parameter(Mandatory = false)]
    public bool SaveSiteAsTemplateEnabled { get; private set; }

    [Parameter(Mandatory = false)]
    public SearchScopeType SearchScope { get; private set; }

    [Parameter(Mandatory = false)]
    public string ServerRelativeUrl { get; private set; }

    [Parameter(Mandatory = false)]
    public string SiteLogoDescription { get; private set; }

    [Parameter(Mandatory = false)]
    public string SiteLogoUrl { get; private set; }

    [Parameter(Mandatory = false)]
    public bool SyndicationEnabled { get; private set; }

    [Parameter(Mandatory = false)]
    public string ThemedCssFolderUrl { get; private set; }

    [Parameter(Mandatory = false)]
    public string Title { get; private set; }

    [Parameter(Mandatory = false)]
    public bool TreeViewEnabled { get; private set; }

    [Parameter(Mandatory = false)]
    public int UIVersion { get; private set; }

    [Parameter(Mandatory = false)]
    public bool UIVersionConfigurationEnabled { get; private set; }

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
