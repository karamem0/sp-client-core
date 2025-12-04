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

namespace Karamem0.SharePoint.PowerShell.Commands.Test;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class SetCommentEnabledCommandTests
{

    [Test()]
    public void InvokeCommand_EnableItem_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKeyPath"] = context.AppSettings["PrivateKeyPath"]
            }
        );
        var result1 = context.Runspace.InvokeCommand<File>(
            "Get-KshFile",
            new Dictionary<string, object>()
            {
                ["FileUrl"] = context.AppSettings["SitePage1Url"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<ListItem>(
            "Get-KshListItem",
            new Dictionary<string, object>()
            {
                ["File"] = result1[0]
            }
        );
        var result3 = context.Runspace.InvokeCommand(
            "Set-KshCommentEnabled",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0],
                ["Enabled"] = true,
                ["PassThru"] = true
            }
        );
        var actual = result3[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_DisableItem_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKeyPath"] = context.AppSettings["PrivateKeyPath"]
            }
        );
        var result1 = context.Runspace.InvokeCommand<File>(
            "Get-KshFile",
            new Dictionary<string, object>()
            {
                ["FileUrl"] = context.AppSettings["SitePage1Url"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<ListItem>(
            "Get-KshListItem",
            new Dictionary<string, object>()
            {
                ["File"] = result1[0]
            }
        );
        var result3 = context.Runspace.InvokeCommand(
            "Set-KshCommentEnabled",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0],
                ["Enabled"] = false,
                ["PassThru"] = true
            }
        );
        var actual = result3[0];
        Assert.That(actual, Is.Not.Null);
    }

}
