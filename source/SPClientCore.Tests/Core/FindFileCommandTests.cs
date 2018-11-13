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
    [TestCategory("File")]
    public class FindFileCommandTests
    {

        [TestMethod()]
        public void SkipAndTakeFiles()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<File>(
                    "Find-SPFile",
                    new Dictionary<string, object>()
                    {
                        { "Folder", context.AppSettings["Folder1Url"] },
                        { "OrderBy", "Name desc" },
                        { "Top", 1 },
                        { "Skip", 1 }
                    }
                );
                var actual = result1.ToArray();
            }
        }

        [TestMethod()]
        public void FilterFiles()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<File>(
                    "Find-SPFile",
                    new Dictionary<string, object>()
                    {
                        { "Folder", context.AppSettings["Folder1Url"] },
                        { "Filter", "Name eq '" + context.AppSettings["File2Name"] + "'" }
                    }
                );
                var actual = result1.ToArray();
            }
        }

    }

}
