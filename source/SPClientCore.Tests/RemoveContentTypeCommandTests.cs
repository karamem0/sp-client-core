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
    public class RemoveContentTypeCommandTests
    {

        [TestMethod()]
        public void RemoveWebContentType()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<ContentType>(
                    "New-SPContentType",
                    new Dictionary<string, object>()
                    {
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
            }
        }

        [TestMethod()]
        public void RemoveListContentType()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<ContentType>(
                    "New-SPContentType",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
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
            }
        }

    }

}
