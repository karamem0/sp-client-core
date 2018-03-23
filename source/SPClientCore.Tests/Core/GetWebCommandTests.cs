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
    [TestCategory("Web")]
    public class GetWebCommandTests
    {

        [TestMethod()]
        public void GetCurrentWeb()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<Web>(
                    "Get-SPWeb",
                    new Dictionary<string, object>()
                    {
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetWebByObject()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<Web>(
                    "Get-SPWeb",
                    new Dictionary<string, object>()
                    {
                        { "Web", context.AppSettings["Web1Id"] }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<Web>(
                    "Get-SPWeb",
                    new Dictionary<string, object>()
                    {
                        { "Web", result1.ElementAt(0) }
                    }
                );
                var actual = result2.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetWebById()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<Web>(
                    "Get-SPWeb",
                    new Dictionary<string, object>()
                    {
                        { "Web", context.AppSettings["Web1Id"] }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetWebByUrl()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<Web>(
                    "Get-SPWeb",
                    new Dictionary<string, object>()
                    {
                        { "Web", context.AppSettings["Web1Url"] }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

    }

}
