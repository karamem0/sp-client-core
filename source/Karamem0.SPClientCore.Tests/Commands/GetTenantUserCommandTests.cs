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

namespace Karamem0.SharePoint.PowerShell.Tests.Commands;

[TestClass()]
public class GetTenantUserCommandTests
{

    [TestMethod()]
    public void GetUserBySiteCollectionAndUserId()
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
            "Get-KshTenantSiteCollection",
            new Dictionary<string, object>()
            {
                { "SiteCollectionUrl", context.AppSettings["BaseUrl"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<User>(
            "Get-KshTenantUser",
            new Dictionary<string, object>()
            {
                { "SiteCollection", result2.ElementAt(0) },
                { "UserId", context.AppSettings["User1Id"] }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.IsNotNull(actual);
    }

    [TestMethod()]
    public void GetUserBySiteCollectionUrlAndUserId()
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
        var result2 = context.Runspace.InvokeCommand<User>(
            "Get-KshTenantUser",
            new Dictionary<string, object>()
            {
                { "SiteCollectionUrl", context.AppSettings["BaseUrl"] },
                { "UserId", context.AppSettings["User1Id"] }
            }
        );
        var actual = result2.ElementAt(0);
        Assert.IsNotNull(actual);
    }

    [TestMethod()]
    public void GetUserBySiteCollectionAndUserLoginName()
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
            "Get-KshTenantSiteCollection",
            new Dictionary<string, object>()
            {
                { "SiteCollectionUrl", context.AppSettings["BaseUrl"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<User>(
            "Get-KshTenantUser",
            new Dictionary<string, object>()
            {
                { "SiteCollection", result2.ElementAt(0) },
                { "UserName", context.AppSettings["User1LoginName"] }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.IsNotNull(actual);
    }

    [TestMethod()]
    public void GetUserBySiteCollectionUrlAndUserLoginName()
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
        var result2 = context.Runspace.InvokeCommand<User>(
            "Get-KshTenantUser",
            new Dictionary<string, object>()
            {
                { "SiteCollectionUrl", context.AppSettings["BaseUrl"] },
                { "UserName", context.AppSettings["User1LoginName"] }
            }
        );
        var actual = result2.ElementAt(0);
        Assert.IsNotNull(actual);
    }

    [TestMethod()]
    public void GetUserBySiteCollectionAndUserEmail()
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
            "Get-KshTenantSiteCollection",
            new Dictionary<string, object>()
            {
                { "SiteCollectionUrl", context.AppSettings["BaseUrl"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<User>(
            "Get-KshTenantUser",
            new Dictionary<string, object>()
            {
                { "SiteCollection", result2.ElementAt(0) },
                { "UserName", context.AppSettings["User1Email"] }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.IsNotNull(actual);
    }

    [TestMethod()]
    public void GetUserBySiteCollectionUrlAndUserEmail()
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
        var result2 = context.Runspace.InvokeCommand<User>(
            "Get-KshTenantUser",
            new Dictionary<string, object>()
            {
                { "SiteCollectionUrl", context.AppSettings["BaseUrl"] },
                { "UserName", context.AppSettings["User1Email"] }
            }
        );
        var actual = result2.ElementAt(0);
        Assert.IsNotNull(actual);
    }

    [TestMethod()]
    public void GetUsersBySiteCollection()
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
            "Get-KshTenantSiteCollection",
            new Dictionary<string, object>()
            {
                { "SiteCollectionUrl", context.AppSettings["BaseUrl"] }
            }
        );
        var result3 = context.Runspace.InvokeCommand<User>(
            "Get-KshTenantUser",
            new Dictionary<string, object>()
            {
                { "SiteCollection", result2.ElementAt(0) }
            }
        );
        var actual = result3.ToArray();
        Assert.IsNotNull(actual);
    }

    [TestMethod()]
    public void GetUsersBySiteCollectionUrl()
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
        var result2 = context.Runspace.InvokeCommand<User>(
            "Get-KshTenantUser",
            new Dictionary<string, object>()
            {
                { "SiteCollectionUrl", context.AppSettings["BaseUrl"] }
            }
        );
        var actual = result2.ToArray();
        Assert.IsNotNull(actual);
    }

}
