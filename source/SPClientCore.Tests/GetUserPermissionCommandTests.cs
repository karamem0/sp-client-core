//
// Copyright (c) 2020 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Tests.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests
{

    [TestClass()]
    [TestCategory("Get-KshUserPermission")]
    public class GetUserPermissionCommandTests
    {

        [TestMethod()]
        public void GetUserPermissionBySite()
        {
            using (var context = new PSCmdletContext())
            {
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
                var result2 = context.Runspace.InvokeCommand<User>(
                    "Get-KshUser",
                    new Dictionary<string, object>()
                    {
                        { "UserId", context.AppSettings["User1Id"] }
                    }
                );
                var result3 = context.Runspace.InvokeCommand<Site>(
                    "Get-KshSite",
                    new Dictionary<string, object>()
                    {
                        { "SiteId", context.AppSettings["Site1Id"] }
                    }
                );
                var result4 = context.Runspace.InvokeCommand<BasePermission>(
                    "Get-KshUserPermission",
                    new Dictionary<string, object>()
                    {
                        { "User", result2.ElementAt(0) },
                        { "Site", result3.ElementAt(0) }
                    }
                );
                var actual = result4.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetUserPermissionByList()
        {
            using (var context = new PSCmdletContext())
            {
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
                var result2 = context.Runspace.InvokeCommand<User>(
                    "Get-KshUser",
                    new Dictionary<string, object>()
                    {
                        { "UserId", context.AppSettings["User1Id"] }
                    }
                );
                var result3 = context.Runspace.InvokeCommand<List>(
                    "Get-KshList",
                    new Dictionary<string, object>()
                    {
                        { "ListId", context.AppSettings["List1Id"] }
                    }
                );
                var result4 = context.Runspace.InvokeCommand<BasePermission>(
                    "Get-KshUserPermission",
                    new Dictionary<string, object>()
                    {
                        { "User", result2.ElementAt(0) },
                        { "List", result3.ElementAt(0) }
                    }
                );
                var actual = result4.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetUserPermissionByListItem()
        {
            using (var context = new PSCmdletContext())
            {
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
                var result2 = context.Runspace.InvokeCommand<User>(
                    "Get-KshUser",
                    new Dictionary<string, object>()
                    {
                        { "UserId", context.AppSettings["User1Id"] }
                    }
                );
                var result3 = context.Runspace.InvokeCommand<List>(
                    "Get-KshList",
                    new Dictionary<string, object>()
                    {
                        { "ListId", context.AppSettings["List1Id"] }
                    }
                );
                var result4 = context.Runspace.InvokeCommand<ListItem>(
                    "Get-KshListItem",
                    new Dictionary<string, object>()
                    {
                        { "List", result3.ElementAt(0) },
                        { "ItemId", context.AppSettings["ListItem1Id"] }
                    }
                );
                var result5 = context.Runspace.InvokeCommand<BasePermission>(
                    "Get-KshUserPermission",
                    new Dictionary<string, object>()
                    {
                        { "User", result2.ElementAt(0) },
                        { "ListItem", result4.ElementAt(0) }
                    }
                );
                var actual = result5.ElementAt(0);
            }
        }

    }

}
