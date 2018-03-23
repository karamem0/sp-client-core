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
    public class NewListItemCommandTests
    {

        [TestMethod()]
        public void CreateListItem()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<ListItem>(
                    "Get-SPListitem",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "ListItem", context.AppSettings["ListItem1Id"] }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<User>(
                    "Get-SPUser",
                    new Dictionary<string, object>()
                    {
                        { "User", context.AppSettings["User1Id"] },
                    }
                );
                var result3 = context.Runspace.InvokeCommand<ListItem>(
                    "New-SPListitem",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "FieldValue", new Dictionary<string, object>()
                            {
                                { "Title", "Test List Item 0" },
                                { "TestField1", "Test Value 0" },
                                { "TestField2", "Test Value 0" },
                                { "TestField3", "Test Value 0" },
                                // { "TestField4", new[] { "Test Value 0" } },
                                { "TestField5", 0 },
                                { "TestField6", 0 },
                                { "TestField7", new DateTime(2010, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                                { "TestField8Id", result1.ElementAt(0).Id },
                                // { "TestField9Id", new[] { result1.ElementAt(0).Id } },
                                { "TestField10", true },
                                { "TestField11Id", result2.ElementAt(0).Id },
                                // { "TestField12Id", new[] { result2.ElementAt(0).Id } },
                                { "TestField13", new FieldUrlValue("http://www.example.com", "Test Value 0") }
                            }
                        }
                    }
                );
                var result4 = context.Runspace.InvokeCommand(
                    "Remove-SPListItem",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "ListItem", result3.ElementAt(0).Id }
                    }
                );
                var actual = result3.ElementAt(0);
            }
        }

    }

}
