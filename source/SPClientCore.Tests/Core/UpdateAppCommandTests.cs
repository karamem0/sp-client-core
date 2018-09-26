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
    public class UpdateAppCommandTests
    {

        [TestMethod()]
        public void UpdateSiteCollectionApp()
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
                    if (result2.ElementAt(0).Status == AppStatus.Installed)
                    {
                        break;
                    }
                }
                var result3 = context.Runspace.InvokeCommand<CorporateCatalogAppMetadata>(
                    "Update-SPApp",
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
                    if (result4.ElementAt(0).Status == AppStatus.Installed)
                    {
                        break;
                    }
                }
                var result5 = context.Runspace.InvokeCommand<CorporateCatalogAppMetadata>(
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
                    var result6 = context.Runspace.InvokeCommand<AppInstance>(
                        "Get-SPAppInstance",
                        new Dictionary<string, object>()
                        {
                            { "ProductId", context.AppSettings["App1ProductId"] }
                        }
                    );
                    if (result6.Count() == 0)
                    {
                        break;
                    }
                }
                var actual = result5.ElementAt(0);
            }
        }

    }

}
