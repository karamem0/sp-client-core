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

public class AddDocumentSetAllowedContentTypeCommandTests
{

    [Test()]
    public void AddDocumentSetAllowedContentType()
    {
        using var context = new PSCmdletContext();
        var result1 = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["BaseUrl"] },
                { "Credential", PSCredentialFactory.CreateCredential(
                    context.AppSettings["LoginUserName"],
                    context.AppSettings["LoginPassword"])
                }
            }
        );
        var result2 = context.Runspace.InvokeCommand<ContentType>(
            "Get-KshContentType",
            new Dictionary<string, object>()
            {
                { "ContentTypeId", "0x0120D520" }
            }
        );
        var result3 = context.Runspace.InvokeCommand<ContentType>(
            "Add-KshContentType",
            new Dictionary<string, object>()
            {
                { "ContentType", result2.ElementAt(0) },
                { "Description", "Test Content Type 0 Description" },
                { "Group", "Test Content Type 0 Group" },
                { "Name", "Test Content Type 0" }
            }
        );
        var result4 = context.Runspace.InvokeCommand<ContentType>(
            "Get-KshContentType",
            new Dictionary<string, object>()
            {
                { "ContentTypeId", "0x0101009D1CB255DA76424F860D91F20E6C4118" }
            }
        );
        var result5 = context.Runspace.InvokeCommand(
            "Add-KshDocumentSetAllowedContentType",
            new Dictionary<string, object>()
            {
                { "ContentType", result3.ElementAt(0) },
                { "AllowedContentType", result4.ElementAt(0) },
                { "PushChanges", true }
            }
        );
        var result6 = context.Runspace.InvokeCommand<ContentTypeId>(
            "Get-KshDocumentSetAllowedContentType",
            new Dictionary<string, object>()
            {
                { "ContentType", result3.ElementAt(0) }
            }
        );
        var result7 = context.Runspace.InvokeCommand(
            "Remove-KshDocumentSetAllowedContentType",
            new Dictionary<string, object>()
            {
                { "ContentType", result3.ElementAt(0) },
                { "AllowedContentType", result4.ElementAt(0) }
            }
        );
        var result8 = context.Runspace.InvokeCommand(
            "Remove-KshContentType",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) }
            }
        );
        var actual = result6.ToArray();
        Assert.That(actual, Is.Not.Null);
    }

}
