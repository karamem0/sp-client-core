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
using System.Threading;

namespace Karamem0.SharePoint.PowerShell.Core.Tests
{

    [TestClass()]
    [TestCategory("App")]
    public class UninstallAppCommandTests
    {

        [TestMethod()]
        public void UninstallSiteCollectionApp()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand(
                    "Install-SPApp",
                    new Dictionary<string, object>()
                    {
                        { "App", context.AppSettings["App1Id"] },
                        { "Scope", "SiteCollection" }
                    }
                );
                while (true)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    var result2 = context.Runspace.InvokeCommand<AppInstance>(
                        "Get-SPAppInstance",
                        new Dictionary<string, object>()
                        {
                            { "ProductId", context.AppSettings["App1ProductId"] }
                        }
                    );
                    if (result2.ElementAt(0).Status == AppInstanceStatus.Installed)
                    {
                        break;
                    }
                }
                var result3 = context.Runspace.InvokeCommand<CorporateCatalogAppMetadata>(
                    "Uninstall-SPApp",
                    new Dictionary<string, object>()
                    {
                        { "App", context.AppSettings["App1Id"] },
                        { "Scope", "SiteCollection" },
                        { "PassThru", true }
                    }
                );
                while (true)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    var result4 = context.Runspace.InvokeCommand<AppInstance>(
                        "Get-SPAppInstance",
                        new Dictionary<string, object>()
                        {
                            { "ProductId", context.AppSettings["App1ProductId"] }
                        }
                    );
                    if (result4.Count() == 0)
                    {
                        break;
                    }
                }
                var actual = result3.ElementAt(0);
            }
        }

    }

}
