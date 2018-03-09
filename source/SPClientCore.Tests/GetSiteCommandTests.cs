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
    [TestCategory("Site")]
    public class GetSiteCommandTests
    {

        [TestMethod()]
        public void GetSite()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<Site>(
                    "Get-SPSite",
                    new Dictionary<string, object>()
                    {
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

    }

}
