//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Test.Utility;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands.Test;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class SetTenantFileVersionPolicyForDocumentLibraryCommandTests
{

    [Test()]
    public void InvokeCommand_SetItemByListId_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["AdminUrl"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKeyPath"] = context.AppSettings["PrivateKeyPath"]
            }
        );
        var result1 = context.Runspace.InvokeCommand<FileVersionPolicyForDocumentLibrary>(
            "Set-KshTenantFileVersionPolicyForDocumentLibrary",
            new Dictionary<string, object>()
            {
                ["SiteUrl"] = context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"],
                ["ListId"] = context.AppSettings["List2Id"],
                ["IsAutoTrimEnabled"] = false,
                ["MajorVersionLimit"] = 500,
                ["ExpireVersionsAfterDays"] = 0,
                ["PassThru"] = true
            }
        );
        var actual = result1[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_SetItemByListTitle_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["AdminUrl"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKeyPath"] = context.AppSettings["PrivateKeyPath"]
            }
        );
        var result1 = context.Runspace.InvokeCommand<FileVersionPolicyForDocumentLibrary>(
            "Set-KshTenantFileVersionPolicyForDocumentLibrary",
            new Dictionary<string, object>()
            {
                ["SiteUrl"] = context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"],
                ["ListTitle"] = context.AppSettings["List2Title"],
                ["IsAutoTrimEnabled"] = false,
                ["MajorVersionLimit"] = 500,
                ["ExpireVersionsAfterDays"] = 0,
                ["PassThru"] = true
            }
        );
        var actual = result1[0];
        Assert.That(actual, Is.Not.Null);
    }

}
