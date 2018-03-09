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
    [TestCategory("List")]
    public class GetListCommandTests
    {

        [TestMethod()]
        public void GetListByObject()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<List>(
                    "Get-SPList",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<List>(
                    "Get-SPList",
                    new Dictionary<string, object>()
                    {
                        { "List", result1.ElementAt(0) }
                    }
                );
                var actual = result2.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetListById()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<List>(
                    "Get-SPList",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetListByTitle()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<List>(
                    "Get-SPList",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Title"] }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

    }

}
