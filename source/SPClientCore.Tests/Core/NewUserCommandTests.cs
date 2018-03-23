//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.Core;
using Karamem0.SharePoint.PowerShell.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Core.Tests
{

    [TestClass()]
    [TestCategory("User")]
    public class NewUserCommandTests
    {

        [TestMethod()]
        public void CreateWebUser()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<User>(
                    "New-SPUser",
                    new Dictionary<string, object>()
                    {
                        { "Email", context.GetUserEmail("testuser0") },
                        { "LoginName", context.GetUserLoginName("testuser0") },
                        { "IsSiteAdmin", true },
                        { "Title", "Test User 0" }
                    }
                );
                var result2 = context.Runspace.InvokeCommand(
                    "Remove-SPUser",
                    new Dictionary<string, object>()
                    {
                        { "User", result1.ElementAt(0).Id }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

        [TestMethod()]
        public void CreateGroupUser()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<User>(
                    "New-SPUser",
                    new Dictionary<string, object>()
                    {
                        { "Group", context.AppSettings["Group1Id"] },
                        { "Email", context.GetUserEmail("testuser0") },
                        { "LoginName", context.GetUserLoginName("testuser0") },
                        { "IsSiteAdmin", true },
                        { "Title", "Test User 0" }
                    }
                );
                var result2 = context.Runspace.InvokeCommand(
                    "Remove-SPUser",
                    new Dictionary<string, object>()
                    {
                        { "Group", context.AppSettings["Group1Id"] },
                        { "User", result1.ElementAt(0).Id }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

    }

}
