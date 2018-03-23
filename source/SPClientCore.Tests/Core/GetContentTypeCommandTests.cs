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
    public class GetContentTypeCommandTests
    {

        [TestMethod()]
        public void GetWebContentTypeByObject()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<ContentType>(
                    "Get-SPContentType",
                    new Dictionary<string, object>()
                    {
                        { "ContentType", context.AppSettings["WebContentType1Id"] }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<ContentType>(
                    "Get-SPContentType",
                    new Dictionary<string, object>()
                    {
                        { "ContentType", result1.ElementAt(0) }
                    }
                );
                var actual = result2.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetWebContentTypeById()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<ContentType>(
                    "Get-SPContentType",
                    new Dictionary<string, object>()
                    {
                        { "ContentType", context.AppSettings["WebContentType1Id"] }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetListContentTypeByObject()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<ContentType>(
                    "Get-SPContentType",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "ContentType", context.AppSettings["ListContentType1Id"] }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<ContentType>(
                    "Get-SPContentType",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "ContentType", result1.ElementAt(0) }
                    }
                );
                var actual = result2.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetListContentTypeById()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<ContentType>(
                    "Get-SPContentType",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "ContentType", context.AppSettings["ListContentType1Id"] }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

    }

}
