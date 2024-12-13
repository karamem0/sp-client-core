//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Tests.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands.Tests;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class RemoveSiteFeatureCommandTests
{

    [Test()]
    public void RemoveSiteFeature()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"] },
                { "ClientId", context.AppSettings["ClientId"] },
                { "CertificatePath", context.AppSettings["CertificatePath"] },
                { "CertificatePassword", context.AppSettings["CertificatePassword"].ToSecureString() }
            }
        );
        var result1 = context.Runspace.InvokeCommand<Feature>(
            "Get-KshSiteFeature",
            new Dictionary<string, object>()
            {
                { "FeatureId", "99fe402e-89a0-45aa-9163-85342e865dc8" }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshSiteFeature",
            new Dictionary<string, object>()
            {
                { "Identity", result1.ElementAt(0) },
                { "Force", false }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Add-KshSiteFeature",
            new Dictionary<string, object>()
            {
                { "FeatureId", "99fe402e-89a0-45aa-9163-85342e865dc8" },
                { "Force", false },
                { "Scope", "None" }
            }
        );
    }

}
