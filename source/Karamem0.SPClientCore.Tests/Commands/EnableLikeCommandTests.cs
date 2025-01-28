//
// Copyright (c) 2018-2025 karamem0
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
public class EnableLikeCommandTests
{

    [Test()]
    public void InvokeCommand_EnableItemOfComment_ShouldSucceed()
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
                ["File"] = result1.ElementAt(0)
            }
        );
        var result3 = context.Runspace.InvokeCommand<Comment>(
            "Get-KshComment",
            new Dictionary<string, object>()
            {
                ["ListItem"] = result2.ElementAt(0),
                ["CommentId"] = context.AppSettings["Comment1Id"]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Enable-KshLike",
            new Dictionary<string, object>()
            {
                ["Comment"] = result3.ElementAt(0)
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Disable-KshLike",
            new Dictionary<string, object>()
            {
                ["Comment"] = result3.ElementAt(0)
            }
        );
    }

    [Test()]
    public void InvokeCommand_EnableItemOfListItem_ShouldSucceed()
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
                ["File"] = result1.ElementAt(0)
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Enable-KshLike",
            new Dictionary<string, object>()
            {
                ["ListItem"] = result2.ElementAt(0)
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Disable-KshLike",
            new Dictionary<string, object>()
            {
                ["ListItem"] = result2.ElementAt(0)
            }
        );
    }

}
