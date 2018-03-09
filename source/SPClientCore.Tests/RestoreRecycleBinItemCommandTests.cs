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
    [TestCategory("RecycleBinItem")]
    public class RestoreRecycleBinItemCommandTests
    {

        [TestMethod()]
        public void RestoreRecycleBinItem()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<ListItem>(
                    "New-SPListItem",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "FieldValue", new Dictionary<string, object>()
                            {
                                { "Title", "Test List Item 0" }
                            }
                        }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<GuidResult>(
                    "Remove-SPListItem",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "ListItem", result1.ElementAt(0).Id },
                        { "RecycleBin", true }
                    }
                );
                var result3 = context.Runspace.InvokeCommand(
                    "Restore-SPRecycleBinItem",
                    new Dictionary<string, object>()
                    {
                        { "RecycleBinItem", result2.ElementAt(0).Recycle }
                    }
                );
                var result4 = context.Runspace.InvokeCommand(
                    "Remove-SPListItem",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "ListItem", result1.ElementAt(0).Id }
                    }
                );
            }
        }

        [TestMethod()]
        public void RestoreAllRecycleBinItems()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<ListItem>(
                    "New-SPListItem",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "FieldValue", new Dictionary<string, object>()
                            {
                                { "Title", "Test List Item 0" }
                            }
                        }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<GuidResult>(
                    "Remove-SPListItem",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "ListItem", result1.ElementAt(0).Id },
                        { "RecycleBin", true }
                    }
                );
                var result3 = context.Runspace.InvokeCommand(
                    "Restore-SPRecycleBinItem",
                    new Dictionary<string, object>()
                    {
                        { "All", true }
                    }
                );
                var result4 = context.Runspace.InvokeCommand(
                    "Remove-SPListItem",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "ListItem", result1.ElementAt(0).Id }
                    }
                );
            }
        }

    }

}
