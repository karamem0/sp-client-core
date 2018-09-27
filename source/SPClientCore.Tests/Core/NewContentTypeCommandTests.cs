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
                        { "DisplayFormUrl", "/TestList0/Forms/DispForm.aspx" },
                        { "EditFormUrl", "/TestList0/Forms/EditForm.aspx" },
                        { "Group", "Test Content Type 0 Group" },
                        { "Hidden", true },
                        { "JSLink", "/TestList0/Forms/JSLink.js" },
                        { "MobileDisplayFormUrl", "/TestList0/Forms/DispForm.aspx" },
                        { "MobileEditFormUrl", "/TestList0/Forms/EditForm.aspx" },
                        { "MobileNewFormUrl", "/TestList0/Forms/NewForm.aspx" },
                        { "Name", "Test Content Type 0" },
                        { "NewFormUrl", "/TestList0/Forms/NewForm.aspx" },
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
                        { "DisplayFormUrl", "/TestList0/Forms/DispForm.aspx" },
                        { "EditFormUrl", "/TestList0/Forms/EditForm.aspx" },
                        { "Group", "Test Content Type 0 Group" },
                        { "Hidden", true },
                        { "JSLink", "/TestList0/Forms/JSLink.js" },
                        { "MobileDisplayFormUrl", "/TestList0/Forms/DispForm.aspx" },
                        { "MobileEditFormUrl", "/TestList0/Forms/EditForm.aspx" },
                        { "MobileNewFormUrl", "/TestList0/Forms/NewForm.aspx" },
                        { "Name", "Test Content Type 0" },
                        { "NewFormUrl", "/TestList0/Forms/NewForm.aspx" },
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
