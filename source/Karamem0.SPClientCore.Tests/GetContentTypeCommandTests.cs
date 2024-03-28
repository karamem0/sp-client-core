//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Tests.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests;

[TestClass()]
public class GetContentTypeCommandTests
{

    [TestMethod()]
    public void GetListContentTypes()
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
            "Get-KshContentType",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) }
            }
        );
        var actual = result3.ToArray();
        Assert.IsNotNull(actual);
    }

    [TestMethod()]
    public void GetListContentTypeByIdentity()
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
            "Get-KshContentType",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "ContentTypeId", context.AppSettings["ListContentType1Id"] }
            }
        );
        var result4 = context.Runspace.InvokeCommand<ContentType>(
            "Get-KshContentType",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) }
            }
        );
        var actual = result4.ElementAt(0);
        Assert.IsNotNull(actual);
    }

    [TestMethod()]
    public void GetListContentTypeByContentTypeId()
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
            "Get-KshContentType",
            new Dictionary<string, object>()
            {
                { "List", result2.ElementAt(0) },
                { "ContentTypeId", context.AppSettings["ListContentType1Id"] }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.IsNotNull(actual);
    }

    [TestMethod()]
    public void GetSiteContentTypes()
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
            }
        );
        var actual = result2.ToArray();
        Assert.IsNotNull(actual);
    }

    [TestMethod()]
    public void GetSiteContentTypeByIdentity()
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
            "Get-KshContentType",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.IsNotNull(actual);
    }

    [TestMethod()]
    public void GetSiteContentTypeByContentTypeId()
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
        var actual = result2.ElementAt(0);
        Assert.IsNotNull(actual);
    }

}
