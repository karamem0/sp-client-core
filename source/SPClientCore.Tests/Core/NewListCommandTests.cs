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
    [TestCategory("List")]
    public class NewListCommandTests
    {

        [TestMethod()]
        public void CreateList()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<List>(
                    "New-SPList",
                    new Dictionary<string, object>()
                    {
                        { "BaseTemplate", 101 },
                        { "ContentTypesEnabled", true },
                        { "DefaultContentApprovalWorkflowId", null },
                        { "DefaultDisplayFormUrl", context.AppSettings["Web1Url"] + "/TestList0/Forms/DispForm.aspx" },
                        { "DefaultEditFormUrl", context.AppSettings["Web1Url"] + "/TestList0/Forms/EditForm.aspx" },
                        { "DefaultNewFormUrl", context.AppSettings["Web1Url"] + "/TestList0/Forms/Upload.aspx" },
                        { "Description", "Test List 0 Description" },
                        { "Direction", "NONE" },
                        { "DocumentTemplateUrl", context.AppSettings["Web1Url"] + "/TestList0/Forms/template.dotx" },
                        { "DraftVersionVisibility", "Author" },
                        { "EnableAttachments", false },
                        { "EnableFolderCreation", true },
                        { "EnableMinorVersions", true },
                        { "EnableModeration", true },
                        { "EnableVersioning", true },
                        { "ForceCheckout", true },
                        { "Hidden", true },
                        { "IrmEnabled", true },
                        { "IrmExpire", true },
                        { "IrmReject", true },
                        { "IsApplicationList", true },
                        { "LastItemModifiedDate", new DateTime(2017, 4, 1) },
                        { "MultipleDataList", false },
                        { "NoCrawl", true },
                        { "OnQuickLaunch", true },
                        { "Title", "TestList0" },
                        { "ValidationFormula", "=TRUE" },
                        { "ValidationMessage", "Test List 0 Validation" }
                    }
                );
                var result2 = context.Runspace.InvokeCommand(
                    "Remove-SPList",
                    new Dictionary<string, object>()
                    {
                        { "List", result1.ElementAt(0).Id }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

    }

}
