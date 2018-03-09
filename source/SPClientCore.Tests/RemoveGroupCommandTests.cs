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
    [TestCategory("Group")]
    public class RemoveGroupCommandTests
    {

        [TestMethod()]
        public void RemoveGroup()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<Group>(
                    "New-SPGroup",
                    new Dictionary<string, object>()
                    {
                        { "Title", "Test Group 0" }
                    }
                );
                var result2 = context.Runspace.InvokeCommand(
                    "Remove-SPGroup",
                    new Dictionary<string, object>()
                    {
                        { "Group", result1.ElementAt(0).Id }
                    }
                );
            }
        }

    }

}
