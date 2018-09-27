//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.Core;
using Karamem0.SharePoint.PowerShell.Models.OData;
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

    [Cmdlet("Update", "SPWeb")]
    [OutputType(typeof(Web))]
    public class UpdateWebCommand : PSCmdlet
    {

        public UpdateWebCommand()
        {
        }

        [Parameter(Mandatory = false)]
        public string AlternateCssUrl { get; private set; }

        [Parameter(Mandatory = false)]
        public Group AssociatedMemberGroup { get; private set; }

        [Parameter(Mandatory = false)]
        public Group AssociatedOwnerGroup { get; private set; }

        [Parameter(Mandatory = false)]
        public Group AssociatedVisitorGroup { get; private set; }

        [Parameter(Mandatory = false)]
        public string CustomMasterUrl { get; private set; }

        [Parameter(Mandatory = false)]
        public string Description { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? EnableMinimalDownload { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? FooterEnabled { get; private set; }

        [Parameter(Mandatory = false)]
        public VariantThemeType? HeaderEmphasis { get; private set; }

        [Parameter(Mandatory = false)]
        public HeaderLayoutType? HeaderLayout { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? HideSiteLogo { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? HideSiteTitle { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? HorizontalQuickLaunch { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? MegaMenuEnabled { get; private set; }

        [Parameter(Mandatory = false)]
        public string MasterUrl { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? NoCrawl { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? ObjectCacheEnabled { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? OverwriteTranslationsOnChange { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? QuickLaunchEnabled { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? SaveSiteAsTemplateEnabled { get; private set; }

        [Parameter(Mandatory = false)]
        public string ServerRelativeUrl { get; private set; }

        [Parameter(Mandatory = false)]
        public string SiteLogoUrl { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? SyndicationEnabled { get; private set; }

        [Parameter(Mandatory = false)]
        public string Title { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? TreeViewEnabled { get; private set; }

        [Parameter(Mandatory = false)]
        public int? UIVersion { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? UIVersionConfigurationEnabled { get; private set; }

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
            var webService = ClientObjectService.ServiceProvider.GetService<IWebService>();
            var webQuery = ODataQuery.Create<Web>(this.MyInvocation.BoundParameters);
            webService.UpdateWeb(this.MyInvocation.BoundParameters);
            if (this.PassThru)
            {
                this.WriteObject(webService.GetWeb(null, webQuery));
            }
        }

    }

}
