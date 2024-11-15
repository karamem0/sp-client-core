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
public class RemoveAttachmentFileCommandTests
{

    [Test()]
    public void RemoveAttachmentFile()
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
        var result2 = context.Runspace.InvokeCommand<List>(
            "Get-KshList",
            new Dictionary<string, object>()
            {
                { "ListId", context.AppSettings["List1Id"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<ListItem>(
            "Get-KshListItem",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "ItemId", context.AppSettings["ListItem1Id"] }
            }
        );
        var result4 = context.Runspace.InvokeCommand<AttachmentFile>(
            "Save-KshAttachmentFile",
            new Dictionary<string, object>()
            {
                { "ListItem", result3.ElementAt(0) },
                { "Content", new System.IO.MemoryStream(Encoding.UTF8.GetBytes("TestFile0")) },
                { "FileName", "TestFile0.txt" },
                { "PassThru", true }
            }
        );
        var result5 = context.Runspace.InvokeCommand(
            "Remove-KshAttachmentFile",
            new Dictionary<string, object>()
            {
                { "Identity", result4.ElementAt(0) }
            }
        );
    }

    [Test()]
    public void MoveAttachmentFileToRecycleBin()
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
        var result2 = context.Runspace.InvokeCommand<List>(
            "Get-KshList",
            new Dictionary<string, object>()
            {
                { "ListId", context.AppSettings["List1Id"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<ListItem>(
            "Get-KshListItem",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "ItemId", context.AppSettings["ListItem1Id"] }
            }
        );
        var result4 = context.Runspace.InvokeCommand<AttachmentFile>(
            "Save-KshAttachmentFile",
            new Dictionary<string, object>()
            {
                { "ListItem", result3.ElementAt(0) },
                { "Content", new System.IO.MemoryStream(Encoding.UTF8.GetBytes("TestFile0")) },
                { "FileName", "TestFile0.txt" },
                { "PassThru", true }
            }
        );
        var result5 = context.Runspace.InvokeCommand(
            "Remove-KshAttachmentFile",
            new Dictionary<string, object>()
            {
                { "Identity", result4.ElementAt(0) },
                { "RecycleBin", true }
            }
        );
        var result6 = context.Runspace.InvokeCommand(
            "Remove-KshRecycleBinItem",
            new Dictionary<string, object>()
            {
                { "All", true }
            }
        );
    }

}
