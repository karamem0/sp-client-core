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
    [TestCategory("ContentType")]
    public class NewContentTypeCommandTests
    {

        [TestMethod()]
        public void CreateWebContentType()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<ContentType>(
                    "New-SPContentType",
                    new Dictionary<string, object>()
                    {
                        { "Description", "Test Content Type 0 Description" },
                        { "Group", "Test Content Type 0 Group" },
                        { "Name", "Test Content Type 0" }
                    }
                );
                var result2 = context.Runspace.InvokeCommand(
                    "Remove-SPContentType",
                    new Dictionary<string, object>()
                    {
                        { "ContentType", result1.ElementAt(0).StringId }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

        [TestMethod()]
        public void CreateListContentType()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<ContentType>(
                    "New-SPContentType",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "Description", "Test Content Type 0 Description" },
                        { "Group", "Test Content Type 0 Group" },
                        { "Name", "Test Content Type 0" }
                    }
                );
                var result2 = context.Runspace.InvokeCommand(
                    "Remove-SPContentType",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "ContentType", result1.ElementAt(0).StringId }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

    }

}
