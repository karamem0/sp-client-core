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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests
{

    [TestClass()]
    [TestCategory("Update-KshListItem")]
    public class UpdateListItemCommandTests
    {

        [TestMethod()]
        public void UpdateListItem()
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
                    "Get-KshList",
                    new Dictionary<string, object>()
                    {
                        { "ListId", context.AppSettings["List1Id"] }
                    }
                );
                var result3 = context.Runspace.InvokeCommand<ListItem>(
                    "New-KshListItem",
                    new Dictionary<string, object>()
                    {
                        { "List", result2.ElementAt(0) },
                        { "Value", new Hashtable() }
                    }
                );
                var result4 = context.Runspace.InvokeCommand<ColumnLookupValue>(
                    "New-KshColumnLookupValue",
                    new Dictionary<string, object>()
                    {
                        { "LookupId", context.AppSettings["ListItem1Id"] },
                    }
                );
                var result5 = context.Runspace.InvokeCommand<ColumnUserValue>(
                    "New-KshColumnUserValue",
                    new Dictionary<string, object>()
                    {
                        { "LookupId", context.AppSettings["User1Id"] },
                    }
                );
                var result6 = context.Runspace.InvokeCommand<ColumnUrlValue>(
                    "New-KshColumnUrlValue",
                    new Dictionary<string, object>()
                    {
                        { "Url", "https://www.example.com" },
                        { "Description", "Test Value 0" }
                    }
                );
                var result7 = context.Runspace.InvokeCommand<ColumnGeolocationValue>(
                    "New-KshColumnGeolocationValue",
                    new Dictionary<string, object>()
                    {
                        { "Latitude", 10 },
                        { "Longitude", 10 }
                    }
                );
                var result8 = context.Runspace.InvokeCommand<ListItem>(
                    "Update-KshListItem",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result3.ElementAt(0) },
                        { "Value", new Hashtable()
                            {
                                { "TestColumn1", "Test Value 0" },
                                { "TestColumn2", "Test Value 0" },
                                { "TestColumn3", "Test Value 0" },
                                { "TestColumn4", new[] { "Test Value 0" } },
                                { "TestColumn5", 1 },
                                { "TestColumn6", 200 },
                                { "TestColumn7", new DateTime(2010, 10, 10) },
                                { "TestColumn8", result4.ElementAt(0) },
                                { "TestColumn9", new[] { result4.ElementAt(0) } },
                                { "TestColumn10", true },
                                { "TestColumn11", result5.ElementAt(0) },
                                { "TestColumn12", new[] { result5.ElementAt(0) } },
                                { "TestColumn13", result6.ElementAt(0) },
                                { "TestColumn15", result7.ElementAt(0) }
                            }
                        },
                        { "PassThru", true }
                    }
                );
                var result9 = context.Runspace.InvokeCommand(
                    "Remove-KshListItem",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result8.ElementAt(0) },
                        { "Force", true }
                    }
                );
                var actual = result8.ElementAt(0);
            }
        }

    }

}