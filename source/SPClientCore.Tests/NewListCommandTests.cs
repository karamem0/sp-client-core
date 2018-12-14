//
// Copyright (c) 2019 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Tests.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests
{

    [TestClass()]
    [TestCategory("New-KshList")]
    public class NewListCommandTests
    {

        [TestMethod()]
        public void NewList()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand(
                    "Connect-KshSite",
                    new Dictionary<string, object>()
                    {
                        { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"] },
                        { "Credential", PSCredentialFactory.CreateCredential(
                            context.AppSettings["LoginUserName"],
                            context.AppSettings["LoginPassword"])
                        }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<List>(
                    "New-KshList",
                    new Dictionary<string, object>()
                    {
                        { "Description", "Test List 0 Description" },
                        { "QuickLaunchOption", "On" },
                        { "ServerRelativeUrl", "Lists/TestList0" },
                        { "Template", "DocumentLibrary" },
                        { "Title", "Test List 0" }
                    }
                );
                var result3 = context.Runspace.InvokeCommand(
                    "Remove-KshList",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result2.ElementAt(0) },
                        { "Force", true }
                    }
                );
                var actual = result2.ElementAt(0);
            }
        }

    }

}
