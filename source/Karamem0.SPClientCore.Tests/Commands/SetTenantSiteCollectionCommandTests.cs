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
public class SetTenantSiteCollectionCommandTests
{

    [Test()]
    public void SetTenantSiteCollection()
    {
        using var context = new PSCmdletContext();
        var result1 = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["AdminUrl"] },
                { "Credential", PSCredentialFactory.CreateCredential(
                    context.AppSettings["LoginUserName"],
                    context.AppSettings["LoginPassword"])
                }
            }
        );
        var result2 = context.Runspace.InvokeCommand<TenantSiteCollection>(
            "Add-KshTenantSiteCollection",
            new Dictionary<string, object>()
            {
                { "Owner", context.AppSettings["LoginUserName"] },
                { "Template", "SITEPAGEPUBLISHING#0" },
                { "Url", context.AppSettings["AuthorityUrl"] + "/sites/TestSite0" }
            }
        );
        var result3 = context.Runspace.InvokeCommand<TenantSiteCollection>(
            "Set-KshTenantSiteCollection",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) },
                { "AllowAnonymousMeetingParticipantsToAccessWhiteboards", "Unspecified" },
                { "AllowDownloadingNonWebViewableFiles", true },
                { "AllowEditing", true },
                { "AnonymousLinkExpirationInDays", 90 },
                { "AuthenticationContextStrength", null },
                { "AuthenticationContextName", null },
                { "BlockDownloadLinksFileType", "ServerRenderedFilesOnly" },
                { "BlockDownloadMicrosoft365GroupIds", null },
                { "BlockDownloadPolicy", false },
                { "CommentsOnSitePagesDisabled", true },
                { "ConditionalAccessPolicy", "BlockAccess" },
                { "DefaultLinkPermission", "Edit" },
                { "DefaultLinkToExistingAccess", true },
                { "DefaultSharingLinkType", "None" },
                { "DenyAddAndCustomizePages", "Enabled" },
                { "DisableAppViews", "NotDisabled" },
                { "DisableCompanyWideSharingLinks", "NotDisabled" },
                { "DisableFlows", "NotDisabled" },
                { "ExcludedBlockDownloadGroupIds", null },
                { "ExternalUserExpirationInDays", 90 },
                { "LimitedAccessFileType", "OfficeOnlineFilesOnly" },
                { "MediaTranscription", "Enabled" },
                { "OverrideBlockUserInfoVisibility", "ApplyToGuestAndExternalUsers" },
                { "OverrideTenantAnonymousLinkExpirationPolicy", true },
                { "OverrideTenantExternalUserExpirationPolicy", true },
                { "Owner", context.AppSettings["User1Email"] },
                { "PWAEnabled", "Disabled" },
                { "ReadOnlyAccessPolicy", true },
                { "RestrictedAccessControl", false },
                { "ReadOnlyForUnmanagedDevices", true },
                { "RestrictedToRegion", "BlockFull" },
                { "SandboxedCodeActivationCapability", "Enabled" },
                { "SensitivityLabel", Guid.Empty },
                { "SensitivityLabel2", null },
                { "SharingAllowedDomainList", "contoso.com" },
                { "SharingBlockedDomainList", "fabricam.com" },
                { "SharingCapability", "Disabled" },
                { "SharingDomainRestrictionMode", "BlockList" },
                { "ShowPeoplePickerSuggestionsForGuestUsers", true },
                { "SocialBarOnSitePagesDisabled", true },
                { "StorageMaximumLevel", 26214400 },
                { "StorageWarningLevel", 25574400 },
                { "TimeZoneId", 20 },
                { "Title", "Test Site 9" },
                { "UserCodeMaximumLevel", 300 },
                { "UserCodeWarningLevel", 100 },
                { "PassThru", true }
            }
        );
        var result4 = context.Runspace.InvokeCommand(
            "Remove-KshTenantSiteCollection",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) }
            }
        );
        var result5 = context.Runspace.InvokeCommand<TenantDeletedSiteCollection>(
            "Get-KshTenantDeletedSiteCollection",
            new Dictionary<string, object>()
            {
                { "SiteCollectionUrl", result2.ElementAt(0).Url }
            }
        );
        var result6 = context.Runspace.InvokeCommand(
            "Remove-KshTenantDeletedSiteCollection",
            new Dictionary<string, object>()
            {
                { "Identity", result5.ElementAt(0) }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}
