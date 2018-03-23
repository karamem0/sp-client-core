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
    [TestCategory("Attachment")]
    public class NewAttachmentCommandTests
    {

        [TestMethod()]
        public void CreateAttachment()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<Attachment>(
                    "New-SPAttachment",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "ListItem", context.AppSettings["ListItem1Id"] },
                        { "Name", "TestFile0.txt" },
                        { "Content", new System.IO.MemoryStream(Encoding.UTF8.GetBytes("TestFile0")) },
                    }
                );
                var result2 = context.Runspace.InvokeCommand(
                    "Remove-SPAttachment",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "ListItem", context.AppSettings["ListItem1Id"] },
                        { "Attachment", result1.ElementAt(0).FileName }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

    }

}
