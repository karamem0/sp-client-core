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
    [TestCategory("ListItem")]
    public class GetListItemCommandTests
    {

        [TestMethod()]
        public void GetListItemByObject()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<ListItem>(
                    "Get-SPListItem",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "ListItem", context.AppSettings["ListItem1Id"] }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<ListItem>(
                    "Get-SPListItem",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "ListItem", result1.ElementAt(0) }
                    }
                );
                var actual = result2.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetListItemById()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<ListItem>(
                    "Get-SPListItem",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "ListItem", context.AppSettings["ListItem1Id"] }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

    }

}
