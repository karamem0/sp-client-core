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
public class GetContentTypeColumnCommandTests
{

    [Test()]
    public void GetListContentTypeColumns()
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
        var result4 = context.Runspace.InvokeCommand<ContentTypeColumn>(
            "Get-KshContentTypeColumn",
            new Dictionary<string, object>()
            {
                { "ContentType", result3.ElementAt(0) }
            }
        );
        var actual = result4.ToArray();
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void GetListContentTypeColumnByIdentity()
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
        var result4 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                { "ContentType", result3.ElementAt(0) },
                { "ColumnId", context.AppSettings["Column1Id"] }
            }
        );
        var result5 = context.Runspace.InvokeCommand<ContentTypeColumn>(
            "Get-KshContentTypeColumn",
            new Dictionary<string, object>()
            {
                { "ContentType", result3.ElementAt(0) },
                { "Column", result4.ElementAt(0) }
            }
        );
        var result6 = context.Runspace.InvokeCommand<ContentTypeColumn>(
            "Get-KshContentTypeColumn",
            new Dictionary<string, object>()
            {
                { "Identity", result5.ElementAt(0) }
            }
        );
        var actual = result6.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void GetListContentTypeColumnByColumn()
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
        var result4 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                { "ContentType", result3.ElementAt(0) },
                { "ColumnId", context.AppSettings["Column1Id"] }
            }
        );
        var result5 = context.Runspace.InvokeCommand<ContentTypeColumn>(
            "Get-KshContentTypeColumn",
            new Dictionary<string, object>()
            {
                { "ContentType", result3.ElementAt(0) },
                { "Column", result4.ElementAt(0) }
            }
        );
        var actual = result5.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void GetSiteContentTypeColumns()
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
        var result3 = context.Runspace.InvokeCommand<ContentTypeColumn>(
            "Get-KshContentTypeColumn",
            new Dictionary<string, object>()
            {
                { "ContentType", result2.ElementAt(0) }
            }
        );
        var actual = result3.ToArray();
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void GetSiteContentTypeColumnByIdentity()
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
        var result3 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                { "ContentType", result2.ElementAt(0) },
                { "ColumnId", context.AppSettings["Column1Id"] }
            }
        );
        var result4 = context.Runspace.InvokeCommand<ContentTypeColumn>(
            "Get-KshContentTypeColumn",
            new Dictionary<string, object>()
            {
                { "ContentType", result2.ElementAt(0) },
                { "Column", result3.ElementAt(0) }
            }
        );
        var result5 = context.Runspace.InvokeCommand<ContentTypeColumn>(
            "Get-KshContentTypeColumn",
            new Dictionary<string, object>()
            {
                { "Identity", result4.ElementAt(0) }
            }
        );
        var actual = result5.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void GetSiteContentTypeColumnByColumn()
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
        var result3 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                { "ContentType", result2.ElementAt(0) },
                { "ColumnId", context.AppSettings["Column1Id"] }
            }
        );
        var result4 = context.Runspace.InvokeCommand<ContentTypeColumn>(
            "Get-KshContentTypeColumn",
            new Dictionary<string, object>()
            {
                { "ContentType", result2.ElementAt(0) },
                { "Column", result3.ElementAt(0) }
            }
        );
        var actual = result4.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}
