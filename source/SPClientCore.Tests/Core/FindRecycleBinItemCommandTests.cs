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
    [TestCategory("RecycleBinItem")]
    public class FindRecycleBinItemCommandTests
    {

        [TestMethod()]
        public void SkipAndTakeRecycleBinItems()
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
                                { "Title", "Test List Item 7" }
                            }
                        }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<ListItem>(
                    "New-SPListItem",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "FieldValue", new Dictionary<string, object>()
                            {
                                { "Title", "Test List Item 8" }
                            }
                        }
                    }
                );
                var result3 = context.Runspace.InvokeCommand<ListItem>(
                    "New-SPListItem",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "FieldValue", new Dictionary<string, object>()
                            {
                                { "Title", "Test List Item 9" }
                            }
                        }
                    }
                );
                var result4 = context.Runspace.InvokeCommand<GuidResult>(
                    "Remove-SPListItem",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "ListItem", result1.ElementAt(0).Id },
                        { "RecycleBin", true }
                    }
                );
                var result5 = context.Runspace.InvokeCommand<GuidResult>(
                    "Remove-SPListItem",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "ListItem", result2.ElementAt(0).Id },
                        { "RecycleBin", true }
                    }
                );
                var result6 = context.Runspace.InvokeCommand<GuidResult>(
                    "Remove-SPListItem",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "ListItem", result3.ElementAt(0).Id },
                        { "RecycleBin", true }
                    }
                );
                var result7 = context.Runspace.InvokeCommand<RecycleBinItem>(
                    "Find-SPRecycleBinItem",
                    new Dictionary<string, object>()
                    {
                        { "OrderBy", "Title desc" },
                        { "Top", 1 },
                        { "Skip", 1 }
                    }
                );
                var result8 = context.Runspace.InvokeCommand(
                    "Remove-SPRecycleBinItem",
                    new Dictionary<string, object>()
                    {
                        { "All", true }
                    }
                );
                var actual = result7.ToArray();
            }
        }

        [TestMethod()]
        public void FilterRecycleBinItems()
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
                                { "Title", "Test List Item 7" }
                            }
                        }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<ListItem>(
                    "New-SPListItem",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "FieldValue", new Dictionary<string, object>()
                            {
                                { "Title", "Test List Item 8" }
                            }
                        }
                    }
                );
                var result3 = context.Runspace.InvokeCommand<ListItem>(
                    "New-SPListItem",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "FieldValue", new Dictionary<string, object>()
                            {
                                { "Title", "Test List Item 9" }
                            }
                        }
                    }
                );
                var result4 = context.Runspace.InvokeCommand<GuidResult>(
                    "Remove-SPListItem",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "ListItem", result1.ElementAt(0).Id },
                        { "RecycleBin", true }
                    }
                );
                var result5 = context.Runspace.InvokeCommand<GuidResult>(
                    "Remove-SPListItem",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "ListItem", result2.ElementAt(0).Id },
                        { "RecycleBin", true }
                    }
                );
                var result6 = context.Runspace.InvokeCommand<GuidResult>(
                    "Remove-SPListItem",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "ListItem", result3.ElementAt(0).Id },
                        { "RecycleBin", true }
                    }
                );
                var result7 = context.Runspace.InvokeCommand<RecycleBinItem>(
                    "Find-SPRecycleBinItem",
                    new Dictionary<string, object>()
                    {
                        { "Filter", "Title eq '" + result2.ElementAt(0)["Title"] + "'" }
                    }
                );
                var result8 = context.Runspace.InvokeCommand(
                    "Remove-SPRecycleBinItem",
                    new Dictionary<string, object>()
                    {
                        { "All", true }
                    }
                );
                var actual = result7.ToArray();
            }
        }

    }

}
