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
    public class GetRecycleBinItemCommandTests
    {

        [TestMethod()]
        public void GetRecycleBinItemByObject()
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
                var result3 = context.Runspace.InvokeCommand<RecycleBinItem>(
                    "Get-SPRecycleBinItem",
                    new Dictionary<string, object>()
                    {
                        { "RecycleBinItem", result2.ElementAt(0).Recycle }
                    }
                );
                var result4 = context.Runspace.InvokeCommand<RecycleBinItem>(
                    "Get-SPRecycleBinItem",
                    new Dictionary<string, object>()
                    {
                        { "RecycleBinItem", result3.ElementAt(0) }
                    }
                );
                var result5 = context.Runspace.InvokeCommand(
                    "Remove-SPRecycleBinItem",
                    new Dictionary<string, object>()
                    {
                        { "RecycleBinItem", result3.ElementAt(0).Id }
                    }
                );
                var actual = result4.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetRecycleBinItemById()
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
                var result3 = context.Runspace.InvokeCommand<RecycleBinItem>(
                    "Get-SPRecycleBinItem",
                    new Dictionary<string, object>()
                    {
                        { "RecycleBinItem", result2.ElementAt(0).Recycle }
                    }
                );
                var result4 = context.Runspace.InvokeCommand(
                    "Remove-SPRecycleBinItem",
                    new Dictionary<string, object>()
                    {
                        { "RecycleBinItem", result3.ElementAt(0).Id }
                    }
                );
                var actual = result3.ElementAt(0);
            }
        }

    }

}
