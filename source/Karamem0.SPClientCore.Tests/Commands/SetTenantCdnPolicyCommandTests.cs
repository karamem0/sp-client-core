//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Tests.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands.Tests;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class SetTenantCdnPolicyCommandTests
{

    [Test()]
    public void InvokeCommand_SetPublic_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["AdminUrl"] },
                { "ClientId", context.AppSettings["ClientId"] },
                { "CertificatePath", context.AppSettings["CertificatePath"] },
                { "CertificatePassword", context.AppSettings["CertificatePassword"].ToSecureString() }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshTenantCdnPolicy",
            new Dictionary<string, object>()
            {
                { "Public", true },
                { "Type", "IncludeFileExtensions" },
                { "Value", "CSS,EOT,GIF,ICO,JPEG,JPG,JS,MAP,PNG,SVG,TTF,WOFF" }
            }
        );
    }

    [Test()]
    public void InvokeCommand_SetPrivate_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["AdminUrl"] },
                { "ClientId", context.AppSettings["ClientId"] },
                { "CertificatePath", context.AppSettings["CertificatePath"] },
                { "CertificatePassword", context.AppSettings["CertificatePassword"].ToSecureString() }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Set-KshTenantCdnPolicy",
            new Dictionary<string, object>()
            {
                { "Private", true },
                { "Type", "IncludeFileExtensions" },
                { "Value", "GIF,ICO,JPEG,JPG,JS,PNG" }
            }
        );
    }

}
