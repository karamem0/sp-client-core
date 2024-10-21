//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests.Commands;

public class EnableLikeCommandTests
{

    [Test()]
    public void EnableCommentLike()
    {
        using var context = new PSCmdletContext();
        var result1 = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"] },
                { "Credential", PSCredentialFactory.CreateCredential(
                    context.AppSettings["LoginUserName"],
                    context.AppSettings["LoginPassword"])
                }
            }
        );
        var result2 = context.Runspace.InvokeCommand<File>(
            "Get-KshFile",
            new Dictionary<string, object>()
            {
                { "FileUrl", context.AppSettings["SitePage1Url"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<ListItem>(
            "Get-KshListItem",
            new Dictionary<string, object>()
            {
                { "File", result2.ElementAt(0) }
            }
        );
        var result4 = context.Runspace.InvokeCommand<Comment>(
            "Get-KshComment",
            new Dictionary<string, object>()
            {
                { "ListItem", result3.ElementAt(0) },
                { "CommentId", context.AppSettings["Comment1Id"] }
            }
        );
        var result5 = context.Runspace.InvokeCommand(
            "Enable-KshLike",
            new Dictionary<string, object>()
            {
                { "Comment", result4.ElementAt(0) }
            }
        );
        var result6 = context.Runspace.InvokeCommand(
            "Disable-KshLike",
            new Dictionary<string, object>()
            {
                { "Comment", result4.ElementAt(0) }
            }
        );
    }

    [Test()]
    public void EnableListItemLike()
    {
        using var context = new PSCmdletContext();
        var result1 = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"] },
                { "Credential", PSCredentialFactory.CreateCredential(
                    context.AppSettings["LoginUserName"],
                    context.AppSettings["LoginPassword"])
                }
            }
        );
        var result2 = context.Runspace.InvokeCommand<File>(
            "Get-KshFile",
            new Dictionary<string, object>()
            {
                { "FileUrl", context.AppSettings["SitePage1Url"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<ListItem>(
            "Get-KshListItem",
            new Dictionary<string, object>()
            {
                { "File", result2.ElementAt(0) }
            }
        );
        var result4 = context.Runspace.InvokeCommand(
            "Enable-KshLike",
            new Dictionary<string, object>()
            {
                { "ListItem", result3.ElementAt(0) }
            }
        );
        var result5 = context.Runspace.InvokeCommand(
            "Disable-KshLike",
            new Dictionary<string, object>()
            {
                { "ListItem", result3.ElementAt(0) }
            }
        );
    }

}
