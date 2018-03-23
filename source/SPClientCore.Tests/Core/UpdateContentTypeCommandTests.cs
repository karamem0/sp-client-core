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
    [TestCategory("ContentType")]
    public class UpdateContentTypeCommandTests
    {

        [TestMethod()]
        public void UpdateWebContentType()
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
                var result2 = context.Runspace.InvokeCommand<ContentType>(
                    "Update-SPContentType",
                    new Dictionary<string, object>()
                    {
                        { "ContentType", result1.ElementAt(0).StringId },
                        { "Description", "Test Content Type 9 Description" },
                        { "PassThru", true }
                    }
                );
                var result3 = context.Runspace.InvokeCommand(
                    "Remove-SPContentType",
                    new Dictionary<string, object>()
                    {
                        { "ContentType", result1.ElementAt(0).StringId }
                    }
                );
                var actual = result2.ElementAt(0);
            }
        }

        [TestMethod()]
        public void UpdateListContentType()
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
                var result2 = context.Runspace.InvokeCommand<ContentType>(
                    "Update-SPContentType",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "ContentType", result1.ElementAt(0).StringId },
                        { "Description", "Test Content Type 9 Description" },
                        { "PassThru", true }
                    }
                );
                var result3 = context.Runspace.InvokeCommand(
                    "Remove-SPContentType",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "ContentType", result1.ElementAt(0).StringId }
                    }
                );
                var actual = result2.ElementAt(0);
            }
        }

    }

}
