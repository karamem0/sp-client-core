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
    public class RemoveListCommandTests
    {

        [TestMethod()]
        public void RemoveList()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<List>(
                    "New-SPList",
                    new Dictionary<string, object>()
                    {
                        { "BaseTemplate", 100 },
                        { "Title", "TestList0" }
                    }
                );
                var result2 = context.Runspace.InvokeCommand(
                    "Remove-SPList",
                    new Dictionary<string, object>()
                    {
                        { "List", result1.ElementAt(0).Id }
                    }
                );
            }
        }

        [TestMethod()]
        public void RecycleList()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<List>(
                    "New-SPList",
                    new Dictionary<string, object>()
                    {
                        { "BaseTemplate", 100 },
                        { "Title", "TestList0" }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<GuidResult>(
                    "Remove-SPList",
                    new Dictionary<string, object>()
                    {
                        { "List", result1.ElementAt(0).Id },
                        { "RecycleBin", true }
                    }
                );
                var result3 = context.Runspace.InvokeCommand(
                    "Remove-SPRecycleBinItem",
                    new Dictionary<string, object>()
                    {
                        { "RecycleBinItem", result2.ElementAt(0).Recycle }
                    }
                );
            }
        }

    }

}
