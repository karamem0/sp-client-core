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
    public class OpenFileCommandTests
    {

        [TestMethod()]
        [TestCategory("File")]
        public void OpenFile()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<System.IO.Stream>(
                    "Open-SPFile",
                    new Dictionary<string, object>()
                    {
                        { "File", context.AppSettings["File1Url"] }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

        [TestMethod()]
        [TestCategory("Attachment")]
        public void OpenAttachment()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<Attachment>(
                    "Get-SPAttachment",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "ListItem", context.AppSettings["ListItem1Id"] },
                        { "Attachment", context.AppSettings["Attachment1Name"] }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<System.IO.Stream>(
                    "Open-SPFile",
                    new Dictionary<string, object>()
                    {
                        { "File", result1.ElementAt(0).ServerRelativeUrl }
                    }
                );
                var actual = result2.ElementAt(0);
            }
        }

    }

}
