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
    public class FindContentTypeCommandTests
    {

        [TestMethod()]
        public void SkipAndTakeWebContentTypes()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<ContentType>(
                    "Find-SPContentType",
                    new Dictionary<string, object>()
                    {
                        { "OrderBy", "Name desc" },
                        { "Top", 1 },
                        { "Skip", 1 }
                    }
                );
                var actual = result1.ToArray();
            }
        }

        [TestMethod()]
        public void SkipAndTakeListContentTypes()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<ContentType>(
                    "Find-SPContentType",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "OrderBy", "Name desc" },
                        { "Top", 1 },
                        { "Skip", 1 }
                    }
                );
                var actual = result1.ToArray();
            }
        }

        [TestMethod()]
        public void FilterWebContentTypes()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<ContentType>(
                    "Find-SPContentType",
                    new Dictionary<string, object>()
                    {
                        { "Filter", "Name eq '" + context.AppSettings["WebContentType2Name"] + "'" }
                    }
                );
                var actual = result1.ToArray();
            }
        }

        [TestMethod()]
        public void FilterListContentTypes()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<ContentType>(
                    "Find-SPContentType",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "Filter", "Name eq '" + context.AppSettings["ListContentType2Name"] + "'" }
                    }
                );
                var actual = result1.ToArray();
            }
        }

    }

}
