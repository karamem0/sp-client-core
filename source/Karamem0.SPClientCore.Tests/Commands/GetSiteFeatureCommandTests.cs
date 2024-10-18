//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Tests.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests.Commands;

[TestClass()]
public class GetSiteFeatureCommandTests
{

    [TestMethod()]
    public void GetSiteFeatures()
    {
        using var context = new PSCmdletContext();
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
        var result2 = context.Runspace.InvokeCommand<Feature>(
            "Get-KshSiteFeature",
            new Dictionary<string, object>()
            {
            }
        );
        var actual = result2.ToArray();
        Assert.IsNotNull(actual);
    }

    [TestMethod()]
    public void GetSiteFeatureByIdentity()
    {
        using var context = new PSCmdletContext();
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
        var result2 = context.Runspace.InvokeCommand<Feature>(
            "Get-KshSiteFeature",
            new Dictionary<string, object>()
            {
                { "FeatureId", "00bfea71-e717-4e80-aa17-d0c71b360101" }
            }
        );
        var result3 = context.Runspace.InvokeCommand<Feature>(
            "Get-KshSiteFeature",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.IsNotNull(actual);
    }

    [TestMethod()]
    public void GetSiteFeatureByFeatureId()
    {
        using var context = new PSCmdletContext();
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
        var result2 = context.Runspace.InvokeCommand<Feature>(
            "Get-KshSiteFeature",
            new Dictionary<string, object>()
            {
                { "FeatureId", "00bfea71-e717-4e80-aa17-d0c71b360101" }
            }
        );
        var actual = result2.ElementAt(0);
        Assert.IsNotNull(actual);
    }

}
