//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Tests.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands.Tests;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class SetSiteCommandTests
{

    [Test()]
    public void InvokeCommand_SetItem_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["BaseUrl"] },
                { "ClientId", context.AppSettings["ClientId"] },
                { "CertificatePath", context.AppSettings["CertificatePath"] },
                { "CertificatePassword", context.AppSettings["CertificatePassword"].ToSecureString() }
            }
        );
        var result1 = context.Runspace.InvokeCommand<Site>(
            "Add-KshSite",
            new Dictionary<string, object>()
            {
                { "Description", "Test Site 0 Description" },
                { "ServerRelativeUrl", "TestSite0" },
                { "Title", "Test Site 0" }
            }
        );
        var result2 = context.Runspace.InvokeCommand<Site>(
            "Set-KshSite",
            new Dictionary<string, object>()
            {
                { "Identity", result1.ElementAt(0) },
                { "AllowAutomaticASPXPageIndexing", true },
                { "AlternateCssUrl", "style.css" },
                // { "AssociatedMemberGroup", null },
                // { "AssociatedOwnerGroup", null },
                // { "AssociatedVisitorGroup", null },
                { "CommentsOnSitePagesDisabled", true },
                { "ContainsConfidentialInfo", true },
                { "CustomMasterUrl", result1.ElementAt(0).ServerRelativeUrl + "/_catalogs/masterpage/oslo.master" },
                { "DisableAppViews", true },
                { "DisableFlows", true },
                { "Description", "Test Site 9 Description" },
                { "EnableMinimalDownload", true },
                { "ExcludeFromOfflineClient", true },
                { "FooterEnabled", true },
                { "FooterLayout", "Simple" },
                { "HeaderEmphasis", "Neutral" },
                { "HeaderLayout", "Standard" },
                { "HorizontalQuickLaunch", true },
                { "LogoAlignment", "Left" },
                // { "MasterUrl", result1.ElementAt(0).ServerRelativeUrl + "/_catalogs/masterpage/oslo.master" },
                { "MembersCanShare", true },
                { "MegaMenuEnabled", true },
                { "NavAudienceTargetingEnabled", true },
                // { "NoCrawl", true },
                { "ObjectCacheEnabled", true },
                { "QuickLaunchEnabled", true },
                { "OverwriteTranslationsOnChange", true },
                { "RequestAccessEmail", "someone@example.com" },
                // { "SaveSiteAsTemplateEnabled", true },
                { "SearchScope", "DefaultScope" },
                // { "ServerRelativeUrl", "TestSite9" },
                { "SiteLogoDescription", "Test Site 9 Description" },
                { "SiteLogoUrl", result1.ElementAt(0).ServerRelativeUrl + "/_layouts/15/images/siteicon.png" },
                { "SyndicationEnabled", true },
                { "ThemedCssFolderUrl", result1.ElementAt(0).ServerRelativeUrl + "/SiteAssets/theme.css" },
                { "Title", "Test Site 9" },
                { "TreeViewEnabled", true },
                { "UIVersion", 15 },
                { "UIVersionConfigurationEnabled", true },
                { "PassThru", true }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshSite",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) }
            }
        );
        var actual = result2.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}
