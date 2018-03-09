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
    [TestCategory("File")]
    public class GetFileCommandTests
    {

        [TestMethod()]
        public void GetFileByObject()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<File>(
                    "Get-SPFile",
                    new Dictionary<string, object>()
                    {
                        { "File", context.AppSettings["File1Url"] }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<File>(
                    "Get-SPFile",
                    new Dictionary<string, object>()
                    {
                        { "File", result1.ElementAt(0) }
                    }
                );
                var actual = result2.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetFileByUrl()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<File>(
                    "Get-SPFile",
                    new Dictionary<string, object>()
                    {
                        { "File", context.AppSettings["File1Url"] }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

    }

}
