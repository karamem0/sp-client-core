//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests
{

    [TestClass()]
    [TestCategory("Group")]
    public class GetGroupCommandTests
    {

        [TestMethod()]
        public void GetGroupByObject()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<Group>(
                    "Get-SPGroup",
                    new Dictionary<string, object>()
                    {
                        { "Group", context.AppSettings["Group1Id"] }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<Group>(
                    "Get-SPGroup",
                    new Dictionary<string, object>()
                    {
                        { "Group", result1.ElementAt(0) }
                    }
                );
                var actual = result2.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetGroupById()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<Group>(
                    "Get-SPGroup",
                    new Dictionary<string, object>()
                    {
                        { "Group", context.AppSettings["Group1Id"] }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetGroupByName()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<Group>(
                    "Get-SPGroup",
                    new Dictionary<string, object>()
                    {
                        { "Group", context.AppSettings["Group1Name"] }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

    }

}
