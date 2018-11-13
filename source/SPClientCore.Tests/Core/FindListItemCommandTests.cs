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
    public class FindListItemCommandTests
    {

        [TestMethod()]
        public void SkipAndTakeListItems()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<ListItem>(
                    "Find-SPListItem",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "OrderBy", "Id desc" },
                        { "Top", 2 },
                        { "Skip", context.AppSettings["ListItem3Id"] }
                    }
                );
                var actual = result1.ToArray();
            }
        }

        [TestMethod()]
        public void FilterListItems()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<ListItem>(
                    "Find-SPListItem",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "Filter", "Id eq '" + context.AppSettings["ListItem2Id"] + "'" }
                    }
                );
                var actual = result1.ToArray();
            }
        }

    }

}
