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
    [TestCategory("Web")]
    public class UpdateWebCommandTests
    {

        [TestMethod()]
        public void UpdateWeb()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<Web>(
                    "New-SPWeb",
                    new Dictionary<string, object>()
                    {
                        { "Description", "Test Web 0 Description" },
                        { "Title", "Test Web 0" },
                        { "Url", "TestWeb0" }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<Web>(
                    "Select-SPWeb",
                    new Dictionary<string, object>()
                    {
                        { "Web", result1.ElementAt(0).Id }
                    }
                );
                var result3 = context.Runspace.InvokeCommand<Web>(
                    "Update-SPWeb",
                    new Dictionary<string, object>()
                    {
                        { "AllowSavePublishDeclarativeWorkflowForCurrentUser", true },
                        //{ "AssociatedMemberGroup", null },
                        //{ "AssociatedOwnerGroup", null },
                        //{ "AssociatedVisitorGroup", null },
                        { "CustomMasterUrl", result1.ElementAt(0).ServerRelativeUrl + "/_catalogs/masterpage/oslo.master" },
                        { "Description", "Test Web 9 Description" },
                        { "EnableMinimalDownload", true },
                        { "MasterUrl", result1.ElementAt(0).ServerRelativeUrl + "/_catalogs/masterpage/oslo.master" },
                        { "QuickLaunchEnabled", true },
                        { "SaveSiteAsTemplateEnabled", true },
                        { "ServerRelativeUrl", "TestWeb9" },
                        { "SyndicationEnabled", true },
                        { "Title", "Test Web 9" },
                        { "TreeViewEnabled", true },
                        { "UIVersion", 15 },
                        { "UIVersionConfigurationEnabled", true },
                        { "PassThru", true }
                    }
                );
                var result4 = context.Runspace.InvokeCommand(
                    "Remove-SPWeb",
                    new Dictionary<string, object>()
                    {
                    }
                );
                var actual = result3.ElementAt(0);
            }
        }

    }

}
