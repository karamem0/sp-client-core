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
    public class GetUserCommandTests
    {

        [TestMethod()]
        public void GetWebUserByObject()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<User>(
                    "Get-SPUser",
                    new Dictionary<string, object>()
                    {
                        { "User", context.AppSettings["User1Id"] }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<User>(
                    "Get-SPUser",
                    new Dictionary<string, object>()
                    {
                        { "User", result1.ElementAt(0) }
                    }
                );
                var actual = result2.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetWebUserById()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<User>(
                    "Get-SPUser",
                    new Dictionary<string, object>()
                    {
                        { "User", context.AppSettings["User1Id"] }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetWebUserByLoginName()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<User>(
                    "Get-SPUser",
                    new Dictionary<string, object>()
                    {
                        { "User", context.AppSettings["User1LoginName"] }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetWebUserByEmail()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<User>(
                    "Get-SPUser",
                    new Dictionary<string, object>()
                    {
                        { "User", context.AppSettings["User1Email"] }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetGroupUserByObject()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<User>(
                    "Get-SPUser",
                    new Dictionary<string, object>()
                    {
                        { "Group", context.AppSettings["Group1Id"] },
                        { "User", context.AppSettings["User1Id"] }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<User>(
                    "Get-SPUser",
                    new Dictionary<string, object>()
                    {
                        { "Group", context.AppSettings["Group1Id"] },
                        { "User", result1.ElementAt(0) }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetGroupUserById()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<User>(
                    "Get-SPUser",
                    new Dictionary<string, object>()
                    {
                        { "Group", context.AppSettings["Group1Id"] },
                        { "User", context.AppSettings["User1Id"] }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetGroupUserByLoginName()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<User>(
                    "Get-SPUser",
                    new Dictionary<string, object>()
                    {
                        { "Group", context.AppSettings["Group1Id"] },
                        { "User", context.AppSettings["User1LoginName"] }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetGroupUserByEmail()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<User>(
                    "Get-SPUser",
                    new Dictionary<string, object>()
                    {
                        { "Group", context.AppSettings["Group1Id"] },
                        { "User", context.AppSettings["User1Email"] }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

    }

}
