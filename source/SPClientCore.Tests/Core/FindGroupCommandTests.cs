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
    [TestCategory("Group")]
    public class FindGroupCommandTests
    {

        [TestMethod()]
        public void SkipAndTakeGroups()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<Group>(
                    "Find-SPGroup",
                    new Dictionary<string, object>()
                    {
                        { "OrderBy", "Title desc" },
                        { "Top", 1 },
                        { "Skip", 1 }
                    }
                );
                var actual = result1.ToArray();
            }
        }

        [TestMethod()]
        public void FilterGroups()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<Group>(
                    "Find-SPGroup",
                    new Dictionary<string, object>()
                    {
                        { "Filter", "Title eq '" + context.AppSettings["Group2Name"] + "'" }
                    }
                );
                var actual = result1.ToArray();
            }
        }

    }

}
