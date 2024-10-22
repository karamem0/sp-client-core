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

public class AddContentTypeCommandTests
{

    [Test()]
    public void AddListContentTypeByContentType()
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
        var result3 = context.Runspace.InvokeCommand<ContentType>(
            "Add-KshContentType",
            new Dictionary<string, object>()
            {
                { "Description", "Test Content Type 0 Description" },
                { "Group", "Test Content Type 0 Group" },
                { "Name", "Test Content Type 0" }
            }
        );
        var result4 = context.Runspace.InvokeCommand<ContentType>(
            "Add-KshContentType",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "ContentType", result3.ElementAt(0) }
            }
        );
        var result5 = context.Runspace.InvokeCommand(
            "Remove-KshContentType",
            new Dictionary<string, object>()
            {
                { "Identity", result4.ElementAt(0) }
            }
        );
        var result6 = context.Runspace.InvokeCommand(
            "Remove-KshContentType",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) }
            }
        );
        var actual = result4.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void AddListContentTypeByParam()
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
        var result3 = context.Runspace.InvokeCommand<ContentType>(
            "Add-KshContentType",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "Description", "Test Content Type 0 Description" },
                { "Group", "Test Content Type 0 Group" },
                { "Name", "Test Content Type 0" }
            }
        );
        var result4 = context.Runspace.InvokeCommand(
            "Remove-KshContentType",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void AddSiteContentTypeByParam()
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
        var result2 = context.Runspace.InvokeCommand<ContentType>(
            "Get-KshContentType",
            new Dictionary<string, object>()
            {
                { "ContentTypeId", context.AppSettings["SiteContentType1Id"] }
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
        var result4 = context.Runspace.InvokeCommand(
            "Remove-KshContentType",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}
